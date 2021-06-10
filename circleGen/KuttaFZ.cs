using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace circleGen
{

	[XmlRoot(ElementName = "AREATYPE")]
	public class AREATYPE
	{
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName = "ACTIVE")]
	public class ACTIVE
	{
		[XmlAttribute(AttributeName = "value")]
		public string Value { get; set; }
	}

	[XmlRoot(ElementName = "CRUISEALT")]
	public class CRUISEALT
	{
		[XmlAttribute(AttributeName = "value")]
		public string Value { get; set; }
	}

	[XmlRoot(ElementName = "ELEVBAND")]
	public class ELEVBAND
	{
		[XmlAttribute(AttributeName = "min")]
		public string Min { get; set; }
		[XmlAttribute(AttributeName = "max")]
		public string Max { get; set; }
	}

	[XmlRoot(ElementName = "LLA")]
	public class LLA
	{
		[XmlAttribute(AttributeName = "latitude")]
		public string Latitude { get; set; }
		[XmlAttribute(AttributeName = "longitude")]
		public string Longitude { get; set; }
		[XmlAttribute(AttributeName = "altitude")]
		public string Altitude { get; set; }
	}

	[XmlRoot(ElementName = "AREA")]
	public class AREA
	{
		[XmlElement(ElementName = "AREATYPE")]
		public AREATYPE AREATYPE { get; set; }
		[XmlElement(ElementName = "ACTIVE")]
		public ACTIVE ACTIVE { get; set; }
		[XmlElement(ElementName = "CRUISEALT")]
		public CRUISEALT CRUISEALT { get; set; }
		[XmlElement(ElementName = "ELEVBAND")]
		public ELEVBAND ELEVBAND { get; set; }
		[XmlElement(ElementName = "LLA")]
		public List<LLA> LLA { get; set; }
		[XmlAttribute(AttributeName = "ident")]
		public string Ident { get; set; }
	}

	[XmlRoot(ElementName = "SAV_DEFINITION")]
	public class KuttaFZ
	{
		[XmlElement(ElementName = "AREA")]
		public AREA AREA { get; set; }
		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }
		[XmlAttribute(AttributeName = "subversion")]
		public string Subversion { get; set; }
		[XmlAttribute(AttributeName = "copyright")]
		public string Copyright { get; set; }
	}

	
}
