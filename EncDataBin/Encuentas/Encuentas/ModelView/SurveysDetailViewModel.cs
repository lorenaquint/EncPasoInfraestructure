
namespace Encuentas.ModelView
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;
 
    using System.Collections.ObjectModel;
   
    using Xamarin.Forms;
	using Encuentas.Services;

	public class SurveysDetailViewModel:Notificable
    {
        private string nombre;
        private DateTime fechaNacimiento;
        private ObservableCollection<string> teams;

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (nombre == value)
                {
                    return;
                }
                nombre = value;
                OnPropertyChanged();

            }
        }
        public DateTime FechaNacimiento
        {
            get
            {
                return fechaNacimiento;
            }
            set
            {
                if (fechaNacimiento == value)
                {
                    return;
                }
                fechaNacimiento = value;
                OnPropertyChanged();

            }
        }


        public ObservableCollection<string> Teams
        {
            get
            {
                return teams;
            }
            set
            {
                if (teams == value)
                {
                    return;
                }
                teams = value;
                OnPropertyChanged();

            }
        }
        private string equipoFavorito;

        public string EquipoFavorito
        {
            get
            {
                return equipoFavorito;
            }
            set
            {
                if (equipoFavorito == value)
                {
                    return;
                }
                equipoFavorito = value;
                OnPropertyChanged();
            }
        }



       
        private ICommand agregarEquipoCommand;

        public ICommand AgregarEquipoCommand
        {
            get
            {
                return new RelayCommand(agregarEquipo);
            }
            
        }
        private ICommand guardarEncuestaCommand;

        public ICommand GuardarEncuestaCommand
        {
            get
            {
                return new RelayCommand(GuardarEncuesta);
            }

        }

        public SurveysDetailViewModel()
        {
            Nombre = "Gabriel";
            EquipoFavorito = "Millonarios";
            FechaNacimiento = new DateTime(2018, 12, 27);
        }
        private readonly string[] equipos =

        {
            "Colombia",
            "México",
            "Perú",
            "Argentina",
            "Brasil",
            "Alemania",
            "España"

        };
        public async void GuardarEncuesta()
        {
            
            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(EquipoFavorito))
            {
                await Application.Current.MainPage.DisplayAlert("Datos Incompletos",
                                  "Recuerde Diligenciar la Información",
                                   "Aceptar");
                return;
            }
            var newSurvey = new Survey()
            {
                Nombre = Nombre,
                FechaNacimiento = this.FechaNacimiento,
                FavoriteTeam = EquipoFavorito
            };
			var geolocalizacionService = DependencyService.Get<IGeolicalizacionService>();
			if (geolocalizacionService !=null)

			{
                try
				{
					var actualLocalizacion = await geolocalizacionService.GetCurrentLocalizationAsync();
					newSurvey.Latitud = actualLocalizacion.Item1;
					newSurvey.Longitud = actualLocalizacion.Item2;
				}
				catch (Exception ex)
				{
					Application.Current.MainPage.DisplayAlert("error", ex.Message, "ok");
					newSurvey.Latitud = 0;
					newSurvey.Longitud = 0;
				}
			}
			MessagingCenter.Send(this,
                                 Messages.NewSurveyComplete,
                                 newSurvey);

            await Application.Current.MainPage.Navigation.PopAsync();
        }


    

    private async void agregarEquipo()
        {
            
            var favoriteTeam = await Application.Current.MainPage.DisplayActionSheet(Literals.FavoriteTeamTitle,
                                                       null,null,equipos);

           
            if (!string.IsNullOrEmpty(favoriteTeam))
            {
                EquipoFavorito = favoriteTeam;
            }
        }



    }
}
