using System;
using System.ComponentModel;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;

namespace MattLamp.Config {

    public class DevicesConfigSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            using (var reader = new XmlNodeReader(section))
            {
                var serializer = new XmlSerializer(typeof(DeviceCollection), "http://schneenet.com/MattLamp/EffectsConfig.xsd");
                return serializer.Deserialize(reader) as DeviceCollection;
            }
        }
    }

    [Serializable]
    [XmlType(AnonymousType=true, Namespace="http://schneenet.com/MattLamp/DevicesConfig.xsd")]
    [XmlRoot(Namespace="http://schneenet.com/MattLamp/DevicesConfig.xsd", IsNullable=false, ElementName = "devices")]
    public class DeviceCollection {
        
        [XmlElement("device")]
        public Device[] Devices { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://schneenet.com/MattLamp/DevicesConfig.xsd")]
    public class Device {
        
        [XmlElement("leds")]
        public LedsCollection Leds { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
        
        [XmlAttribute("vid")]
        public ushort VID { get; set; }

        [XmlAttribute("pid")]
        public ushort PID { get; set; }

        [XmlAttribute("rev")]
        public ushort Revision { get; set; }

        [XmlAttribute("usagePage")]
        public ushort UsagePage { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Device;
            return other != null && other.VID == VID && other.PID == PID && other.Revision == Revision;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (int)2166136261;
                hash = hash * 486187739 + VID.GetHashCode();
                hash = hash * 486187739 + PID.GetHashCode();
                hash = hash * 486187739 + Revision.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} ({1:X4}:{2:X4}:{3:X4})", Name, VID, PID, Revision);
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://schneenet.com/MattLamp/DevicesConfig.xsd")]
    public class LedsCollection {
        
        [XmlElement("led")]
        public Led[] Leds { get; set; }

        [XmlIgnore]
        public int Count => Leds.Length;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://schneenet.com/MattLamp/DevicesConfig.xsd")]
    public partial class Led {
        
        public Led() {
            Size = 4;
        }
        
        [XmlAttribute("x")]
        public int X { get; set; }

        [XmlAttribute("y")]
        public int Y { get; set; }

        [XmlAttribute("size")]
        [DefaultValue(typeof(uint), "20")]
        public int Size { get; set; }
    }
}
