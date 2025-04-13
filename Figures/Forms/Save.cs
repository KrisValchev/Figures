namespace Figures.Forms
{
	public partial class Save : Form
	{
		public Save()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
			
			this.DialogResult = DialogResult.Yes;
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.No;
			this.Close();
		}

		
	}
}
