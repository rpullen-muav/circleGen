using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using CoordinateSharp;

namespace circleGen
{
    public class GeoHandler
    {
        public bool UseMeters { get; set; } = false;
        public bool UseDMS { get; set; } = false;
        public string DistanceUnits { get; set; }
        public string LatLonFormat { get; set; }
        public double M2F { get; set; } = 0.0;
        public double F2M { get; set; } = 0.0;
        public bool SingleCoordinateMode = false;

        public StringLocation TransformCoordinate(string lat, string lon, bool mgrsMode)
        {
            if (mgrsMode)
            {
                bool success = Coordinate.TryParse(lat, DateTime.Now, out Coordinate c);
                if (success)
                {
                    return new StringLocation()
                    {
                        Latitude = c.Latitude.DecimalDegree.ToString(),
                        Longitude = c.Longitude.DecimalDegree.ToString(),
                        Altitude = "0"
                    };
                }
                else
                {
                    MessageBox.Show("Not able to parse MGRS/UTM");
                    return new StringLocation();
                }
                
            }
            else
            {
                bool success = Coordinate.TryParse($"{lat}\" {lon}\"", DateTime.Now, out Coordinate c);
                
                if(success)
                {
                    Debug.WriteLine(c.Latitude.ToString());
                    return new StringLocation()
                    {
                        Latitude = c.Latitude.DecimalDegree.ToString(),
                        Longitude = c.Longitude.DecimalDegree.ToString(),
                        Altitude = "0"
                    };
                }
                else
                {
                    MessageBox.Show("Not able to parse Lat/Lon");
                    return new StringLocation();
                }
               
            }
            
        }

        public double MetersToFeet(double d)
        {
            return d * 3.28084;
        }
        public double FeetToMeters(double d)
        {
            return d * .3048;
        }

        public StringLocation Destination(double Lat, double Lon, double radius, double bearing)
        {
            const int GeoidRadius = 6371000;
            double lat1 = Lat * (Math.PI / 180);
            double lon1 = Lon * (Math.PI / 180);
            double brng = bearing * (Math.PI / 180);
            double lat2 = Math.Asin(Math.Sin(lat1) * Math.Cos(radius / GeoidRadius) + Math.Cos(lat1) * Math.Sin(radius / GeoidRadius) * Math.Cos(brng));
            double lon2 = lon1 + Math.Atan2(Math.Sin(brng) * Math.Sin(radius / GeoidRadius) * Math.Cos(lat1), Math.Cos(radius / GeoidRadius) - Math.Sin(lat1) * Math.Sin(lat2));
            StringLocation loc = new StringLocation()
            {
                Latitude = lat2.ToString(),
                Longitude = lon2.ToString(),
                Altitude = "0"
            };
            //return (lat2 * (180 / Math.PI), lon2 * (180 / Math.PI)); // return degrees
            return loc;
        }



        public double ConvertDegreeAngleToDouble(double degrees, double minutes, double seconds)
        {
            //Decimal degrees = 
            //   whole number of degrees, 
            //   plus minutes divided by 60, 
            //   plus seconds divided by 3600

            return degrees + (minutes / 60) + (seconds / 3600);
        }

