package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("Carrot.Droid.MainApplication, Carrot.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", md5a489e6cd471ebf0506ba4e2e67bd5d6a.MainApplication.class, md5a489e6cd471ebf0506ba4e2e67bd5d6a.MainApplication.__md_methods);
		mono.android.Runtime.register ("MvvmCross.Platforms.Android.Views.MvxAndroidApplication, MvvmCross, Version=6.0.1.0, Culture=neutral, PublicKeyToken=null", md5c71e9765908d379bb0e386024bb3e2ce.MvxAndroidApplication.class, md5c71e9765908d379bb0e386024bb3e2ce.MvxAndroidApplication.__md_methods);
		mono.android.Runtime.register ("MvvmCross.Platforms.Android.Views.MvxAndroidApplication`2, MvvmCross, Version=6.0.1.0, Culture=neutral, PublicKeyToken=null", md5c71e9765908d379bb0e386024bb3e2ce.MvxAndroidApplication_2.class, md5c71e9765908d379bb0e386024bb3e2ce.MvxAndroidApplication_2.__md_methods);
		
	}
}
