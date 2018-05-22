package md516352a761036abaf239a0473f8a47cfc;


public class MvxJavaContainer_1
	extends md516352a761036abaf239a0473f8a47cfc.MvxJavaContainer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MvvmCross.Platforms.Android.MvxJavaContainer`1, MvvmCross, Version=6.0.1.0, Culture=neutral, PublicKeyToken=null", MvxJavaContainer_1.class, __md_methods);
	}


	public MvxJavaContainer_1 ()
	{
		super ();
		if (getClass () == MvxJavaContainer_1.class)
			mono.android.TypeManager.Activate ("MvvmCross.Platforms.Android.MvxJavaContainer`1, MvvmCross, Version=6.0.1.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
