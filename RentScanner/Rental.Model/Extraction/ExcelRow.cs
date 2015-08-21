using System.Xml.Serialization;

namespace Rental.Model.Extraction
{
    public class ExcelRow
    {
        [XmlAttribute("r")]
        public int RowNumber { get; set; }

        [XmlElement(ElementName = "c")]
        public ExcelCell[] Cells { get; set; }
    }
}
