package md5c71e9765908d379bb0e386024bb3e2ce;


public abstract class MvxSplashScreenActivity_2
	extends mvvmcross.platforms.android.views.MvxSplashScreenActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MvvmCross.Platforms.Android.Views.MvxSplashScreenActivity`2, MvvmCross, Version=6.0.1.0, Culture=neutral, PublicKeyToken=null", MvxSplashScreenActivity_2.class, __md_methods);
	}


	public MvxSplashScreenActivity_2 ()
	{
		super ();
		if (getClass () == MvxSplashScreenActivity_2.class)
			mono.android.TypeManager.Activate ("MvvmCross.Platforms.Android.Views.MvxSplashScreenActivity`2, MvvmCross, Version=6.0.1.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
