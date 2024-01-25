using DesignPatterns.Models;
using System.Collections.Generic;

namespace DesignPatterns.Infraestructure.Singletons
{
	public class MemoryCollection
	{
		private static MemoryCollection _instance; //implementacion del patron Singleton para mantener en memoria la instancia de la base de datos en memoria.
		public ICollection<Vehicle>	Vehicles {get;set;}

		public static MemoryCollection Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new MemoryCollection();
				}
				return _instance;
			}
		}

		private MemoryCollection()
		{
			Vehicles = new List<Vehicle>();
		}
	}
}
