﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.Core.Host
{
    public class ShellViewModel : ViewModelBase
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    }
}
