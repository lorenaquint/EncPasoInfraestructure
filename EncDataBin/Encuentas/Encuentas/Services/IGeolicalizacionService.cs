using System;
using System.Threading.Tasks;

namespace Encuentas.Services
{
    public interface IGeolicalizacionService
    {
		Task<Tuple<double, double>> GetCurrentLocalizationAsync();
    }
}
