using System;
using System.Windows.Input;
using Aurora.Core.Activities;
using Aurora.Core.Host;

namespace Aurora.Core.Commands
{
    public class StartActivityCommand<TActivityInfo> : ICommand where TActivityInfo : ActivityInfo
    {
        public event EventHandler CanExecuteChanged = delegate {};
        private readonly IActivityService service;
        private readonly Func<TActivityInfo> activityInfoFunc;

        public StartActivityCommand(IActivityService service, Func<TActivityInfo> activityInfoFunc)
        {
            this.service = service;
            this.activityInfoFunc = activityInfoFunc;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var activityInfo = activityInfoFunc();
            service.StartActivityAsync(activityInfo);
        }

    }
}
