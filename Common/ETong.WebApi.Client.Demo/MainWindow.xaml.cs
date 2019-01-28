using ETong.WebApi.Client.Order;
using ETong.WebApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ETong.WebApi.Client.Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OrderManager manager = new OrderManager();
            manager.Get("ET1508140839227788", "d8fbed9ac1f26333e0406a714d196db9");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            testobject o = new testobject();
            o.name = "超能物战队";
            o.age = 12;
            //建议封装
            var ss = Execute(o);
        }

        private static ResponseInfo<string> Execute(testobject o)
        { 
            //直接调用
            return SecurityHttpClient.Post<testobject, string>("http://localhost:27215/api/Values?ak=1", o);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            testobject o = new testobject();
            o.name = "超能物战队";
            o.age = 12;
           
            var xx = NormalHttpClient.Post<testobject, string>("http://localhost:27215/api/Values?ak=1", o);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var xx = SecurityHttpClient.Get<string>("http://localhost:27215/api/Values?id=1");
        }
    }


    public class testobject
    {
        public string name { get; set; }

        public int age { get; set; }
    }
}
