
using DesignPatterns.ModelBuilders;
using DesignPatterns.Models;

namespace DesignPatterns.Creators
{
	public class FordExplorerCreator : Creator
	{
		public override Vehicle Create()
		{
			var builder = new CarModelBuilder()
			.SetModel("Explorer")
			.SetColor("blue");
			return builder.Build();
		}
	}
}
