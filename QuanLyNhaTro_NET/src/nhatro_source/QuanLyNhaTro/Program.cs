using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro
{
    internal class Program
    {

        private static void Main(string[] args)
        {   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form f = new Form();
            f.Text = "Quản lý nhà trọ";
            f.WindowState = FormWindowState.Maximized;
            f.StartPosition = FormStartPosition.CenterScreen;
            InvoiceForm invoiceForm = new InvoiceForm();
            f.Controls.Add(invoiceForm);
            Application.Run(new DetailInvoiceForm());

        }
    }
}
