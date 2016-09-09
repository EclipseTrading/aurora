using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Aurora.Core.Workspace;
using Microsoft.Practices.Prism.Regions;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;

namespace Aurora.DockingContainer.Views.DockingContainer
{
    public class AvalonDockRegionAdapter : RegionAdapterBase<DockingManager>
    {
        public AvalonDockRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, DockingManager regionTarget)
        {
            region.Views.CollectionChanged += (sender, e) => OnViewsCollectionChanged(sender, e, region, regionTarget);
            regionTarget.DocumentClosed += (sender, e) => this.OnDocumentClosedEventArgs(sender, e, region);
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }

        private static void OnViewsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e, IRegion region, DockingManager regionTarget)
        {
           
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                region.Context = regionTarget;
                foreach (ViewContext item in e.NewItems)
                {
                    var viewActivityInfo = item.Info;
                    var location = viewActivityInfo.ViewLocation;

                    if (location == null)
                    {
                        //do normal docking as before
                        var paneGroup = (LayoutDocumentPaneGroup)regionTarget.Layout.RootPanel.Children[0];
                        var pane = (LayoutDocumentPane)paneGroup.Children.ToList()[0];
                        var newLayoutDocument = new PresenterLayoutDocument(item);
                        pane.InsertChildAt(0, newLayoutDocument);
                        continue;
                    }

                    if (location.IsFloating)
                    {
                        var newLayoutDocument = new PresenterLayoutDocument(item);
                        newLayoutDocument.FloatingTop = location.FloatingTop;
                        newLayoutDocument.FloatingLeft = location.FloatingLeft;
                        newLayoutDocument.FloatingWidth = location.FloatingWidth;
                        newLayoutDocument.FloatingHeight = location.FloatingHeight;
                        newLayoutDocument.IsMaximized = location.Maximized;

                        var paneGroup = (LayoutDocumentPaneGroup)regionTarget.Layout.RootPanel.Children[0];
                        var pane = (LayoutDocumentPane)paneGroup.Children[0];
                        pane.InsertChildAt(0, newLayoutDocument);
                        newLayoutDocument.Float();

                    }
                    else
                    {
                        var paneGroup = (LayoutDocumentPaneGroup)regionTarget.Layout.RootPanel.Children[0];
                        if (location.Orientation != DockingOrientation.UseCurrentOrientation)
                        {
                            paneGroup.Orientation = location.Orientation == DockingOrientation.Vertical
                                ? Orientation.Vertical
                                : Orientation.Horizontal;
                        }

                        int paneGroupCount = paneGroup.Children.Count;
                        if (location.GroupIdx >= paneGroupCount)
                        {
                            var diff = location.GroupIdx - paneGroupCount + 1;
                            Enumerable.Range(0, diff).ToList().ForEach(arg =>
                            {
                                var newPane = new LayoutDocumentPane();
                                if (paneGroup.Orientation == Orientation.Vertical)
                                {
                                    newPane.DockHeight = new GridLength(location.DockProportion, GridUnitType.Star);
                                }
                                else
                                {
                                    newPane.DockWidth = new GridLength(location.DockProportion, GridUnitType.Star);
                                }
                                paneGroup.InsertChildAt(paneGroup.ChildrenCount, newPane);
                            });

                        }

                        var pane = (LayoutDocumentPane)paneGroup.Children.ToList()[location.GroupIdx];

                        if (paneGroup.Orientation == Orientation.Vertical)
                        {
                            pane.DockHeight = new GridLength(location.DockProportion, GridUnitType.Star);
                        }
                        else
                        {
                            pane.DockWidth = new GridLength(location.DockProportion, GridUnitType.Star);
                        }
                       
                            
                        var newLayoutDocument = new PresenterLayoutDocument(item);
                        pane.InsertChildAt(0, newLayoutDocument);
  
                            
                        var sorted = pane.Children.OrderBy(d => ((PresenterLayoutDocument)d).ViewLocation.Order).ToList();
                        pane.Children.Clear();
                        sorted.ForEach((sortedItem) =>{ pane.InsertChildAt(pane.ChildrenCount, sortedItem); } );

                        var selectedIdx = sorted.FindIndex(d => ((PresenterLayoutDocument)d).ViewLocation.IsSelected);
                        pane.SelectedContentIndex = selectedIdx;
                    }
                }

            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (ViewContext item in e.OldItems)
                {
                    item.View?.Dispose();
                }
            }
        }

        /// <summary>
        /// Handles the DocumentClosedEventArgs event raised by the DockingNanager when
        /// one of the LayoutContent it hosts is closed.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event.</param>
        /// <param name="region">The region.</param>
        void OnDocumentClosedEventArgs(object sender, DocumentClosedEventArgs e, IRegion region)
        {
            var presenterLayoutDocument = e.Document as PresenterLayoutDocument;
            if (presenterLayoutDocument != null)
            {
                region.Remove(presenterLayoutDocument.ViewContext);  
            }
        }
    }
}
