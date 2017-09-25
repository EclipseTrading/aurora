using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aurora.Core.Activities;
using Aurora.Core.Container;
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

        public async Task CreateView(Type presenterType, string id, string title, object viewData, ViewLocation location)
        {
            var info = new ViewActivityInfo(id)
            {
                ViewLocation = location,
                ViewData = viewData,
                Title = title
            };

            var activeView = await ViewFactory.CreateActiveViewAsync(null, presenterType, info);
            await ViewManager.AddViewAsync(activeView, info);
        }

        public void CloseAllView()
        {
            var service = (IWorkspaceContainerService)ViewManager.GetViewContainerService(HostLocation.Center);
            service.CloseAllView();
        }

        private async Task CreateFloatingViews(IList<WorkspaceViewConfig> source, string dockTarget)
        {
            var parentViews = new List<WorkspaceViewConfig>();
            var floatViews = source.Where(e => e.DockState == DockingState.Float && e.FloatingDockTarget == dockTarget).OrderBy(e => e.FloatingDockIndex);
            foreach (var view in floatViews)
            {
                parentViews.Add(view);

                var location = new ViewLocation
                {
                    IsFloating = true,
                    FloatingTop = view.FloatingLocation.Top,
                    FloatingLeft = view.FloatingLocation.Left,
                    FloatingWidth = view.FloatingLocation.Width,
                    FloatingHeight = view.FloatingLocation.Height,
                    Maximized = view.Maximized,
                    Minimized = view.Minimized,
                    FloatTarget = view.FloatingDockTarget,
                    DockSide = view.FloatingDockSide,
                    DockIndex = view.FloatingDockIndex,
                    DockWidth = view.FloatingDockWidth,
                    DockHeight = view.FloatingDockHeight,
                    TabOrderInDocument = view.TabOrderInDocument,
                    TabOrderInDock = view.TabOrderInDock,
                    TabOrderInFloating = view.TabOrderInFloating
                };

                await CreateView(view.PresenterType, view.ViewId, view.ViewTitle, view.ViewData, location);
            }

            foreach (var view in parentViews)
            {
                await CreateFloatingViews(source, view.ViewId);
            }
        }

        private async Task CreateDockedViews(IList<WorkspaceViewConfig> source, string dockTarget)
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
                var location = new ViewLocation
                {
                    IsFloating = false,
                    DockTarget = view.DockTarget,
                    DockState = view.DockState,
                    DockSide = view.DockSide,
                    DockWidth = view.DockWidth,
                    DockHeight = view.DockHeight,
                    DockIndex = view.DockIndex,
                    TabOrderInDocument = view.TabOrderInDocument,
                    TabOrderInDock = view.TabOrderInDock,
                    TabOrderInFloating = view.TabOrderInFloating
                };
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

            await CreateFloatingViews(layout.Views.ToList(), "");
            await CreateDockedViews(layout.Views.ToList(), "");
        }

        public WorkspaceLayout GetCurrentLayout()
        {
            var service = (IWorkspaceContainerService)ViewManager.GetViewContainerService(HostLocation.Center);
            var views = service.GetWorkspaceViews();
            var rect = new Rect(Application.Current.MainWindow.Left,
                                             Application.Current.MainWindow.Top,
                                             Application.Current.MainWindow.Width,
                                             Application.Current.MainWindow.Height);
            var layout = new WorkspaceLayout(rect,
                Application.Current.MainWindow.WindowState == WindowState.Minimized,
                Application.Current.MainWindow.WindowState == WindowState.Maximized,
                views);

            return layout;
        }
    }
}
