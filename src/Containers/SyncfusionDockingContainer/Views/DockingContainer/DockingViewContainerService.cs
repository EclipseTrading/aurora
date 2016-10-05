using System;
using System.Threading.Tasks;
using System.Windows;
using Aurora.Core;
using Aurora.Core.Activities;
using Aurora.Core.Container;
using Aurora.Core.Workspace;
using Microsoft.Practices.Prism.Regions;
using Syncfusion.Windows.Tools.Controls;

namespace Aurora.SyncfusionDockingContainer.Views.DockingContainer
{
   
    public class DockingViewContainerService : IWorkspaceContainerService
    {
        private readonly IRegionManager regionManager;

        public DockingViewContainerService(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }


        public async Task<IDisposable> AddViewAsync<TActivityInfo>(ActiveView contentView, TActivityInfo activityInfo) where TActivityInfo : ViewActivityInfo
        {
            var newView = new ViewContext { View = contentView, Info = activityInfo };
            regionManager.RegisterViewWithRegion(DockingContainerRegion.Default, () => newView);

            return await Task.FromResult(new ActionDisposable(() => {
                if (regionManager.Regions[DockingContainerRegion.Default].Views.Contains(newView))
                {
                    regionManager.Regions[DockingContainerRegion.Default].Remove(newView);
                    newView = null;
                }
            }));
        }

        public async Task CloseAllView()
        {
            var region = regionManager.Regions[DockingContainerRegion.Default];
            var dockingManager = (DockingManager)region.Context;
            if (dockingManager == null)
            {
                return;
            }

            dockingManager.Children.RemoveRange(0, dockingManager.Children.Count);

        }

        public async Task<WorkspaceLayout> GetCurrentLayout()
        {
            var region = regionManager.Regions[DockingContainerRegion.Default];
            var dockingManager = (DockingManager)region.Context;
            if (dockingManager == null)
            {
                return new WorkspaceLayout();
            }

            var layout = new WorkspaceLayout();

            var count = dockingManager.Children.Count;
            for (int i = 0; i < count; i++)
            {
                var doc = dockingManager.Children[i];

                var dockState = DockingManager.GetState(doc);
                if (dockState == DockState.Float)
                {
                    var presenterDoc = (PresenterLayoutDocument)doc;                  
                    var location = DockingManager.GetFloatingWindowRect(doc);
                    var winState = DockingManager.GetFloatWindowState(doc);
                    
                    var config = new WorkspaceViewConfig(presenterDoc.ViewContext.View.Presenter.GetType(),
                        presenterDoc.Name, presenterDoc.ViewContext.Info.ViewData)
                    {
                        DockState = DockingState.Float,
                        FloatingLocation = location,
                        Maximized = winState == WindowState.Maximized,
                        Minimized = winState == WindowState.Minimized,
                        FloatingDockTarget = DockingManager.GetTargetNameInFloatingMode(doc) ?? "",
                        FloatingDockIndex = DockingManager.GetIndexInFloatMode(doc),
                        FloatingDockSide = (DockingSide) DockingManager.GetSideInFloatMode(doc),
                        ViewTitle = presenterDoc.ViewContext.Info.Title,
                        ViewId = presenterDoc.ViewContext.Info.Id
                    };

                    layout.WorkspaceViews.Add(config);
                }
                else
                {
                    var presenterDoc = (PresenterLayoutDocument)doc;
                    var config = new WorkspaceViewConfig(presenterDoc.ViewContext.View.Presenter.GetType(), presenterDoc.Name, presenterDoc.ViewContext.Info.ViewData)
                    {
                        DockTarget = DockingManager.GetTargetNameInDockedMode(doc),
                        DockState = (DockingState) dockState,
                        DockSide = (DockingSide) DockingManager.GetSideInDockedMode(doc),
                        DockWidth = DockingManager.GetDesiredWidthInDockedMode(doc),
                        DockHeight = DockingManager.GetDesiredHeightInDockedMode(doc),
                        DockIndex = DockingManager.GetIndexInDockMode(doc),
                        ViewTitle = presenterDoc.ViewContext.Info.Title,
                        ViewId = presenterDoc.ViewContext.Info.Id
                    };

                    layout.WorkspaceViews.Add(config);

                }
               

            }

            return layout;
        }
    }
}
