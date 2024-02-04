using RatingViewControl.ViewModels;

namespace RatingViewControl
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();
        }
    }

}