        public bool GenerateBox(string lat, string lon, string width, string height, string from, KuttaFZ fzp, ProgressBar pb1, TextBox txtOutput)
        {
            StringLocation SL1 = TransformCoordinate(lat, lon, SingleCoordinateMode);

            //Debug.WriteLine($"boxgen input {SL1.Latitude}, {SL1.Longitude}, {SL1.Altitude}");
            bool trylat = double.TryParse(SL1.Latitude, out double GoodLat);
            bool trylon = double.TryParse(SL1.Longitude, out double GoodLon);
            bool tryHeight = int.TryParse(height, out int Height);
            bool tryWidth = int.TryParse(width, out int Width);
            bool tryFrom = false;

            if (string.IsNullOrEmpty(from))
            {
                MessageBox.Show("Error, invalid corner?");
                return false;
            }

            if (GoodLat > 90 || GoodLat < -90)
            {
                MessageBox.Show("Error, is there a missing decimal point in the Lattitude?");
                return false;
            }

            if (GoodLon > 180 || GoodLon < -180)
            {
                MessageBox.Show("Error, is there a missing decimal point in the Longitude?");
                return false;
            }

            if (!tryWidth)
            {
                MessageBox.Show("Error, Width is not a valid number?");
                return false;
            }

            if (!tryHeight)
            {
                MessageBox.Show("Error, Height is not a valid number?");
                return false;
            }

            switch (from)
            {
                case "bl":
                    tryFrom = true;
                    break;
                case "br":
                    tryFrom = true;
                    break;
                case "tl":
                    tryFrom = true;
                    break;
                case "tr":
                    tryFrom = true;
                    break;
                case "c":
                    tryFrom = true;
                    break;
            }

            if (trylat && trylon && tryHeight && tryWidth && tryFrom)
            {
                EasyFZv3.BoxGenerator BG = new EasyFZv3.BoxGenerator(GoodLat, GoodLon, Height, Width);
                switch (from)
                {
                    case "bl":
                        BG.FromBL();
                        foreach (StringLocation point in BG.PointList)
                        {
                            Debug.WriteLine($"{from}, {point.Latitude}, {point.Longitude}, {point.Altitude}");
                            txtOutput.AppendText($"{point.Latitude}, {point.Longitude}, {point.Altitude}");
                            txtOutput.AppendText(Environment.NewLine);
                            fzp.AREA.LLA.Add(new LLA()
                            {
                                Latitude = point.Latitude,
                                Longitude = point.Longitude,
                                Altitude = point.Altitude
                            });
                        }
                        BG.PointList.Clear();
                        break;
                    case "br":
                        BG.FromBR();
                        foreach (StringLocation point in BG.PointList)
                        {
                            Debug.WriteLine($"{from}, {point.Latitude}, {point.Longitude}, {point.Altitude}");
                            txtOutput.AppendText($"{point.Latitude}, {point.Longitude}, {point.Altitude}");
                            txtOutput.AppendText(Environment.NewLine);
                            fzp.AREA.LLA.Add(new LLA()
                            {
                                Latitude = point.Latitude,
                                Longitude = point.Longitude,
                                Altitude = point.Altitude
                            });
                        }
                        BG.PointList.Clear();
                        break;
                    case "tl":
                        BG.FromTL();
                        foreach (StringLocation point in BG.PointList)
                        {
                            
                            txtOutput.AppendText($"{point.Latitude}, {point.Longitude}, {point.Altitude}");
                            txtOutput.AppendText(Environment.NewLine);
                            fzp.AREA.LLA.Add(new LLA()
                            {
                                Latitude = point.Latitude,
                                Longitude = point.Longitude,
                                Altitude = point.Altitude
                            });
                            Debug.WriteLine($"{from}, {point.Latitude}, {point.Longitude}, {point.Altitude}");
                        }
                        BG.PointList.Clear();
                        break;
                    case "tr":
                        BG.FromTR();
                        foreach (StringLocation point in BG.PointList)
                        {
                            Debug.WriteLine($"{from}, {point.Latitude}, {point.Longitude}, {point.Altitude}");
                            txtOutput.AppendText($"{point.Latitude}, {point.Longitude}, {point.Altitude}");
                            txtOutput.AppendText(Environment.NewLine);
                            fzp.AREA.LLA.Add(new LLA()
                            {
                                Latitude = point.Latitude,
                                Longitude = point.Longitude,
                                Altitude = point.Altitude
                            });
                        }
                        BG.PointList.Clear();
                        break;
                    case "c":
                        
                        BG.FromCenter();
                        foreach (StringLocation point in BG.PointList)
                        {
                            Debug.WriteLine($"{from}, {point.Latitude}, {point.Longitude}, {point.Altitude}");
                            txtOutput.AppendText($"{point.Latitude}, {point.Longitude}, {point.Altitude}");
                            txtOutput.AppendText(Environment.NewLine);
                            fzp.AREA.LLA.Add(new LLA()
                            {
                                Latitude = point.Latitude,
                                Longitude = point.Longitude,
                                Altitude = point.Altitude
                            });
                        }
                        BG.PointList.Clear();
                        break;
                }
                BG = null;
                return true;
            }
            else
            {
                MessageBox.Show("Invalid Lat, Lon, width, height, or corner invalid!");
                return false;
            }
        }

