using DesignPatterns.ModelBuilders;
using DesignPatterns.Models;

namespace DesignPatterns.Creators
{
	public class FordEscapeCreator : Creator
	{
		public override Vehicle Create()
		{
			var builder = new CarModelBuilder()
				.SetModel("Escape")
				.SetColor("Yellow");
			return builder.Build();
		}
	}
}
