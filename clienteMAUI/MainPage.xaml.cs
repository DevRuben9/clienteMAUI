using clienteMAUI.Conexion;
using clienteMAUI.Models;
using clienteMAUI.Pages;
using System.Diagnostics;

namespace clienteMAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly IRestConexionDatos _restConexionDatos;
        public MainPage(IRestConexionDatos restConexionDatos)
        {
            InitializeComponent();
            _restConexionDatos = restConexionDatos;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            coleccionPlatosView.ItemsSource = await _restConexionDatos.GetPlatosAsync();
        }
        async void OnAddPlatoClic(object sender, EventArgs e)
        {
            Debug.WriteLine("OnAddPlatoClic invoked.");
            var param = new Dictionary<string, object>
            {
                { nameof(Plato), new Plato()  }
            };
            await Shell.Current.GoToAsync(nameof(PlatosPage), param);
        }
        async void OnElementoCambiado(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("OnElementoCambiado invoked.");
            var param = new Dictionary<string, object>
            {
                { nameof(Plato), e.CurrentSelection.FirstOrDefault() as Plato }
            };
            await Shell.Current.GoToAsync(nameof(PlatosPage), param);
        }
    }

}
