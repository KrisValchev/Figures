using System.Drawing;

namespace Figures.Core.Models
{
	public class Rectangle : Shape
	{

		public int Width { get; set; }
		public int Height { get; set; }
		public Rectangle(int width, Point position, Color borderColor, Color fillColor)
		{
			Width = width;
			Height = width / 2;
			Position = position;
			BorderColor = borderColor;
			FillColor = fillColor;
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
			using (var p = new Pen(this.BorderColor, penSize))
			{
				figure.DrawRectangle(p, Position.X, Position.Y, this.Width, this.Height);

			}
			using (SolidBrush b = new SolidBrush(this.FillColor))
			{
				figure.FillRectangle(b, Position.X, Position.Y, this.Width, this.Height);

			}
		}

		public override void Move(Point p)
		{
			Position = new Point(p.X, p.Y);
		}

		public override void Resize(int size)
		{
			if (size >= 10)
			{
				Width = size;
				Height = size / 2;
			}
		}

		public override bool PointInShape(Point point)
		{
			return
			   Position.X <= point.X && point.X <= Position.X + Width &&
			   Position.Y <= point.Y && point.Y <= Position.Y + Height;
		}

		public override RectangleF GetResizeHandle()
		{
			int handleSize = 10;
			return new RectangleF(
				Position.X + Width,
				Position.Y + Height,
				handleSize,
				handleSize);
		}

		public override int GetSize()
		{
			return Width;
		}

		public override Shape Clone()
		{
			return new Rectangle(this.Width, this.Position, this.BorderColor, this.FillColor);
		}
	}
}
