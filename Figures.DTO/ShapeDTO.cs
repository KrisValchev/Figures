

namespace Figures.DTO
{
	//data transfer object class used for JSON serialization and deserialization
	public class ShapeDTO
	{
		public string FigureType { get; set; } = null!;
		public int Size { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public string BorderColor { get; set; } = null!;
		public string FillColor { get; set; } = null!;

	}
}
