
namespace Encuentas
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using System;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SurveysView : ContentPage
    {
        public SurveysView()
        {
            InitializeComponent();
           
        }
    
        public async void AddSurvey_Clicked(Object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SurveyDetailsView());
        }

    }
}