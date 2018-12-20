using Android.App;
using Android.OS;
using Android.Content.PM;
using GalaSoft.MvvmLight.Ioc;
using Iridium.DB;
using System.IO;

namespace Todo
{
    [Activity(Label = "Todo", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity :  global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Instance = this;
            SimpleIoc.Default.Register<IDataProvider>(() => new SqliteDataProvider(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Iridium.db")));
            global::Xamarin.Forms.Forms.Init(this, bundle);            
            LoadApplication(new App());

        }
    }
}
