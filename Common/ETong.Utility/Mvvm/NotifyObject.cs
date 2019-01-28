using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ETong.Utility.Mvvm
{
    /// <summary>
    /// 属性更改通知MVVM
    /// </summary>
    public abstract class NotifyObject : INotifyPropertyChanged
    {

        public void OnPropertyChanged(string propname)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
