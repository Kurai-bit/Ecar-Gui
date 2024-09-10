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
using EcarGUI.Properties;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Diagnostics;


namespace EcarGUI
{
    public partial class Dashboard : Form
    {
        private int currentHour = 0;
        int weight = 2800;
        double engineTorque = 0;
        float voltage = 0;
        float airFriction = 0.0005f;
        float deceleration = 0.15f;

        float acceleration = 0;
        float brake = 0;

        // Other variables
        double V1 = 0.001; // Initial spee
        double V2 = 0.0;
        int gear = 2;

        float battery = 180; //240max
        double currentSpent = 0;
        int KWh = 0;
        float hoursToDrive = 0;
        int driven = 3985;


        bool charging = false;
        bool handBrake = false;
        bool blinkRight = false;
        bool blinkLeft = false;
        bool isBlinking = false;


        int RPM = 0; //3000
        int Pmotor = 50000; // 50000
        double a1 = 0;
        double VKmh = 0;

        double A = 1.50 * 1.80;
        double m = 500;
        double rho = 1.181;
        double g = 9.81;

        double eta = 0.9;
        double eta2 = 0.65;
        double Cd = 0.25;
        double Cr = 0.01;
        double Fa = 1500; // 3 -> deceleration x 500kg
        


        double Twheels = 0.3;
        double deltaTime = 0.08;

        double distance = 0;




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

        private void button2_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GoogleMapProvider.Instance;
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
                        string visibility = weatherData["visibility"].ToString();

                        double windDirectionDegrees = Convert.ToDouble(weatherData["wind"]["deg"]);
                        string windDirection = WindDirectionToCompass(windDirectionDegrees);
                        string skyInfo = "";
                        if (weatherData["weather"] != null && weatherData["weather"].HasValues)
                        {
                            skyInfo = weatherData["weather"][0]["icon"].ToString();
                        }

                        string formattedWeatherData = $"T: {temperatureCelsius:F1}°C, H: {humidity}%, W: {windDirection} {windSpeed} m/s, V: {visibility}";

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
            //chartArea.AxisX.Minimum = 0; // Starting hour
            //chartArea.AxisX.Maximum = 20; // Ending hour
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
            //chartArea.AxisX.Title = "Hour";
            chartArea.AxisY.Title = "Current spent";

            double current = 0;


            // Initialize the timer
            int minute = 0; // temporar 
            System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
            timer2.Interval = 1000; // 1 seconds
            timer2.Tick += (s, args) =>
            {
                UpdateChart();
                minute++;
            };
            
            // Define a method to update the chart
            void UpdateChart()
            {
                current = currentSpent;


                if (chart.Series["Current"].Points.Count > minute)
                {
                    chart.Series["Current"].Points[minute].SetValueY(current);
                }
                else
                {
                    chart.Series["Current"].Points.AddXY(minute, current);
                }
            }

            // Initial chart update call to display the graph immediately
            UpdateChart();

            // Start the timer after the initial update
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

            if (e.KeyCode == Core.KeyCharging)
            {
                charging = !charging;
                Core.IsCharging = charging;
            }

            if (e.KeyCode == Core.KeyLights)
            {
                Core.IsLights++;
                if (Core.IsLights == 3)
                {
                    Core.IsLights = 0;
                }
            }

            if (e.KeyCode == Core.KeyHandBrake)
            {
                handBrake = !handBrake;
                Core.IsHandBrake = handBrake;
            }

            if (e.KeyCode == Core.KeyRightBlink)
            {
                blinkRight = !blinkRight;
                Core.IsRightBlink = blinkRight;
            }

