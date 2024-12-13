using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.controller;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    public partial class NoticeForm : UserControl
    {
        public NoticeForm()
        {
            InitializeComponent();
            NoticeFormController noticeFormController = new NoticeFormController(this);
            noticeFormController.Init();
        }
    }
}
