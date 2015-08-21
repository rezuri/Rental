using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Rental.Service
{
    public static class ExcelHelper
    {
        public static string GetSharedStringItemById(WorkbookPart workparPart, int id)
        {
            return
                workparPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id).InnerText;
        }
    }
}
