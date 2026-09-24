using MauiAppTempoAgora.Models;
using Newtonsoft.Json.Linq;

namespace MauiAppTempoAgora.Services
{
    internal class DataServices
    {
        public static async Task<tempo?> GetPrevisao(string cidade)
        {
            tempo? t = null;

            string chave = "422573e5d6a3895b8a8b6c6b8a0da663";


            string url = $"https://api.openweathermap.org/data/2.5/weather?" +
            $"q={cidade},BR&units=metric&lang=pt_br&appid=422573e5d6a3895b8a8b6c6b8a0da663";

            using (HttpClient httpClient = new HttpClient()) // Ajuste: removido ';' para que o bloco use corretamente as chaves
            {
                HttpResponseMessage resp = await httpClient.GetAsync(url); // Ajuste: requisição feita com a instância do bloco using

                if (resp.IsSuccessStatusCode)
                {

                    String json = await resp.Content.ReadAsStringAsync();

                    var rascunho = JObject.Parse(json);

                    // Ajuste: leitura correta das chaves JSON "sunrise" e "sunset" (Unix timestamp)
                    DateTime sunrise = DateTimeOffset
                        .FromUnixTimeSeconds((long)rascunho["sys"]!["sunrise"]!)
                        .LocalDateTime;

                    DateTime sunset = DateTimeOffset
                        .FromUnixTimeSeconds((long)rascunho["sys"]!["sunset"]!)
                        .LocalDateTime;




                    t = new()
                    {
                        lat = (double)rascunho["coord"]["lat"],
                        // Ajuste: longitude deve vir de "lon", não de "lat"
                        Lon = (double)rascunho["coord"]["lon"],
                        description = (string)rascunho["weather"][0]["description"],
                        main = (string)rascunho["weather"][0]["main"],
                        temp_max = (double)rascunho["main"]["temp_max"],
                        temp_min = (double)rascunho["main"]["temp_min"],
                        sunrise = sunrise.ToString(),
                        sunset = sunset.ToString(),
                        visibility = (int?)(double)rascunho["visibility"],
                        speed = (int?)(double)rascunho["wind"]["speed"],
                    };//dfecha objeto do tempo 

                }//fecha status do servidor 

            } // Ajuste: fechamento do bloco using validado fecha laço iusing

            return t;

        }

       
    }
}