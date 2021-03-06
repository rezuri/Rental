﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Rental.DataAccess;
using Rental.Model;
using Rental.Model.Extraction;
using Rental.Service.Mappers;

namespace Rental.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void ProcessTransactions(string fullPathFileName)
        {
            var criteriaList = new List<TransactionCriteria>();
            using (var context = new RentalContext())
            {
                var repo = new TransactionRepository(context);
                criteriaList = repo.GetTransactionCriterias(true).ToList();
                context.Dispose();
            }
            var extracts = ExtractTransactions(fullPathFileName, criteriaList);
            var filteredExtracts = FilterTransactionItemsToPersist(extracts);
            SaveTransactionItems(filteredExtracts);
            var x = 1;
        }

        private IList<TransactionItem> ExtractTransactions(string fullPathFileName, IEnumerable<TransactionCriteria> criterias)
        {
            var dataList = new List<ExcelRow>();
            var mappedItems = new List<TransactionItem>();
            var qualifiedItems = new List<TransactionItem>();
            using (var spreadsheetDocument = SpreadsheetDocument.Open(fullPathFileName, false))
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

                    mappedItems = dataList.Select(x => ExcelRowToTransactionItemMapper.Map(x, workbook)).ToList();

                    //_rentalTransactions.AddRange(mappedItems.Where(x => x.Description.Contains("RAVINDER KAUR")));
                    //_rentalTransactions.AddRange(mappedItems.Where(x => x.Description.Contains("PAYMENT TO R.A.C.I.")));
                }
            }

            foreach (var criteria in criterias)
            {
                var items = mappedItems.Where(x => x.Description.Contains(criteria.Keyword)).ToList();
                foreach (var i in items)
                {
                    i.IsExpenditure = criteria.IsExpenditure;
                    i.IsRental = criteria.IsRental;
                }
                qualifiedItems.AddRange(items);
            }

            return qualifiedItems;
        }

        private IList<TransactionItem> FilterTransactionItemsToPersist(IList<TransactionItem> extractItems)
        {
            var newTransactionItems = new List<TransactionItem>();
            var searchDate = extractItems.OrderBy(x => x.TransactionDate).First().TransactionDate;
            var existingTransactions = new List<TransactionItem>();

            using (var context = new RentalContext())
            {
                var repo = new TransactionRepository(context);
                existingTransactions = repo.GetTransactionItems(searchDate).ToList();
            }

            foreach (var item in extractItems)
            {
                if (!existingTransactions.Any(x => x.TransactionDate.Equals(item.TransactionDate) && 
                    x.Amount.Equals(item.Amount) && 
                    x.Description.Equals(item.Description)))
                {
                    newTransactionItems.Add(item);
                }
            }

            return newTransactionItems;
        }

        private void SaveTransactionItems(IList<TransactionItem> newItems)
        {
            using (var context = new RentalContext())
            {
                var repo = new TransactionRepository(context);
                repo.SaveTransactionItems(newItems);
            }
        }
    }
}
