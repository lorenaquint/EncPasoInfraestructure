using System;

using System.Threading.Tasks;
using Android.Locations;
using Encuentas.Droid.Services;
using Encuentas.Services;
using Xamarin.Forms;
using Android.Content;
[assembly:Dependency(typeof(GeolocalizacionService))]
namespace Encuentas.Droid.Services
{
	public class GeolocalizacionService:IGeolicalizacionService
    {
		private readonly LocationManager locationManager = null;

        public GeolocalizacionService()
        {
			locationManager = Forms.Context.GetSystemService(Context.LocationService) as LocationManager;
        }

		public Task<Tuple<double, double>> GetCurrentLocalizationAsync()
		{
			var provider = locationManager.GetBestProvider(new Criteria()
            {
                Accuracy = Accuracy.Fine

            }, true);
            var location = locationManager.GetLastKnownLocation(provider);
            var result = new Tuple<double, double>(location.Latitude, location.Longitude);
            return Task.FromResult(result);
		}


	}
}
