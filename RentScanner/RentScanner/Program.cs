using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
using Rental.DataAccess;
using Rental.Service;
using StructureMap;
using StructureMap.Graph;

namespace RentScanner
{
    public class Program
    {
        private static IContainer _container;

        public static void Main(string[] args)
        {
            Initialize();
            TestEntity();
            //TestProcess();
        }

        private static void GetRental()
        {
            var rental = new RentalExtract();
        }

        private static void TestEntity()
        {
            var repo = new TenantRepository(); 
            repo.SaveTest();
        }

        private static void TestProcess()
        {
            var transactionService = _container.GetInstance<ITransactionService>();
            transactionService.ProcessTransactions("test");
        }

        private static void Initialize()
        {
            _container = new Container(c => c.Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.Assembly("Rental.DataAccess");
                scan.Assembly("Rental.Service");
                scan.WithDefaultConventions();
            }));
        }
    }
}