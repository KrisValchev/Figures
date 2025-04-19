using Figures.DTO;
using Figures.Forms;
using Figures.Core.Models;
using Figures.Core.Factories;
using Figures.Core.Interfaces;
using System.Text.Json;
using Figures.Core.Serialization;

namespace Figures
{
	public partial class Scene : Form
	{
		private List<Shape> _shapes = new List<Shape>();
		private Stack<List<Shape>> _undoStack = new Stack<List<Shape>>();
		private Stack<List<Shape>> _redoStack = new Stack<List<Shape>>();

		private const int DEFAULT_SIDE_VALUE = 60;
		private const int DEFAULT_TRACKBAR_VALUE = 5;
		private Shape _visualizedFigure;
		private Shape _lastSelectedFigure;
		//boolean for dragging and resizing figure
		private bool _isDragging = false;
		private bool _isResizing = false;
		private bool _hasUnsavedChanges = false;
		private bool _clickedOnShape;

		//boolean for checking if drag and resize are did for SaveUndoState
		private bool _didDrag = false;
		private bool _didResize = false;
		public Scene()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			//size of a side showing in label
			label2.Text = ((trackBar1.Value + 1) * 10).ToString();
			panel1.Invalidate();
		}
		//method for selecting border color for figure which is going to be painted
		private void button1_Click(object sender, EventArgs e)
		{
			ColorDialog MyDialog = new ColorDialog();
			// Keeps the user from selecting a custom color.
			MyDialog.AllowFullOpen = false;

			// Sets the initial color select to the current text color.
			MyDialog.Color = button1.BackColor;

			// Update the text box color if the user clicks OK 
			if (MyDialog.ShowDialog() == DialogResult.OK)
			{
				button1.BackColor = MyDialog.Color;
				panel1.Invalidate();
			}

		}


		//panel1 method for visualizing current shape which is going to be painted
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			int side = int.Parse(label2.Text);
			Point location = new Point();
			//if for calculating every shape location
			if (radioButton1.Checked || radioButton2.Checked)
			{
				location = new Point((panel1.ClientSize.Width - side) / 2, (panel1.ClientSize.Height - side) / 2);
			}
			else if (radioButton3.Checked)
			{
				int height = (int)Math.Round(side * Math.Sqrt(3) / 2);
				location = new Point((panel1.ClientSize.Width - side) / 2 + side / 2, (panel1.ClientSize.Height - height) / 2);
			}
			else if (radioButton4.Checked)
			{
				location = new Point((panel1.ClientSize.Width - side) / 2 + side / 2, (panel1.ClientSize.Height - side) / 2 + side / 2);
			}

			_visualizedFigure = CreateFigure(side, location);