        public bool GenrateCircle(string lat, string lon, string rad, KuttaFZ fzp, ProgressBar pb1, TextBox txtOutput)
        {


            StringLocation SL1 = TransformCoordinate(lat, lon, SingleCoordinateMode);


            bool trylat = double.TryParse(SL1.Latitude, out double GoodLat);
            bool trylon = double.TryParse(SL1.Longitude, out double GoodLon);
            bool tryrad = double.TryParse(rad, out double GoodRadius);

            if (GoodLat > 90 || GoodLat < -90)
            {
                MessageBox.Show("Error, is there a missing decimal point in the Lattitude?");
                return false;
            }

            if (GoodLon > 180 || GoodLon < -180)
            {
                MessageBox.Show("Error, is there a missing decimal point in the Longitude?");
                return false;
            }

            if (trylat && trylon && tryrad)
            {
                if (!UseMeters)
                {
                    GoodRadius = FeetToMeters(GoodRadius);
                }
                pb1.Maximum = 350;
                for (int i = 0; i < 360; i += 10)
                {
                    pb1.Value = i;
                    StringLocation SL = Destination(GoodLat, GoodLon, GoodRadius, i);
                    txtOutput.AppendText($"{SL.Latitude}, {SL.Longitude}, {SL.Altitude}");
                    txtOutput.AppendText(Environment.NewLine);
                    fzp.AREA.LLA.Add(new LLA()
                    {
                        Latitude = SL.Latitude,
                        Longitude = SL.Longitude,
                        Altitude = SL.Altitude
                    });
                }

                return true;
            }
            else
            {
                MessageBox.Show("Invalid Lat, Lon, or Alt Entered!");
                return false;
            }
        }
        
        public string LLA2RAD(string c)
        {
            //Debug.WriteLine($"In ll2rad:{c}");
            double x = Convert.ToDouble(c, CultureInfo.InvariantCulture);
            double rad = (Math.PI / 180) * x;
            return rad.ToString();
        }

        public string RAD2LLA(string c)
        {
            double degrees = (180 / Math.PI) * double.Parse(c);
            return (degrees.ToString());
        }

        public void GetLocation(string lla, List<LLA> ll)
        {
            if (!string.IsNullOrEmpty(lla))
            {
                double ConvertedAlt = 0.0;
                string[] LLA = lla.Split(",".ToCharArray());
                if (!UseMeters)
                {
                    double.TryParse(LLA[2], out ConvertedAlt);
                    ConvertedAlt = FeetToMeters(ConvertedAlt);
                    ll.Add(new LLA()
                    {
                        Latitude = LLA2RAD(LLA[1]),
                        Longitude = LLA2RAD(LLA[0]),
                        Altitude = ConvertedAlt.ToString()
                    });
                }
                else
                {
                    ll.Add(new LLA()
                    {
                        Latitude = LLA2RAD(LLA[1]),
                        Longitude = LLA2RAD(LLA[0]),
                        Altitude = LLA[2]
                    });
                }

            }
        }

