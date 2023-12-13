using System.Collections.ObjectModel;

namespace parte2dos2;
public partial class MainPage : ContentPage
{
    public class Fruta
    {
        public string Nombre { get; set; }
        public string Url { get; set; }
    }
    ObservableCollection<Fruta> datos = new ObservableCollection<Fruta>();
    public MainPage()
    {
        InitializeComponent();
        milista.ItemsSource = datos;

    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        datos.Add(new Fruta { Nombre = valor.Text, Url = direccionurl.Text });
    }
    private async void milista_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var myListView = (ListView)sender;
        var myItem = myListView.SelectedItem;
        int index = datos.IndexOf((Fruta)myItem);
        string action = await DisplayActionSheet("Acciones:", "Cancelar",
        null, "Eliminar", "Editar");
        if (action == "Eliminar")
        {
            datos.RemoveAt(index);
            await DisplayAlert("Eliminar elemento", "Se elimino el lemento no:"
            + index, "OK");
            milista.ItemsSource = null;
            milista.ItemsSource = datos;
        }
        if (action == "Editar")
        {
            await DisplayAlert("Mensaje", "Seleccio editar", "ok");
        }
    }
    private void MenuItem_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Mensaje", "Seleccio Mostrar", "ok");
    }
    private void MenuItem_Clicked_1(object sender, EventArgs e)
    {
        var mi = ((MenuItem)sender);
        DisplayAlert("Fruta seleccioada", "Fruta:" +
        mi.CommandParameter.ToString(), "ok");
    }
}