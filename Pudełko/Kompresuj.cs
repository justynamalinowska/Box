using System;
using Pudełko;

namespace ExtensionMethod
{
	public static class BoxExtension
	{
		public static Pudelko Kompresuj(this Pudelko pudelko)
		{
			double edge = Math.Cbrt(pudelko.Objetosc);
			return new Pudelko(edge, edge, edge);
		}

		

	}
}

