using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Practices.ObjectBuilder2;

namespace Aurora.Core.Container
{
    public class MenuItemCommand : CommandBarItem
    {
        private static readonly ObservableCollection<CommandBarItem> DefaultChildren = new ObservableCollection<CommandBarItem>
        {
            new MenuItemCommand("Loading...")
        };
        private readonly Func<MenuItemCommand, Task<CommandBarItem[]>> getChildren;
        private ObservableCollection<CommandBarItem> children;
        private string iconPath;

        public MenuItemCommand(string title, params CommandBarItem[] children)
        {
            this.Title = title;
            this.children = new ObservableCollection<CommandBarItem>(children);
            this.IconPath = "";
        }

        public MenuItemCommand(string title, Func<MenuItemCommand, Task<CommandBarItem[]>> getChildren) 
            : this(title, null, getChildren) { }

        public MenuItemCommand(string title, ICommand command = null, Func<MenuItemCommand, Task<CommandBarItem[]>> getChildren = null)
        {
            this.getChildren = getChildren;
            Title = title;
            Command = command;
            Description = "";
            IconPath = "";
        }

        public ICommand Command { get; }

        public ObservableCollection<CommandBarItem> Children
        {
            get
            {
                if (children == null)
                {
                    LoadChildren();
                }
                return children;
            }
            set
            {
                children = value;
            }
        }

        private void LoadChildren()
        {
            if (getChildren == null)
            {
                Children = new ObservableCollection<CommandBarItem>();
                return;
            }
            Children = new ObservableCollection<CommandBarItem>(DefaultChildren);
            var res = getChildren(this);
            res.ContinueWith(c =>
            {
                Children.Clear();
                c.Result.ForEach(child => this.children.Add(child));
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }


        public async Task<CommandBarItem[]> GetChildren()
        {
            return await getChildren(this);
        }

        public string Title { get; }
        public string BarName { get; set; }

        public string Description { get; set; }

        public string IconPath
        {
            get { return iconPath; }
            set
            {
                iconPath = value;
                var path = string.IsNullOrEmpty(iconPath) ? "pack://application:,,,/Aurora.CommandBarContainer;component/Image/default.png" : iconPath;
                Icon = new Image {Source = new BitmapImage(new Uri(path)), Width = 20, Height = 20};
            }
        }

        public object Icon { get; set; }
        public override MenuType MenuType => MenuType.MenuItem;
    }
}