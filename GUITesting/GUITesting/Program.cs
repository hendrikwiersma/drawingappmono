using System;
using Gtk;

namespace GUITesting
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			Window win = new Window ();
			win.Show ();
			Application.Run ();

		}
	}
}
