using System;
using System.Collections.Generic;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.controller
{
    public class DetailContractController
    {
        private readonly DetailContract detailContract;
        private readonly ContractForm contractForm;
        private readonly IKhachThueDAO khachThueDAO;
        private readonly IPhongDAO phongDAO;
        private readonly IChuNhaDAO chuNhaDAO;
        private readonly IPhong_DichVu_DAO phongDichVuDao;
        private readonly ICoSoVatChatDAO coSoVatChatDAO;

        public DetailContractController(DetailContract detailContract, ContractForm contractForm)
        {
            this.detailContract = detailContract;
            this.contractForm = contractForm;
            this.khachThueDAO = new KhachThueDAOImpl();
            this.phongDAO = new PhongDAOImpl();
            this.chuNhaDAO = new ChuNhaDAOImpl();
            this.phongDichVuDao = new Phong_DichVu_DAOImpl();
            this.coSoVatChatDAO = new CoSoVatChatDAOImpl();
        }

        public void Init()
        {
            HandleDate();
            HandleInformation();
            HandleListService();
        }

        private void HandleDate()
        {
            DateTime date = DateTime.Parse(contractForm.NgaytaoField.Text);
            detailContract.DayOfCreateLbl.Text = $"Hà Nội, ngày {date.Day} tháng {date.Month} năm {date.Year}";
        }

        private void HandleInformation()
        {
            // Get tenant information
            int idKhach = int.Parse(contractForm.MakhachField.Text);
            KhachThue khachThue = khachThueDAO.GetKhachThue(idKhach);
            detailContract.CccdField_B.Text = khachThue.MaCCCD;
            detailContract.NameField_B.Text = khachThue.Ten;
            detailContract.AddressField_B.Text = khachThue.DiaChi;

            // Get landlord information
            int idPhong = int.Parse(contractForm.MaphongField.Text);
            int idChuNha = phongDAO.GetMaChuNha(idPhong);
            ChuNha chuNha = chuNhaDAO.GetChuNhaByMa(idChuNha);
            detailContract.CccdField_A.Text = chuNha.MaCCCD;
            detailContract.NameField_A.Text = chuNha.Ten;
            detailContract.AddressField_A.Text = chuNha.DiaChi;
        }

        private void HandleListService()
        {
            int idPhong = int.Parse(contractForm.MaphongField.Text);

            // Get room price and deposit
            string giaPhong = phongDAO.GetGiaPhong(idPhong).ToString();
            string tienCoc = contractForm.TiencocField.Text;

            // Clear existing rows
            while (detailContract.PriceListTable.Rows.Count > 0)
            {
                detailContract.PriceListTable.Rows.RemoveAt(0);
            }

            // Add room price and deposit information
            string[][] basicRows = new string[][]
            {
                new string[] { "Tiền phòng", giaPhong, "Tính theo tháng" },
                new string[] { "Tiền cọc", tienCoc, "Sẽ được hoàn trả khi hết hợp đồng" }
            };

            foreach (string[] row in basicRows)
            {
                detailContract.PriceListTable.Rows.Add(row);
            }

            // Get and add facility information
            List<CoSoVatChat> coSoVatChatList = coSoVatChatDAO.GetAllCoSoVatChat(idPhong);
            foreach (var csvc in coSoVatChatList)
            {
                detailContract.PriceListTable.Rows.Add(new string[]
                {
                    csvc.TenCSVC,
                    "free",
                    csvc.TrangThai
                });
            }
        }
    }
}