using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    public partial class ContractForm : UserControl
    {
        public ContractForm()
        {
            InitializeComponent();
            ContractFormController contractFormController = new ContractFormController(this);
            contractFormController.Init();
        }
    }
}
