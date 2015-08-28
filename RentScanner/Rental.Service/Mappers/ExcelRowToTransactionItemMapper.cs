using System;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using Rental.Model;
using Rental.Model.Extraction;

namespace Rental.Service.Mappers
{
    public static class ExcelRowToTransactionItemMapper
    {
        public static TransactionItem Map(ExcelRow request, WorkbookPart workbookPart)
        {
            var response = new TransactionItem();
            foreach (var cell in request.Cells)
            {
                var column = cell.CellId.First().ToString();

                switch (column.ToUpper())
                {
                    case "A":
                        response.TransactionDate = DateTime.FromOADate(double.Parse(cell.Value));
                        break;
                    case "B":
                        var value = Math.Abs(decimal.Parse(cell.Value));
                        response.Amount = Math.Round(value, 2);
                        break;
                    case "C":
                        response.Description = ExcelHelper.GetSharedStringItemById(workbookPart, int.Parse(cell.Value));
                        break;
                }
            }

            return response;
        }
    }
}
