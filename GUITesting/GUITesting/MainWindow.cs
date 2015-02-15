using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainWindow
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			modes.SelectedIndex = 0;
			SolidBrush brush = new SolidBrush(Color.White);
			this.CreateGraphics().FillRectangle(brush, 0, 0, 100, 100);
		}
		string mode = "Create Rectangle";
		private static readonly Random Random = new Random();
		bool mouse_down = false;
		System.Drawing.Point initial_mouse_pos;
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			initial_mouse_pos = this.PointToClient(Cursor.Position);
			mouse_down = true;
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (mouse_down)
			{
				label1.Text = "Coordinates: " + this.PointToClient(Cursor.Position).X + "x" + this.PointToClient(Cursor.Position).Y;
			}
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			mouse_down = false;
		}
		protected override void OnClick(EventArgs e)
		{
			var mouse_pos = this.PointToClient(Cursor.Position);
			Color randomColor = Color.FromArgb(Random.Next(255), Random.Next(255), Random.Next(255));
			String new_pos = mouse_pos.X + "x" + mouse_pos.Y;
			SolidBrush brush = new SolidBrush(randomColor);
			if(mode == "Create Rectangle"){
				int size_x = mouse_pos.X - initial_mouse_pos.X;
				int size_y = mouse_pos.Y - initial_mouse_pos.Y;
				if(size_x < 0 && size_y > 0){
					this.CreateGraphics().FillRectangle(brush, mouse_pos.X, initial_mouse_pos.Y, size_x * -1, size_y);
				}
				else if (size_x > 0 && size_y < 0)
				{
					this.CreateGraphics().FillRectangle(brush, initial_mouse_pos.X, mouse_pos.Y, size_x, size_y * -1);
				}
				if (size_x < 0 && size_y < 0)
				{
					this.CreateGraphics().FillRectangle(brush, mouse_pos.X, mouse_pos.Y, size_x * -1, size_y * -1);
				}
				else{
					this.CreateGraphics().FillRectangle(brush, initial_mouse_pos.X , initial_mouse_pos.Y, size_x,size_y);
				}
			}
			else if(mode == "Create Elipse"){
				int size_x = mouse_pos.X - initial_mouse_pos.X;
				int size_y = mouse_pos.Y - initial_mouse_pos.Y;
				if (size_x < 0 && size_y > 0)
				{
					this.CreateGraphics().FillEllipse(brush, mouse_pos.X, initial_mouse_pos.Y, size_x * -1, size_y);
				}
				else if (size_x > 0 && size_y < 0)
				{
					this.CreateGraphics().FillEllipse(brush, initial_mouse_pos.X, mouse_pos.Y, size_x, size_y * -1);
				}
				if (size_x < 0 && size_y < 0)
				{
					this.CreateGraphics().FillEllipse(brush, mouse_pos.X, mouse_pos.Y, size_x * -1, size_y * -1);
				}
				else
				{
					this.CreateGraphics().FillEllipse(brush, initial_mouse_pos.X, initial_mouse_pos.Y, size_x, size_y);
				}
			}

		}

		private void modes_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			mode = (string)comboBox.SelectedItem;
		}
	}
}
