using System.Runtime.InteropServices;

namespace WinFormsApp1
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void MoveUserIntoWindow(object sender, EventArgs e)
		{
			this.Capture = true;
			System.Windows.Forms.Cursor.Clip = Bounds;

			this.Activate();
			this.Focus();
			this.DisableNonPrimaryScreens();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing ||
				e.CloseReason == CloseReason.TaskManagerClosing ||
				e.CloseReason == CloseReason.FormOwnerClosing)
			{
				// Cancel the event
				e.Cancel = true;
			}
		}

		private int SC_MONITORPOWER = 0xF170;
		private uint WM_SYSCOMMAND = 0x0112;

		[DllImport("user32.dll")]
		static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
		private void DisableNonPrimaryScreens()
		{
			Screen primaryScreen = Screen.PrimaryScreen;
			Screen[] screens = Screen.AllScreens;
			if (screens.Length > 1)
			{
				foreach (Screen s in screens)
				{
					if (!s.Equals(primaryScreen))
					{
						Form frm = new Form();
						frm.Location = s.WorkingArea.Location;
						SendMessage(frm.Handle, WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)2);
					}
				}
			}
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();


			this.components = new System.ComponentModel.Container();
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Text = "Form1";

			// Bring it into "focus" and move the window to the top
			this.Activate();
			this.TopMost = true;

			// Make the window borderless
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

			// Maximize the window so that it takes up all space on the current monitor
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

			// Hide the cursor:
			Cursor = System.Windows.Forms.Cursors.No;
			Cursor.Hide();

			// Prevent the user from doing pretty much anything  ¯\_(ツ)_/¯
			this.Resize += new System.EventHandler(this.MoveUserIntoWindow);
			this.Activated += new System.EventHandler(this.MoveUserIntoWindow);
			this.LocationChanged += new System.EventHandler(this.MoveUserIntoWindow);
			this.Enter += new System.EventHandler(this.MoveUserIntoWindow);
			this.GotFocus += new System.EventHandler(this.MoveUserIntoWindow);
			this.LostFocus += new System.EventHandler(this.MoveUserIntoWindow);

			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(311, 186);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 50);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;

			// Add the payload media to the PictureBox
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.ImageLocation = "https://c.tenor.com/0AUShZgWlM4AAAAC/adorable-cute.gif";



			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}

		#endregion

		private PictureBox pictureBox1;
	}
}