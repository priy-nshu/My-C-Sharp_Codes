using MyCoreWebAPP.Models;
using Newtonsoft.Json;

namespace MyCoreWebAPP.Services
{
    public class GradeService:  IGradeService
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



    }
}
