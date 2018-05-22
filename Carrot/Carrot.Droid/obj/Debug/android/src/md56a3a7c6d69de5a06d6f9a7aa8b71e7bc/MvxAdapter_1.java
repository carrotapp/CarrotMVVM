package md56a3a7c6d69de5a06d6f9a7aa8b71e7bc;


public class MvxAdapter_1
	extends md56a3a7c6d69de5a06d6f9a7aa8b71e7bc.MvxAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MvvmCross.Platforms.Android.Binding.Views.MvxAdapter`1, MvvmCross, Version=6.0.1.0, Culture=neutral, PublicKeyToken=null", MvxAdapter_1.class, __md_methods);
	}


	public MvxAdapter_1 ()
	{
		super ();
		if (getClass () == MvxAdapter_1.class)
			mono.android.TypeManager.Activate ("MvvmCross.Platforms.Android.Binding.Views.MvxAdapter`1, MvvmCross, Version=6.0.1.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public MvxAdapter_1 (android.content.Context p0)
	{
		super ();
		if (getClass () == MvxAdapter_1.class)
			mono.android.TypeManager.Activate ("MvvmCross.Platforms.Android.Binding.Views.MvxAdapter`1, MvvmCross, Version=6.0.1.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
