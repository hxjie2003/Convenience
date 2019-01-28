using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.ComponentModel;

namespace ETong.Controls.WPF
{
    public class PageNavigate : Page, INavigation
    {
        public void OnNavigateCompleted(NavigationEventArgs e)
        {
            this.OnNavigated(e);
        }
        public virtual void OnNavigated(NavigationEventArgs e)
        {

        }

        public void OnNavigatingBegin(NavigatingCancelEventArgs e)
        {
            this.OnNavigating(e);
        }

        public virtual void OnNavigating(NavigatingCancelEventArgs e)
        {
			
        }

        public virtual void OnNavigateFrom(CancelEventArgs e)
        {
 
        }
    }

    public class PageFunctionBooleanNavigate : PageFunction<Boolean>, INavigation
    {
        public void OnNavigateCompleted(NavigationEventArgs e)
        {
            this.OnNavigated(e);
        }

        public virtual void OnNavigated(NavigationEventArgs e)
        {

        }

        public void OnNavigatingBegin(NavigatingCancelEventArgs e)
        {
            this.OnNavigating(e);
        }

        public virtual void OnNavigating(NavigatingCancelEventArgs e)
        {

        }

        public virtual void OnNavigateFrom(CancelEventArgs e)
        {

        }
    }

    public class PageFunctionObjectNavigate: PageFunctionBase, INavigation
    {
        public void OnNavigateCompleted(NavigationEventArgs e)
        {
            this.OnNavigated(e);
        }

        public virtual void OnNavigated(NavigationEventArgs e)
        {

        }

        public void OnNavigatingBegin(NavigatingCancelEventArgs e)
        {
            this.OnNavigating(e);
        }

        public virtual void OnNavigating(NavigatingCancelEventArgs e)
        {

        }

        public virtual void OnNavigateFrom(CancelEventArgs e)
        {

        }
    }
}
