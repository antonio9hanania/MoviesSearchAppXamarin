using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace NetflixMoviesSearchApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            try
            {
                MainPage = new NavigationPage(new MainPage());
            }
            catch(TargetInvocationException ex)
            {
                Console.WriteLine(ex.Message);
            }  
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
