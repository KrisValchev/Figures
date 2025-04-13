namespace Figures.Forms
{
	partial class Save
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			button1 = new Button();
			button2 = new Button();
			label1 = new Label();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new Point(82, 96);
			button1.Name = "button1";
			button1.Size = new Size(76, 36);
			button1.TabIndex = 0;
			button1.Text = "Yes";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.Location = new Point(180, 96);
			button2.Name = "button2";
			button2.Size = new Size(76, 36);
			button2.TabIndex = 1;
			button2.Text = "No";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(76, 19);
			label1.MaximumSize = new Size(200, 0);
			label1.Name = "label1";
			label1.Size = new Size(192, 60);
			label1.TabIndex = 2;
			label1.Text = "You have unsaved changes. Do you want to save before exiting?";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// Save
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(346, 164);
			Controls.Add(label1);
			Controls.Add(button2);
			Controls.Add(button1);
			MaximizeBox = false;
			Name = "Save";
			Text = "Exit";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button1;
		private Button button2;
		private Label label1;
	}
}