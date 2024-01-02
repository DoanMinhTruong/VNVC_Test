using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNVC_Jackpot
{
    public class ApiUserClient
    {
        private string _api;
        private readonly HttpClient httpClient;

        public ApiUserClient()
        {
            _api = "http://localhost:8000/user/";
            httpClient = new HttpClient();
        }
        public async Task<bool> CheckExistUser(string phone_number)
        {
            HttpResponseMessage response = await httpClient.GetAsync(_api + phone_number);
            return response.IsSuccessStatusCode;
        }
        public async Task<int> GetUserId(string phone_number)
        {
            HttpResponseMessage response = await httpClient.GetAsync(_api + phone_number);
            string responseContent = await response.Content.ReadAsStringAsync();
            JsonDocument jsonDocument = JsonDocument.Parse(responseContent);
            JsonElement root = jsonDocument.RootElement;

            int id = root.GetProperty("id").GetInt32();
            return id;
        }
        public async Task<string> Register(string phone_number , string name, string birth_date)
        {
            string jsonData = "{" +
                        "\"phone_number\": \"" + phone_number + "\"," +
                        "\"name\": \"" + name + "\"," +
                        "\"birth_date\": \"" + birth_date + "\"" +
                     "}";
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(_api , content);

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
