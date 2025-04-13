
using Figures.Core.Models;
using System.Drawing;
using Rectangle = Figures.Core.Models.Rectangle;

namespace Figures.Core.Factories
{
	//factory class for creating shape of specific type
	public class ShapeFactory
	{
		public static Shape GetShape(string shapeType, int side, Point position, Color borderColor, Color fillColor)
		{
			switch (shapeType.ToLower())
			{
				case "circle":
					return new Circle(side, position, borderColor, fillColor);
				case "square":
					return new Square(side, position, borderColor, fillColor);
				case "rectangle":
					return new Rectangle(side, position, borderColor, fillColor);
				case "triangle":
					return new Triangle(side, position, borderColor, fillColor);
				default:
					throw new ArgumentException("Invalid shape type");

			}
		}
	}
}
