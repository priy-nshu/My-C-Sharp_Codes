using MyCoreWebAPP.Models;
using Newtonsoft.Json;

namespace MyCoreWebAPP.Services
{
    public class GradeService: IGradeService
    {
        private readonly IHttpClientFactory httpClient;
        private readonly string baseUrl = "https://localhost:7133/api/Grade/";

        public GradeService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Grade>> GetAllGrades()
        {
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(baseUrl);
            List<Grade> grades = null;

            try
            {
                var response = await client.GetAsync("getallgrades");
                response.EnsureSuccessStatusCode();//throws exception if not successful

                //Read the respone content
                string json = await response.Content.ReadAsStringAsync();
                //Deserilizes the respone
                grades = JsonConvert.DeserializeObject<List<Grade>>(json);
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
            return grades;
        }

        public async Task<int> AddGrade(Grade grade)
        {
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(baseUrl);

            try
            {
                var response = await client.PostAsJsonAsync($"addgrade",grade);
                response.EnsureSuccessStatusCode();//throws exception if not successful

                ////Read the respone content
                //string json = await response.Content.ReadAsStringAsync();
                ////Deserilizes the respone
                //int result = JsonConvert.DeserializeObject<int>(json);

                return 1;
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }

        }

    }
}
