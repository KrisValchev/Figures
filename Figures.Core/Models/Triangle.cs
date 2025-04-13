using System.Drawing;
using System.Drawing.Drawing2D;

namespace Figures.Core.Models
{
	class Triangle : Shape
	{

		public Point BottomLeft { get; set; }
		public Point BottomRight { get; set; }
		public int SideSize { get; set; }
		public int Height
		{
			get
			{
				return CalculateHeight();
			}
			set
			{
			}
		}
		public Triangle(int sideSize, Point position, Color borderColor, Color fillColor)
		{
			Position = position;
			SideSize = sideSize;
			BorderColor = borderColor;
			FillColor = fillColor;
			CalculateBottomVertices();
		}
		//private method for calculating other two vertices of the triangle 
		private void CalculateBottomVertices()
		{
			BottomLeft = new Point((Position.X - SideSize / 2), Position.Y + Height);
			BottomRight = new Point((Position.X + SideSize / 2), Position.Y + Height);
		}
		//private method for calculating height of the triangle
		private int CalculateHeight()
		{
			return (int)Math.Round(SideSize * Math.Sqrt(3) / 2);
		}


		public override void Draw(Graphics figure)
		{
			int penSize = 2;
			if (Focused)
			{
				var handle = GetResizeHandle();
				using (Brush b = new SolidBrush(Color.Black))
				{
					figure.FillRectangle(b, handle);
				}
				penSize = 6;
			}
			using (Pen p = new Pen(this.BorderColor, penSize))
			{
				figure.DrawPolygon(p, new Point[] { Position, BottomLeft, BottomRight });
			}
			using (SolidBrush b = new SolidBrush(this.FillColor))
			{
				figure.FillPolygon(b, new Point[] { Position, BottomLeft, BottomRight });

			}
		}

		public override void Move(Point p)
		{
			Position = new Point(p.X, p.Y);
			CalculateBottomVertices();
		}

		public override void Resize(int size)
		{
			if (size >= 10)
			{
				SideSize = (int)Math.Round((size * 2) / Math.Sqrt(3));
				CalculateBottomVertices();
			}
		}

		public override bool PointInShape(Point point)
		{
			using (GraphicsPath path = new GraphicsPath())
			{
				path.AddPolygon(new Point[] { Position, BottomLeft, BottomRight });
				return path.IsVisible(point);
			}
		}

		public override RectangleF GetResizeHandle()
		{
			int handleSize = 10;
			return new RectangleF(
				Position.X + SideSize / 2,
				Position.Y + Height,
				handleSize,
				handleSize);
		}

		public override int GetSize()
		{
			return SideSize;
		}

		public override Shape Clone()
		{
			return new Triangle(this.SideSize,this.Position,this.BorderColor,this.FillColor);
		}
	}
}
