using System.Threading.Tasks;
using Aurora.Core;
using Aurora.Core.Activities;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Aurora.Core.Container;
using Aurora.Core.Workspace;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;

namespace Aurora.DockingContainer.Views.DockingContainer
{

    public class DockingViewContainerService : IWorkspaceContainerService
    {
        private readonly IRegionManager regionManager;
      
        public DockingViewContainerService(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public async Task<IDisposable> AddViewAsync<TActivityInfo>(ActiveView contentView, TActivityInfo activityInfo)
            where TActivityInfo : ViewActivityInfo
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
                

            var paneGroup = (LayoutDocumentPaneGroup)dockingManager.Layout.RootPanel.Children[0];
            var allDocList = new List<LayoutDocument>();
            var paneList = paneGroup.Children.OfType<LayoutDocumentPane>();            
            foreach (var pane in paneList)
            {
                var docList = pane.Children.OfType<LayoutDocument>();
                allDocList.AddRange(docList);
            }

            foreach (var floating in dockingManager.Layout.FloatingWindows)
            {
                var docList = floating.Children.OfType<LayoutDocument>();
                allDocList.AddRange(docList);
            }


            foreach (var doc in allDocList)
            {
                doc.Close();
            }

            await Task.FromResult(0);

        }

        public async Task ArrangeDockingState(DockingConfig dockingConfig)
        {

            var region = regionManager.Regions[DockingContainerRegion.Default];
            var dockingManager = (DockingManager) region.Context;
            if (dockingManager == null)
            {
                return;
            }

            var paneGroup = (LayoutDocumentPaneGroup)dockingManager.Layout.RootPanel.Children[0];

            paneGroup.Orientation = dockingConfig.Orientation == DockingOrientation.Vertical ? Orientation.Vertical : Orientation.Horizontal;

            var paneList = new List<LayoutDocumentPane>();
            foreach (var pane in paneGroup.Children.Cast<LayoutDocumentPane>())
            {
                var idx = paneGroup.IndexOfChild(pane);
                pane.DockWidth = new GridLength(dockingConfig.GroupProportion[idx], GridUnitType.Star);
                pane.DockHeight = new GridLength(dockingConfig.GroupProportion[idx], GridUnitType.Star);
                paneList.Add(pane);
            }


            paneList.ForEach( e => paneGroup.RemoveChild(e));


            foreach (var pane in paneList)
            {
               paneGroup.InsertChildAt(paneGroup.ChildrenCount, pane);
            }
            
            await Task.FromResult(0);

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
            var paneGroup = (LayoutDocumentPaneGroup)dockingManager.Layout.RootPanel.Children[0];

            //orientation
            layout.Orientation = paneGroup.Orientation == Orientation.Vertical ? DockingOrientation.Vertical : DockingOrientation.Horizontal;

            //docked windows
            foreach (var pane in paneGroup.Children.Cast<LayoutDocumentPane>())
            {
                var group = new DockGroupConfig();
                @group.Proportion = paneGroup.Orientation == Orientation.Vertical ? pane.DockHeight.Value : pane.DockWidth.Value;
                    
                layout.DockGroups.Add(group);
                foreach (var doc in pane.Children)
                {
                    var presenterDoc = (PresenterLayoutDocument) doc;
                    group.DockingViews.Add(new DockingViewConfig(presenterDoc.ViewContext.View.Presenter.GetType(), presenterDoc.Title,
                        presenterDoc.ViewContext.Info.ViewData, pane.IndexOfChild(doc), presenterDoc.IsSelected));
                   
                }
            }

            //floating windows
            foreach (var floating in dockingManager.Layout.FloatingWindows)
            {
                foreach (var doc in floating.Children)
                {
                    var presenterDoc = (PresenterLayoutDocument)doc;
                    layout.FloatingViews.Add(new FloatingViewConfig(presenterDoc.ViewContext.View.Presenter.GetType(), presenterDoc.Title,
                        presenterDoc.ViewContext.Info.ViewData,
                        new Rect(presenterDoc.FloatingLeft, presenterDoc.FloatingTop, presenterDoc.FloatingWidth, presenterDoc.FloatingHeight),
                        presenterDoc.IsMaximized));
                   
                }
                
            }

            return layout;

        }
    }
}