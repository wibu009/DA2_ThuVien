using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace PJC.Models
{
    public class StoreContext
    {
        
        public StoreContext()
        {
        }
        public string ConnectionString { get; set; }
        public StoreContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<Sach> GetSanPham()
        {
            List<Sach> list = new List<Sach>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from SACH ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Sach()
                        {
                            MaSach = reader["MaSach"].ToString(),
                            TenSach = reader["TenSach"].ToString(),
                            TenTG = reader["TenTG"].ToString(),
                            NhaXB = reader["NhaXB"].ToString(),
                            TheLoai = reader["TheLoai"].ToString(),
                            SoLuong = int.Parse(reader["SoLuong"].ToString()),
                            GiaTien = double.Parse(reader["GiaTien"].ToString()),
                            ImageUrl= reader["ImageUrl"].ToString(),
                        }); ;
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }      
        public List<Sach> GetSanPhamSearch(string searchString)
        {
            List<Sach> list = new List<Sach>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from SACH where TenSach like @tensach ", conn);
                cmd.Parameters.AddWithValue("tensach", "%" + searchString + "%");
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Sach()
                        {
                            MaSach = reader["MaSach"].ToString(),
                            TenSach = reader["TenSach"].ToString(),
                            TenTG = reader["TenTG"].ToString(),
                            NhaXB = reader["NhaXB"].ToString(),
                            TheLoai = reader["TheLoai"].ToString(),
                            SoLuong = int.Parse(reader["SoLuong"].ToString()),
                            GiaTien = double.Parse(reader["GiaTien"].ToString()),
                            ImageUrl = reader["ImageUrl"].ToString(),
                        }); ;
                    }
                    reader.Close();
                }
                conn.Close();
            }
     
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from SACH where TenTG like @tacgia ", conn);
                cmd.Parameters.AddWithValue("tacgia", "%" + searchString + "%");
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Sach()
                        {
                            MaSach = reader["MaSach"].ToString(),
                            TenSach = reader["TenSach"].ToString(),
                            TenTG = reader["TenTG"].ToString(),
                            NhaXB = reader["NhaXB"].ToString(),
                            TheLoai = reader["TheLoai"].ToString(),
                            SoLuong = int.Parse(reader["SoLuong"].ToString()),
                            GiaTien = double.Parse(reader["GiaTien"].ToString()),
                            ImageUrl = reader["ImageUrl"].ToString(),
                        }); ;
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<TaiKhoan> GetTaiKhoan()
        {
            List<TaiKhoan> list = new List<TaiKhoan>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from taikhoan ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TaiKhoan()
                        {
                            User = reader["User"].ToString(),
                            PassWord = reader["PassWord"].ToString(),
                            PhanQuyen = int.Parse(reader["PhanQuyen"].ToString()),
                            TenND = reader["TenND"].ToString(),
                            SDT = reader["SDT"].ToString(),
                            CMND = reader["CMND"].ToString(),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public TaiKhoan GetTaiKhoanByUser(string id)
        {
            TaiKhoan tk = new TaiKhoan();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from taikhoan where User=@user";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("user", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tk.User = reader["User"].ToString();
                        tk.PassWord = reader["PassWord"].ToString();
                        tk.PhanQuyen = int.Parse(reader["PhanQuyen"].ToString());
                        tk.TenND = reader["TenND"].ToString();
                        tk.SDT = reader["SDT"].ToString();
                        tk.CMND = reader["CMND"].ToString();
                    }

                }
            }
            return tk;
        }
        public int CreateUser(TaiKhoan tk)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into taikhoan values(@User, @PassWord,@PhanQuyen,@TenND,@SDT,@CMND)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("User", tk.User);
                cmd.Parameters.AddWithValue("PassWord", tk.PassWord);
                cmd.Parameters.AddWithValue("PhanQuyen", tk.PhanQuyen);
                cmd.Parameters.AddWithValue("TenND", tk.TenND);
                cmd.Parameters.AddWithValue("SDT", tk.SDT);
                cmd.Parameters.AddWithValue("CMND", tk.CMND);

                return (cmd.ExecuteNonQuery());

            }
        }
        public int DeleteUser(TaiKhoan tk)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "Delete from taikhoan where User=@user";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("User", tk.User);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int UpdateUser(TaiKhoan tk)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update taikhoan set  PassWord=@PassWord,PhanQuyen=@PhanQuyen,TenND=@TenND,SDT=@SDT,CMND=@CMND where User=@User";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("PassWord", tk.PassWord);
                cmd.Parameters.AddWithValue("PhanQuyen", tk.PhanQuyen);
                cmd.Parameters.AddWithValue("TenND", tk.TenND);
                cmd.Parameters.AddWithValue("SDT", tk.SDT);
                cmd.Parameters.AddWithValue("CMND", tk.CMND);
                cmd.Parameters.AddWithValue("User", tk.User);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int CreateSach(Sach s)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into sach values(@MaSach, @TenSach,@TenTG,@NhaXB,@TheLoai,@SoLuong,@GiaTien,@ImageUrl,@MieuTa)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("MaSach", s.MaSach);
                cmd.Parameters.AddWithValue("TenSach", s.TenSach);
                cmd.Parameters.AddWithValue("TenTG", s.TenTG);
                cmd.Parameters.AddWithValue("NhaXB", s.NhaXB);
                cmd.Parameters.AddWithValue("TheLoai", s.TheLoai);
                cmd.Parameters.AddWithValue("SoLuong", s.SoLuong);
                cmd.Parameters.AddWithValue("GiaTien", s.GiaTien);
                cmd.Parameters.AddWithValue("ImageUrl","/img/sach/"+s.ImageUrl);
                cmd.Parameters.AddWithValue("MieuTa", s.MieuTa);

                return (cmd.ExecuteNonQuery());

            }
        }
        public int UpdateProduct(Sach s)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update sach set TenSach=@TenSach,TenTG=@TenTG,NhaXB=@NhaXB,TheLoai=@TheLoai,SoLuong=@SoLuong,GiaTien=@GiaTien,ImageUrl=@ImageUrl,MieuTa=@MieuTa where MaSach=@MaSach ";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("TenSach", s.TenSach);
                cmd.Parameters.AddWithValue("TenTG", s.TenTG);
                cmd.Parameters.AddWithValue("NhaXB", s.NhaXB);
                cmd.Parameters.AddWithValue("TheLoai", s.TheLoai);
                cmd.Parameters.AddWithValue("SoLuong", s.SoLuong);
                cmd.Parameters.AddWithValue("GiaTien", s.GiaTien);
                cmd.Parameters.AddWithValue("ImageUrl", "/img/sach/" + s.ImageUrl);
                cmd.Parameters.AddWithValue("MieuTa", s.MieuTa);
                cmd.Parameters.AddWithValue("MaSach", s.MaSach);
                return (cmd.ExecuteNonQuery());
            }
        }
        public Sach GetSachByMa(string id)
        {
            Sach s = new Sach();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from sach where MaSach=@masach";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("masach", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        s.MaSach = reader["MaSach"].ToString();
                        s.TenSach = reader["TenSach"].ToString();
                        s.TenTG = reader["TenTG"].ToString();
                        s.NhaXB = reader["NhaXB"].ToString();
                        s.TheLoai = reader["TheLoai"].ToString();
                        s.SoLuong = int.Parse(reader["SoLuong"].ToString());
                        s.GiaTien = double.Parse(reader["GiaTien"].ToString());
                        s.ImageUrl = reader["ImageUrl"].ToString();
                        s.MieuTa = reader["MieuTa"].ToString();
                    }

                }
            }
            return s;
        }
        public int DeleteSach(Sach s)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "Delete from sach where MaSach=@masach";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("masach", s.MaSach);
                return (cmd.ExecuteNonQuery());
            }
        }
        public List<DocGia> GetDocGia()
        {
            List<DocGia> list = new List<DocGia>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from docgia ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DocGia()
                        {
                            MaDG = reader["MaDG"].ToString(),
                            TenDG = reader["TenDG"].ToString(),
                            SDT = reader["SDT"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            MatSach = int.Parse(reader["MatSach"].ToString()),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public int CreateDocGia(DocGia dg)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into docgia values(@MaDG, @TenDG,@SDT,@DiaChi,@GioiTinh,@MatSach)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("MaDG", dg.MaDG);
                cmd.Parameters.AddWithValue("TenDG", dg.TenDG);
                cmd.Parameters.AddWithValue("SDT", dg.SDT);
                cmd.Parameters.AddWithValue("DiaChi", dg.DiaChi);
                cmd.Parameters.AddWithValue("GioiTinh", dg.GioiTinh);
                cmd.Parameters.AddWithValue("MatSach", dg.MatSach);

                return (cmd.ExecuteNonQuery());

            }
        }
        public int UpdateDocGia(DocGia dg)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update docgia set TenDG=@TenDG,SDT=@SDT,DiaChi=@DiaChi,GioiTinh=@GioiTinh,MatSach=@MatSach where MaDG=@MaDG";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("TenDG", dg.TenDG);
                cmd.Parameters.AddWithValue("SDT", dg.SDT);
                cmd.Parameters.AddWithValue("DiaChi", dg.DiaChi);
                cmd.Parameters.AddWithValue("GioiTinh", dg.GioiTinh);
                cmd.Parameters.AddWithValue("MatSach", dg.MatSach);
                cmd.Parameters.AddWithValue("MaDG", dg.MaDG);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int DeleteDocGia(DocGia dg)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "Delete from docgia where MaDG=@madg";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("madg", dg.MaDG);
                return (cmd.ExecuteNonQuery());
            }
        }
        public DocGia GetDocGiaByMaDG(string id)
        {
            DocGia dg = new DocGia();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from docgia where MaDG=@madg";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("madg", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dg.MaDG = reader["MaDG"].ToString();
                        dg.TenDG = reader["TenDG"].ToString();
                        dg.SDT = reader["SDT"].ToString();
                        dg.DiaChi = reader["DiaChi"].ToString();
                        dg.GioiTinh = reader["GioiTinh"].ToString();
                        dg.MatSach = int.Parse(reader["MatSach"].ToString());
                    }

                }
            }
            return dg;
        }
        public List<PhieuMuon> GetPhieuMuon()
        {
            List<PhieuMuon> list = new List<PhieuMuon>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from phieumuon ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PhieuMuon()
                        {
                            MaPM = reader["MaPM"].ToString(),
                            MaDG = reader["MaDG"].ToString(),
                            NgayMuon = DateTime.Parse(reader["NgayMuon"].ToString()),
                            NgayHenTra = DateTime.Parse(reader["NgayHenTra"].ToString()),
                            SoLuongMuon = int.Parse(reader["SoLuongMuon"].ToString()),
                            User = reader["User"].ToString(),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public int CreatePhieuMuon(PhieuMuon pm)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into phieumuon values(@MaPM, @MaDG,@NgayMuon,@NgayHenTra,@SoLuongMuon,@User)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("MaPM", pm.MaPM);
                cmd.Parameters.AddWithValue("MaDG", pm.MaDG);
                cmd.Parameters.AddWithValue("NgayMuon", pm.NgayMuon);
                cmd.Parameters.AddWithValue("NgayHenTra", pm.NgayHenTra);
                cmd.Parameters.AddWithValue("SoLuongMuon", pm.SoLuongMuon);
                cmd.Parameters.AddWithValue("User", pm.User);
                int matsach = 0;
                using (MySqlConnection conn1 = GetConnection())
                {
                    conn1.Open();
                    var str1 = "select MatSach from docgia where MaDG=@madg";
                    MySqlCommand cmd1 = new MySqlCommand(str1, conn1);
                    cmd1.Parameters.AddWithValue("madg", pm.MaDG);
                    using (var reader = cmd1.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            matsach = int.Parse(reader["MatSach"].ToString());
                        }
                    }
                    if (matsach == 3)
                        return 100;
                    
                }
                return (cmd.ExecuteNonQuery());
            }
        }
        public int UpdatePhieuMuon(PhieuMuon pm)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update phieumuon set MaDG=@MaDG,NgayMuon=@NgayMuon,NgayHenTra=@NgayHenTra,SoLuongMuon=@SoLuongMuon,User=@User where MaPM=@MaPM";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("MaDG", pm.MaDG);
                cmd.Parameters.AddWithValue("NgayMuon", pm.NgayMuon);
                cmd.Parameters.AddWithValue("NgayHenTra", pm.NgayHenTra);
                cmd.Parameters.AddWithValue("SoLuongMuon", pm.SoLuongMuon);
                cmd.Parameters.AddWithValue("User", pm.User);
                cmd.Parameters.AddWithValue("MaPM", pm.MaPM);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int UpdateSoLuongSach(string id)
        {
            int demsoluong = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select*from ctpm where MaPM=@mapm";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mapm", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (string.Compare(reader["MaPM"].ToString(), id, false) == 0)
                        {
                            demsoluong++;
                        }
                    }
                    reader.Close();
                }
                conn.Close();

            }
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update phieumuon set SoLuongMuon=@SoLuongMuon where MaPM=@MaPM";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("SoLuongMuon", demsoluong);
                cmd.Parameters.AddWithValue("MaPM", id);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int DeletePhieuMuon(PhieuMuon pm)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "Delete from phieumuon where MaPM=@mapm";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mapm", pm.MaPM);
                return (cmd.ExecuteNonQuery());
            }
        }
        public PhieuMuon GetPhieuMuonByMaPM(string id)
        {
            PhieuMuon pm = new PhieuMuon();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from phieumuon where MaPM=@mapm";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mapm", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pm.MaPM = reader["MaPM"].ToString();
                        pm.MaDG = reader["MaDG"].ToString();
                        pm.NgayMuon = DateTime.Parse(reader["NgayMuon"].ToString());
                        pm.NgayHenTra = DateTime.Parse(reader["NgayHenTra"].ToString());
                        pm.SoLuongMuon = int.Parse(reader["SoLuongMuon"].ToString());
                        pm.User = reader["User"].ToString();
                    }

                }
            }
            return pm;
        }
        public List<PhieuMuon> GetPhieuMuonByMADG(string id)
        {
            List<PhieuMuon> list = new List<PhieuMuon>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from phieumuon where MaDG=@madg ", conn);
                cmd.Parameters.AddWithValue("madg", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PhieuMuon()
                        {
                            MaPM = reader["MaPM"].ToString(),
                            MaDG = reader["MaDG"].ToString(),
                            NgayMuon = DateTime.Parse(reader["NgayMuon"].ToString()),
                            NgayHenTra = DateTime.Parse(reader["NgayHenTra"].ToString()),
                            SoLuongMuon = int.Parse(reader["SoLuongMuon"].ToString()),
                            User = reader["User"].ToString(),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<CTPM> GetPhieuTra()
        {
            List<CTPM> list = new List<CTPM>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from ctpm ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        if (reader["Ngaytra"].ToString().Length != 0)
                        {
                            list.Add(new CTPM()
                            {
                                MaPM = reader["MaPM"].ToString(),
                                MaSach = reader["MaSach"].ToString(),
                                NgayTra = DateTime.Parse(reader["NgayTra"].ToString()),
                                TinhTrangSach = int.Parse(reader["TinhTrangSach"].ToString()),
                                TinhTrangTra = int.Parse(reader["TinhTrangTra"].ToString()),
                                User = reader["User"].ToString(),
                                GhiChu = reader["GhiChu"].ToString(),
                                TienPhat = double.Parse(reader["TienPhat"].ToString()),

                            });
                        }


                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<CTPM> GetPhieuTraBiPhat()
        {
            List<CTPM> list = new List<CTPM>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from ctpm ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        if (reader["Ngaytra"].ToString().Length != 0 && double.Parse(reader["TienPhat"].ToString()) != 0)
                        {
                            list.Add(new CTPM()
                            {
                                MaPM = reader["MaPM"].ToString(),
                                MaSach = reader["MaSach"].ToString(),
                                NgayTra = DateTime.Parse(reader["NgayTra"].ToString()),
                                TinhTrangSach = int.Parse(reader["TinhTrangSach"].ToString()),
                                TinhTrangTra = int.Parse(reader["TinhTrangTra"].ToString()),
                                User = reader["User"].ToString(),
                                GhiChu = reader["GhiChu"].ToString(),
                                TienPhat = double.Parse(reader["TienPhat"].ToString()),

                            });
                        }


                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public int CreatePhieuTra(CTPM pt)
        {
            int soluongsach = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into ctpm values(@MaPM, @MaSach,@NgayTra,@TinhTrangSach,@TinhTrangTra,@User,@GhiChu,@TienPhat)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("MaPM", pt.MaPM);
                cmd.Parameters.AddWithValue("MaSach", pt.MaSach);
                cmd.Parameters.AddWithValue("NgayTra", null);
                cmd.Parameters.AddWithValue("TinhTrangSach", pt.TinhTrangSach);
                cmd.Parameters.AddWithValue("TinhTrangTra", null);
                cmd.Parameters.AddWithValue("User", null);
                cmd.Parameters.AddWithValue("GhiChu", null);
                cmd.Parameters.AddWithValue("TienPhat", null);
                cmd.ExecuteNonQuery();
                using (MySqlConnection conn3 = GetConnection())
                {
                    conn3.Open();
                    var str3 = "Select SoLuong from sach where MaSach=@masach";
                    MySqlCommand cmd3 = new MySqlCommand(str3, conn3);
                    cmd3.Parameters.AddWithValue("MaSach", pt.MaSach);
                    using (var reader3 = cmd3.ExecuteReader())
                    {
                        while (reader3.Read())
                        {
                            soluongsach = int.Parse(reader3["SoLuong"].ToString());
                        }

                    }
                }
                using (MySqlConnection conn2 = GetConnection())
                {
                    conn2.Open();
                    var str2 = "update sach set SoLuong=@soluong where MaSach=@masach";
                    MySqlCommand cmd2 = new MySqlCommand(str2, conn2);
                    cmd2.Parameters.AddWithValue("soluong", soluongsach - 1);
                    cmd2.Parameters.AddWithValue("masach", pt.MaSach);
                    return cmd2.ExecuteNonQuery();
                }
            }
           
            

        }
        public int UpdatePhieuTra(PhieuMuonInCTPM pt)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update ctpm set NgayTra=@NgayTra,TinhTrangTra=@TinhTrangTra,User=@User,GhiChu=@GhiChu where MaPM=@MaPM and MaSach=@MaSach";
                MySqlCommand cmd = new MySqlCommand(str, conn);

                cmd.Parameters.AddWithValue("NgayTra", pt.NgayTra);
                // cmd.Parameters.AddWithValue("TinhTrangSach", pt.TinhTrangSach);
                cmd.Parameters.AddWithValue("TinhTrangTra", pt.TinhTrangTra);
                cmd.Parameters.AddWithValue("User", pt.User);
                cmd.Parameters.AddWithValue("GhiChu", pt.GhiChu);
                cmd.Parameters.AddWithValue("MaPM", pt.MaPM);
                cmd.Parameters.AddWithValue("MaSach", pt.MaSach);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int DeletePhieuTra(CTPM pt)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "Delete from ctpm where MaPM=@mapm";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mapm", pt.MaPM);
                return (cmd.ExecuteNonQuery());
            }
        }
        public CTPM GetPhieuTraByMaPM(string id, string masach)
        {
            CTPM pt = new CTPM();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from ctpm where MaPM=@mapm and MaSach=@masach";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mapm", id);
                cmd.Parameters.AddWithValue("Masach", masach);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["NgayTra"].ToString().Length == 0)
                        {
                            pt.MaPM = reader["MaPM"].ToString();
                            pt.MaSach = reader["MaSach"].ToString();
                            pt.NgayTra = (DateTime?)null;
                            pt.TinhTrangSach = int.Parse(reader["TinhTrangSach"].ToString());
                            pt.TinhTrangTra = (int?)null;
                            pt.User = reader["User"].ToString();
                            pt.GhiChu = reader["GhiChu"].ToString();
                        }
                        else
                        {
                            pt.MaPM = reader["MaPM"].ToString();
                            pt.MaSach = reader["MaSach"].ToString();
                            pt.NgayTra = DateTime.Parse(reader["NgayTra"].ToString());
                            pt.TinhTrangSach = int.Parse(reader["TinhTrangSach"].ToString());
                            pt.TinhTrangTra = int.Parse(reader["TinhTrangTra"].ToString());
                            pt.User = reader["User"].ToString();
                            pt.GhiChu = reader["GhiChu"].ToString();
                        }

                    }

                }
            }
            return pt;
        }
        public List<PhieuMuonInCTPM> GetPhieuChuaTra()
        {
            List<PhieuMuonInCTPM> list = new List<PhieuMuonInCTPM>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Select c.MaPM,a.MaDG,c.MaSach,a.NgayHenTra,c.NgayTra,c.TinhTrangSach,c.TinhTrangTra,c.User,c.GhiChu FROM ctpm c,phieumuon a where a.MaPM=c.MaPM ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["Ngaytra"].ToString().Length == 0)
                        {
                            list.Add(new PhieuMuonInCTPM()
                            {
                                MaPM = reader["MaPM"].ToString(),
                                MaDG = reader["MaDG"].ToString(),
                                MaSach = reader["MaSach"].ToString(),
                                NgayHenTra = DateTime.Parse(reader["NgayHenTra"].ToString()),
                                NgayTra = (DateTime?)null,
                                TinhTrangSach = int.Parse(reader["TinhTrangSach"].ToString()),
                                TinhTrangTra = (int?)null,
                                User = reader["User"].ToString(),
                                GhiChu = reader["GhiChu"].ToString(),
                            });
                        }
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public PhieuMuonInCTPM GetPhieuChuaTraById(string id, string masach)
        {
            PhieuMuonInCTPM pt = new PhieuMuonInCTPM();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "Select c.MaPM,a.MaDG,c.MaSach,a.NgayHenTra,c.NgayTra,c.TinhTrangSach,c.TinhTrangTra,c.User,c.GhiChu FROM ctpm c,phieumuon a where a.MaPM=c.MaPM HAVING c.MaPM=@mapm and c.MaSach=@masach  ";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mapm", id);
                cmd.Parameters.AddWithValue("masach", masach);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["NgayTra"].ToString().Length == 0)
                        {
                            pt.MaPM = reader["MaPM"].ToString();
                            pt.MaDG = reader["MaDG"].ToString();
                            pt.MaSach = reader["MaSach"].ToString();
                            pt.NgayHenTra = DateTime.Parse(reader["NgayHenTra"].ToString());
                            pt.NgayTra = (DateTime?)null;
                            pt.TinhTrangSach = int.Parse(reader["TinhTrangSach"].ToString());
                            pt.TinhTrangTra = (int?)null;
                            pt.User = reader["User"].ToString();
                            pt.GhiChu = reader["GhiChu"].ToString();

                        }
                    }

                }
            }
            return pt;
        }
        public int UpdateTienPhat(PhieuMuonInCTPM pt)
        {
            int soluongsach = 0;
            int TongSoNgay = 0;
            int time = 0;
            double tienphat = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "Select c.MaPM,c.MaSach, a.NgayHenTra,c.NgayTra,c.TinhTrangSach,c.TinhTrangTra FROM ctpm c,phieumuon a where a.MaPM=c.MaPM HAVING c.MaPM=@mapm and c.MaSach=@masach ";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mapm", pt.MaPM);
                cmd.Parameters.AddWithValue("masach", pt.MaSach);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int a = int.Parse(reader["TinhTrangSach"].ToString());
                        int b = int.Parse(reader["TinhTrangTra"].ToString());
                        
                        time = a - b;
                        DateTime ngaytra = DateTime.Parse(reader["NgayTra"].ToString());
                        DateTime ngayhentra = DateTime.Parse(reader["NgayHenTra"].ToString());
                        TimeSpan Time = ngaytra - ngayhentra;
                        TongSoNgay = Time.Days;
                        if (time > 0 && TongSoNgay > 0)
                        {
                            tienphat = time * 1000 + TongSoNgay * 5000;
                        }
                        if (time > 0 && TongSoNgay <= 0)
                        {
                            tienphat = time * 1000;
                        }
                        if (time == 0 && TongSoNgay > 0)
                        {
                            tienphat = TongSoNgay * 5000;
                        }
                        if (int.Parse(reader["TinhTrangTra"].ToString()) == 0)
                        {
                            using (MySqlConnection conn1 = GetConnection())
                            {
                                conn1.Open();
                                var str1 = "Select GiaTien from sach where MaSach=@masach";
                                MySqlCommand cmd1 = new MySqlCommand(str1, conn1);
                                cmd1.Parameters.AddWithValue("MaSach", pt.MaSach);
                                using (var reader1 = cmd1.ExecuteReader())
                                {
                                    while (reader1.Read())
                                    {
                                        tienphat = double.Parse(reader1["GiaTien"].ToString());
                                    }

                                }
                            }
                        }
                        
                        if (pt.TinhTrangTra != 0)
                        {
                            using (MySqlConnection conn3 = GetConnection())
                            {
                                conn3.Open();
                                var str3 = "Select SoLuong from sach where MaSach=@masach";
                                MySqlCommand cmd3 = new MySqlCommand(str3, conn3);
                                cmd3.Parameters.AddWithValue("MaSach", pt.MaSach);
                                using (var reader3 = cmd3.ExecuteReader())
                                {
                                    while (reader3.Read())
                                    {
                                        soluongsach = int.Parse(reader3["SoLuong"].ToString());
                                    }

                                }
                            }
                            using (MySqlConnection conn2 = GetConnection())
                            {
                                conn2.Open();
                                var str2 = "update sach set SoLuong=@soluong where MaSach=@masach";
                                MySqlCommand cmd2 = new MySqlCommand(str2, conn2);
                                cmd2.Parameters.AddWithValue("soluong", soluongsach + 1);
                                cmd2.Parameters.AddWithValue("masach", pt.MaSach);
                                cmd2.ExecuteNonQuery();
                            }
                        }
                       
                        else
                        {
                            int matsach = 0;
                            using (MySqlConnection conn3 = GetConnection())
                            {
                                conn3.Open();
                                var str3 = "Select MatSach from docgia where MaDG=@madg";
                                MySqlCommand cmd3 = new MySqlCommand(str3, conn3);
                                cmd3.Parameters.AddWithValue("madg", pt.MaDG);
                                using (var reader3 = cmd3.ExecuteReader())
                                {
                                    while (reader3.Read())
                                    {
                                        matsach = int.Parse(reader3["MatSach"].ToString());
                                    }

                                }
                            }
                            using (MySqlConnection conn4 = GetConnection())
                            {
                                conn4.Open();
                                var str4 = "update docgia set MatSach=@matsach where MaDG=@madg";
                                MySqlCommand cmd4 = new MySqlCommand(str4, conn4);
                                cmd4.Parameters.AddWithValue("matsach", matsach+1);
                                cmd4.Parameters.AddWithValue("madg", pt.MaDG);
                                cmd4.ExecuteNonQuery();
                            }
                        }

                    }
                }
            }

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update ctpm set TienPhat=@TienPhat where MaPM=@MaPM and MaSach=@MaSach";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("TienPhat", tienphat);
                cmd.Parameters.AddWithValue("MaPM", pt.MaPM);
                cmd.Parameters.AddWithValue("MaSach", pt.MaSach);
                return (cmd.ExecuteNonQuery());
            }
        }
        public List<CTPM> GetPhieuTraByMaPM(string id)
        {
            List<CTPM> list = new List<CTPM>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from ctpm where MaPM=@mapm", conn);
                cmd.Parameters.AddWithValue("mapm", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        if (reader["Ngaytra"].ToString().Length != 0)
                        {
                            list.Add(new CTPM()
                            {
                                MaPM = reader["MaPM"].ToString(),
                                MaSach = reader["MaSach"].ToString(),
                                NgayTra = DateTime.Parse(reader["NgayTra"].ToString()),
                                TinhTrangSach = int.Parse(reader["TinhTrangSach"].ToString()),
                                TinhTrangTra = int.Parse(reader["TinhTrangTra"].ToString()),
                                User = reader["User"].ToString(),
                                GhiChu = reader["GhiChu"].ToString(),
                                TienPhat = double.Parse(reader["TienPhat"].ToString()),

                            });
                        }
                        else
                        {
                            list.Add(new CTPM()
                            {
                                MaPM = reader["MaPM"].ToString(),                              
                                MaSach = reader["MaSach"].ToString(),                               
                                NgayTra = (DateTime?)null,
                                TinhTrangSach = int.Parse(reader["TinhTrangSach"].ToString()),
                                TinhTrangTra = (int?)null,
                                User = reader["User"].ToString(),
                                GhiChu = reader["GhiChu"].ToString(),
                            });
                        }


                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public int Login(string id, string pass)
        {
            List<TaiKhoan> list = new List<TaiKhoan>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from taikhoan ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TaiKhoan()
                        {
                            User = reader["User"].ToString(),
                            PassWord = reader["PassWord"].ToString(),
                            PhanQuyen = int.Parse(reader["PhanQuyen"].ToString()),
                            TenND = reader["TenND"].ToString(),
                            SDT = reader["SDT"].ToString(),
                            CMND = reader["CMND"].ToString(),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            foreach (TaiKhoan tk in list)
            {
                if (string.Compare(id, tk.User, false) == 0)
                {
                    if (string.Compare(pass, tk.PassWord, false) == 0)
                    {
                        if (tk.PhanQuyen == 1)
                            return 1;
                        else return 0;
                    }
                }
            }
            return -1;
        }
        public int DoiMK(DoiMK s)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update taikhoan set  PassWord=@PassWord where User=@User";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("PassWord", s.PassWord);
                cmd.Parameters.AddWithValue("User", s.User);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int DemSach()
        {
            int soluongsach1 = 0;
            List<Sach> list = new List<Sach>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from SACH ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        soluongsach1++;
                        list.Add(new Sach()
                        {
                            MaSach = reader["MaSach"].ToString(),
                            TenSach = reader["TenSach"].ToString(),
                            TenTG = reader["TenTG"].ToString(),
                            NhaXB = reader["NhaXB"].ToString(),
                            TheLoai = reader["TheLoai"].ToString(),
                            SoLuong = int.Parse(reader["SoLuong"].ToString()),
                            GiaTien = double.Parse(reader["GiaTien"].ToString()),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return soluongsach1;

        }
        public int DemDocGia()
        {
            int soluong = 0;
            List<DocGia> list = new List<DocGia>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from docgia ", conn);

                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        soluong++;
                        list.Add(new DocGia()
                        {
                            MaDG = reader["MaDG"].ToString(),
                            TenDG = reader["TenDG"].ToString(),
                            SDT = reader["SDT"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            MatSach = int.Parse(reader["MatSach"].ToString()),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return soluong;
        }
        public int DemPhieuMuon()
        {
            int soluongphieumuon = 0;
            List<PhieuMuon> list = new List<PhieuMuon>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from phieumuon ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        soluongphieumuon++;
                        list.Add(new PhieuMuon()
                        {
                            MaPM = reader["MaPM"].ToString(),
                            MaDG = reader["MaDG"].ToString(),
                            NgayMuon = DateTime.Parse(reader["NgayMuon"].ToString()),
                            NgayHenTra = DateTime.Parse(reader["NgayHenTra"].ToString()),
                            SoLuongMuon = int.Parse(reader["SoLuongMuon"].ToString()),
                            User = reader["User"].ToString(),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return soluongphieumuon;
        }
        public int DemPhieuTra()
        {
            List<CTPM> list = new List<CTPM>();
            int soluongphieutra = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from ctpm ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        if (reader["Ngaytra"].ToString().Length == 0)
                        {
                            list.Add(new CTPM()
                            {
                                MaPM = reader["MaPM"].ToString(),
                                MaSach = reader["MaSach"].ToString(),
                                NgayTra = (DateTime?)null,
                                TinhTrangSach = int.Parse(reader["TinhTrangSach"].ToString()),
                                TinhTrangTra = (int?)null,
                                User = reader["User"].ToString(),
                                GhiChu = reader["GhiChu"].ToString(),
                                TienPhat = (double?)null,

                            });
                        }
                        else
                        {
                            soluongphieutra++;
                            list.Add(new CTPM()
                            {
                                
                                 MaPM = reader["MaPM"].ToString(),
                                MaSach = reader["MaSach"].ToString(),
                                NgayTra = DateTime.Parse(reader["NgayTra"].ToString()),
                                TinhTrangSach = int.Parse(reader["TinhTrangSach"].ToString()),
                                TinhTrangTra = int.Parse(reader["TinhTrangTra"].ToString()),
                                User = reader["User"].ToString(),
                                GhiChu = reader["GhiChu"].ToString(),
                                TienPhat = double.Parse(reader["TienPhat"].ToString()),

                            });
                        }


                    }
                    reader.Close();
                }
                conn.Close();
            }
            return soluongphieutra;
        }
        public int DemPhieuChuaTra()
        {
            List<PhieuMuonInCTPM> list = new List<PhieuMuonInCTPM>();
            int soluongphieuchuatra = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Select c.MaPM,a.MaDG,c.MaSach,a.NgayHenTra,c.NgayTra,c.TinhTrangSach,c.TinhTrangTra,c.User,c.GhiChu FROM ctpm c,phieumuon a where a.MaPM=c.MaPM ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["Ngaytra"].ToString().Length == 0)
                        {
                            soluongphieuchuatra++;
                            list.Add(new PhieuMuonInCTPM()
                            {
                                MaPM = reader["MaPM"].ToString(),
                                MaDG = reader["MaDG"].ToString(),
                                MaSach = reader["MaSach"].ToString(),
                                NgayHenTra = DateTime.Parse(reader["NgayHenTra"].ToString()),
                                NgayTra = (DateTime?)null,
                                TinhTrangSach = int.Parse(reader["TinhTrangSach"].ToString()),
                                TinhTrangTra = (int?)null,
                                User = reader["User"].ToString(),
                                GhiChu = reader["GhiChu"].ToString(),
                            });
                        }
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return soluongphieuchuatra;
        }
        public double DemDoanhThu()
        {
            double tong = 0;
          
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from ctpm ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {                                        
                        if (reader["Ngaytra"].ToString().Length != 0)
                        {
                            tong = tong + double.Parse(reader["TienPhat"].ToString());
                        }
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return tong;
        }
    }
}
