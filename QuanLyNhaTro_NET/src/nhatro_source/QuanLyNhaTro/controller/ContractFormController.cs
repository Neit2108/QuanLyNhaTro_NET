using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.controller
{
    public class ContractFormController
    {
        private readonly ContractForm contractForm;
        private readonly IHopDongDAO hopDongDAO;
        private readonly IKhachThueDAO khachThueDAO;
        private readonly ITaiKhoanDAO taiKhoanDAO;
        private readonly IChuNhaDAO chuNhaDAO;

        public ContractFormController(ContractForm contractForm)
        {
            this.contractForm = contractForm;
            this.hopDongDAO = new HopDongDAOImpl();
            this.khachThueDAO = new KhachThueDAOImpl();
            this.taiKhoanDAO = new TaiKhoanDAOImpl();
            this.chuNhaDAO = new ChuNhaDAOImpl();
        }

        public void Init()
        {
            ShowData();

            // Single click handler
            contractForm.MainTable.CellClick += (sender, e) =>
            {
                if (e.RowIndex >= 0)
                    HandleTable();
            };

            // Double click handler
            contractForm.MainTable.CellDoubleClick += (sender, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var detailContract = new DetailContract();
                    var detailContractController = new DetailContractController(detailContract, contractForm);
                    detailContractController.Init();
                    detailContract.ShowDialog();
                }
            };
        }

        private void ShowData()
        {
            contractForm.MainTable.Rows.Clear();
            string role = Constant.Role ?? "Admin";

            if (role.Equals("Khách Thuê", StringComparison.OrdinalIgnoreCase))
            {
                ShowDataForTenant();
            }
            else if (role.Equals("Chủ Nhà", StringComparison.OrdinalIgnoreCase))
            {
                ShowDataForLandlord();
            }
            else
            {
                ShowDataForAdmin();
            }
        }

        private void ShowDataForAdmin()
        {
            List<HopDong> hopDongList = hopDongDAO.GetAllHopDong();
            foreach (var x in hopDongList)
            {
                AddRowToTable(x);
            }
        }

        private void ShowDataForLandlord()
        {
            int maChuNha = taiKhoanDAO.GetMaChuNha(Constant.TaiKhoan.MaTaiKhoan);
            List<HopDong> hopDongList = hopDongDAO.GetHopDongByMaChuNha(maChuNha);
            foreach (var x in hopDongList)
            {
                AddRowToTable(x);
            }
        }

        private void ShowDataForTenant()
        {
            int maKhachThue = taiKhoanDAO.GetMaKhachThue(Constant.TaiKhoan.MaTaiKhoan);
            List<HopDong> hopDongList = hopDongDAO.GetHopDongByMaKhach(maKhachThue);
            foreach (var x in hopDongList)
            {
                KhachThue khachThue = khachThueDAO.GetKhachThue(x.MaKhachThue);
                AddRowToTable(x);
            }
        }

        private void AddRowToTable(HopDong hopDong)
        {
            contractForm.MainTable.Rows.Add(
                hopDong.MaHopDong.ToString(),
                hopDong.MaPhong.ToString(),
                hopDong.MaKhachThue.ToString(),
                string.Format("{0:F2}", hopDong.TienCoc),
                hopDong.NgayThue.ToString(),
                $"{hopDong.ThoiHanHopDong} tháng",
                hopDong.NgayTao.Date.ToString("dd/MM/yyyy"),
                hopDong.TrangThai
            );
        }

        private void HandleTable()
        {
            int selectedRow = contractForm.MainTable.CurrentRow.Index;
            if (selectedRow != -1)
            {
                var row = contractForm.MainTable.Rows[selectedRow];

                contractForm.MahdField.Text = row.Cells[0].Value.ToString();
                contractForm.MaphongField.Text = row.Cells[1].Value.ToString();
                contractForm.MakhachField.Text = row.Cells[2].Value.ToString();
                contractForm.TiencocField.Text = row.Cells[3].Value.ToString();
                contractForm.NgaythueField.Text = row.Cells[4].Value.ToString();
                contractForm.TimeField.Text = row.Cells[5].Value.ToString();
                contractForm.NgaytaoField.Text = row.Cells[6].Value.ToString();
                contractForm.TrangthaiField.Text = row.Cells[7].Value.ToString();
            }
        }

        public void SetNull()
        {
            contractForm.MahdField.Text = string.Empty;
            contractForm.MaphongField.Text = string.Empty;
            contractForm.MakhachField.Text = string.Empty;
            contractForm.TiencocField.Text = string.Empty;
            contractForm.NgaythueField.Text = string.Empty;
            contractForm.TimeField.Text = string.Empty;
            contractForm.NgaytaoField.Text = string.Empty;
            contractForm.TrangthaiField.Text = string.Empty;
        }
    }
}