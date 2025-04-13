using Figures.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Core.Models
{
	public abstract class Shape : IShape
	{
		public bool Focused { get; set; }
		public Point Position { get; set; }
		public Color BorderColor { get; set; }
		public Color FillColor { get; set; }
		//method for changing shape's border color
		public virtual void ChangeBorderColor(Color newColor)
		{
			BorderColor = newColor;
		}
		//method for changing shape's fill color
		public virtual void ChangeFillColor(Color newColor)
		{
			FillColor = newColor;
		}
		//method fo drawing shape
		public abstract void Draw(Graphics figure);
		//method for moving shape

		public abstract void Move(Point p);
		//method for checking if point is in shape's borders
		public abstract bool PointInShape(Point point);

		//method for resizing shape
		public abstract void Resize(int size);
		
		//method for creating rectangle shaped handle for resizing
		public abstract RectangleF GetResizeHandle();
		//method for resizing 
		public abstract int GetSize();
		//method for cloning shape for undo and redo stack
		public abstract Shape Clone();
	}
}
