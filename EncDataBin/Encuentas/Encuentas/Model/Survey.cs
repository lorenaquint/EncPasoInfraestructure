
namespace Encuentas
{
	using System;
	public class Survey
	{
		public string Nombre
		{
			get;
			set;
		}
		public DateTime FechaNacimiento
		{
			get;
			set;
		}
		public object FavoriteTeam
		{
			get;
			set;
		}
		public double Latitud
		{
			get;
			set;
		}
        public double Longitud
		{
			get;
			set;
		}
	


		public override string ToString()
		{
			return $"{Nombre} | {FechaNacimiento} | {FavoriteTeam} | {Longitud} | {Latitud}";
		}

		public Survey()
        {
            
        }
    }
}