        public  void ParseLocations(string stream, KuttaFZ kfz, string fileName)
        {
            if (string.IsNullOrEmpty(stream))
            {
                MessageBox.Show("Empty input stream");
                return;// new List<Location>();
            }
            //Debug.WriteLine($"stream: {stream}");
            List<Location> locationList = new List<Location>();

            var doc = XDocument.Load(stream);
            List<XElement> placemarks = doc.Descendants().Where(x => x.Name.LocalName == "Placemark").ToList();
            //List<string> poly = placemarks.Descendants().Where(x => x.Name.LocalName == "LinearRing").Select(x => x.Value).ToList();
            List<string> poly = placemarks.Descendants().Where(x => x.Name.LocalName == "coordinates").Select(x => x.Value).ToList();
            
            int count = 0;
            foreach (var item in poly)
            {
                string[] coordinates;
                //List<string> locs = new List<string>();
                //Debug.WriteLine($"Item: {item}");
                coordinates = item.Split(" ".ToCharArray());
                if(coordinates.Length <= 1)
                {
                    Debug.WriteLine("Found New line separator");
                    coordinates = item.Split("\n".ToCharArray());
                }
                else
                {
                    Debug.WriteLine("Found space separator");
                }
                for (int i = 0; i < coordinates.Count(); i++)
                {
                    if (i == 0)
                    {
                        GetLocation(coordinates[i].TrimStart(), kfz.AREA.LLA);
                        //Debug.WriteLine(coordinates[i].TrimStart());
                    }
                    else if (i == coordinates.Count() - 1)
                    {
                        GetLocation(coordinates[i].TrimEnd(), kfz.AREA.LLA);
                        //Debug.WriteLine(coordinates[i].TrimEnd());
                    }
                    else
                    {
                        GetLocation(coordinates[i], kfz.AREA.LLA);
                        //Debug.WriteLine(coordinates[i]);
                    }
                }
                count++;
                string name = $"{fileName}_{count}";
                CreateArea(kfz, name);
            }
            

        }

        public void CreateArea (KuttaFZ fzp, string fileNmae)
        {
            XmlSerializer x = new XmlSerializer(fzp.GetType());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            //x.Serialize(Console.Out, fzp, ns);
            if (!string.IsNullOrEmpty(fileNmae))
            {
                if(Directory.Exists(@"C:\KUTTA\Missions\Areas"))
                {
                    using (StreamWriter writer = new StreamWriter($@"C:\KUTTA\Missions\Areas\{fileNmae}.area"))
                    {
                        x.Serialize(writer, fzp, ns);
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter($@"Areas\{fileNmae}.area"))
                    {
                        x.Serialize(writer, fzp, ns);
                    }
                }
                
            }
            else
            {
                if (Directory.Exists(@"C:\KUTTA\Missions\Areas"))
                {
                    using (StreamWriter writer = new StreamWriter(@"C:\KUTTA\Missions\Areas\KML_XFORM_TEST.area"))
                    {
                        x.Serialize(writer, fzp, ns);
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(@"Areas\KML_XFORM_TEST.area"))
                    {
                        x.Serialize(writer, fzp, ns);
                    }
                }
                
            }
        }

        public void AreaToPointList(TextBox tb)
        {
            tb.Clear();
            string path = string.Empty;
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse for area Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "area",
                Filter = "area files (*.area)|*.area",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
            }
            else
            {
                return;
            }

            var doc = XDocument.Load(path);

            
            XmlSerializer serializer = new XmlSerializer(typeof(KuttaFZ));
            using (TextReader reader = new StringReader(doc.ToString()))
            {
                KuttaFZ result = (KuttaFZ)serializer.Deserialize(reader);
                foreach (var item in result.AREA.LLA)
                {
                    if (!SingleCoordinateMode)
                    {
                        tb.AppendText($"{RAD2LLA(item.Latitude)}, {RAD2LLA(item.Longitude)}{Environment.NewLine}");
                    }
                    else
                    {
                        Coordinate.TryParse($"{RAD2LLA(item.Latitude)}\" {RAD2LLA(item.Longitude)}\"", DateTime.Now, out Coordinate c);
                        tb.AppendText($"{c.MGRS}{Environment.NewLine}");
                    }
                }
            }
        }
    }

    

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
    }

    public class StringLocation
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Altitude { get; set; }
    }
}
