// Eithery: Eloquent Extensions
// Enum ActivationMode
// A dummy enumeration for test purposes
//
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace EloquentExtensions
{
    [DataContract]
    [DisplayName("Available activation modes")]
    internal enum ActivationMode
    {
        [DisplayName("Undefined")]
        Undefined,

        [EnumMember]
        [DisplayName("Singleton mode")]
        Singleton,

        [DisplayName("Single call mode")]
        SingleCall,

        [DisplayName("Client activation")]
        [XmlElement]
        [XmlElement("SomeName")]
        [XmlElement(typeof(ActivationMode))]
        Client,

        Other,

        [DisplayName("   ")]
        Failed
    }
}
