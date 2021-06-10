using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using circleGen;
using System.Globalization;

namespace EasyFZv3
{
    public class BoxGenerator
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double HalfWidth { get; set; }
        public double HalfLength { get; set; }
        public double Angle { get; set; } = 0.0;
        public double Point_1_Brng { get; set; } = 0.0;
        public double Point_2_Brng { get; set; } = 0.0;
        public double Point_3_Brng { get; set; } = 0.0;
        public double Point_4_Brng { get; set; } = 0.0;
        public double Point_Distance { get; set; } = 0.0;
        public StringLocation TopRight { get; set; } = new StringLocation();
        public StringLocation BotRight { get; set; } = new StringLocation();
        public StringLocation BotLeft { get; set; } = new StringLocation();
        public StringLocation TopLeft { get; set; } = new StringLocation();
        public double EarthRadius { get; set; } = 6371.01;
        public double Epsilon { get; set; } = 1E-06;
        public List<StringLocation> PointList { get; set; } 

        public BoxGenerator(double lat, double lon, double wid, double len)
        {
            Lat = lat;
            Lon = lon;
            Length = len;
            Width = wid;
            HalfWidth = wid / 2;
            HalfLength = len / 2;
            PointList = new List<StringLocation>(){};
        }

        public void GetHypotenuse()
        {
            Point_Distance = Math.Sqrt(Math.Pow(HalfLength, 2) + Math.Pow(HalfWidth, 2));
        }

        public string ToRadiansString(string c)
        {
            //Debug.WriteLine($"In ll2rad:{c}");
            double x = Convert.ToDouble(c, CultureInfo.InvariantCulture);
            double rad = (Math.PI / 180) * x;
            return rad.ToString();
        }

        public string ToDegreesString(string c)
        {
            double degrees = (180 / Math.PI) * double.Parse(c);
            return (degrees.ToString());
        }

        public double ToRadiansDouble(string c)
        {
            //Debug.WriteLine($"In ll2rad:{c}");
            double x = Convert.ToDouble(c, CultureInfo.InvariantCulture);
            double rad = (Math.PI / 180) * x;
            return rad;
        }

        public double ToDegreesDouble(string c)
        {
            double x = Convert.ToDouble(c, CultureInfo.InvariantCulture);
            double degrees = (180 / Math.PI) * x;
            return degrees;
        }

        public void GetAngle()
        {
            Angle = ToDegreesDouble(Math.Atan(HalfLength / HalfWidth).ToString());
            Point_1_Brng = Angle;
            Point_2_Brng = 179 - Angle;
            Point_3_Brng = 179 + Angle;
            Point_4_Brng = 359 - Angle;
            Console.WriteLine($"angle: {Angle}");
            Console.WriteLine($"bearing: p1-{Point_1_Brng}");
            Console.WriteLine($"bearing: p2-{Point_2_Brng}");
            Console.WriteLine($"bearing: p3-{Point_3_Brng}");
            Console.WriteLine($"bearing: p4-{Point_4_Brng}");
        }
        //public class StringLocation
        //{
        //    public string Latitude { get; set; }
        //    public string Longitude { get; set; }
        //    public string Altitude { get; set; }
        //}

        public StringLocation Destination(double Lat, double Lon, double bearing, double distance)
        {
            const int GeoidRadius = 6371000;
            double lat1 = Lat * (Math.PI / 180);
            double lon1 = Lon * (Math.PI / 180);
            double brng = bearing * (Math.PI / 180);
            double lat2 = Math.Asin(Math.Sin(lat1) * Math.Cos(distance / GeoidRadius) + Math.Cos(lat1) * Math.Sin(distance / GeoidRadius) * Math.Cos(brng));
            double lon2 = lon1 + Math.Atan2(Math.Sin(brng) * Math.Sin(distance / GeoidRadius) * Math.Cos(lat1), Math.Cos(distance / GeoidRadius) - Math.Sin(lat1) * Math.Sin(lat2));
            lon2 = (lon2 % 360 + 540) % 360 - 180;
            StringLocation loc = new StringLocation()
            {
                Latitude = lat2.ToString(),
                Longitude = lon2.ToString(),
                Altitude = "0"
            };
            return loc;
        }

        public void FromCenter()
        {
            GetHypotenuse();
            GetAngle();
            TopRight = Destination(Lat, Lon, Point_1_Brng, Point_Distance);
            BotRight = Destination(Lat, Lon, Point_2_Brng, Point_Distance);
            BotLeft = Destination(Lat, Lon, Point_3_Brng, Point_Distance);
            TopLeft = Destination(Lat, Lon, Point_4_Brng, Point_Distance);

            PointList.Add(TopLeft);
            PointList.Add(TopRight);
            PointList.Add(BotRight);
            PointList.Add(BotLeft);
        }

        public void FromTR()
        {
            // top right
            TopRight.Latitude = ToRadiansString(Lat.ToString());
            TopRight.Longitude = ToRadiansString(Lon.ToString());
            TopRight.Altitude = "0";

            TopLeft = Destination(Lat, Lon, 270, Length);
            BotRight = Destination(Lat, Lon, 180, Width);
            BotLeft = Destination(ToDegreesDouble(BotRight.Latitude), ToDegreesDouble(BotRight.Longitude), 270, Length);

            PointList.Add(TopLeft);
            PointList.Add(TopRight);
            PointList.Add(BotRight);
            PointList.Add(BotLeft);
        }

        public void FromBR()
        {
            // bottom right
            BotRight.Latitude = ToRadiansString(Lat.ToString());
            BotRight.Longitude = ToRadiansString(Lon.ToString());
            BotRight.Altitude = "0";

            TopRight = Destination(Lat, Lon, 0, Width);
            BotLeft = Destination(Lat, Lon, 270, Length);
            TopLeft = Destination(ToDegreesDouble(BotLeft.Latitude), ToDegreesDouble(BotLeft.Longitude), 0, Width);

            PointList.Add(TopLeft);
            PointList.Add(TopRight);
            PointList.Add(BotRight);
            PointList.Add(BotLeft);
        }

        public void FromBL()
        {
            // bottom left
            BotLeft.Latitude = ToRadiansString(Lat.ToString());
            BotLeft.Longitude = ToRadiansString(Lon.ToString());
            BotLeft.Altitude = "0";

            TopLeft = Destination(Lat, Lon, 0, Width);
            BotRight = Destination(Lat, Lon, 90, Length);
            TopRight = Destination(ToDegreesDouble(TopLeft.Latitude), ToDegreesDouble(TopLeft.Longitude), 90, Length);

            PointList.Add(TopLeft);
            PointList.Add(TopRight);
            PointList.Add(BotRight);
            PointList.Add(BotLeft);
        }

        public void FromTL()
        {
            // top left
            TopLeft.Latitude = ToRadiansString(Lat.ToString());
            TopLeft.Longitude = ToRadiansString(Lon.ToString());
            TopLeft.Altitude = "0";

            BotLeft = Destination(Lat, Lon, 180, Width);
            TopRight = Destination(Lat, Lon, 90, Length);
            BotRight = Destination(ToDegreesDouble(BotLeft.Latitude), ToDegreesDouble(BotLeft.Longitude), 90, Length);

            PointList.Add(TopLeft);
            PointList.Add(TopRight);
            PointList.Add(BotRight);
            PointList.Add(BotLeft);
            
        }
    }
}
