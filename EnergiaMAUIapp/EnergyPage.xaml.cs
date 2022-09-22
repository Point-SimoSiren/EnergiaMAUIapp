using Newtonsoft.Json;
using System.Collections.ObjectModel;
using EnergiaBackend.Data;

namespace EnergiaMAUIapp;

public partial class EnergyPage : TabbedPage
{

    // Muuttujan alustaminen
    ObservableCollection<Sahko> dataa = new ObservableCollection<Sahko>();
    public EnergyPage()
	{
		InitializeComponent();

        LoadDataFromRestAPI();

    }


    private async void LoadDataFromRestAPI()
    {

        // Annetaan latausilmoitus
        lataus.Text = "Ladataan...";

        try
        {
            // T‰t‰ metodia tarvitaan kun ollaan debuggaustilassa ja k‰ytet‰‰n paikallista back-endi‰
      
            HttpClient client = new HttpClient();   

            client.BaseAddress = new Uri("https://energiabackend.azurewebsites.net/");
            string json = await client.GetStringAsync("api/sahko");

            IEnumerable<Sahko> sahko = JsonConvert.DeserializeObject<Sahko[]>(json);
            // dataa -niminen observableCollection on alustettukin jo ylh‰‰ll‰ p‰‰tasolla ett‰ hakutoiminto,
            // p‰‰see siihen k‰siksi.
            // asetetaan sen sis‰ltˆ ensi kerran t‰ss‰ pienell‰ kepulikonstilla:
            ObservableCollection<Sahko> dataa2 = new ObservableCollection<Sahko>(sahko);
            dataa = dataa2;

            // Asetetaan datat n‰kyviin xaml tiedostossa olevalle listalle
            sahkoList.ItemsSource = dataa;

            // Tyhjennet‰‰n latausilmoitus label
            lataus.Text = "";

        }

        catch (Exception e)
        {
            await DisplayAlert("Virhe", e.Message.ToString(), "SELVƒ!");

        }
    }
    
}
