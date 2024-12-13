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
    public partial class DetailRoom : Form
    {
        public DetailRoom(int maPhong)
        {
            InitializeComponent();
            DetailRoomController detailRoomController = new DetailRoomController(this);
            detailRoomController.Init(maPhong);
        }
    }
}
