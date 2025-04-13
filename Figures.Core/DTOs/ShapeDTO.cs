using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Core.DTOs
{
	//data transfer object class used for JSON serialization and deserialization
	public class ShapeDTO
	{
		public string FigureType { get; set; } = null!;
		public int Size { get; set; }
		public Point Position { get; set; }
		public string BorderColor { get; set; } = null!;
		public string FillColor { get; set; } = null!;

	}
}
