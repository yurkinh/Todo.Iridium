using UIKit;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System;
using System.IO;
using GalaSoft.MvvmLight.Ioc;
using Iridium.DB;

namespace Todo
{
	[Register("AppDelegate")]
	public partial class AppDelegate : FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			// affects all UISwitch controls in the app
			UISwitch.Appearance.OnTintColor = UIColor.FromRGB(0x91, 0xCA, 0x47);
            SimpleIoc.Default.Register<IDataProvider>(() => new SqliteDataProvider(GetLocalFilePath()));
            Forms.Init();
			LoadApplication(new App());
			return base.FinishedLaunching(app, options);
		}

        public string GetLocalFilePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, "Iridium.db");
        }
    }
}