using System;
using System.Configuration;
using System.Xml.Serialization;
using System.Xml;

namespace MattLamp.Config
{
    public class CustomColorConfigSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            using (var reader = new XmlNodeReader(section))
            {
                var serializer = new XmlSerializer(typeof(CustomColorCollection));
                return serializer.Deserialize(reader) as CustomColorCollection;
            }
        }
    }

    [Serializable]
    [XmlRoot(Namespace = "http://schneenet.com/MattLamp/CustomColorsConfig.xsd", IsNullable = false, ElementName = "colors")]
    [XmlType(AnonymousType=true, Namespace="http://schneenet.com/MattLamp/CustomColorsConfig.xsd")]
    public class CustomColorCollection
    {
        [XmlElement("color")]
        public CustomColor[] Colors { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://schneenet.com/MattLamp/CustomColorsConfig.xsd")]
    public class CustomColor
    {
        [XmlAttribute("r")]
        public byte R { get; set; }

        [XmlAttribute("g")]
        public byte G { get; set; }

        [XmlAttribute("b")]
        public byte B { get; set; }
    }
}
