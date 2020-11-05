using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows;



using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

using EasyNetworkServer.Data;


namespace EasyNetworkServer
{
    /// <summary> Interaction logic for App.xaml </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {



            Init();
            // MainViewModel mainViewModel=new MainViewModel();
        }

        private void Init()
        {
            //9819cf4d-f19b-49ce-8279-e42a649a436b
            //59f2835fe7329827dce83db7d57355674cb0ba8b

            // AppCenter.Start("9819cf4d-f19b-49ce-8279-e42a649a436b", typeof(Analytics), typeof(Crashes));

            GlobalData.Init();
            InitAutofac();
        }

        private void InitAutofac()
        {

        }
    }
}