            if (e.KeyCode == Core.KeyLeftBlink)
            {
                blinkLeft = !blinkLeft;
                Core.IsLeftBlink = blinkLeft;
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

            
            // TODO formule normale !!!!
            chargingPictureBoxx.Visible = Core.IsCharging;
            handBrakePictureBox.Visible = Core.IsHandBrake;

            if (V2 == 0)
            {
                airFriction = 0.0005f;
                deceleration = 0.15f;
            }

            
            

            engineTorque = Pmotor / ((2*Math.PI* RPM)/60);


            double Ek = 0.5 * m * V1 * V1;
            double Ex = eta2 * Ek;

            double Pdr = 0.5 * Cd * rho * A * Math.Pow(V1, 3); // aerodynamic drag
            double Pwh = Cr * m * g * V1;// the rolling resistance
            double Pm = (Pdr + Pwh) / eta; // total power requirement

            double E1 = Pm * 0.08; // 1 --> t

            double E2 = eta2 * Ex; // energy recovery during braking
            double percentageEnergyRecovered = (E2 / E1) * 100; // percentage of energy recovered
            double Pregen = eta2 * (Fa * V1) / 0.08; // power dynamics during regeneration instead of 1 --> t

            double Pacc = Pmotor - Pm; //puterea de acceleratia
            double Facc = Pacc / V1; //forta de acceleratie

            //acceleration = 9.82f * engineTorque * airFriction;
            double Fwheels = engineTorque / Twheels; // forta aplicata rotilor
            double a = Facc/ m; // acceleratia
            a = Math.Min(a,5); 



            drivenKm.Text = driven.ToString() + "Km";

            //baterry
            voltage = (int)(engineTorque * 204) / 320;
            KWh = (int)(battery * 350) / 240;
            hoursToDrive = ((battery * 350) / 240) / 60;
            float batteryPercentage = (battery * 100) / 240;

            batteryPanel.Size = new System.Drawing.Size((int)battery, 47);
            batteryLabel.Text = Math.Truncate(batteryPercentage * 10) / 10 + "%";
            batteryCapacity.Text = KWh.ToString() + "Kwh";
            hoursRemaining.Text = Math.Truncate(hoursToDrive * 10) / 10 + "h";

            if (battery <= 240 * 0.1)
            {
                batteryWarningPictureBox.Visible = true;
            }
            else
            {
                batteryWarningPictureBox.Visible = false;
            }

            Debug.WriteLine("V1 : " + V1);

            string[] gears = ["P", "R", "N", "D", "S"];
            if (Core.IsUp)
            {
                if (battery > 0.1 && !handBrake)
                {
                    V2 = V1+a*deltaTime; // acceleration 
                    V1 = V2;
                    VKmh = V2*3.6;

                    distance += V2/deltaTime;

                    currentSpent = Pm * deltaTime;
                }
            }
            else
            {

                V2 = Math.Max(V1 - a * deltaTime, 0); // natural deceleration when not accelerating
                V1 = V2;
                VKmh = V2 * 3.6;

                
                currentSpent = 0;

            }
            if (Core.IsDown)
            {
                if (battery < 240 && V2 > 0 && !handBrake)
                {
                    V2 = Math.Max(V1 - 10 * deltaTime, 0); // deceleration when braking (a = 10)
                    V1 = V2;
                    VKmh = V2 * 3.6;

                    pictureBox3.Visible = true;
                }
            }
            else
            {
                pictureBox3.Visible = false;
            }

            if (handBrake && V2 > 0)
            {
                V2 -= 10;
            }
            V2 = Math.Max(0.0f, V2);


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

            int decimalSpeed = (int)VKmh;
            speedLabel.Text = decimalSpeed.ToString();

            Panel panelNow = Controls.Find(gears[gear], true).FirstOrDefault() as Panel;
            panelNow.BackColor = Color.FromArgb(57, 112, 255); ;

            switch (gear)
            {
                case 1:
                    //engineTorque = 50;
                    break;
                case 3:
                    //engineTorque = 119;
                    RPM = 3000;
                    break;
                case 4:
                    //engineTorque = 204;
                    //if (airFriction > 0.0005f)
                    //{
                    //    airFriction = 0.0005f;
                    //}
                    RPM = 1500;
                    break;
                default:

                    //engineTorque = 0;
                    //if (V > 0)
                    //{
                    //    V -= 0.5f;
                    //}
                    break;
            }

            switch (Core.IsLights)
            {
                case 1:
                    lightsPictureBox.Visible = true;
                    lightsPictureBox.Image = Resources.LOW_BEAM_1;
                    break;
                case 2:
                    lightsPictureBox.Image = Resources.HIGH_BEAM;
                    break;
                default:
                    lightsPictureBox.Visible = false;
                    break;
            }

            if (blinkRight)
            {
                blinkLeft = false;
                blinksTimer.Enabled = true;
                if (isBlinking)
                {
                    carPictureBox1.Image = Resources.rightBlink;
                }
                else
                {
                    carPictureBox1.Image = Resources.autocad_drawing_tesla_model_3_tesla_inc_cars_top_vehicles_dwg_dxf_435_transformed;
                }
            }
            else if (blinkLeft)
            {
                blinkRight = false;
                blinksTimer.Enabled = true;
                if (!isBlinking)
                {
                    carPictureBox1.Image = Resources.leftBlink;
                }
                else
                {
                    carPictureBox1.Image = Resources.autocad_drawing_tesla_model_3_tesla_inc_cars_top_vehicles_dwg_dxf_435_transformed;
                }
            }
            else
            {
                blinksTimer.Enabled = false;
                carPictureBox1.Image = Resources.autocad_drawing_tesla_model_3_tesla_inc_cars_top_vehicles_dwg_dxf_435_transformed;
            }

        }

        private void blinksTimer_Tick(object sender, EventArgs e)
        {
            isBlinking = !isBlinking;
        }
    }
}
