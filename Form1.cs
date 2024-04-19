using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading.Tasks.Sources;
using System.Security.Cryptography.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Security.Cryptography;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET;


namespace EcarGUI
{
    public partial class Dashboard : Form
    {
        private int currentHour = 0;
        int weight = 2800;
        int engineTorque = 0;
        float voltage = 0;
        float airFriction = 0.0005f;
        float deceleration = 0.15f;

        float acceleration = 0;
        float brake = 0;

        // Other variables
        float speed = 0.0f; // Initial spee
        int gear = 2;

        float battery = 180; //240max
        float currentSpent = 0;
        int KWh = 0;
        float hoursToDrive = 0;
        int driven = 30000;



        public Dashboard()
        {
            InitializeComponent();
            this.KeyPreview = true;
            // this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProcessingWeather();
            ChartInit();

            TH.Text = DateTime.Now.ToString("HH:mm");
            TY.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            // Set up GMap control
            gMapControl1.MapProvider = GoogleMapProvider.Instance; // or other provider
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl1.Position = new PointLatLng(0, 0); // Initial position
            gMapControl1.MinZoom = 0; // Adjust as needed
            gMapControl1.MaxZoom = 18; // Adjust as needed
            gMapControl1.Zoom = 13; // Initial zoom level
            gMapControl1.Position = new PointLatLng(45.41667, 23.36667);

            gMapControl1.CanDragMap = true;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;

            gMapControl1.MouseClick += Gmap_MouseClick;
            gMapControl1.Dock = DockStyle.Fill;


            gMapControl1.MouseWheel += gMapControl1_MouseWheel;

        }

        int mapZoom = 0;
        private void gMapControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            mapZoom = (int)gMapControl1.Zoom;
                
        }


        private double startingPointY = 45.41667;
        private double startingPointX = 23.36667;
        
        private double wayPointY = 0;
        private double wayPointX = 0;


