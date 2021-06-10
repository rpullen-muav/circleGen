namespace circleGen
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.lblCirleLat = new System.Windows.Forms.Label();
            this.lblCirleLon = new System.Windows.Forms.Label();
            this.txtLon = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.btnPolyGen = new System.Windows.Forms.Button();
            this.btnCircleGen = new System.Windows.Forms.Button();
            this.txtOutputName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbNFZ = new System.Windows.Forms.CheckBox();
            this.cbActivated = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblBoxHeight = new System.Windows.Forms.Label();
            this.btnBoxGen = new System.Windows.Forms.Button();
            this.txtBoxHeight = new System.Windows.Forms.TextBox();
            this.lblLatUnit = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblLonUnit = new System.Windows.Forms.Label();
            this.lblBoxWidth = new System.Windows.Forms.Label();
            this.lblRadiusUnit = new System.Windows.Forms.Label();
            this.txtBoxWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBoxPointCenter = new System.Windows.Forms.CheckBox();
            this.cbBoxPointBottomLeft = new System.Windows.Forms.CheckBox();
            this.cbBoxPointBottomRight = new System.Windows.Forms.CheckBox();
            this.cbBoxPointTopRight = new System.Windows.Forms.CheckBox();
            this.cbBoxPointTopLeft = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtKmlFileName = new System.Windows.Forms.TextBox();
            this.btnLoadKML = new System.Windows.Forms.Button();
            this.gbOutputLabel = new System.Windows.Forms.GroupBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cbbDistanceUnits = new System.Windows.Forms.ComboBox();
            this.cbbGeoUnits = new System.Windows.Forms.ComboBox();
            this.lblMinAltUnit = new System.Windows.Forms.Label();
            this.lblMaxAltUnit = new System.Windows.Forms.Label();
            this.lblCruiseAltUnit = new System.Windows.Forms.Label();
            this.txtCruiseAlt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMinAlt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaxAlt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pb1 = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnArea2List = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbOutputLabel.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Coordinate";
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(118, 92);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(198, 29);
            this.txtLat.TabIndex = 1;
            // 
            // lblCirleLat
            // 
            this.lblCirleLat.AutoSize = true;
            this.lblCirleLat.Location = new System.Drawing.Point(49, 95);
            this.lblCirleLat.Name = "lblCirleLat";
            this.lblCirleLat.Size = new System.Drawing.Size(50, 25);
            this.lblCirleLat.TabIndex = 2;
            this.lblCirleLat.Text = "LAT";
            // 
            // lblCirleLon
            // 
            this.lblCirleLon.AutoSize = true;
            this.lblCirleLon.Location = new System.Drawing.Point(49, 150);
            this.lblCirleLon.Name = "lblCirleLon";
            this.lblCirleLon.Size = new System.Drawing.Size(53, 25);
            this.lblCirleLon.TabIndex = 4;
            this.lblCirleLon.Text = "LON";
            // 
            // txtLon
            // 
            this.txtLon.Location = new System.Drawing.Point(118, 147);
            this.txtLon.Name = "txtLon";
            this.txtLon.Size = new System.Drawing.Size(198, 29);
            this.txtLon.TabIndex = 3;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(25, 57);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(684, 716);
            this.txtOutput.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "RADIUS";
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(118, 204);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.Size = new System.Drawing.Size(198, 29);
            this.txtRadius.TabIndex = 6;
            // 
            // btnPolyGen
            // 
            this.btnPolyGen.Location = new System.Drawing.Point(27, 800);
            this.btnPolyGen.Name = "btnPolyGen";
            this.btnPolyGen.Size = new System.Drawing.Size(214, 52);
            this.btnPolyGen.TabIndex = 8;
            this.btnPolyGen.Text = "Make Poly";
            this.btnPolyGen.UseVisualStyleBackColor = true;
            this.btnPolyGen.Click += new System.EventHandler(this.btnPolyGen_Click);
            // 
            // btnCircleGen
            // 
            this.btnCircleGen.Location = new System.Drawing.Point(236, 551);
            this.btnCircleGen.Name = "btnCircleGen";
            this.btnCircleGen.Size = new System.Drawing.Size(169, 41);
            this.btnCircleGen.TabIndex = 9;
            this.btnCircleGen.Text = "Circle";
            this.btnCircleGen.UseVisualStyleBackColor = true;
            this.btnCircleGen.Click += new System.EventHandler(this.btnCircleGen_Click);
            // 
            // txtOutputName
            // 
            this.txtOutputName.Location = new System.Drawing.Point(115, 137);
            this.txtOutputName.Name = "txtOutputName";
            this.txtOutputName.Size = new System.Drawing.Size(201, 29);
            this.txtOutputName.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Name";
            // 
            // cbNFZ
            // 
            this.cbNFZ.AutoSize = true;
            this.cbNFZ.Location = new System.Drawing.Point(97, 328);
            this.cbNFZ.Name = "cbNFZ";
            this.cbNFZ.Size = new System.Drawing.Size(76, 29);
            this.cbNFZ.TabIndex = 12;
            this.cbNFZ.Text = "NFZ";
            this.cbNFZ.UseVisualStyleBackColor = true;
            // 
            // cbActivated
            // 
            this.cbActivated.AutoSize = true;
            this.cbActivated.Location = new System.Drawing.Point(189, 328);
            this.cbActivated.Name = "cbActivated";
            this.cbActivated.Size = new System.Drawing.Size(127, 29);
            this.cbActivated.TabIndex = 13;
            this.cbActivated.Text = "Not Active";
            this.cbActivated.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblBoxHeight);
            this.groupBox1.Controls.Add(this.btnBoxGen);
            this.groupBox1.Controls.Add(this.txtBoxHeight);
            this.groupBox1.Controls.Add(this.lblLatUnit);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblLonUnit);
            this.groupBox1.Controls.Add(this.lblBoxWidth);
            this.groupBox1.Controls.Add(this.lblRadiusUnit);
            this.groupBox1.Controls.Add(this.txtBoxWidth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCircleGen);
            this.groupBox1.Controls.Add(this.cbBoxPointCenter);
            this.groupBox1.Controls.Add(this.cbBoxPointBottomLeft);
            this.groupBox1.Controls.Add(this.txtLon);
            this.groupBox1.Controls.Add(this.cbBoxPointBottomRight);
            this.groupBox1.Controls.Add(this.txtLat);
            this.groupBox1.Controls.Add(this.cbBoxPointTopRight);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbBoxPointTopLeft);
            this.groupBox1.Controls.Add(this.lblCirleLat);
            this.groupBox1.Controls.Add(this.txtRadius);
            this.groupBox1.Controls.Add(this.lblCirleLon);
            this.groupBox1.Location = new System.Drawing.Point(13, 416);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 612);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Circular/Box Annotation";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(110, 374);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(169, 25);
            this.label11.TabIndex = 19;
            this.label11.Text = "Choose Box Point";
            // 
            // lblBoxHeight
            // 
            this.lblBoxHeight.AutoSize = true;
            this.lblBoxHeight.Location = new System.Drawing.Point(322, 316);
            this.lblBoxHeight.Name = "lblBoxHeight";
            this.lblBoxHeight.Size = new System.Drawing.Size(35, 25);
            this.lblBoxHeight.TabIndex = 18;
            this.lblBoxHeight.Text = "[#]";
            // 
            // btnBoxGen
            // 
            this.btnBoxGen.Location = new System.Drawing.Point(39, 551);
            this.btnBoxGen.Name = "btnBoxGen";
            this.btnBoxGen.Size = new System.Drawing.Size(169, 41);
            this.btnBoxGen.TabIndex = 13;
            this.btnBoxGen.Text = "Box";
            this.btnBoxGen.UseVisualStyleBackColor = true;
            this.btnBoxGen.Click += new System.EventHandler(this.btnBoxGen_Click);
            // 
            // txtBoxHeight
            // 
            this.txtBoxHeight.Location = new System.Drawing.Point(129, 313);
            this.txtBoxHeight.Name = "txtBoxHeight";
            this.txtBoxHeight.Size = new System.Drawing.Size(187, 29);
            this.txtBoxHeight.TabIndex = 16;
            // 
            // lblLatUnit
            // 
            this.lblLatUnit.AutoSize = true;
            this.lblLatUnit.Location = new System.Drawing.Point(322, 96);
            this.lblLatUnit.Name = "lblLatUnit";
            this.lblLatUnit.Size = new System.Drawing.Size(35, 25);
            this.lblLatUnit.TabIndex = 12;
            this.lblLatUnit.Text = "[#]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 316);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 25);
            this.label10.TabIndex = 17;
            this.label10.Text = "HEIGHT";
            // 
            // lblLonUnit
            // 
            this.lblLonUnit.AutoSize = true;
            this.lblLonUnit.Location = new System.Drawing.Point(322, 147);
            this.lblLonUnit.Name = "lblLonUnit";
            this.lblLonUnit.Size = new System.Drawing.Size(35, 25);
            this.lblLonUnit.TabIndex = 11;
            this.lblLonUnit.Text = "[#]";
            // 
            // lblBoxWidth
            // 
            this.lblBoxWidth.AutoSize = true;
            this.lblBoxWidth.Location = new System.Drawing.Point(322, 262);
            this.lblBoxWidth.Name = "lblBoxWidth";
            this.lblBoxWidth.Size = new System.Drawing.Size(35, 25);
            this.lblBoxWidth.TabIndex = 15;
            this.lblBoxWidth.Text = "[#]";
            // 
            // lblRadiusUnit
            // 
            this.lblRadiusUnit.AutoSize = true;
            this.lblRadiusUnit.Location = new System.Drawing.Point(322, 207);
            this.lblRadiusUnit.Name = "lblRadiusUnit";
            this.lblRadiusUnit.Size = new System.Drawing.Size(35, 25);
            this.lblRadiusUnit.TabIndex = 10;
            this.lblRadiusUnit.Text = "[#]";
            // 
            // txtBoxWidth
            // 
            this.txtBoxWidth.Location = new System.Drawing.Point(129, 258);
            this.txtBoxWidth.Name = "txtBoxWidth";
            this.txtBoxWidth.Size = new System.Drawing.Size(187, 29);
            this.txtBoxWidth.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "WIDTH";
            // 
            // cbBoxPointCenter
            // 
            this.cbBoxPointCenter.AutoSize = true;
            this.cbBoxPointCenter.Location = new System.Drawing.Point(175, 462);
            this.cbBoxPointCenter.Name = "cbBoxPointCenter";
            this.cbBoxPointCenter.Size = new System.Drawing.Size(97, 29);
            this.cbBoxPointCenter.TabIndex = 4;
            this.cbBoxPointCenter.Tag = "c";
            this.cbBoxPointCenter.Text = "Center";
            this.cbBoxPointCenter.UseVisualStyleBackColor = true;
            // 
            // cbBoxPointBottomLeft
            // 
            this.cbBoxPointBottomLeft.AutoSize = true;
            this.cbBoxPointBottomLeft.Location = new System.Drawing.Point(79, 497);
            this.cbBoxPointBottomLeft.Name = "cbBoxPointBottomLeft";
            this.cbBoxPointBottomLeft.Size = new System.Drawing.Size(62, 29);
            this.cbBoxPointBottomLeft.TabIndex = 3;
            this.cbBoxPointBottomLeft.Tag = "bl";
            this.cbBoxPointBottomLeft.Text = "BL";
            this.cbBoxPointBottomLeft.UseVisualStyleBackColor = true;
            // 
            // cbBoxPointBottomRight
            // 
            this.cbBoxPointBottomRight.AutoSize = true;
            this.cbBoxPointBottomRight.Location = new System.Drawing.Point(257, 497);
            this.cbBoxPointBottomRight.Name = "cbBoxPointBottomRight";
            this.cbBoxPointBottomRight.Size = new System.Drawing.Size(64, 29);
            this.cbBoxPointBottomRight.TabIndex = 2;
            this.cbBoxPointBottomRight.Tag = "br";
            this.cbBoxPointBottomRight.Text = "BR";
            this.cbBoxPointBottomRight.UseVisualStyleBackColor = true;
            // 
            // cbBoxPointTopRight
            // 
            this.cbBoxPointTopRight.AutoSize = true;
            this.cbBoxPointTopRight.Location = new System.Drawing.Point(257, 420);
            this.cbBoxPointTopRight.Name = "cbBoxPointTopRight";
            this.cbBoxPointTopRight.Size = new System.Drawing.Size(64, 29);
            this.cbBoxPointTopRight.TabIndex = 1;
            this.cbBoxPointTopRight.Tag = "tr";
            this.cbBoxPointTopRight.Text = "TR";
            this.cbBoxPointTopRight.UseVisualStyleBackColor = true;
            // 
            // cbBoxPointTopLeft
            // 
            this.cbBoxPointTopLeft.AutoSize = true;
            this.cbBoxPointTopLeft.Location = new System.Drawing.Point(79, 421);
            this.cbBoxPointTopLeft.Name = "cbBoxPointTopLeft";
            this.cbBoxPointTopLeft.Size = new System.Drawing.Size(62, 29);
            this.cbBoxPointTopLeft.TabIndex = 0;
            this.cbBoxPointTopLeft.Tag = "tl";
            this.cbBoxPointTopLeft.Text = "TL";
            this.cbBoxPointTopLeft.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Controls.Add(this.txtKmlFileName);
            this.groupBox2.Controls.Add(this.btnLoadKML);
            this.groupBox2.Location = new System.Drawing.Point(719, 888);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 140);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "KML to Area";
            // 
            // txtKmlFileName
            // 
            this.txtKmlFileName.Location = new System.Drawing.Point(40, 105);
            this.txtKmlFileName.Name = "txtKmlFileName";
            this.txtKmlFileName.Size = new System.Drawing.Size(41, 29);
            this.txtKmlFileName.TabIndex = 1;
            this.txtKmlFileName.Visible = false;
            // 
            // btnLoadKML
            // 
            this.btnLoadKML.Location = new System.Drawing.Point(21, 51);
            this.btnLoadKML.Name = "btnLoadKML";
            this.btnLoadKML.Size = new System.Drawing.Size(198, 41);
            this.btnLoadKML.TabIndex = 0;
            this.btnLoadKML.Text = "Convert KML";
            this.btnLoadKML.UseVisualStyleBackColor = true;
            this.btnLoadKML.Click += new System.EventHandler(this.btnLoadKML_Click);
            // 
            // gbOutputLabel
            // 
            this.gbOutputLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.gbOutputLabel.Controls.Add(this.btnHelp);
            this.gbOutputLabel.Controls.Add(this.lblOutput);
            this.gbOutputLabel.Controls.Add(this.button1);
            this.gbOutputLabel.Controls.Add(this.btnPolyGen);
            this.gbOutputLabel.Controls.Add(this.txtOutput);
            this.gbOutputLabel.Location = new System.Drawing.Point(467, 12);
            this.gbOutputLabel.Name = "gbOutputLabel";
            this.gbOutputLabel.Size = new System.Drawing.Size(731, 870);
            this.gbOutputLabel.TabIndex = 16;
            this.gbOutputLabel.TabStop = false;
            this.gbOutputLabel.Text = "Polygon/Batch From List";
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(495, 802);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(214, 52);
            this.btnHelp.TabIndex = 11;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(192, 29);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(154, 25);
            this.lblOutput.TabIndex = 10;
            this.lblOutput.Text = "Format: Lat,Lon ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(257, 800);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 52);
            this.button1.TabIndex = 9;
            this.button1.Text = "Clear Form";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.cbbDistanceUnits);
            this.groupBox4.Controls.Add(this.cbbGeoUnits);
            this.groupBox4.Controls.Add(this.lblMinAltUnit);
            this.groupBox4.Controls.Add(this.lblMaxAltUnit);
            this.groupBox4.Controls.Add(this.lblCruiseAltUnit);
            this.groupBox4.Controls.Add(this.txtOutputName);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtCruiseAlt);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtMinAlt);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtMaxAlt);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.cbNFZ);
            this.groupBox4.Controls.Add(this.cbActivated);
            this.groupBox4.Location = new System.Drawing.Point(13, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(437, 382);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Global Annotation Parameters";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(36, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 25);
            this.label17.TabIndex = 25;
            this.label17.Text = "GEO Units";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(36, 90);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(137, 25);
            this.label16.TabIndex = 23;
            this.label16.Text = "Distance Units";
            // 
            // cbbDistanceUnits
            // 
            this.cbbDistanceUnits.FormattingEnabled = true;
            this.cbbDistanceUnits.Items.AddRange(new object[] {
            "[M]",
            "[FT]"});
            this.cbbDistanceUnits.Location = new System.Drawing.Point(195, 87);
            this.cbbDistanceUnits.Name = "cbbDistanceUnits";
            this.cbbDistanceUnits.Size = new System.Drawing.Size(121, 32);
            this.cbbDistanceUnits.TabIndex = 22;
            this.cbbDistanceUnits.SelectedIndexChanged += new System.EventHandler(this.cbbDistanceUnits_SelectedIndexChanged);
            // 
            // cbbGeoUnits
            // 
            this.cbbGeoUnits.FormattingEnabled = true;
            this.cbbGeoUnits.Items.AddRange(new object[] {
            "[D.DD/DMS]",
            "[MGRS/UTM]"});
            this.cbbGeoUnits.Location = new System.Drawing.Point(147, 41);
            this.cbbGeoUnits.Name = "cbbGeoUnits";
            this.cbbGeoUnits.Size = new System.Drawing.Size(169, 32);
            this.cbbGeoUnits.TabIndex = 24;
            this.cbbGeoUnits.SelectedIndexChanged += new System.EventHandler(this.cbbGeoUnits_SelectedIndexChanged);
            // 
            // lblMinAltUnit
            // 
            this.lblMinAltUnit.AutoSize = true;
            this.lblMinAltUnit.Location = new System.Drawing.Point(324, 186);
            this.lblMinAltUnit.Name = "lblMinAltUnit";
            this.lblMinAltUnit.Size = new System.Drawing.Size(35, 25);
            this.lblMinAltUnit.TabIndex = 21;
            this.lblMinAltUnit.Text = "[#]";
            // 
            // lblMaxAltUnit
            // 
            this.lblMaxAltUnit.AutoSize = true;
            this.lblMaxAltUnit.Location = new System.Drawing.Point(324, 234);
            this.lblMaxAltUnit.Name = "lblMaxAltUnit";
            this.lblMaxAltUnit.Size = new System.Drawing.Size(35, 25);
            this.lblMaxAltUnit.TabIndex = 20;
            this.lblMaxAltUnit.Text = "[#]";
            // 
            // lblCruiseAltUnit
            // 
            this.lblCruiseAltUnit.AutoSize = true;
            this.lblCruiseAltUnit.Location = new System.Drawing.Point(322, 287);
            this.lblCruiseAltUnit.Name = "lblCruiseAltUnit";
            this.lblCruiseAltUnit.Size = new System.Drawing.Size(35, 25);
            this.lblCruiseAltUnit.TabIndex = 11;
            this.lblCruiseAltUnit.Text = "[#]";
            // 
            // txtCruiseAlt
            // 
            this.txtCruiseAlt.Location = new System.Drawing.Point(118, 283);
            this.txtCruiseAlt.Name = "txtCruiseAlt";
            this.txtCruiseAlt.Size = new System.Drawing.Size(198, 29);
            this.txtCruiseAlt.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 25);
            this.label8.TabIndex = 19;
            this.label8.Text = "Cuise ALT";
            // 
            // txtMinAlt
            // 
            this.txtMinAlt.Location = new System.Drawing.Point(118, 182);
            this.txtMinAlt.Name = "txtMinAlt";
            this.txtMinAlt.Size = new System.Drawing.Size(198, 29);
            this.txtMinAlt.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "MIN ALT";
            // 
            // txtMaxAlt
            // 
            this.txtMaxAlt.Location = new System.Drawing.Point(118, 230);
            this.txtMaxAlt.Name = "txtMaxAlt";
            this.txtMaxAlt.Size = new System.Drawing.Size(198, 29);
            this.txtMaxAlt.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "MAX ALT";
            // 
            // pb1
            // 
            this.pb1.Location = new System.Drawing.Point(12, 1049);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(1186, 23);
            this.pb1.TabIndex = 18;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox3.Controls.Add(this.btnArea2List);
            this.groupBox3.Location = new System.Drawing.Point(467, 888);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(241, 140);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Area to Point List";
            // 
            // btnArea2List
            // 
            this.btnArea2List.Location = new System.Drawing.Point(25, 51);
            this.btnArea2List.Name = "btnArea2List";
            this.btnArea2List.Size = new System.Drawing.Size(194, 41);
            this.btnArea2List.TabIndex = 0;
            this.btnArea2List.Text = "Get Area File";
            this.btnArea2List.UseVisualStyleBackColor = true;
            this.btnArea2List.Click += new System.EventHandler(this.btnArea2List_Click_1);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(970, 888);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(228, 140);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Area to KML";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(24, 51);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(182, 41);
            this.button3.TabIndex = 0;
            this.button3.Text = "Convert Area";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 1088);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.pb1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gbOutputLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbOutputLabel.ResumeLayout(false);
            this.gbOutputLabel.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.Label lblCirleLat;
        private System.Windows.Forms.Label lblCirleLon;
        private System.Windows.Forms.TextBox txtLon;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRadius;
        private System.Windows.Forms.Button btnPolyGen;
        private System.Windows.Forms.Button btnCircleGen;
        private System.Windows.Forms.TextBox txtOutputName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbNFZ;
        private System.Windows.Forms.CheckBox cbActivated;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbOutputLabel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtCruiseAlt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMinAlt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaxAlt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLoadKML;
        private System.Windows.Forms.TextBox txtKmlFileName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblLatUnit;
        private System.Windows.Forms.Label lblLonUnit;
        private System.Windows.Forms.Label lblRadiusUnit;
        private System.Windows.Forms.Label lblMinAltUnit;
        private System.Windows.Forms.Label lblMaxAltUnit;
        private System.Windows.Forms.Label lblCruiseAltUnit;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbbDistanceUnits;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbbGeoUnits;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnArea2List;
        public System.Windows.Forms.ProgressBar pb1;
        private System.Windows.Forms.Label lblBoxWidth;
        private System.Windows.Forms.TextBox txtBoxWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbBoxPointCenter;
        private System.Windows.Forms.CheckBox cbBoxPointBottomLeft;
        private System.Windows.Forms.CheckBox cbBoxPointBottomRight;
        private System.Windows.Forms.CheckBox cbBoxPointTopRight;
        private System.Windows.Forms.CheckBox cbBoxPointTopLeft;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblBoxHeight;
        private System.Windows.Forms.Button btnBoxGen;
        private System.Windows.Forms.TextBox txtBoxHeight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button3;
    }
}

