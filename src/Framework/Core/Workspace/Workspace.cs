using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task CreateView(Type presenterType, string id, string title, JObject viewData, ViewLocation location)
        {
            var info = new ViewActivityInfo(id);
            info.ViewLocation = location;
            info.ViewData = viewData;
            info.Title = title;

            var activeView = await ViewFactory.CreateActiveViewAsync(null, presenterType, info);
            await ViewManager.AddViewAsync(activeView, info);

        }

        public async Task CloseAllView()
        {
            var service = (IWorkspaceContainerService)ViewManager.GetViewContainerService(HostLocation.Center);
            await service.CloseAllView();

        }

        private async Task CreateFloatingViews(List<WorkspaceViewConfig> source, string dockTarget)
        {
            var parentViews = new List<WorkspaceViewConfig>();
            var floatViews = source.Where(e => e.DockState == DockingState.Float && e.FloatingDockTarget == dockTarget).OrderBy(e => e.FloatingDockIndex);
            foreach (var view in floatViews)
            {
                parentViews.Add(view);

                var location = new ViewLocation();
                location.IsFloating = true;
                location.FloatingTop = view.FloatingLocation.Top;
                location.FloatingLeft = view.FloatingLocation.Left;
                location.FloatingWidth = view.FloatingLocation.Width;
                location.FloatingHeight = view.FloatingLocation.Height;
                location.Maximized = view.Maximized;
                location.FloatTarget = view.FloatingDockTarget;

                location.DockSide = view.FloatingDockSide;
                location.DockIndex = view.FloatingDockIndex;
                location.DockWidth = view.FloatingDockWidth;
                location.DockHeight = view.FloatingDockHeight;
                location.TabOrderInDocument = view.TabOrderInDocument;
                location.TabOrderInDock = view.TabOrderInDock;
                location.TabOrderInFloating = view.TabOrderInFloating;

                await CreateView(view.PresenterType, view.ViewId, view.ViewTitle, view.ViewData, location);
            }

            foreach (var view in parentViews)
            {
                await CreateFloatingViews(source, view.ViewId);
            }

        }

        private async Task CreateDockedViews(List<WorkspaceViewConfig> source, string dockTarget)
        {
            var parentViews = new List<WorkspaceViewConfig>();
            IEnumerable<WorkspaceViewConfig> dockedViews;
            if (dockTarget == "")
            {
                dockedViews =
                    source.Where(e => e.DockState != DockingState.Float && e.DockTarget == dockTarget)
                        .OrderByDescending(e => e.DockIndex);
            }
            else
            {
                dockedViews = source.Where(e => e.DockState != DockingState.Float && e.DockTarget == dockTarget).OrderBy(e => e.DockIndex);
            }
            foreach (var view in dockedViews)
            {
                parentViews.Add(view);
                var location = new ViewLocation();
                location.IsFloating = false;
                location.DockTarget = view.DockTarget;
                location.DockState = view.DockState;
                location.DockSide = view.DockSide;
                location.DockWidth = view.DockWidth;
                location.DockHeight = view.DockHeight;
                location.DockIndex = view.DockIndex;
                location.TabOrderInDocument = view.TabOrderInDocument;
                location.TabOrderInDock = view.TabOrderInDock;
                location.TabOrderInFloating = view.TabOrderInFloating;
                await CreateView(view.PresenterType, view.ViewId, view.ViewTitle, view.ViewData, location);
            }

            foreach (var view in parentViews)
            {
                await CreateDockedViews(source, view.ViewId);
            }

        }

        public async Task LoadLayout(WorkspaceLayout layout)
        {

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

            await CreateFloatingViews(layout.WorkspaceViews.ToList(), "");
            await CreateDockedViews(layout.WorkspaceViews.ToList(), "");
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

    }
}
