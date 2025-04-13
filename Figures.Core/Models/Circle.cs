using Figures.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Core.Models
{
	public class Circle : Shape
	{
		private Point _center;
		public int Radius { get; set; }
		public Circle(int diameter, Point center, Color borderColor, Color fillColor)
		{
			Radius = diameter/2;
			_center = center;
			BorderColor = borderColor;
			FillColor = fillColor;
			CalculatePosition();
		}
		//private method for calculating position of circle for drawing
		private void CalculatePosition()
		{
			Position = new Point(_center.X - Radius, _center.Y - Radius);
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
				figure.DrawEllipse(p, Position.X, Position.Y, Radius * 2, Radius * 2);
			}
			using (SolidBrush b = new SolidBrush(this.FillColor))
			{
				figure.FillEllipse(b, Position.X, Position.Y, Radius * 2, Radius * 2);
			}
		}

		public override void Move(Point p)
		{
			_center = new Point(p.X, p.Y);
			CalculatePosition();
		}

		public override void Resize(int size)
		{
			if (size >= 10)
			{
				Radius = size / 2;
			}
		}

		public override bool PointInShape(Point point)
		{
			double distance = Math.Sqrt(Math.Pow(point.X - _center.X, 2) + Math.Pow(point.Y - _center.Y, 2));
			return distance <= Radius;
		}

		public override RectangleF GetResizeHandle()
		{
			int handleSize = 10;
			return new RectangleF(
				Position.X + Radius * 2,
				Position.Y + Radius * 2,
				handleSize,
				handleSize);
		}

		public override int GetSize()
		{
			return Radius * 2;
		}

		public override Shape Clone()
		{
			return new Circle(this.Radius*2, this._center, this.BorderColor, this.FillColor);
		}
	}
}
