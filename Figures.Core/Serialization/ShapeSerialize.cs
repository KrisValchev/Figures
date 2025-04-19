using Figures.Core.Models;
using Figures.DTO;
using System.Text.Json;

namespace Figures.Core.Serialization
{
	public static class ShapeSerialize
	{
		public static List<ShapeDTO> LoadShapesFromJsonFile(string filePath)
		{
			if (File.Exists(filePath))
			{
				string jsonFile = File.ReadAllText(filePath);
				if (jsonFile != string.Empty)
				{
					//deserializing json file text to list of ShapeDTOs
					return  JsonSerializer.Deserialize<List<ShapeDTO>>(jsonFile);
				}
			}
			return null;
		}

		public static void SaveAsJson(List<Shape> shapes,string filePath)
		{
			var figuresInfoList = shapes.Select(f => new ShapeDTO
			{
				FigureType = f.GetType().Name,
				Size = f.GetSize(),
				//if shape is circle the position is equal to the position of the center
				X = (f is Circle) ? f.Position.X + f.GetSize() / 2 : f.Position.X,
				Y= (f is Circle) ? f.Position.Y + f.GetSize() / 2 : f.Position.Y,
				//saving border and fill color as hex
				BorderColor = $"#{f.BorderColor.A:X2}{f.BorderColor.R:X2}{f.BorderColor.G:X2}{f.BorderColor.B:X2}",
				FillColor = $"#{f.FillColor.A:X2}{f.FillColor.R:X2}{f.FillColor.G:X2}{f.FillColor.B:X2}"
			})
				.ToList();
			string jsonString = JsonSerializer.Serialize(figuresInfoList);
			File.WriteAllText(filePath, jsonString);
		}
	}
}
