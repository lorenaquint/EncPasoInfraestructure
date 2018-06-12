


namespace Encuentas
{
    using Encuentas.ModelView;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class SurveysViewModel : Notificable
    {
        private ObservableCollection<Survey> encuestas;
        private Survey encSeleccionada;

        public ICommand NuevaEncCommand
        {
            get
            {
                return new RelayCommand(NuevaEnc);
            }
        }

        private async void NuevaEnc()
        {
            MainViewModel.GetInstance().NewEncuesta = new SurveysDetailViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new SurveyDetailsView());
           
        }

        public Survey EncSeleccionada
        {
            get
            {
                return encSeleccionada;

            }
            set {
                if (encSeleccionada == value)
                {
                    return;
                }
                encSeleccionada = value;
                OnPropertyChanged();
            }
        }
    

        public ObservableCollection<Survey> Encuestas
        {
            get
            {
                return encuestas;
            }
            set
            {
                if (encuestas == value)
                {
                    return;
                }
                encuestas = value;
                OnPropertyChanged();
            }
        }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public SurveysViewModel()
        {
            Encuestas = new ObservableCollection<Survey>();
            MessagingCenter.Subscribe<SurveysDetailViewModel,
           Survey>(this, Messages.NewSurveyComplete, (sender, args)
            =>
           {
               Encuestas.Add(args);


           });
        }
    }
}
