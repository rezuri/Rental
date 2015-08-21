using System.Xml.Serialization;

namespace Rental.Model.Extraction
{
    public class ExcelCell
    {
        [XmlAttribute(AttributeName = "r")]
        public string CellId { get; set; }

        [XmlElement(ElementName = "v")]
        public string Value { get; set; }
    }
}
