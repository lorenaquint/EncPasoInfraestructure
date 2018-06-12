

namespace Encuentas.ModelView
{
    public class MainViewModel
    {
        #region ViewModel
        public SurveysViewModel ListaEncuestas
        {
            get;
            set;
        }
        public SurveysDetailViewModel NewEncuesta
        {
            get;
            set;
        }
        #endregion

        #region Constructores
        public MainViewModel()
        {
            instance = this;
            this.ListaEncuestas = new SurveysViewModel();
        }
        #endregion
        //7Una unica ven viewmodel
        #region Sinlgeton
        public static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            else
            {
                return instance;
            }

        }
        #endregion
    }
}

