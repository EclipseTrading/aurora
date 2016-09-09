using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aurora.Core.Activities;
using Aurora.Core.Container;
using Newtonsoft.Json.Linq;
using System.Windows;

namespace Aurora.Core.Workspace
{
   
    public class Workspace : IWorkspace
    {
        public Workspace(IViewFactory viewFactory, IViewManager viewManager)
        {
            this.ViewFactory = viewFactory;
            this.ViewManager = viewManager;
        }

        private IViewFactory ViewFactory { get; }

        private IViewManager ViewManager { get; }

        public async Task CreateFloatingView(Type presenterType, string viewName, JObject viewData, Rect location, bool maximized)
        {
            var info = new ViewActivityInfo(viewName);
            info.ViewLocation = new ViewLocation();
            info.ViewLocation.IsFloating = true;
            info.ViewLocation.FloatingTop = location.Top;
            info.ViewLocation.FloatingLeft = location.Left;
            info.ViewLocation.FloatingWidth = location.Width;
            info.ViewLocation.FloatingHeight = location.Height;
            info.ViewLocation.Maximized = maximized;

            info.ViewData = viewData;
            var activeView = await ViewFactory.CreateActiveViewAsync(null, presenterType, info);
            await ViewManager.AddViewAsync(activeView, info);
        }

        public async Task CreateDockedView(Type presenterType, string viewName, JObject viewData, int groupIdx, int order, bool selected)
        {
            var info = new ViewActivityInfo(viewName);
            info.ViewLocation = new ViewLocation();
            info.ViewLocation.IsFloating = false;
            info.ViewLocation.GroupIdx = groupIdx;
            info.ViewLocation.Order = order;
            info.ViewLocation.DockProportion = 1.0;
            info.ViewLocation.Orientation = DockingOrientation.UseCurrentOrientation;
            info.ViewLocation.IsSelected = selected;
        

            info.ViewData = viewData;
            var activeView = await ViewFactory.CreateActiveViewAsync(null, presenterType, info);
            await ViewManager.AddViewAsync(activeView, info);
        }


        public async Task CloseAllView()
        {
            var service = (IWorkspaceContainerService)ViewManager.GetViewContainerService(HostLocation.Center);
            await service.CloseAllView();

        }

    
        public async Task LoadLayout(WorkspaceLayout layout)
        {
            var dockingConfig = new DockingConfig();
            dockingConfig.Orientation = layout.Orientation;

            //move main window
            Application.Current.MainWindow.Top = layout.MainWindowRect.Top;
            Application.Current.MainWindow.Left = layout.MainWindowRect.Left;
            Application.Current.MainWindow.Width = layout.MainWindowRect.Width;
            Application.Current.MainWindow.Height = layout.MainWindowRect.Height;
            if (layout.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else if (layout.Minimized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }


            foreach (var group in layout.DockGroups)
            {
                
                foreach (var view in group.DockingViews)
                {
                    await CreateDockedView(view.PresenterType, view.ViewName, view.ViewData, 
                                            layout.DockGroups.IndexOf(group), view.Order, view.Selected);
                }
                dockingConfig.GroupProportion.Add(group.Proportion);
            }

            await ArrangeDocking(dockingConfig);


            foreach (var view in layout.FloatingViews)
            {
                await CreateFloatingView(view.PresneterType, view.ViewName, view.ViewData, view.Location, view.Maximized);
            }

            
        }

        public async Task<WorkspaceLayout> GetCurrentLayout()
        {

            var service = (IWorkspaceContainerService)ViewManager.GetViewContainerService(HostLocation.Center);
            var layout = await service.GetCurrentLayout();
          

            layout.MainWindowRect = new Rect(Application.Current.MainWindow.Left,
                                             Application.Current.MainWindow.Top,
                                             Application.Current.MainWindow.Width,
                                             Application.Current.MainWindow.Height);

            layout.Maximized = Application.Current.MainWindow.WindowState == WindowState.Maximized;
            layout.Minimized = Application.Current.MainWindow.WindowState == WindowState.Minimized;
          
            return layout;

        }



        public async Task ArrangeDocking(DockingConfig config)
        {
            var service = (IWorkspaceContainerService)ViewManager.GetViewContainerService(HostLocation.Center);
            await service.ArrangeDockingState(config);

        }

    }
}
