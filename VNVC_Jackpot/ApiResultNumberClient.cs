using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace VNVC_Jackpot
{
    public class ApiResultNumberClient
    {
        private string _api ;
        private readonly HttpClient httpClient;

        public ApiResultNumberClient() {
            _api =  "http://localhost:8000/jackpot/";
            httpClient = new HttpClient();  
        }

        public string GetApiResponse(string url)
        {
            string responseText = string.Empty;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_api + url);
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        if (stream != null)
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                responseText = reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show($"Lỗi khi gọi API: {ex.Message}");
            }

            return responseText;
        }
        public async Task<JsonElement> GetBySize(int size)
        {
            HttpResponseMessage response = await httpClient.GetAsync(_api + "size/" + size.ToString());
            string responseContent = await response.Content.ReadAsStringAsync();
            JsonDocument jsonDocument = JsonDocument.Parse(responseContent);
            return jsonDocument.RootElement;
            
        }
        public async Task<JsonElement> GetNumberStat()
        {
            HttpResponseMessage response = await httpClient.GetAsync(_api + "stats/number_stats/");
            string responseContent = await response.Content.ReadAsStringAsync();
            JsonDocument jsonDocument = JsonDocument.Parse(responseContent);
            return jsonDocument.RootElement;

        }
        public async Task<JsonElement> GetNumberStatWin() { 
            HttpResponseMessage response = await httpClient.GetAsync(_api + "stats/number_stats_win/");
            string responseContent = await response.Content.ReadAsStringAsync();
            JsonDocument jsonDocument = JsonDocument.Parse(responseContent);
            return jsonDocument.RootElement;

        }
        public async Task<string> CreateJackPot(int user_id , int slot,  int number)
        {
            string jsonData = "{" +
                        "\"user\": " + user_id.ToString() + "," +
                        "\"slot\": " + slot.ToString() + "," +
                        "\"number\": " + number.ToString() + "" +
                     "}";
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(_api, content);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else
            {
                throw new Exception($"Failed to send POST request. Status code: {response.StatusCode}");
            }
        }
    }
}
