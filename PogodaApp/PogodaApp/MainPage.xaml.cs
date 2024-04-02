using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;
using Xamarin.Forms.Xaml;

namespace PogodaApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            daysEntry.Text = "1";
        }
        public double lat = 61.00318527;
        public double lon = 69.01891327;
        public int limit = 3;

        public void ChangeParameters()
        {
            if(Convert.ToInt32(daysEntry.Text) <=0)
                limit = Math.Max(Convert.ToInt32(daysEntry.Text), 1);
            else
                limit = Math.Min(Convert.ToInt32(daysEntry.Text), 7);

            switch (Cities.SelectedIndex)
            {
                case 0: // Khanty-Mansiysk
                    lat = 61.00318527;
                    lon = 69.01891327;
                        break;
                case 1: // Saint-Petersburg
                    lat = 59.93867493;
                    lon = 30.31449318;
                        break;
                case 2: // Yekaterinburg{
                    lat = 56.8380127;
                    lon = 60.59747314;
                        break;
                case 3: // Tyumen
                    lat = 57.15298462;
                    lon = 65.54122925;
                        break;
                case 4: // Moscow
                    lat = 55.75581741;
                    lon = 37.61764526;
                        break;
                default: // Khanty
                    lat = 61.00318527;
                    lon = 69.01891327;
                        break;
            }
        }

        public async void DoRequest()
        {
            ChangeParameters();
            string APIkey = "b9c4e26d-1a1f-4e34-bf37-69825cf9fdd7";
            HttpClient client = new HttpClient();

            string url = $"https://api.weather.yandex.ru/v2/forecast/?lat={lat}&lon={lon}&lang=ru_RU&limit={limit}&hours=false";

            try
            {
                client.DefaultRequestHeaders.Add("X-Yandex-API-Key", APIkey);
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "text2.txt");


                System.IO.File.WriteAllText(PATH, responseBody);
                var json = System.IO.File.ReadAllText(PATH);
                Root pogoda = System.Text.Json.JsonSerializer.Deserialize<Root>(json);
                List<Forecast> forecasts = pogoda.forecasts;

                //foreach (var i in forecasts) 
                //{
                //    string imageValue = i.parts.day_short.icon;
                //    i.parts.day_short.icon = $"https://yastatic.net/weather/i/icons/funky/dark/{imageValue}.svg";
                //}
                   
                    

                Title.Text = "Прогноз погоды для " + Cities.SelectedItem;
                days.ItemsSource = forecasts;

                const string defaultValue = "г. Ханты-Мансийск";
                if (Cities.Title == "Город")
                {
                    Cities.Title = defaultValue;
                    Title.Text = "Прогноз погоды для " + defaultValue;
                }
                //try
                //{
                //    List<Root> rootLists = JsonConvert.DeserializeObject<List<Root>>(json);
                //}
                //catch 
                //{
                //    Root root = JsonConvert.DeserializeObject<Root>(json);
                //}

                //taskList.ItemsSource = items;
            }
            catch (HttpRequestException e) { Console.WriteLine("Анлаки"); }
        }

        private void Zapros_Clicked(object sender, EventArgs e)
        {
            DoRequest();
        }
    }

    public class Biomet
    {
        public double index { get; set; }
        public string condition { get; set; }
    }

    public class Country
    {
        public double id { get; set; }
        public string name { get; set; }
    }

    public class Day
    {
        public string _source { get; set; }
        public double temp_min { get; set; }
        public double temp_avg { get; set; }
        public double temp_max { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mm { get; set; }
        public double pressure_pa { get; set; }
        public double humidity { get; set; }
        public double soil_temp { get; set; }
        public double soil_moisture { get; set; }
        public double prec_mm { get; set; }
        public double prec_prob { get; set; }
        public double prec_period { get; set; }
        public double cloudness { get; set; }
        public double prec_type { get; set; }
        public double prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public double uv_index { get; set; }
        public double feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
        public double fresh_snow_mm { get; set; }
    }

    public class DayShort
    {
        public string _source { get; set; }
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mm { get; set; }
        public double pressure_pa { get; set; }
        public double humidity { get; set; }
        public double soil_temp { get; set; }
        public double soil_moisture { get; set; }
        public double prec_mm { get; set; }
        public double prec_prob { get; set; }
        public double prec_period { get; set; }
        public double cloudness { get; set; }
        public double prec_type { get; set; }
        public double prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public double uv_index { get; set; }
        public double feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
        public double fresh_snow_mm { get; set; }
    }

    public class District
    {
        public double id { get; set; }
        public string name { get; set; }
    }

    public class Evening
    {
        public string _source { get; set; }
        public double temp_min { get; set; }
        public double temp_avg { get; set; }
        public double temp_max { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mm { get; set; }
        public double pressure_pa { get; set; }
        public double humidity { get; set; }
        public double soil_temp { get; set; }
        public double soil_moisture { get; set; }
        public double prec_mm { get; set; }
        public double prec_prob { get; set; }
        public double prec_period { get; set; }
        public double cloudness { get; set; }
        public double prec_type { get; set; }
        public double prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public double uv_index { get; set; }
        public double feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
        public double fresh_snow_mm { get; set; }
    }

    public class Fact
    {
        public double obs_time { get; set; }
        public double uptime { get; set; }
        public double temp { get; set; }
        public double feels_like { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public double cloudness { get; set; }
        public double prec_type { get; set; }
        public double prec_prob { get; set; }
        public double prec_strength { get; set; }
        public bool is_thunder { get; set; }
        public double wind_speed { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mm { get; set; }
        public double pressure_pa { get; set; }
        public double humidity { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
        public string season { get; set; }
        public string source { get; set; }
        public double soil_moisture { get; set; }
        public double soil_temp { get; set; }
        public double uv_index { get; set; }
        public double wind_gust { get; set; }
    }

    public class Forecast
    {
        public string date { get; set; }
        public double date_ts { get; set; }
        public double week { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string rise_begin { get; set; }
        public string set_end { get; set; }
        public double moon_code { get; set; }
        public string moon_text { get; set; }
        public Parts parts { get; set; }
        public List<object> hours { get; set; }
        public Biomet biomet { get; set; }
    }

    public class GeoObject
    {
        public District district { get; set; }
        public Locality locality { get; set; }
        public Province province { get; set; }
        public Country country { get; set; }
    }

    public class Info
    {
        public bool n { get; set; }
        public double geoid { get; set; }
        public string url { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public Tzinfo tzinfo { get; set; }
        public double def_pressure_mm { get; set; }
        public double def_pressure_pa { get; set; }
        public string slug { get; set; }
        public double zoom { get; set; }
        public bool nr { get; set; }
        public bool ns { get; set; }
        public bool nsr { get; set; }
        public bool p { get; set; }
        public bool f { get; set; }
        public bool _h { get; set; }
    }

    public class Locality
    {
        public double id { get; set; }
        public string name { get; set; }
    }

    public class Morning
    {
        public string _source { get; set; }
        public double temp_min { get; set; }
        public double temp_avg { get; set; }
        public double temp_max { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mm { get; set; }
        public double pressure_pa { get; set; }
        public double humidity { get; set; }
        public double soil_temp { get; set; }
        public double soil_moisture { get; set; }
        public double prec_mm { get; set; }
        public double prec_prob { get; set; }
        public double prec_period { get; set; }
        public double cloudness { get; set; }
        public double prec_type { get; set; }
        public double prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public double uv_index { get; set; }
        public double feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
        public double fresh_snow_mm { get; set; }
    }

    public class Night
    {
        public string _source { get; set; }
        public double temp_min { get; set; }
        public double temp_avg { get; set; }
        public double temp_max { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mm { get; set; }
        public double pressure_pa { get; set; }
        public double humidity { get; set; }
        public double soil_temp { get; set; }
        public double soil_moisture { get; set; }
        public double prec_mm { get; set; }
        public double prec_prob { get; set; }
        public double prec_period { get; set; }
        public double cloudness { get; set; }
        public double prec_type { get; set; }
        public double prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public double uv_index { get; set; }
        public double feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
        public double fresh_snow_mm { get; set; }
    }

    public class NightShort
    {
        public string _source { get; set; }
        public double temp { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mm { get; set; }
        public double pressure_pa { get; set; }
        public double humidity { get; set; }
        public double soil_temp { get; set; }
        public double soil_moisture { get; set; }
        public double prec_mm { get; set; }
        public double prec_prob { get; set; }
        public double prec_period { get; set; }
        public double cloudness { get; set; }
        public double prec_type { get; set; }
        public double prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public double uv_index { get; set; }
        public double feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
        public double fresh_snow_mm { get; set; }
    }

    public class Parts
    {
        public DayShort day_short { get; set; }
        public Evening evening { get; set; }
        public NightShort night_short { get; set; }
        public Night night { get; set; }
        public Morning morning { get; set; }
        public Day day { get; set; }
    }

    public class Province
    {
        public double id { get; set; }
        public string name { get; set; }
    }

    public class Root
    {
        public double now { get; set; }
        public DateTime now_dt { get; set; }
        public Info info { get; set; }
        public GeoObject geo_object { get; set; }
        public Yesterday yesterday { get; set; }
        public Fact fact { get; set; }
        public List<Forecast> forecasts { get; set; }
    }

    public class Tzinfo
    {
        public string name { get; set; }
        public string abbr { get; set; }
        public bool dst { get; set; }
        public double offset { get; set; }
    }

    public class Yesterday
    {
        public double temp { get; set; }
    }
}
