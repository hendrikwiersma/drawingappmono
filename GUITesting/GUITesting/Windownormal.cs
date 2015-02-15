using System;

namespace GUITesting
{
	public partial class Windownormal : Gtk.Window
	{
		public Windownormal () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

