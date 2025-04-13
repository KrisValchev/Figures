
using Figures.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Core.Models
{
	class Square : Shape
	{

		public int SideSize { get; set; }
		public Square(int sideSize, Point position, Color borderColor, Color fillColor)
		{
			SideSize = sideSize;
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
				figure.DrawRectangle(p, Position.X, Position.Y, SideSize, SideSize);
			}
			using (SolidBrush b = new SolidBrush(this.FillColor))
			{
				figure.FillRectangle(b, Position.X, Position.Y, SideSize, SideSize);
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
				SideSize =  size;
			}
		}
		public override bool PointInShape(Point point)
		{
			return
			   Position.X <= point.X && point.X <= Position.X + SideSize &&
			   Position.Y <= point.Y && point.Y <= Position.Y + SideSize;
		}
		public override RectangleF GetResizeHandle()
		{
			int handleSize = 10;
			return new RectangleF(
				Position.X + SideSize,
				Position.Y + SideSize,
				handleSize,
				handleSize);
		}

		public override int GetSize()
		{
			return SideSize;
		}

		public override Shape Clone()
		{
			return new Square(this.SideSize, this.Position, this.BorderColor, this.FillColor);
		}
	}
}
