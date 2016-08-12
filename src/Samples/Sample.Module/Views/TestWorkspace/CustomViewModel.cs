using System;
using System.Globalization;
using System.Windows.Data;
using Aurora.Core;
using Newtonsoft.Json.Linq;

namespace Aurora.Sample.Module.Views.TestWorkspace
{   
    public class CustomViewModel : ViewModelBase
    {
        private string jsonString;
        private JObject rawJsonObject;
        

        public string JsonString
        {
            get { return jsonString; }
            set
            {
                jsonString = value;
                OnPropertyChanged();
            }
        }

        public JObject RawJsonObject
        {
            get { return rawJsonObject; }
            set
            {
                rawJsonObject = value;
                OnPropertyChanged();
            }
        }
    }
}
