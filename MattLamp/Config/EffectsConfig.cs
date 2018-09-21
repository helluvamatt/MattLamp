using System;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;

namespace MattLamp.Config {

    public class EffectsConfigSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            using (var reader = new XmlNodeReader(section))
            {
                var serializer = new XmlSerializer(typeof(EffectsCollection), "http://schneenet.com/MattLamp/EffectsConfig.xsd");
                return serializer.Deserialize(reader) as EffectsCollection;
            }
        }
    }

    [Serializable]
    [XmlType(AnonymousType=true, Namespace="http://schneenet.com/MattLamp/EffectsConfig.xsd")]
    [XmlRoot(Namespace="http://schneenet.com/MattLamp/EffectsConfig.xsd", IsNullable=false, ElementName="effects")]
    public class EffectsCollection {
        
        [XmlElement("effect")]
        public Effect[] Effects { get; set; }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://schneenet.com/MattLamp/EffectsConfig.xsd")]
    public class Effect {
        
        [XmlAttribute("name")]
        public string Name { get; set; }
        
        [XmlAttribute("description")]
        public string Description { get; set; }
    }
}
