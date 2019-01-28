using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
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

using ICommandService = ETong.Maintenance.Common.ICommandService;

namespace ETong.Maintenance
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
        }

   

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Proxy proxy = new Proxy("movie");
            proxy.InnerChannel.Closed += InnerChannel_Closed;
            proxy.ExecuteAsync("downloadshows");
          

        }

        void InnerChannel_Closed(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                Application.Current.Shutdown();
            }));
          
        }
    }
    [ServiceContract]
    public interface ICommandService
    {
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICommandService/Execute", ReplyAction = "http://tempuri.org/ICommandService/ExecuteResponse")]
        System.Threading.Tasks.Task<string> ExecuteAsync(string command);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICommandService/Execute", ReplyAction = "http://tempuri.org/ICommandService/ExecuteResponse")]
        string Execute(string command);
    }

    public interface ICommandServiceChannel : ICommandService, System.ServiceModel.IClientChannel
    {
    }

    public class Proxy : ClientBase<ICommandService>, ICommandService
    {
        public Proxy()
        {
        }
        public Proxy(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }


        public string Execute(string command)
        {
            return base.Channel.Execute(command);
        }

        public System.Threading.Tasks.Task<string> ExecuteAsync(string command)
        {
            return base.Channel.ExecuteAsync(command);
        }
    }
}
