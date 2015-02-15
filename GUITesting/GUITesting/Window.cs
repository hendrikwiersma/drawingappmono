using Gtk;
using Gdk;
using Cairo;
using System;
namespace GUITesting
{
	public partial class Window : Gtk.Window
	{
		public Context cr;
		string mode = "Rectangle";
		public Window () : base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
			cr = CairoHelper.Create (drawingarea1.GdkWindow);
			this.DoubleBuffered = true;
			DeleteEvent += delegate { Application.Quit(); };;
			drawingarea1.AddEvents ((int) 
					(EventMask.ButtonPressMask    
					|EventMask.ButtonReleaseMask    
					|EventMask.KeyPressMask    
					|EventMask.PointerMotionMask
					|EventMask.ScrollMask));

		}

		protected void OnCombobox1Changed (object sender, EventArgs e)
		{
			mode = combobox1.ActiveText;
			Console.WriteLine (mode);
		}

		protected void OnDrawingarea1ExposeEvent (object o, ExposeEventArgs args)
		{


		}

		protected void OnDrawingarea1MotionNotifyEvent (object o, MotionNotifyEventArgs args)
		{
			
			poslabel.Text = args.Event.X + "x" + args.Event.Y;
		}

		protected void OnDrawingarea1ButtonPressEvent (object o, ButtonPressEventArgs args)
		{
			cr.SetSourceRGB(colorbutton1.Color.Red, colorbutton1.Color.Green, colorbutton1.Color.Blue);
			cr.Save ();
			cr.Scale (0.5, 1.0);
			cr.Arc(args.Event.X, args.Event.Y, 50, 0, 2*Math.PI);
			cr.Fill();
			cr.Restore();
		}
		protected void OnDawingarea1PointerMotion(){

		}

		protected void OnDrawingarea1DragMotion (object o, DragMotionArgs args)
		{
			Console.WriteLine ("Mouse motion event OnDrawingarea1DragMotion");
		}

		protected void OnDrawingarea1ScrollEvent (object o, ScrollEventArgs args)
		{
			Console.WriteLine ("Yup it scrolls");
		}
	}
}

