using Gtk;
using Gdk;
using Cairo;
using System;
namespace GUITesting
{
	public partial class Window : Gtk.Window
	{
		public Context cr;
		bool drawing = false;
		PointD beginpoint;
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
			if (drawing == true) {
				drawingarea1.QueueDraw();
				cr.Save ();
				cr.SetSourceRGB (0.0, 0.0, 0.0);
				double width = args.Event.X - beginpoint.X;
				double height = args.Event.Y - beginpoint.Y;
				cr.LineWidth = 1;
				cr.Rectangle(beginpoint.X, beginpoint.Y, width, height);
				cr.StrokePreserve();
				cr.Restore ();
			}
		}

		protected void OnDrawingarea1ButtonPressEvent (object o, ButtonPressEventArgs args)
		{
			drawing = true;
			beginpoint.X = args.Event.X;
			beginpoint.Y = args.Event.Y;

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

		protected void OnDrawingarea1ButtonReleaseEvent (object o, ButtonReleaseEventArgs args)
		{
			drawing = false;
			Console.WriteLine ("Released at "+args.Event.X + "x" + args.Event.Y);
			cr.Save ();

			if (mode == "Rectangle") {
				cr.SetSourceRGB (colorbutton1.Color.Red, colorbutton1.Color.Green, colorbutton1.Color.Blue);
				double width = args.Event.X - beginpoint.X;
				double height = args.Event.Y - beginpoint.Y;
				cr.LineWidth = 1;
				cr.Rectangle(beginpoint.X, beginpoint.Y, width, height);
				cr.StrokePreserve();

				cr.Fill();

			} else if (mode == "Ellipse") {
				cr.SetSourceRGB(colorbutton1.Color.Red, colorbutton1.Color.Green, colorbutton1.Color.Blue);
				cr.Scale (0.5, 1.0);
				cr.Arc(args.Event.X, args.Event.Y, 50, 0, 2*Math.PI);
				cr.Fill();
			}
			//cr.PushGroup ();
			cr.Restore();
		}

		protected void OnButton1Clicked (object sender, EventArgs e)
		{

			//Pattern tn = cr.PopGroup ();
		}
	}
}

