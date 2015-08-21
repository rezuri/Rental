using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Rental.Model.Extraction;
using Rental.Service.Mappers;

namespace RentScanner
{
    public class RentalExtract
    {
        private List<TransactionItem> _rentalTransactions;

        public RentalExtract()
        {
            _rentalTransactions = new List<TransactionItem>();
            OpenExcelWorkbook();
        }

        private void OpenExcelWorkbook()
        {
            var fileName = @"C:\Temp\ANZ_3Month.xlsx";
            var dataList = new List<ExcelRow>();
            using (var spreadsheetDocument = SpreadsheetDocument.Open(fileName, false))
            {
                var workbook = spreadsheetDocument.WorkbookPart;
                var worksheet = workbook.WorksheetParts.First();
                var sheetData = worksheet.Worksheet.Elements<SheetData>().First();

                if (sheetData != null)
                {
                    var rootElement = new XmlRootAttribute();
                    rootElement.ElementName = "row";
                    rootElement.IsNullable = true;
                    rootElement.Namespace = @"http://schemas.openxmlformats.org/spreadsheetml/2006/main";

                    var test = sheetData.OuterXml;

                    foreach (var row in sheetData.Elements<Row>())
                    {
                        var test1 = row.InnerXml;
                        var test2 = row.OuterXml;

                        var reader = new StringReader(row.OuterXml);
                        var xmlSetting = new XmlReaderSettings
                        {
                            CloseInput = true,
                            ConformanceLevel = ConformanceLevel.Fragment,
                            IgnoreWhitespace = true
                        };
                        var xmlReader = XmlReader.Create(reader, xmlSetting);
                        var serializer = new XmlSerializer(typeof(ExcelRow), rootElement);
                        var rowContent = serializer.Deserialize(xmlReader);
                        dataList.Add((ExcelRow)rowContent);
                    }

                    var mappedItems = dataList.Select(x => ExcelRowToTransactionItemMapper.Map(x, workbook)).ToList();

                    _rentalTransactions.AddRange(mappedItems.Where(x => x.Description.Contains("RAVINDER KAUR")));
                    _rentalTransactions.AddRange(mappedItems.Where(x => x.Description.Contains("PAYMENT TO R.A.C.I.")));                    
                }
            }
        }

        public List<TransactionItem> GetTransactions()
        {
            return _rentalTransactions;
        }
    }
}
