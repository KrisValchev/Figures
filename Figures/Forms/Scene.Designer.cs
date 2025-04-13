namespace Figures
{
    partial class Scene
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

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			trackBar1 = new TrackBar();
			label1 = new Label();
			label2 = new Label();
			panel1 = new Panel();
			label3 = new Label();
			radioButton1 = new RadioButton();
			radioButton2 = new RadioButton();
			radioButton3 = new RadioButton();
			radioButton4 = new RadioButton();
			colorDialog1 = new ColorDialog();
			button1 = new Button();
			label4 = new Label();
			panel2 = new Panel();
			label5 = new Label();
			button2 = new Button();
			label6 = new Label();
			textBox1 = new TextBox();
			label7 = new Label();
			button3 = new Button();
			label8 = new Label();
			label9 = new Label();
			button4 = new Button();
			UndoButton = new Button();
			RedoButton = new Button();
			((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
			SuspendLayout();
			// 
			// trackBar1
			// 
			trackBar1.LargeChange = 10;
			trackBar1.Location = new Point(843, 36);
			trackBar1.Name = "trackBar1";
			trackBar1.Size = new Size(200, 56);
			trackBar1.TabIndex = 0;
			trackBar1.Value = 5;
			trackBar1.Scroll += trackBar1_Scroll;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(924, 9);
			label1.Name = "label1";
			label1.Size = new Size(36, 20);
			label1.TabIndex = 1;
			label1.Text = "Size";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(931, 72);
			label2.Name = "label2";
			label2.Size = new Size(0, 20);
			label2.TabIndex = 2;
			// 
			// panel1
			// 
			panel1.BorderStyle = BorderStyle.FixedSingle;
			panel1.ForeColor = Color.Black;
			panel1.Location = new Point(833, 102);
			panel1.Name = "panel1";
			panel1.Size = new Size(218, 217);
			panel1.TabIndex = 3;
			panel1.Paint += panel1_Paint;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(885, 322);
			label3.Name = "label3";
			label3.Size = new Size(119, 20);
			label3.TabIndex = 4;
			label3.Text = "Visualized figure";
			// 
			// radioButton1
			// 
			radioButton1.AutoSize = true;
			radioButton1.Location = new Point(277, 24);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new Size(76, 24);
			radioButton1.TabIndex = 5;
			radioButton1.TabStop = true;
			radioButton1.Text = "Square";
			radioButton1.UseVisualStyleBackColor = true;
			radioButton1.Click += radioButton1_Click;
			// 
			// radioButton2
			// 
			radioButton2.AutoSize = true;
			radioButton2.Location = new Point(426, 24);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new Size(96, 24);
			radioButton2.TabIndex = 6;
			radioButton2.TabStop = true;
			radioButton2.Text = "Rectangle";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton2.Click += radioButton2_Click;
			// 
			// radioButton3
			// 
			radioButton3.AutoSize = true;
			radioButton3.Location = new Point(597, 24);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new Size(83, 24);
			radioButton3.TabIndex = 7;
			radioButton3.TabStop = true;
			radioButton3.Text = "Triangle";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton3.Click += radioButton3_Click;
			// 
			// radioButton4
			// 
			radioButton4.AutoSize = true;
			radioButton4.Location = new Point(744, 24);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new Size(67, 24);
			radioButton4.TabIndex = 8;
			radioButton4.TabStop = true;
			radioButton4.Text = "Circle";
			radioButton4.UseVisualStyleBackColor = true;
			radioButton4.Click += radioButton4_Click;
			// 
			// button1
			// 
			button1.ForeColor = SystemColors.ControlText;
			button1.Location = new Point(977, 363);
			button1.Name = "button1";
			button1.Size = new Size(62, 37);
			button1.TabIndex = 9;
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(819, 371);
			label4.Name = "label4";
			label4.Size = new Size(152, 20);
			label4.TabIndex = 10;
			label4.Text = "Choose border color :";
			// 
			// panel2
			// 
			panel2.BorderStyle = BorderStyle.FixedSingle;
			panel2.Location = new Point(24, 54);
			panel2.Name = "panel2";
			panel2.Size = new Size(789, 577);
			panel2.TabIndex = 11;
			panel2.Paint += panel2_Paint;
			panel2.MouseClick += panel2_MouseClick;
			panel2.MouseDown += panel2_MouseDown;
			panel2.MouseMove += panel2_MouseMove;
			panel2.MouseUp += panel2_MouseUp;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(843, 431);
			label5.Name = "label5";
			label5.Size = new Size(124, 20);
			label5.TabIndex = 12;
			label5.Text = "Choose fill color :";
			// 
			// button2
			// 
			button2.ForeColor = SystemColors.ControlText;
			button2.Location = new Point(977, 423);
			button2.Name = "button2";
			button2.Size = new Size(62, 37);
			button2.TabIndex = 13;
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(891, 480);
			label6.Name = "label6";
			label6.Size = new Size(109, 20);
			label6.TabIndex = 14;
			label6.Text = "Selected figure";
			// 
			// textBox1
			// 
			textBox1.BackColor = Color.White;
			textBox1.Location = new Point(938, 516);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(54, 27);
			textBox1.TabIndex = 15;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(896, 519);
			label7.Name = "label7";
			label7.Size = new Size(39, 20);
			label7.TabIndex = 16;
			label7.Text = "Size:";
			// 
			// button3
			// 
			button3.ForeColor = SystemColors.ControlText;
			button3.Location = new Point(964, 592);
			button3.Name = "button3";
			button3.Size = new Size(52, 30);
			button3.TabIndex = 20;
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(885, 596);
			label8.Name = "label8";
			label8.Size = new Size(73, 20);
			label8.TabIndex = 19;
			label8.Text = "Fill color :";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(860, 562);
			label9.Name = "label9";
			label9.Size = new Size(99, 20);
			label9.TabIndex = 18;
			label9.Text = "Border color :";
			// 
			// button4
			// 
			button4.ForeColor = SystemColors.ControlText;
			button4.Location = new Point(964, 559);
			button4.Name = "button4";
			button4.Size = new Size(52, 27);
			button4.TabIndex = 17;
			button4.UseVisualStyleBackColor = true;
			button4.Click += button4_Click;
			// 
			// UndoButton
			// 
			UndoButton.Location = new Point(28, 22);
			UndoButton.Name = "UndoButton";
			UndoButton.Size = new Size(71, 29);
			UndoButton.TabIndex = 21;
			UndoButton.Text = "Undo";
			UndoButton.UseVisualStyleBackColor = true;
			UndoButton.Click += UndoButton_Click;
			// 
			// RedoButton
			// 
			RedoButton.Location = new Point(105, 22);
			RedoButton.Name = "RedoButton";
			RedoButton.Size = new Size(71, 29);
			RedoButton.TabIndex = 22;
			RedoButton.Text = "Redo";
			RedoButton.UseVisualStyleBackColor = true;
			RedoButton.Click += RedoButton_Click;
			// 
			// Scene
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1065, 643);
			Controls.Add(RedoButton);
			Controls.Add(UndoButton);
			Controls.Add(button3);
			Controls.Add(label8);
			Controls.Add(label9);
			Controls.Add(button4);
			Controls.Add(label7);
			Controls.Add(textBox1);
			Controls.Add(label6);
			Controls.Add(button2);
			Controls.Add(label5);
			Controls.Add(panel2);
			Controls.Add(label4);
			Controls.Add(button1);
			Controls.Add(radioButton4);
			Controls.Add(radioButton3);
			Controls.Add(radioButton2);
			Controls.Add(radioButton1);
			Controls.Add(label3);
			Controls.Add(panel1);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(trackBar1);
			Font = new Font("Segoe UI", 9F);
			MaximizeBox = false;
			Name = "Scene";
			Text = "Scene";
			FormClosing += Scene_FormClosing;
			Load += Scene_Load;
			KeyDown += Scene_KeyDown;
			((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TrackBar trackBar1;
		private Label label1;
		private Label label2;
		private Panel panel1;
		private Label label3;
		private RadioButton radioButton1;
		private RadioButton radioButton2;
		private RadioButton radioButton3;
		private RadioButton radioButton4;
		private ColorDialog colorDialog1;
		private Button button1;
		private Label label4;
		private Panel panel2;
		private Label label5;
		private Button button2;
		private Label label6;
		private TextBox textBox1;
		private Label label7;
		private Button button3;
		private Label label8;
		private Label label9;
		private Button button4;
		private Button UndoButton;
		private Button RedoButton;
	}
}
