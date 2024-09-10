namespace EcarGUI
{
    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            panel1 = new Panel();
            panel4 = new Panel();
            panel21 = new Panel();
            panel20 = new Panel();
            gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            panel19 = new Panel();
            button2 = new Button();
            button1 = new Button();
            terrainMap = new Button();
            hybridMap = new Button();
            satelliteMap = new Button();
            panel3 = new Panel();
            carInfoPanel = new Panel();
            panel15 = new Panel();
            label8 = new Label();
            label10 = new Label();
            label9 = new Label();
            panel16 = new Panel();
            label5 = new Label();
            drivenKm = new Label();
            panel13 = new Panel();
            label7 = new Label();
            batteryCapacity = new Label();
            panel14 = new Panel();
            label6 = new Label();
            label14 = new Label();
            label13 = new Label();
            panel12 = new Panel();
            pictureBox3 = new PictureBox();
            panel18 = new Panel();
            batteryPanel = new Panel();
            chargingPictureBoxx = new PictureBox();
            batteryLabel = new Label();
            label3 = new Label();
            hoursRemaining = new Label();
            label2 = new Label();
            panel5 = new Panel();
            batteryWarningPictureBox = new PictureBox();
            handBrakePictureBox = new PictureBox();
            lightsPictureBox = new PictureBox();
            panel6 = new Panel();
            D = new Panel();
            LabelD = new Label();
            S = new Panel();
            sportLabel = new Label();
            N = new Panel();
            neutralLabel = new Label();
            R = new Panel();
            parkingLabel = new Label();
            P = new Panel();
            rearLabel = new Label();
            carPictureBox1 = new PictureBox();
            speedLabel = new Label();
            measurementSystemLabel = new Label();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            weatherPictureBox = new PictureBox();
            networkType = new Label();
            temperature = new Label();
            TY = new Label();
            TH = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            timer3 = new System.Windows.Forms.Timer(components);
            blinksTimer = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel20.SuspendLayout();
            panel19.SuspendLayout();
            carInfoPanel.SuspendLayout();
            panel15.SuspendLayout();
            panel16.SuspendLayout();
            panel13.SuspendLayout();
            panel14.SuspendLayout();
            panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel18.SuspendLayout();
            batteryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chargingPictureBoxx).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)batteryWarningPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)handBrakePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lightsPictureBox).BeginInit();
            panel6.SuspendLayout();
            D.SuspendLayout();
            S.SuspendLayout();
            N.SuspendLayout();
            R.SuspendLayout();
            P.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)carPictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)weatherPictureBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(carInfoPanel);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1129, 729);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(7, 7, 7);
            panel4.Controls.Add(panel21);
            panel4.Controls.Add(panel20);
            panel4.Controls.Add(panel19);
            panel4.Location = new Point(501, 35);
            panel4.Name = "panel4";
            panel4.Size = new Size(627, 687);
            panel4.TabIndex = 1;
            // 
            // panel21
            // 
            panel21.Location = new Point(7, 0);
            panel21.Name = "panel21";
            panel21.Size = new Size(617, 184);
            panel21.TabIndex = 3;
            // 
            // panel20
            // 
            panel20.Controls.Add(gMapControl1);
            panel20.Location = new Point(3, 294);
            panel20.Name = "panel20";
            panel20.Size = new Size(621, 388);
            panel20.TabIndex = 2;
            // 
            // gMapControl1
            // 
            gMapControl1.Bearing = 0F;
            gMapControl1.CanDragMap = true;
            gMapControl1.EmptyTileColor = Color.Navy;
            gMapControl1.GrayScaleMode = false;
            gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            gMapControl1.ImeMode = ImeMode.NoControl;
            gMapControl1.LevelsKeepInMemory = 5;
            gMapControl1.Location = new Point(4, 3);
            gMapControl1.MarkersEnabled = true;
            gMapControl1.MaxZoom = 2;
            gMapControl1.MinZoom = 2;
            gMapControl1.MouseWheelZoomEnabled = true;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            gMapControl1.Name = "gMapControl1";
            gMapControl1.NegativeMode = false;
            gMapControl1.PolygonsEnabled = true;
            gMapControl1.RetryLoadTile = 0;
            gMapControl1.RoutesEnabled = true;
            gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            gMapControl1.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            gMapControl1.ShowTileGridLines = false;
            gMapControl1.Size = new Size(614, 382);
            gMapControl1.TabIndex = 0;
            gMapControl1.Zoom = 0D;
            gMapControl1.Load += gMapControl1_Load;
            // 
            // panel19
            // 
            panel19.Controls.Add(button2);
            panel19.Controls.Add(button1);
            panel19.Controls.Add(terrainMap);
            panel19.Controls.Add(hybridMap);
            panel19.Controls.Add(satelliteMap);
            panel19.Location = new Point(7, 190);
            panel19.Name = "panel19";
            panel19.Size = new Size(617, 98);
            panel19.TabIndex = 1;
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(517, 7);
            button2.Name = "button2";
            button2.Size = new Size(44, 41);
            button2.TabIndex = 3;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(37, 43, 75);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.FromArgb(224, 224, 224);
            button1.Location = new Point(219, 60);
            button1.Name = "button1";
            button1.Size = new Size(191, 29);
            button1.TabIndex = 2;
            button1.Text = "Generate Route";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // terrainMap
            // 
            terrainMap.BackgroundImage = (Image)resources.GetObject("terrainMap.BackgroundImage");
            terrainMap.BackgroundImageLayout = ImageLayout.Zoom;
            terrainMap.FlatStyle = FlatStyle.Flat;
            terrainMap.Location = new Point(567, 54);
            terrainMap.Name = "terrainMap";
            terrainMap.Size = new Size(44, 41);
            terrainMap.TabIndex = 1;
            terrainMap.UseVisualStyleBackColor = true;
            terrainMap.Click += terrainMap_Click;
            // 
            // hybridMap
            // 
            hybridMap.BackgroundImage = (Image)resources.GetObject("hybridMap.BackgroundImage");
            hybridMap.BackgroundImageLayout = ImageLayout.Zoom;
            hybridMap.FlatStyle = FlatStyle.Flat;
            hybridMap.Location = new Point(567, 7);
            hybridMap.Name = "hybridMap";
            hybridMap.Size = new Size(44, 41);
            hybridMap.TabIndex = 1;
            hybridMap.UseVisualStyleBackColor = true;
            hybridMap.Click += hybridMap_Click;
            // 
            // satelliteMap
            // 
            satelliteMap.BackgroundImage = (Image)resources.GetObject("satelliteMap.BackgroundImage");
            satelliteMap.BackgroundImageLayout = ImageLayout.Zoom;
            satelliteMap.FlatStyle = FlatStyle.Flat;
            satelliteMap.Location = new Point(517, 54);
            satelliteMap.Name = "satelliteMap";
            satelliteMap.Size = new Size(44, 41);
            satelliteMap.TabIndex = 1;
            satelliteMap.UseVisualStyleBackColor = true;
            satelliteMap.Click += satelliteMap_Click;
            // 
            // panel3
            // 
            panel3.Location = new Point(488, 33);
            panel3.Name = "panel3";
            panel3.Size = new Size(453, 696);
            panel3.TabIndex = 1;
            // 
            // carInfoPanel
            // 
            carInfoPanel.BackColor = Color.FromArgb(37, 43, 63);
            carInfoPanel.Controls.Add(panel15);
            carInfoPanel.Controls.Add(panel16);
            carInfoPanel.Controls.Add(panel13);
            carInfoPanel.Controls.Add(panel14);
            carInfoPanel.Controls.Add(panel12);
            carInfoPanel.Controls.Add(panel5);
            carInfoPanel.Location = new Point(0, 33);
            carInfoPanel.Name = "carInfoPanel";
            carInfoPanel.Size = new Size(495, 696);
            carInfoPanel.TabIndex = 1;
            // 
            // panel15
            // 
            panel15.BackColor = Color.FromArgb(37, 43, 75);
            panel15.Controls.Add(label8);
            panel15.Controls.Add(label10);
            panel15.Controls.Add(label9);
            panel15.Location = new Point(264, 603);
            panel15.Name = "panel15";
            panel15.Size = new Size(106, 56);
            panel15.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);
            label8.ForeColor = Color.LightGray;
            label8.Location = new Point(12, 7);
            label8.Name = "label8";
            label8.Size = new Size(93, 17);
            label8.TabIndex = 0;
            label8.Text = "Tyre pressure";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label10.ForeColor = Color.LightGray;
            label10.Location = new Point(48, 32);
            label10.Name = "label10";
            label10.Size = new Size(39, 21);
            label10.TabIndex = 0;
            label10.Text = "bar";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label9.ForeColor = Color.LightGray;
            label9.Location = new Point(12, 29);
            label9.Name = "label9";
            label9.Size = new Size(38, 23);
            label9.TabIndex = 0;
            label9.Text = "2.0";
            // 
            // panel16
            // 
            panel16.BackColor = Color.FromArgb(37, 43, 75);
            panel16.Controls.Add(label5);
            panel16.Controls.Add(drivenKm);
            panel16.Location = new Point(376, 603);
            panel16.Name = "panel16";
            panel16.Size = new Size(106, 56);
            panel16.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);
            label5.ForeColor = Color.LightGray;
            label5.Location = new Point(12, 7);
            label5.Name = "label5";
            label5.Size = new Size(50, 17);
            label5.TabIndex = 0;
            label5.Text = "Driven";
            // 
            // drivenKm
            // 
            drivenKm.AutoSize = true;
            drivenKm.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            drivenKm.ForeColor = Color.LightGray;
            drivenKm.Location = new Point(12, 29);
            drivenKm.Name = "drivenKm";
            drivenKm.Size = new Size(65, 23);
            drivenKm.TabIndex = 0;
            drivenKm.Text = "30000";
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(37, 43, 75);
            panel13.Controls.Add(label7);
            panel13.Controls.Add(batteryCapacity);
            panel13.Location = new Point(264, 533);
            panel13.Name = "panel13";
            panel13.Size = new Size(106, 56);
            panel13.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);
            label7.ForeColor = Color.LightGray;
            label7.Location = new Point(12, 6);
            label7.Name = "label7";
            label7.Size = new Size(70, 17);
            label7.TabIndex = 0;
            label7.Text = "Capacity";
            // 
            // batteryCapacity
            // 
            batteryCapacity.AutoSize = true;
            batteryCapacity.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            batteryCapacity.ForeColor = Color.LightGray;
            batteryCapacity.Location = new Point(12, 28);
            batteryCapacity.Name = "batteryCapacity";
            batteryCapacity.Size = new Size(43, 23);
            batteryCapacity.TabIndex = 0;
            batteryCapacity.Text = "150";
            // 
            // panel14
            // 
            panel14.BackColor = Color.FromArgb(37, 43, 75);
            panel14.Controls.Add(label6);
            panel14.Controls.Add(label14);
            panel14.Controls.Add(label13);
            panel14.Location = new Point(376, 533);
            panel14.Name = "panel14";
            panel14.Size = new Size(106, 56);
            panel14.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);
            label6.ForeColor = Color.LightGray;
            label6.Location = new Point(3, 3);
            label6.Name = "label6";
            label6.Size = new Size(96, 17);
            label6.TabIndex = 0;
            label6.Text = "Temp.battery";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label14.ForeColor = Color.LightGray;
            label14.Location = new Point(53, 30);
            label14.Name = "label14";
            label14.Size = new Size(24, 21);
            label14.TabIndex = 0;
            label14.Text = "C";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label13.ForeColor = Color.LightGray;
            label13.Location = new Point(12, 28);
            label13.Name = "label13";
            label13.Size = new Size(40, 23);
            label13.TabIndex = 0;
            label13.Text = "22°";
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(37, 43, 75);
            panel12.Controls.Add(pictureBox3);
            panel12.Controls.Add(panel18);
            panel12.Controls.Add(batteryLabel);
            panel12.Controls.Add(label3);
            panel12.Controls.Add(hoursRemaining);
            panel12.Controls.Add(label2);
            panel12.Location = new Point(12, 533);
            panel12.Name = "panel12";
            panel12.Size = new Size(243, 126);
            panel12.TabIndex = 1;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources._2780667_200;
            pictureBox3.Location = new Point(103, 59);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(37, 36);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // panel18
            // 
            panel18.BackColor = Color.FromArgb(37, 43, 90);
            panel18.Controls.Add(batteryPanel);
            panel18.Location = new Point(3, 3);
            panel18.Name = "panel18";
            panel18.Size = new Size(240, 53);
            panel18.TabIndex = 3;
            // 
            // batteryPanel
            // 
            batteryPanel.BackColor = Color.FromArgb(0, 192, 0);
            batteryPanel.Controls.Add(chargingPictureBoxx);
            batteryPanel.Location = new Point(3, 3);
            batteryPanel.Name = "batteryPanel";
            batteryPanel.Size = new Size(158, 47);
            batteryPanel.TabIndex = 3;
            // 
            // chargingPictureBoxx
            // 
            chargingPictureBoxx.BackgroundImage = Properties.Resources.charging;
            chargingPictureBoxx.BackgroundImageLayout = ImageLayout.None;
            chargingPictureBoxx.Image = Properties.Resources.charging;
            chargingPictureBoxx.InitialImage = Properties.Resources.charging;
            chargingPictureBoxx.Location = new Point(97, 0);
            chargingPictureBoxx.Name = "chargingPictureBoxx";
            chargingPictureBoxx.Size = new Size(50, 44);
            chargingPictureBoxx.SizeMode = PictureBoxSizeMode.Zoom;
            chargingPictureBoxx.TabIndex = 0;
            chargingPictureBoxx.TabStop = false;
            // 
            // batteryLabel
            // 
            batteryLabel.AutoSize = true;
            batteryLabel.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            batteryLabel.ForeColor = Color.LightGray;
            batteryLabel.Location = new Point(6, 59);
            batteryLabel.Name = "batteryLabel";
            batteryLabel.Size = new Size(77, 37);
            batteryLabel.TabIndex = 2;
            batteryLabel.Text = "67%";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.ForeColor = Color.LightGray;
            label3.Location = new Point(126, 81);
            label3.Name = "label3";
            label3.Size = new Size(27, 40);
            label3.TabIndex = 0;
            label3.Text = ".";
            // 
            // hoursRemaining
            // 
            hoursRemaining.AutoSize = true;
            hoursRemaining.ForeColor = Color.LightGray;
            hoursRemaining.Location = new Point(163, 99);
            hoursRemaining.Name = "hoursRemaining";
            hoursRemaining.Size = new Size(59, 19);
            hoursRemaining.TabIndex = 0;
            hoursRemaining.Text = "5.40 h";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(6, 98);
            label2.Name = "label2";
            label2.Size = new Size(151, 19);
            label2.TabIndex = 0;
            label2.Text = "Battery remaining";
            // 
            // panel5
            // 
            panel5.Controls.Add(batteryWarningPictureBox);
            panel5.Controls.Add(handBrakePictureBox);
            panel5.Controls.Add(lightsPictureBox);
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(carPictureBox1);
            panel5.Controls.Add(speedLabel);
            panel5.Controls.Add(measurementSystemLabel);
            panel5.Location = new Point(12, 5);
            panel5.Name = "panel5";
            panel5.Size = new Size(442, 493);
            panel5.TabIndex = 0;
            // 
            // batteryWarningPictureBox
            // 
            batteryWarningPictureBox.Image = Properties.Resources.batteryWarning;
            batteryWarningPictureBox.Location = new Point(66, 247);
            batteryWarningPictureBox.Name = "batteryWarningPictureBox";
            batteryWarningPictureBox.Size = new Size(54, 52);
            batteryWarningPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            batteryWarningPictureBox.TabIndex = 3;
            batteryWarningPictureBox.TabStop = false;
            // 
            // handBrakePictureBox
            // 
            handBrakePictureBox.Image = Properties.Resources.handbrake;
            handBrakePictureBox.Location = new Point(66, 187);
            handBrakePictureBox.Name = "handBrakePictureBox";
            handBrakePictureBox.Size = new Size(54, 52);
            handBrakePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            handBrakePictureBox.TabIndex = 3;
            handBrakePictureBox.TabStop = false;
            // 
            // lightsPictureBox
            // 
            lightsPictureBox.Image = (Image)resources.GetObject("lightsPictureBox.Image");
            lightsPictureBox.Location = new Point(319, 187);
            lightsPictureBox.Name = "lightsPictureBox";
            lightsPictureBox.Size = new Size(54, 52);
            lightsPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            lightsPictureBox.TabIndex = 3;
            lightsPictureBox.TabStop = false;
            // 
            // panel6
            // 
            panel6.Controls.Add(D);
            panel6.Controls.Add(S);
            panel6.Controls.Add(N);
            panel6.Controls.Add(R);
            panel6.Controls.Add(P);
            panel6.Location = new Point(52, 441);
            panel6.Name = "panel6";
            panel6.Size = new Size(330, 39);
            panel6.TabIndex = 1;
            // 
            // D
            // 
            D.BackColor = Color.FromArgb(37, 43, 63);
            D.Controls.Add(LabelD);
            D.Location = new Point(202, 0);
            D.Name = "D";
            D.Size = new Size(66, 39);
            D.TabIndex = 0;
            // 
            // LabelD
            // 
            LabelD.AutoSize = true;
            LabelD.ForeColor = Color.LightGray;
            LabelD.Location = new Point(26, 12);
            LabelD.Name = "LabelD";
            LabelD.Size = new Size(21, 19);
            LabelD.TabIndex = 2;
            LabelD.Text = "D";
            // 
            // S
            // 
            S.Controls.Add(sportLabel);
            S.Location = new Point(267, 0);
            S.Name = "S";
            S.Size = new Size(66, 39);
            S.TabIndex = 0;
            // 
            // sportLabel
            // 
            sportLabel.AutoSize = true;
            sportLabel.ForeColor = Color.LightGray;
            sportLabel.Location = new Point(25, 12);
            sportLabel.Name = "sportLabel";
            sportLabel.Size = new Size(18, 19);
            sportLabel.TabIndex = 2;
            sportLabel.Text = "S";
            // 
            // N
            // 
            N.BackColor = Color.FromArgb(57, 112, 255);
            N.Controls.Add(neutralLabel);
            N.Location = new Point(134, 0);
            N.Name = "N";
            N.Size = new Size(66, 39);
            N.TabIndex = 0;
            // 
            // neutralLabel
            // 
            neutralLabel.AutoSize = true;
            neutralLabel.ForeColor = Color.LightGray;
            neutralLabel.Location = new Point(26, 12);
            neutralLabel.Name = "neutralLabel";
            neutralLabel.Size = new Size(22, 19);
            neutralLabel.TabIndex = 2;
            neutralLabel.Text = "N";
            // 
            // R
            // 
            R.Controls.Add(parkingLabel);
            R.Location = new Point(68, 0);
            R.Name = "R";
            R.Size = new Size(66, 39);
            R.TabIndex = 0;
            // 
            // parkingLabel
            // 
            parkingLabel.AutoSize = true;
            parkingLabel.ForeColor = Color.LightGray;
            parkingLabel.Location = new Point(25, 12);
            parkingLabel.Name = "parkingLabel";
            parkingLabel.Size = new Size(19, 19);
            parkingLabel.TabIndex = 2;
            parkingLabel.Text = "R";
            // 
            // P
            // 
            P.Controls.Add(rearLabel);
            P.Location = new Point(2, 0);
            P.Name = "P";
            P.Size = new Size(66, 39);
            P.TabIndex = 0;
            // 
            // rearLabel
            // 
            rearLabel.AutoSize = true;
            rearLabel.ForeColor = Color.LightGray;
            rearLabel.Location = new Point(24, 12);
            rearLabel.Name = "rearLabel";
            rearLabel.Size = new Size(19, 19);
            rearLabel.TabIndex = 2;
            rearLabel.Text = "P";
            // 
            // carPictureBox1
            // 
            carPictureBox1.Image = Properties.Resources.autocad_drawing_tesla_model_3_tesla_inc_cars_top_vehicles_dwg_dxf_435_transformed;
            carPictureBox1.Location = new Point(31, 89);
            carPictureBox1.Name = "carPictureBox1";
            carPictureBox1.Size = new Size(378, 346);
            carPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            carPictureBox1.TabIndex = 0;
            carPictureBox1.TabStop = false;
            // 
            // speedLabel
            // 
            speedLabel.AutoSize = true;
            speedLabel.Font = new Font("Century Gothic", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            speedLabel.ForeColor = Color.LightGray;
            speedLabel.Location = new Point(188, 6);
            speedLabel.Name = "speedLabel";
            speedLabel.Size = new Size(72, 51);
            speedLabel.TabIndex = 2;
            speedLabel.Text = "85";
            // 
            // measurementSystemLabel
            // 
            measurementSystemLabel.AutoSize = true;
            measurementSystemLabel.ForeColor = Color.LightGray;
            measurementSystemLabel.Location = new Point(196, 58);
            measurementSystemLabel.Name = "measurementSystemLabel";
            measurementSystemLabel.Size = new Size(54, 19);
            measurementSystemLabel.TabIndex = 2;
            measurementSystemLabel.Text = "Km/h";
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(weatherPictureBox);
            panel2.Controls.Add(networkType);
            panel2.Controls.Add(temperature);
            panel2.Controls.Add(TY);
            panel2.Controls.Add(TH);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1129, 32);
            panel2.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(7, 7, 7);
            pictureBox2.ErrorImage = null;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(12, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(29, 26);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // weatherPictureBox
            // 
            weatherPictureBox.BackColor = Color.FromArgb(7, 7, 7);
            weatherPictureBox.ErrorImage = null;
            weatherPictureBox.Image = Properties.Resources._01d;
            weatherPictureBox.InitialImage = (Image)resources.GetObject("weatherPictureBox.InitialImage");
            weatherPictureBox.Location = new Point(940, 3);
            weatherPictureBox.Name = "weatherPictureBox";
            weatherPictureBox.Size = new Size(29, 26);
            weatherPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            weatherPictureBox.TabIndex = 3;
            weatherPictureBox.TabStop = false;
            // 
            // networkType
            // 
            networkType.AutoSize = true;
            networkType.ForeColor = Color.LightGray;
            networkType.Location = new Point(43, 7);
            networkType.Name = "networkType";
            networkType.Size = new Size(33, 19);
            networkType.TabIndex = 2;
            networkType.Text = "5G";
            // 
            // temperature
            // 
            temperature.AutoSize = true;
            temperature.ForeColor = Color.LightGray;
            temperature.Location = new Point(616, 7);
            temperature.Name = "temperature";
            temperature.Size = new Size(36, 19);
            temperature.TabIndex = 2;
            temperature.Text = "20°";
            // 
            // TY
            // 
            TY.AutoSize = true;
            TY.ForeColor = Color.LightGray;
            TY.Location = new Point(1035, 7);
            TY.Name = "TY";
            TY.Size = new Size(99, 19);
            TY.TabIndex = 1;
            TY.Text = "01:01:2024";
            // 
            // TH
            // 
            TH.AutoSize = true;
            TH.ForeColor = Color.LightGray;
            TH.Location = new Point(975, 7);
            TH.Name = "TH";
            TH.Size = new Size(54, 19);
            TH.TabIndex = 0;
            TH.Text = "12:50";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 60000;
            timer1.Tick += Timmer1_Tick;
            // 
            // timer3
            // 
            timer3.Enabled = true;
            timer3.Interval = 80;
            timer3.Tick += Sim;
            // 
            // blinksTimer
            // 
            blinksTimer.Enabled = true;
            blinksTimer.Interval = 500;
            blinksTimer.Tick += blinksTimer_Tick;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(7, 7, 7);
            ClientSize = new Size(1129, 729);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            ForeColor = Color.FromArgb(7, 7, 7);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel20.ResumeLayout(false);
            panel19.ResumeLayout(false);
            carInfoPanel.ResumeLayout(false);
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel18.ResumeLayout(false);
            batteryPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chargingPictureBoxx).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)batteryWarningPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)handBrakePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)lightsPictureBox).EndInit();
            panel6.ResumeLayout(false);
            D.ResumeLayout(false);
            D.PerformLayout();
            S.ResumeLayout(false);
            S.PerformLayout();
            N.ResumeLayout(false);
            N.PerformLayout();
            R.ResumeLayout(false);
            R.PerformLayout();
            P.ResumeLayout(false);
            P.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)carPictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)weatherPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label TY;
        private Label TH;
        private Label temperature;
        private PictureBox weatherPictureBox;
        private PictureBox pictureBox2;
        private Label networkType;
        private Panel carInfoPanel;
        private Panel panel4;
        private Panel panel3;
        private Panel panel5;
        private Panel panel6;
        private PictureBox carPictureBox1;
        private Label speedLabel;
        private Label measurementSystemLabel;
        private Panel R;
        private Label parkingLabel;
        private Panel P;
        private Label rearLabel;
        private Panel S;
        private Label sportLabel;
        private Panel N;
        private Label neutralLabel;
        private Panel D;
        private Label LabelD;
        private PictureBox lightsPictureBox;
        private Panel panel16;
        private Panel panel14;
        private Panel panel12;
        private Panel panel18;
        private Panel batteryPanel;
        private Label batteryLabel;
        private Label label3;
        private Label label2;
        private Label hoursRemaining;
        private Panel panel15;
        private Label label8;
        private Label label5;
        private Panel panel13;
        private Label label7;
        private Label label6;
        private Label label9;
        private Label label10;
        private Label drivenKm;
        private Label batteryCapacity;
        private Label label14;
        private Label label13;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox3;
        private Panel panel19;
        private Panel panel20;
        private Panel panel21;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private Button terrainMap;
        private Button hybridMap;
        private Button satelliteMap;
        private Button button1;
        private Button button2;
        private PictureBox chargingPictureBoxx;
        private PictureBox batteryWarningPictureBox;
        private PictureBox handBrakePictureBox;
        private System.Windows.Forms.Timer blinksTimer;
    }
}
