using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;

namespace circleGen
{
    public partial class Form1 : Form
    {
        public GeoHandler GU = new GeoHandler();
        public Form1()
        {
            InitializeComponent();
            Version EFZV = new Version(Application.ProductVersion);
            string WindowTitle = $"EasyFZ {EFZV.Major}.{EFZV.Minor}.{EFZV.Build}";
            Text = WindowTitle;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (cbbGeoUnits.Text == "[D.DD/DMS]")
            {
                GU.UseDMS = false;
                GU.SingleCoordinateMode = false;
            }
            else
            {
                GU.UseDMS = true;
                GU.SingleCoordinateMode = true;
            }
            cbbDistanceUnits.SelectedIndex = 0;
            cbbGeoUnits.SelectedIndex = 0;
            if (!Directory.Exists("Areas"))
            {
                Directory.CreateDirectory("Areas");
            }
        }

        private void btnArea2List_Click(object sender, EventArgs e)
        {
            GU.AreaToPointList(txtOutput);
        }

        private void cbbGeoUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbGeoUnits.Text == "[D.DD/DMS]")
            {
                GU.UseDMS = false;
                GU.SingleCoordinateMode = false;
                lblCirleLat.Text = "LAT";
                lblCirleLon.Text = "LON";
                txtLon.Enabled = true;
                txtLon.BackColor = SystemColors.Window;
                GU.LatLonFormat = cbbGeoUnits.Text;
                lblLatUnit.Text = GU.LatLonFormat;
                lblLonUnit.Text = GU.LatLonFormat;
                lblOutput.Text = " Line Format: LAT,LON";
            }
            else
            {
                GU.UseDMS = true;
                GU.SingleCoordinateMode = true;
                lblCirleLat.Text = string.Empty;
                txtLon.Enabled = false;
                txtLon.BackColor = Color.Gainsboro;
                GU.LatLonFormat = cbbGeoUnits.Text;
                lblLatUnit.Text = GU.LatLonFormat;
                lblLonUnit.Text = string.Empty;
                lblCirleLon.Text = string.Empty;
                lblOutput.Text = "Line Format: MGRS COORDINATE";
            }

        }

        

        private void cbbDistanceUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDistanceUnits.Text == "[FT]")
            {
                GU.UseMeters = false;
            }
            else
            {
                GU.UseMeters = true;
            }

            GU.DistanceUnits = cbbDistanceUnits.Text;
            lblMaxAltUnit.Text = GU.DistanceUnits;
            lblMinAltUnit.Text = GU.DistanceUnits;
            lblCruiseAltUnit.Text = GU.DistanceUnits;
            lblRadiusUnit.Text = GU.DistanceUnits;
            lblBoxHeight.Text = GU.DistanceUnits;
            lblBoxWidth.Text = GU.DistanceUnits;
        }


        private void btnCircleGen_Click(object sender, EventArgs e)
        {
            string areatype = string.Empty;
            string active = string.Empty;
            string cruisealt = string.Empty;
            string minalt = string.Empty;
            string maxalt = string.Empty;
            if (cbNFZ.Checked)
            {
                areatype = "2";
            }
            else
            {
                areatype = "1";
            }
            if (cbActivated.Checked)
            {
                active = "0";
            }
            else
            {
                active = "1";
            }

            if (!string.IsNullOrEmpty(txtCruiseAlt.Text))
            {
                if (int.TryParse(txtCruiseAlt.Text, out _))
                {
                    cruisealt = txtCruiseAlt.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Cruise Altitude Entered!");
                    return;
                }

            }
            else
            {
                cruisealt = "7500";
            }

            if (!string.IsNullOrEmpty(txtMaxAlt.Text))
            {
                if (int.TryParse(txtMaxAlt.Text, out _))
                {
                    maxalt = txtMaxAlt.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Max Altitude Entered!");
                    return;
                }

            }
            else
            {
                maxalt = "9999";
            }

            if (!string.IsNullOrEmpty(txtMinAlt.Text))
            {
                if (int.TryParse(txtMinAlt.Text, out _))
                {
                    minalt = txtMinAlt.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Min Altitude Entered!");
                    return;
                }

            }
            else
            {
                minalt = "5000";
            }

            KuttaFZ fzp = new KuttaFZ
            {
                Version = "1",
                Subversion = "0",
                Copyright = "MUAV",

                AREA = new AREA()
                {
                    Ident = "",
                    AREATYPE = new AREATYPE()
                    {
                        Type = areatype
                    },
                    ACTIVE = new ACTIVE()
                    {
                        Value = active
                    },
                    CRUISEALT = new CRUISEALT()
                    {
                        Value = cruisealt
                    },
                    ELEVBAND = new ELEVBAND()
                    {
                        Max = maxalt,
                        Min = minalt
                    },
                    LLA = new List<LLA>()
                }
            };
            bool success = GU.GenrateCircle(txtLat.Text, txtLon.Text, txtRadius.Text, fzp, pb1, txtOutput);
            if(success)
            {
                XmlSerializer x = new XmlSerializer(fzp.GetType());
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                x.Serialize(Console.Out, fzp, ns);
                if (!string.IsNullOrEmpty(txtOutputName.Text))
                {
                    //using (StreamWriter writer = new StreamWriter($"{txtOutputName.Text}.area"))
                    //{
                    //    x.Serialize(writer, fzp, ns);
                    //}
                    GU.CreateArea(fzp, txtOutputName.Text);
                }
                else
                {
                    //using (StreamWriter writer = new StreamWriter("CIRCLE_TEST.area"))
                    //{
                    //    x.Serialize(writer, fzp, ns);
                    //}
                    GU.CreateArea(fzp, "CIRCLE_TEST");
                }

            }
            else
            {
                Debug.WriteLine("Returning False");
                return;
            }
            
            
        }

        public XDocument GetKml(string path)
        {
            string[] X = path.Split('.');
            File.Copy(path, Path.ChangeExtension(path, ".zip"), true);
            //XmlDocument xmlDoc = new XmlDocument();
            XDocument doc = new XDocument();
            Stream stream =Stream.Null;
            using (var file = File.OpenRead($"{X[0]}.zip"))

            using (var zip = new ZipArchive(file, ZipArchiveMode.Read))
            {
                foreach (var entry in zip.Entries)
                {
                    stream = entry.Open();
                    //xmlDoc.Load(stream);
                    //xmlDoc.Save(Console.Out);
                    doc = XDocument.Load(stream);
                    return doc;
                }
            }
            return doc;
        }

        private void btnLoadKML_Click(object sender, EventArgs e)
        {
            pb1.Value = 0;
            string areatype = string.Empty;
            string active = string.Empty;
            string cruisealt = string.Empty;
            string minalt = string.Empty;
            string maxalt = string.Empty;
            if(cbNFZ.Checked)
            {
                areatype = "2";
            }
            else
            {
                areatype = "1";
            }
            if (cbActivated.Checked)
            {
                active = "0";
            }
            else
            {
                active = "1";
            }

            if(!string.IsNullOrEmpty(txtCruiseAlt.Text))
            {
                if(int.TryParse(txtCruiseAlt.Text, out _))
                {
                    cruisealt = txtCruiseAlt.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Cruise Altitude Entered!");
                    return;
                }

            }
            else
            {
                cruisealt = "7500";
            }

            if (!string.IsNullOrEmpty(txtMaxAlt.Text))
            {
                if (int.TryParse(txtMaxAlt.Text, out _))
                {
                    maxalt = txtMaxAlt.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Max Altitude Entered!");
                    return;
                }

            }
            else
            {
                maxalt = "9999";
            }

            if (!string.IsNullOrEmpty(txtMinAlt.Text))
            {
                if (int.TryParse(txtMinAlt.Text, out _))
                {
                    minalt = txtMinAlt.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Min Altitude Entered!");
                    return;
                }

            }
            else
            {
                minalt = "5000";
            }

            KuttaFZ fzp = new KuttaFZ
            {
                Version = "1",
                Subversion = "0",
                Copyright = "MUAV",

                AREA = new AREA()
                {
                    Ident = "",
                    AREATYPE = new AREATYPE()
                    {
                        Type = areatype
                    },
                    ACTIVE = new ACTIVE()
                    {
                        Value = active
                    },
                    CRUISEALT = new CRUISEALT()
                    {
                        Value = cruisealt
                    },
                    ELEVBAND = new ELEVBAND()
                    {
                        Max = maxalt,
                        Min = minalt
                    },
                    LLA = new List<LLA>()
                }
            };

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse for KMZ Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "kmz",
                Filter = "kmz files (*.kmz)|*.kmz",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtKmlFileName.Text = openFileDialog1.FileName;
            }
            else
            {
                return;
            }

            if (string.IsNullOrEmpty(openFileDialog1.FileName.ToString()))
            {
                MessageBox.Show("Empty input stream");
                return;
            }

            Debug.WriteLine($"stream: {openFileDialog1.FileName}");
            List<Location> locationList = new List<Location>();
            //Stream d = GetKml(openFileDialog1.FileName.ToString());
            //var doc = GetKml(openFileDialog1.FileName.ToString());
            //var doc = XDocument.Load(d);
            var doc = GetKml(openFileDialog1.FileName.ToString());
            //var doc = XDocument.Load(openFileDialog1.FileName.ToString());
            List<XElement> placemarks = doc.Descendants().Where(x => x.Name.LocalName == "Placemark").ToList();
            List<string> poly = placemarks.Descendants().Where(x => x.Name.LocalName == "coordinates").Select(x => x.Value).ToList();
            //List<string> poly = placemarks.Descendants().Where(x => x.Name.LocalName == "LinearRing").Select(x => x.Value).ToList();
            List<string> names = placemarks.Descendants().Where(x => x.Name.LocalName == "name").Select(x => x.Value).ToList();
            
            int count = 0;
            foreach (var item in poly)
            {
                
                //Debug.WriteLine($"Name: {names[count]}");
                string[] coordinates;
                coordinates = item.Split(" ".ToCharArray());
                if (coordinates.Length <= 1)
                {
                    coordinates = item.Split(Environment.NewLine.ToCharArray());
                }
                pb1.Maximum = coordinates.Length;
                for (int i = 0; i < coordinates.Count(); i++)
                {
                    if (i == 0)
                    {
                        GU.GetLocation(coordinates[i].TrimStart(), fzp.AREA.LLA);
                        Debug.WriteLine(coordinates[i].TrimStart());
                    }
                    else if (i == coordinates.Count() - 1)
                    {
                        GU.GetLocation(coordinates[i].TrimEnd(), fzp.AREA.LLA);
                        Debug.WriteLine(coordinates[i].TrimEnd());
                    }
                    else
                    {
                        GU.GetLocation(coordinates[i], fzp.AREA.LLA);
                        Debug.WriteLine(coordinates[i]);
                        
                    }
                    pb1.Value = i+1;
                }
                
                if (!string.IsNullOrEmpty(txtOutputName.Text))
                {
                    if (names.Count > 1)
                    {
                        string name = $"{txtOutputName.Text}_{count}";
                        GU.CreateArea(fzp, name);
                    }
                    else
                    {
                        GU.CreateArea(fzp, txtOutputName.Text);
                    }
                }
                else
                {
                    if (names.Count > 1)
                    {
                        List<string> FZType = names[count].Split('_').ToList();
                        if(FZType.Count > 1)
                        {
                            if (FZType[1] == "NFZ" || FZType[1] == "nfz")
                            {
                                Debug.WriteLine(FZType[0]);
                                fzp.AREA.AREATYPE.Type = "2";
                            }
                        }
                        
                        string name = $"{names[count]}_{count}";
                        GU.CreateArea(fzp, name);
                    }
                    else
                    {
                        if(names[count] == "" || names[count] == string.Empty)
                        {

                            GU.CreateArea(fzp, "KML_XFORM");
                        }
                        else
                        {
                            GU.CreateArea(fzp, txtOutputName.Text);
                        }
                    }
                }
                count++;
                //pb1.Value = 0;
                fzp.AREA.AREATYPE.Type = "1";
                fzp.AREA.LLA.Clear();
            }
            ClearForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearFormAll();
        }

        public void ClearFormAll()
        {
            txtOutput.Clear();
            txtLat.Clear();
            txtLon.Clear();
            txtCruiseAlt.Clear();
            txtKmlFileName.Clear();
            txtOutputName.Clear();
            txtRadius.Clear();
            txtMinAlt.Clear();
            txtMaxAlt.Clear();
            cbActivated.Checked = false;
            cbNFZ.Checked = false;
            pb1.Value = 0;
        }

        public void ClearForm()
        {
            txtOutput.Clear();
            txtLat.Clear();
            txtLon.Clear();
            txtCruiseAlt.Clear();
            txtKmlFileName.Clear();
            txtOutputName.Clear();
            txtRadius.Clear();
            txtMinAlt.Clear();
            txtMaxAlt.Clear();
            cbActivated.Checked = false;
            cbNFZ.Checked = false;
            //pb1.Value = 0;
        }

        private void btnPolyGen_Click(object sender, EventArgs e)
        {
            string areatype = string.Empty;
            string active = string.Empty;
            string cruisealt = string.Empty;
            string minalt = string.Empty;
            string maxalt = string.Empty;
            if (cbNFZ.Checked)
            {
                areatype = "2";
            }
            else
            {
                areatype = "1";
            }
            if (cbActivated.Checked)
            {
                active = "0";
            }
            else
            {
                active = "1";
            }

            if (!string.IsNullOrEmpty(txtCruiseAlt.Text))
            {
                if (int.TryParse(txtCruiseAlt.Text, out _))
                {
                    cruisealt = txtCruiseAlt.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Cruise Altitude Entered!");
                    return;
                }

            }
            else
            {
                cruisealt = "7500";
            }

            if (!string.IsNullOrEmpty(txtMaxAlt.Text))
            {
                if (int.TryParse(txtMaxAlt.Text, out _))
                {
                    maxalt = txtMaxAlt.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Max Altitude Entered!");
                    return;
                }

            }
            else
            {
                maxalt = "9999";
            }

            if (!string.IsNullOrEmpty(txtMinAlt.Text))
            {
                if (int.TryParse(txtMinAlt.Text, out _))
                {
                    minalt = txtMinAlt.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Min Altitude Entered!");
                    return;
                }

            }
            else
            {
                minalt = "5000";
            }

            KuttaFZ fzp = new KuttaFZ
            {
                Version = "1",
                Subversion = "0",
                Copyright = "MUAV",

                AREA = new AREA()
                {
                    Ident = "",
                    AREATYPE = new AREATYPE()
                    {
                        Type = areatype
                    },
                    ACTIVE = new ACTIVE()
                    {
                        Value = active
                    },
                    CRUISEALT = new CRUISEALT()
                    {
                        Value = cruisealt
                    },
                    ELEVBAND = new ELEVBAND()
                    {
                        Max = maxalt,
                        Min = minalt
                    },
                    LLA = new List<LLA>()
                }
            };

            string[] llaArray = txtOutput.Lines;
            if (llaArray.Length < 3)
            {
                MessageBox.Show("Not enough Lat/Lon pairs for a polygon!");
                return;
            }
            pb1.Maximum = llaArray.Length-1;
            for (int i = 0; i < llaArray.Length; i++)
            {
                pb1.Value = i;
                Debug.WriteLine(llaArray[i]);
                StringLocation SL1;
                if (GU.SingleCoordinateMode)
                {
                    SL1 = GU.TransformCoordinate(llaArray[i],string.Empty, GU.SingleCoordinateMode);
                    bool trylat = double.TryParse(SL1.Latitude, out double GoodLat);
                    bool trylon = double.TryParse(SL1.Longitude, out double GoodLon);

                    if (GoodLat > 90 || GoodLat < -90)
                    {
                        fzp.AREA.LLA.Clear();
                        pb1.Value = 0;
                        MessageBox.Show("Error, is there a missing decimal point in the Lattitude?");
                        return;
                    }

                    if (GoodLon > 180 || GoodLon < -180)
                    {
                        fzp.AREA.LLA.Clear();
                        pb1.Value = 0;
                        MessageBox.Show("Error, is there a missing decimal point in the Longitude?");
                        return;
                    }

                    if (trylat && trylon)
                    {

                        fzp.AREA.LLA.Add(new LLA()
                        {
                            Latitude = GU.LLA2RAD(SL1.Latitude),
                            Longitude = GU.LLA2RAD(SL1.Longitude),
                            Altitude = "0"
                        });

                    }
                }
                else
                {
                    string[] split = llaArray[i].Split(',');
                    SL1 = GU.TransformCoordinate(split[0], split[1], GU.SingleCoordinateMode);
                    bool trylat = double.TryParse(SL1.Latitude, out double GoodLat);
                    bool trylon = double.TryParse(SL1.Longitude, out double GoodLon);

                    if (GoodLat > 90 || GoodLat < -90)
                    {
                        fzp.AREA.LLA.Clear();
                        pb1.Value = 0;
                        MessageBox.Show("Error, is there a missing decimal point in the Lattitude?");
                        return;
                    }

                    if (GoodLon > 180 || GoodLon < -180)
                    {
                        fzp.AREA.LLA.Clear();
                        pb1.Value = 0;
                        MessageBox.Show("Error, is there a missing decimal point in the Longitude?");
                        return;
                    }

                    if (trylat && trylon)
                    {

                        fzp.AREA.LLA.Add(new LLA()
                        {
                            Latitude = GU.LLA2RAD(SL1.Latitude),
                            Longitude = GU.LLA2RAD(SL1.Longitude),
                            Altitude = "0"
                        });
                    }
                }
            }
            
            XmlSerializer x = new XmlSerializer(fzp.GetType());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            x.Serialize(Console.Out, fzp, ns);
            if (!string.IsNullOrEmpty(txtOutputName.Text))
            {
                //using (StreamWriter writer = new StreamWriter($"{txtOutputName.Text}.area"))
                //{
                //    x.Serialize(writer, fzp, ns);
                //}
                GU.CreateArea(fzp, txtOutputName.Text);
            }
            else
            {
                //using (StreamWriter writer = new StreamWriter("FROM_LIST_TEST.area"))
                //{
                //    x.Serialize(writer, fzp, ns);
                //}
                GU.CreateArea(fzp, "FROM_LIST_TEST");
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Process.Start(@"EasyFZ_Instructions.docx");
        }

        private void btnArea2List_Click_1(object sender, EventArgs e)
        {
            GU.AreaToPointList(txtOutput);
        }

        private void btnBoxGen_Click(object sender, EventArgs e)
        {
            string Corner = string.Empty;

            List<CheckBox> CornerList = new List<CheckBox>() { 
                cbBoxPointTopLeft, 
                cbBoxPointTopRight, 
                cbBoxPointCenter, 
                cbBoxPointBottomLeft, 
                cbBoxPointBottomRight 
            };

            foreach (CheckBox point in CornerList)
            {
                if (point.Checked)
                {
                    Corner = point.Tag.ToString();
                }
            }

            Debug.WriteLine($"Corner: {Corner}");

            string areatype = string.Empty;
            string active = string.Empty;
            string cruisealt = string.Empty;
            string minalt = string.Empty;
            string maxalt = string.Empty;

            if (cbNFZ.Checked)
            {
                areatype = "2";
            }
            else
            {
                areatype = "1";
            }
            if (cbActivated.Checked)
            {
                active = "0";
            }
            else
            {
                active = "1";
            }

            if (!string.IsNullOrEmpty(txtCruiseAlt.Text))
            {
                if (int.TryParse(txtCruiseAlt.Text, out _))
                {
                    cruisealt = txtCruiseAlt.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Cruise Altitude Entered!");
                    return;
                }

            }
            else
            {
                cruisealt = "7500";
            }

            if (!string.IsNullOrEmpty(txtMaxAlt.Text))
            {
                if (int.TryParse(txtMaxAlt.Text, out _))
                {
                    maxalt = txtMaxAlt.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Max Altitude Entered!");
                    return;
                }

            }
            else
            {
                maxalt = "9999";
            }

            if (!string.IsNullOrEmpty(txtMinAlt.Text))
            {
                if (int.TryParse(txtMinAlt.Text, out _))
                {
                    minalt = txtMinAlt.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Min Altitude Entered!");
                    return;
                }

            }
            else
            {
                minalt = "5000";
            }

            KuttaFZ fzp = new KuttaFZ
            {
                Version = "1",
                Subversion = "0",
                Copyright = "MUAV",

                AREA = new AREA()
                {
                    Ident = "",
                    AREATYPE = new AREATYPE()
                    {
                        Type = areatype
                    },
                    ACTIVE = new ACTIVE()
                    {
                        Value = active
                    },
                    CRUISEALT = new CRUISEALT()
                    {
                        Value = cruisealt
                    },
                    ELEVBAND = new ELEVBAND()
                    {
                        Max = maxalt,
                        Min = minalt
                    },
                    LLA = new List<LLA>()
                }
            };

            bool success = GU.GenerateBox(txtLat.Text, txtLon.Text, txtBoxWidth.Text, txtBoxHeight.Text, Corner, fzp, pb1, txtOutput);
            if (success)
            {
                XmlSerializer x = new XmlSerializer(fzp.GetType());
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                x.Serialize(Console.Out, fzp, ns);
                if (!string.IsNullOrEmpty(txtOutputName.Text))
                {
                    //using (StreamWriter writer = new StreamWriter($"{txtOutputName.Text}.area"))
                    //{
                    //    x.Serialize(writer, fzp, ns);
                    //}
                    GU.CreateArea(fzp, txtOutputName.Text);
                }
                else
                {
                    //using (StreamWriter writer = new StreamWriter("CIRCLE_TEST.area"))
                    //{
                    //    x.Serialize(writer, fzp, ns);
                    //}
                    GU.CreateArea(fzp, $"{Corner}_Box_point_TEST");
                }

            }
            else
            {
                Debug.WriteLine("Returning False");
                return;
            }

            foreach (CheckBox point in CornerList)
            {
                if (point.Checked)
                {
                    point.Checked = false;
                }
            }
        }
    }
}
