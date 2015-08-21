using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentScanner;

namespace RentalViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var extracts = new RentalExtract();

            var dt = new DataTable();
            dt.Columns.Add("Date");
            dt.Columns.Add("Description");
            dt.Columns.Add("Amount");

            foreach (var transaction in extracts.GetTransactions().OrderBy(x => x.TransactionDate))
            {
                object[] row =
                {
                    transaction.TransactionDate.ToString("dd-MMM-yyyy"),
                    transaction.Description,
                    transaction.Amount.ToString("C2")
                };
                dt.Rows.Add(row);
            }

            


            dataGridView1.DataSource = dt;
            
        }
    }
}
