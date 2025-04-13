using Figures.Core.Models;
using System.Drawing;

namespace Figures.Core.Interfaces
{
	public interface IShape
	{
		void Draw(Graphics figure);
		void Move(Point p);
		void Resize(int size);
		void ChangeBorderColor(Color newColor);
		void ChangeFillColor(Color newColor);
		bool PointInShape(Point point);
		 RectangleF GetResizeHandle();
		int GetSize();
		Shape Clone();


	}
}
