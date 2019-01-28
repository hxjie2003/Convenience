using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;
using System.ComponentModel;

namespace ETong.Controls.WPF
{
    public interface INavigation
    {
        void OnNavigateCompleted(NavigationEventArgs e);
        void OnNavigatingBegin(NavigatingCancelEventArgs e);
        void OnNavigateFrom(CancelEventArgs e);
    }
}