        private void Gmap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // Check if left mouse button is clicked
            {
                // Convert screen coordinates to geographic coordinates
                PointLatLng clickedPoint = gMapControl1.FromLocalToLatLng(e.X, e.Y); 

                wayPointY = (double)clickedPoint.Lat;
                wayPointX = (double)clickedPoint.Lng;

                // Add marker at clicked location
                GMarkerGoogle marker = new GMarkerGoogle(clickedPoint, GMarkerGoogleType.red);
                GMapOverlay markersOverlay = new GMapOverlay("markers");
                markersOverlay.Markers.Add(marker);
                gMapControl1.Overlays.Add(markersOverlay);
                gMapControl1.Zoom = mapZoom;
            }
        }

        private void hybridMap_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleHybridMapProvider.Instance;
        }

        private void terrainMap_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleTerrainMapProvider.Instance;
        }

        private void satelliteMap_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
        }

        /// <summary>
        ///  routing
        /// </summary>
        private readonly HttpClient httpClient = new HttpClient();

        public async Task<string> GetRouteJsonAsync(double startLat, double startLng, double endLat, double endLng)
        {

            string sLat = startLat.ToString().Replace(",", ".");
            string sLng = startLng.ToString().Replace(",", ".");
            string eLat = endLat.ToString().Replace(",", ".");
            string eLng = endLng.ToString().Replace(",", ".");

            //System.Diagnostics.Debug.WriteLine(sLat.Replace(",","."));

            string apiUrl = $"https://api.geoapify.com/v1/routing?waypoints={sLat},{sLng}|{eLat},{eLng}&mode=drive&apiKey=fff67f9fe9684413af2a5787647fcb68";

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode(); // Throw exception if not successful

            return await response.Content.ReadAsStringAsync();
        }


        private void DisplayRoute(string routeJson)
        {
            JObject routeData = JObject.Parse(routeJson);
            JArray routeFeatures = (JArray)routeData["features"];

            if (routeFeatures.Count == 0)
                return; // No route data available

            // Assuming only one feature is present and it is a MultiLineString
            JArray allLines = (JArray)routeFeatures[0]["geometry"]["coordinates"];

            List<PointLatLng> points = new List<PointLatLng>();

            // Iterate through each line in the MultiLineString
            foreach (JArray line in allLines)
            {
                foreach (JArray coordinate in line)
                {
                    if (coordinate.Count < 2)
                        continue; // Skip if there are not enough data points for latitude and longitude

                    if (!double.TryParse(coordinate[1].ToString(), out double lat))
                        continue; // Skip if latitude is not a valid double

                    if (!double.TryParse(coordinate[0].ToString(), out double lng))
                        continue; // Skip if longitude is not a valid double

                    points.Add(new PointLatLng(lat, lng));
                }
            }

            GMapRoute route = new GMapRoute(points, "Route");
            GMapOverlay routeOverlay = new GMapOverlay("RouteOverlay"); // Changed name to avoid potential conflicts
            routeOverlay.Routes.Add(route);
            gMapControl1.Overlays.Add(routeOverlay);
            gMapControl1.Zoom = mapZoom;

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Get start and end coordinates from user input
            double startLat = Convert.ToDouble(startingPointY);
            double startLng = Convert.ToDouble(startingPointX);
            double endLat = Convert.ToDouble(wayPointY);
            double endLng = Convert.ToDouble(wayPointX);


            // Call Geoapify API to get route details
            string routeJson = await GetRouteJsonAsync(startLat, startLng, endLat, endLng);

            // Display route on map
            DisplayRoute(routeJson);
        }


        static async Task<(string formattedWeatherData, string skyInfo)> FetchWeatherAsync()
        {
            string apiKey = "dd99eca5f172bc9ab8d42cb7b705f6d8";
            string city = "petrosani";
            string country = "romania";

            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city},{country}&appid={apiKey}";



            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        JObject weatherData = JObject.Parse(json);

                        double temperatureKelvin = Convert.ToDouble(weatherData["main"]["temp"]);
                        double temperatureCelsius = temperatureKelvin - 273.15;

                        string humidity = weatherData["main"]["humidity"].ToString();
                        string windSpeed = weatherData["wind"]["speed"].ToString();
                        //string visibility = weatherData["visibility"].ToString();

                        double windDirectionDegrees = Convert.ToDouble(weatherData["wind"]["deg"]);
                        string windDirection = WindDirectionToCompass(windDirectionDegrees);
                        string skyInfo = "";
                        if (weatherData["weather"] != null && weatherData["weather"].HasValues)
                        {
                            skyInfo = weatherData["weather"][0]["icon"].ToString();
                        }

                        string formattedWeatherData = $"T: {temperatureCelsius:F1}°C, H: {humidity}%, W: {windDirection} {windSpeed} m/s";

                        return (formattedWeatherData, skyInfo);
                    }
                    else
                    {
                        return ($"Failed to fetch weather data. Status code: {response.StatusCode}", "");
                    }
                }
                catch (Exception ex)
                {
                    return ($"An error occurred: {ex.Message}", "");
                }
            }
        }

        static string WindDirectionToCompass(double degrees)
        {
            string[] compassLetters = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW" };
            int index = (int)((degrees / 22.5) + 0.5) % 16;
            return compassLetters[index];
        }

        private async void ProcessingWeather()
        {
            var (formattedWeatherData, skyInfo) = await FetchWeatherAsync();

            temperature.Text = formattedWeatherData;
            weatherPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(skyInfo);

        }

        private void ChartInit()
        {
            Chart chart = new Chart
            {
                Dock = DockStyle.Fill
            };
            panel21.Controls.Add(chart);

            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            Series series = new Series("Current");
            series.ChartType = SeriesChartType.Line;
            chart.Series.Add(series);

            // Set the background color of the chart
            chart.BackColor = Color.FromArgb(7, 7, 7);

            // Set the background color of the chart area
            chartArea.BackColor = Color.FromArgb(7, 7, 7);

            // Set the colors of the axis lines, grid and labels
            chartArea.AxisX.LineColor = Color.FromArgb(7, 7, 7);
            chartArea.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea.AxisY.LineColor = Color.FromArgb(7, 7, 7);
            chartArea.AxisY.LabelStyle.ForeColor = Color.White;
            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(7, 7, 7);
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(7, 7, 7);
            chartArea.AxisX.TitleForeColor = Color.White;
            chartArea.AxisY.TitleForeColor = Color.White;
            chartArea.AxisX.Minimum = 0; // Starting hour
            chartArea.AxisX.Maximum = 23; // Ending hour
            chartArea.AxisX.Interval = 1;

            // Set the color of the series line
            series.Color = Color.FromArgb(57, 112, 255);

            // Set the color of the data points
            series.MarkerColor = Color.Red;
            series.MarkerBorderColor = Color.Black;

            // Adjust the overall position of the chart area (including margin)
            chartArea.Position.Auto = false;
            chartArea.Position.X = 00;
            chartArea.Position.Y = 00;
            chartArea.Position.Width = 100;
            chartArea.Position.Height = 100;

            // Configure axes
            chartArea.AxisX.Title = "Hour";
            chartArea.AxisY.Title = "Current spent";

            // Initialize the timer
            System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
            timer2.Interval = 1000; // 2 seconds
            timer2.Tick += (s, args) =>
            {
                //int current = random.Next(0, 100); // Random speed for demonstration
                int current = (int)currentSpent;

                if (chart.Series["Current"].Points.Count > DateTime.Now.Hour)
                {
                    chart.Series["Current"].Points[DateTime.Now.Hour].SetValueY(current);
                }
                else
                {
                    chart.Series["Current"].Points.AddXY(DateTime.Now.Hour, current);
                }

                // Update the chart to move to the next hour
                currentHour++;
                if (currentHour > 23) // Reset after 24 hours
                {
                    currentHour = 0;
                    chart.Series["Current"].Points.Clear();
                }
            };
            timer2.Start();
        }



        private void Timmer1_Tick(object sender, EventArgs e)
        {
            TH.Text = DateTime.Now.ToString("HH:mm");

        }




        // simulation //
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Core.KeyUp)
            {
                Core.IsUp = true;
            }
            if (e.KeyCode == Core.KeyDown)
            {
                Core.IsDown = true;
            }

            if (e.KeyCode == Core.KeyRight)
            {
                Core.IsRight = true;
            }
            if (e.KeyCode == Core.KeyLeft)
            {
                Core.IsLeft = true;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Core.KeyUp)
            {
                Core.IsUp = false;
            }
            if (e.KeyCode == Core.KeyDown)
            {
                Core.IsDown = false;
            }

            if (e.KeyCode == Core.KeyRight)
            {
                Core.IsRight = false;
            }
            if (e.KeyCode == Core.KeyLeft)
            {
                Core.IsLeft = false;
            }
        }





        private void Sim(object sender, EventArgs e)
        {

            if (speed == 0)
            {
                airFriction = 0.0005f;
                deceleration = 0.15f;
            }
            float force = weight * 9.82f * engineTorque * airFriction;
            acceleration = force / weight;
            driven += (int)(120 / 3600) * (int)speed; // sim on 2 mins

            drivenKm.Text = driven.ToString() + "Km";

            //baterry
            voltage = (engineTorque * 204) / 320;
            KWh = (int)(battery * 350) / 240;
            hoursToDrive = ((battery * 350) / 240) / 60;
            float batteryPercentage = (battery * 100) / 240;

            batteryPanel.Size = new System.Drawing.Size((int)battery, 47);
            batteryLabel.Text = Math.Truncate(batteryPercentage * 10) / 10 + "%";
            batteryCapacity.Text = KWh.ToString() + "Kwh";
            hoursRemaining.Text = Math.Truncate(hoursToDrive * 10) / 10 + "h";

            //mapbox GPS
            //

            string[] gears = ["P", "R", "N", "D", "S"];
            if (Core.IsUp)
            {
                if (battery > 0.1)
                {
                    speed += acceleration;
                    airFriction -= 0.000001f;
                    deceleration += 0.01f;
                    battery -= (voltage / 60) * 0.005f;
                    currentSpent += (voltage / 60) * 0.005f;
                }
            }
            else
            {
                speed -= deceleration;
                if (airFriction < 0.0005f)
                {
                    airFriction += 0.000001f;

                }
                if (deceleration > 0.15f)
                {
                    deceleration -= 0.005f;
                }


            }
            if (Core.IsDown)
            {
                speed -= 2;
            }
            speed = Math.Max(0.0f, speed);


            if (Core.IsRight)
            {
                if (gear < 4) gear++;
                Panel panelLast = Controls.Find(gears[gear - 1], true).FirstOrDefault() as Panel;
                panelLast.BackColor = Color.FromArgb(37, 43, 63);
            }
            if (Core.IsLeft)
            {
                if (gear >= 1)
                {
                    gear--;
                    Panel panelLast = Controls.Find(gears[gear + 1], true).FirstOrDefault() as Panel;
                    panelLast.BackColor = Color.FromArgb(37, 43, 63);
                }
            }
            int decimalSpeed = (int)speed;
            speedLabel.Text = decimalSpeed.ToString();

            Panel panelNow = Controls.Find(gears[gear], true).FirstOrDefault() as Panel;
            panelNow.BackColor = Color.FromArgb(57, 112, 255); ;

            switch (gear)
            {
                case 1:
                    engineTorque = 50;
                    break;
                case 3:
                    engineTorque = 119;
                    break;
                case 4:
                    engineTorque = 204;
                    if (airFriction > 0.0005f)
                    {
                        airFriction = 0.0005f;
                    }
                    break;
                default:
                    engineTorque = 0;
                    if (speed > 0)
                    {
                        speed -= 0.5f;
                    }
                    break;
            }

        }

        
    }
}