			if (_visualizedFigure != null)
			{
				_visualizedFigure.Draw(e.Graphics);
			}

		}

		private void radioButton1_Click(object sender, EventArgs e)
		{
			panel1.Invalidate();
		}

		private void radioButton2_Click(object sender, EventArgs e)
		{
			panel1.Invalidate();
		}

		private void radioButton3_Click(object sender, EventArgs e)
		{
			panel1.Invalidate();
		}

		private void radioButton4_Click(object sender, EventArgs e)
		{
			panel1.Invalidate();
		}

		//method for selecting fill color for figure which is going to be painted
		private void button2_Click(object sender, EventArgs e)
		{
			ColorDialog MyDialog = new ColorDialog();
			MyDialog.AllowFullOpen = false;
			MyDialog.Color = button2.BackColor;
			if (MyDialog.ShowDialog() == DialogResult.OK)
			{
				button2.BackColor = MyDialog.Color;
				panel1.Invalidate();
			}
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
			foreach (IShape figure in _shapes)
			{
				figure.Draw(e.Graphics);
			}
		}

		//method for creating shape which takes int and Point as params
		private Shape CreateFigure(int side, Point position)
		{

			Color fillColor = button2.BackColor;
			Color borderColor = button1.BackColor;
			var selectedRadioButton = this.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
			if (selectedRadioButton != null)
			{
				return ShapeFactory.GetShape(selectedRadioButton.Text, side, position, borderColor, fillColor);
			}
			return null;
		}


		private void panel2_MouseClick(object sender, MouseEventArgs e)
		{
			if (_isResizing || _isDragging)
			{
				return;
			}
			//clickedOnShape boolean set to false
			_clickedOnShape = false;

			_shapes.ForEach(f => f.Focused = false);

			_lastSelectedFigure = _shapes.LastOrDefault(s => s.PointInShape(e.Location));

			if (_lastSelectedFigure != null)
			{

				//clicked on shape boolean set to true
				_clickedOnShape = true;

				//last selected figure refers to shape where mouse is pointed in, and setting its focused value to true so in drawing method to draw the border thicker

				_lastSelectedFigure.Focused = true;

				//removing shape from collection and adding it at last, so it can appear on top in the panel
				_shapes.Remove(_lastSelectedFigure);
				_shapes.Add(_lastSelectedFigure);

				//showing characteristics of selected shape 
				textBox1.Text = _lastSelectedFigure.GetSize().ToString();
				button4.BackColor = _lastSelectedFigure.BorderColor;
				button3.BackColor = _lastSelectedFigure.FillColor;
				button3.Enabled = true;
				button4.Enabled = true;

				panel2.Invalidate();
				return;
			}

			//if no shape is clicked create new one
			if (!_clickedOnShape)
			{
				_lastSelectedFigure = null;

				//clearing items for showing focused shape characteristics
				textBox1.Text = String.Empty;
				button4.BackColor = Color.White;
				button3.BackColor = Color.White;
				button3.Enabled = false;
				button4.Enabled = false;

				//unsaved changes boolean set to true
				_hasUnsavedChanges = true;

				//save before adding new figure for undo/redo
				UndoButton.Enabled = true;
				SaveUndoState();

				//creating new shape
				Point position = e.Location;
				int side = int.Parse(label2.Text);
				Shape shape = CreateFigure(side, position);
				_shapes.Add(shape);

				panel2.Invalidate();
			}
		}
		private void panel2_MouseDown(object sender, MouseEventArgs e)
		{
			//check there is checked figure
			if (_lastSelectedFigure != null)
			{
				//check if is resizing
				if (_lastSelectedFigure.GetResizeHandle().Contains(e.Location))
				{
					_isResizing = true;
				}
				//check if is dragging
				else if (_lastSelectedFigure.PointInShape(e.Location))
				{
					_isDragging = true;
				}
			}

		}

		private void panel2_MouseMove(object sender, MouseEventArgs e)
		{
			//if for resizing
			if (_isResizing && _lastSelectedFigure != null)
			{

				int newSizeByX = e.X - _lastSelectedFigure.Position.X;
				int newSizeByY = e.Y - _lastSelectedFigure.Position.Y;
				
				//if x>y to change size by X(the dominant direction)
				if (Math.Abs(newSizeByX) > Math.Abs(newSizeByY))
				{
					//check if is resizing 
					if (!_didResize)
					{
						_hasUnsavedChanges = true;
						SaveUndoState();//Save only once, when first started resizing
						_didResize = true;
					}
					_lastSelectedFigure.Resize(newSizeByX);
				}
				else
				{
					//check if is resizing 
					if (!_didResize)
					{
						_hasUnsavedChanges = true;
						SaveUndoState();//Save only once, when first started resizing
						_didResize = true;
					}
					_lastSelectedFigure.Resize(newSizeByY);
				}
				textBox1.Text = _lastSelectedFigure.GetSize().ToString();
				panel2.Invalidate();
			}
			//if for dragging
			else if (_isDragging && _lastSelectedFigure != null)
			{

				int x = e.X;
				int y = e.Y;
				Point newPosition = new Point(x, y);
				//check if is dragged 
				if (!_didDrag)
				{
					_hasUnsavedChanges = true;
					SaveUndoState();//Save only once, when first started dragging
					_didDrag = true;
				}
				_lastSelectedFigure.Move(newPosition);
				panel2.Invalidate();
			}
		}

		private void panel2_MouseUp(object sender, MouseEventArgs e)
		{

			_isDragging = false;
			_isResizing = false;
			_didDrag = false;
			_didResize = false;

		}

		//method for selecting border color for selected figure 
		private void button4_Click(object sender, EventArgs e)
		{
			if (_lastSelectedFigure != null)
			{
				ColorDialog MyDialog = new ColorDialog();
				MyDialog.AllowFullOpen = false;
				MyDialog.Color = button4.BackColor;
				if (MyDialog.ShowDialog() == DialogResult.OK)
				{
					_hasUnsavedChanges = true;
					SaveUndoState();
					button4.BackColor = MyDialog.Color;
					_lastSelectedFigure.ChangeBorderColor(MyDialog.Color);
					panel2.Invalidate();
				}
			}
		}

		//method for selecting fill color for selected figure 
		private void button3_Click(object sender, EventArgs e)
		{

			if (_lastSelectedFigure != null)
			{
				ColorDialog MyDialog = new ColorDialog();
				MyDialog.AllowFullOpen = false;
				MyDialog.Color = button3.BackColor;
				if (MyDialog.ShowDialog() == DialogResult.OK)
				{
					_hasUnsavedChanges = true;
					SaveUndoState();
					button3.BackColor = MyDialog.Color;
					_lastSelectedFigure.ChangeFillColor(MyDialog.Color);
					panel2.Invalidate();
				}
			}
		}

		private void Scene_FormClosing(object sender, FormClosingEventArgs e)
		{
			//check for if has unsaved changes
			if (_hasUnsavedChanges)
			{
				Save saveForm = new Save();
				var result = saveForm.ShowDialog();
				if (result == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
				else if (result == DialogResult.Yes)
				{
					SaveToFile();
				}

			}
		}

		private void Scene_Load(object sender, EventArgs e)
		{
			//default values for items after loading
			trackBar1.Value = DEFAULT_TRACKBAR_VALUE;
			label2.Text = DEFAULT_SIDE_VALUE.ToString();
			radioButton1.Checked = true;
			button1.BackColor = Color.Black;
			this.KeyPreview = true;
			textBox1.Enabled = false;
			UndoButton.Enabled = false;
			RedoButton.Enabled = false;

			//loading save data
			List<ShapeDTO> shapeDTOs = ShapeSerialize.LoadShapesFromJsonFile("savedInfo.json");
			if (shapeDTOs != null)
			{
				foreach (var shape in shapeDTOs!)
				{
					Color borderColor = ColorTranslator.FromHtml(shape.BorderColor);
					Color fillColor = ColorTranslator.FromHtml(shape.FillColor);
					_shapes.Add(ShapeFactory.GetShape(shape.FigureType, shape.Size, new Point ( shape.X, shape.Y), borderColor, fillColor));
					panel2.Invalidate();
				}
			}
		}


		private void Scene_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Back && _lastSelectedFigure != null)
			{
				_hasUnsavedChanges = true;
				//save before adding new figure for undo/redo
				SaveUndoState();

				//deleting selected shape from the list
				_shapes.Remove(_lastSelectedFigure);
				_lastSelectedFigure = null;
				panel2.Invalidate();
			}
		}

		private void Undo()
		{
			if (_undoStack.Any())
			{
				//getting the current list of figures on the panel
				var currentListState = _shapes.Select(f => f.Clone()).ToList();
				//saving the current state to the redo stack
				_redoStack.Push(currentListState);
				RedoButton.Enabled = true;

				//restore the last state from the undo stack 
				_shapes = _undoStack.Pop();
				panel2.Invalidate();


				// Reset selection state
				_lastSelectedFigure = null;
				textBox1.Text = string.Empty;
				button3.BackColor = Color.White;
				button4.BackColor = Color.White;
				button3.Enabled = false;
				button4.Enabled = false;

				if (_undoStack.Count == 0)
				{
					UndoButton.Enabled = false;
				}
			}
		}
		private void Redo()
		{
			if (_redoStack.Any())
			{
				var currentState = _shapes.Select(f => f.Clone()).ToList();
				//saving the current state to the undo stack
				_undoStack.Push(currentState);
				UndoButton.Enabled = true;

				//restore the last state from the redo stack 
				_shapes = _redoStack.Pop();
				panel2.Invalidate();
				if (_redoStack.Count == 0)
				{
					RedoButton.Enabled = false;
				}

			}
		}
		private void SaveUndoState()
		{
			//save the last change into undo stack
			_undoStack.Push(_shapes.Select(f => f.Clone()).ToList());
			//clear redo stack because a new change is made
			_redoStack.Clear();
			RedoButton.Enabled = false;
			UndoButton.Enabled = true;

		}

		private void UndoButton_Click(object sender, EventArgs e)
		{
			Undo();
			RedoButton.Enabled = true;

		}

		private void RedoButton_Click(object sender, EventArgs e)
		{

			Redo();
		}

		//method for saving data as JSON file
		private void SaveToFile()
		{
			string jsonFile = "savedInfo.json";
			ShapeSerialize.SaveAsJson(_shapes, jsonFile);

		}
	}
}
