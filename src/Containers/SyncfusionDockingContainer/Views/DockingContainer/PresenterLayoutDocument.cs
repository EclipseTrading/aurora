using System.Windows.Controls;
using Aurora.Controls;
using Aurora.Core;
using Aurora.Core.Activities;
using Aurora.Core.ViewContainer;
using Aurora.Core.Workspace;
using Syncfusion.Windows.Tools.Controls;

namespace Aurora.SyncfusionDockingContainer.Views.DockingContainer
{
    public class PresenterLayoutDocument : ContentControl, IViewContainerService
    {
        public ViewContext ViewContext { get; }
        public ViewLocation ViewLocation { get; }
        public ITitleBarSettings TitleBar { get; }

        public PresenterLayoutDocument(ViewContext viewContext)
        {
            this.ViewContext = viewContext;
            this.Content = this.ViewContext.View.View;

            this.ViewLocation = this.ViewContext.Info?.ViewLocation;
            var hostWindowManager = this.ViewContext.View.Presenter as IHostWindowManager;
            var settings = hostWindowManager != null
                     ? hostWindowManager.TitleBarSettings
                     : new DefaultTitleBarSettings();
            
            if (settings.HeaderContent == null)
            {
                settings.HeaderContent = viewContext.Info?.Title;
            }

            this.TitleBar = settings;

            if (hostWindowManager != null)
            {
                hostWindowManager.CloseAction = CloseView;
            }
        }

        public void CloseView()
        {
            DockingManager.GetDockingManager(this).ExecuteClose(this);
        }
    }
}
