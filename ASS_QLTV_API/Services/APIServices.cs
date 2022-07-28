using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ASS_QLTV_API.Models;
using Newtonsoft.Json;

namespace ASS_QLTV_API.Services
{
    public class APIServices
    {
        public string GetDataFromAPI(string uri, string requestUri)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var jsonConnect = client.GetAsync(requestUri).Result;
                string jsonData = jsonConnect.Content.ReadAsStringAsync().Result;
                return jsonData;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public string GetDataFromAPIById(string uri, string requestUri, string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var jsonConnect = client.GetAsync(requestUri + "/" + id).Result;
                string jsonData = jsonConnect.Content.ReadAsStringAsync().Result;
                return jsonData;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public int DeleteData(string uri, string requestUri, string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var result = client.DeleteAsync(requestUri + "/" + id).Result;
                if(result.IsSuccessStatusCode)
                    return 1;
                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int PostUser(string uri, Taikhoan tk)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var newPostJson = JsonConvert.SerializeObject(tk);
                var payLoad = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(uri, payLoad).Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    return 1;
                }
                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int PostDocGia(string uri, Docgium docgium)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var newPostJson = JsonConvert.SerializeObject(docgium);
                var payLoad = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(uri, payLoad).Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    return 1;
                }
                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int PostSach(string uri, Sach sach)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var newPostJson = JsonConvert.SerializeObject(sach);
                var payLoad = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(uri, payLoad).Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    return 1;
                }
                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int PostPhieuMuon(string uri, Phieumuon phieumuon)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var data = GetDataFromAPIById("https://localhost:44301/", "api/Docgiums", phieumuon.MaDg);
                Docgium dg = JsonConvert.DeserializeObject<Docgium>(data);
                if (dg.MatSach >= 3)
                    return 100;
                var newPostJson = JsonConvert.SerializeObject(phieumuon);
                var payLoad = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(uri, payLoad).Result;
                if (result.IsSuccessStatusCode)
                {
                    var d = result.Content.ReadAsStringAsync().Result;
                    return 1;
                }
                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int PostCtPhieuMuon(string uri, Ctpm ctpm)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var d = GetDataFromAPI("https://localhost:44301/", "api/Ctpms");
                List<Ctpm> ct = JsonConvert.DeserializeObject<List<Ctpm>>(d);
                if (ct.Any(c => c.MaPm == ctpm.MaPm && c.MaSach == ctpm.MaSach))
                {
                    return 100;
                }

                var newPostJson = JsonConvert.SerializeObject(ctpm);
                var payLoad = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(uri, payLoad).Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    return 1;
                }
                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int PutUser(string uri,Taikhoan tk)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var newPutJson = JsonConvert.SerializeObject(tk);
                var payLoad = new StringContent(newPutJson, Encoding.UTF8, "application/json");
                var result = client.PutAsync(uri + "/" + tk.User, payLoad).Result.Content.ReadAsStringAsync().Result;
                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int PutDG(string uri, Docgium dg)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var newPutJson = JsonConvert.SerializeObject(dg);
                var payLoad = new StringContent(newPutJson, Encoding.UTF8, "application/json");
                var result = client.PutAsync(uri + "/" + dg.MaDg, payLoad).Result.Content.ReadAsStringAsync().Result;
                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int PutSach(string uri, Sach sach)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var newPutJson = JsonConvert.SerializeObject(sach);
                var payLoad = new StringContent(newPutJson, Encoding.UTF8, "application/json");
                var result = client.PutAsync(uri + "/" + sach.MaSach, payLoad).Result.Content.ReadAsStringAsync().Result;
                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int PutPhieuMuon(string uri, Phieumuon pm)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var newPutJson = JsonConvert.SerializeObject(pm);
                var payLoad = new StringContent(newPutJson, Encoding.UTF8, "application/json");
                var result = client.PutAsync(uri + "/" + pm.MaPm, payLoad).Result.Content.ReadAsStringAsync().Result;
                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int PutCtPhieuMuon(string uri, Ctpm ct)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var newPutJson = JsonConvert.SerializeObject(ct);
                var payLoad = new StringContent(newPutJson, Encoding.UTF8, "application/json");
                var result = client.PutAsync(uri + "/" + ct.MaCtpm, payLoad).Result.Content.ReadAsStringAsync().Result;
                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int Login(string username, string password)
        {
            try
            {
                var data= GetDataFromAPI("https://localhost:44301/", "api/Taikhoans");
                List<Taikhoan> accList = JsonConvert.DeserializeObject<List<Taikhoan>>(data);
                var acc = accList.FirstOrDefault(acc => acc.User == username && acc.Password == password);
                if (acc is {PhanQuyen: 1})
                {
                    return 1;
                }
                else if(acc is { PhanQuyen: 2})
                {
                    return 0;
                }
                return -1;
            }
            catch (Exception )
            {
                return -1;
            }
        }

        public int ChangePass(string username, string newPass)
        {
            try
            {
                var data = GetDataFromAPIById("https://localhost:44301/", "api/Taikhoans", username);
                Taikhoan tk = JsonConvert.DeserializeObject<Taikhoan>(data);
                tk.Password = newPass;
                return PutUser("https://localhost:44301/api/Taikhoans", tk);
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}
