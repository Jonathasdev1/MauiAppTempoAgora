using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object? sender, EventArgs e)
        {
            try
            {
                // Ajuste: validação correta para evitar chamada com texto vazio
                if (!string.IsNullOrWhiteSpace(txt_cidade.Text))
                {
                    // Ajuste: esta linha está correta, só depende do método e escopo estarem válidos
                    tempo? t = await DataServices.GetPrevisao(txt_cidade.Text);

                    // Ajuste: feedback simples para retorno nulo
                    //  lbl_res.Text = t is null ? "Não foi possível obter a previsão." : $"Clima: {t.main} - {t.description}";

                    if (t != null)
                    {
                        string dados_previsao = "";
                        dados_previsao = $"latitude:{t.lat} \n" +
                                         $"Longitide:{t.lon}\n " +
                                         $"nascer do sol:{t.sunrise}\n "  +
                                         $"por do sol:{t.sunset} \n " +
                                         $"temperatura maxima{t.temp_max}\n "  +
                                         $"temperatura minima{t.temp_min}\n ";
                        lbl_res.Text = dados_previsao;

                    }




                }
                else
                {
                    lbl_res.Text = "Preencha a cidade";
                }
            }
            catch (Exception ex)
            {
                // Ajuste: captura a exceção para usar ex.Message corretamente
                await DisplayAlert("Ops", ex.Message, "Ok");
            }
        }
    }
}
