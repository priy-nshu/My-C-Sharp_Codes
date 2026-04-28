using HttpTriggers.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HttpTriggers.Services
{
    public class GradeService: IGradeService
    {
        //private readonly IHttpClientFactory httpClient;
        //private readonly string baseUrl = "https://localhost:7133/api/Grade/";
        private readonly SchoolDBContext dBContext;
        public GradeService(SchoolDBContext dBContext)
        {
            this.dBContext=dBContext;
        }

        public async Task<List<Grade>> GetAllGrades()
        {
            //var client = httpClient.CreateClient();
            //client.BaseAddress = new Uri(baseUrl);
            List<Grade> grades;

            try
            {
                grades = await dBContext.Grades.ToListAsync();
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
            return grades??null;
        }

        //public async Task<int> AddGrade(Grade grade)
        //{
        //    var client = httpClient.CreateClient();
        //    client.BaseAddress = new Uri(baseUrl);

        //    try
        //    {
        //        var response = await client.PostAsJsonAsync($"addgrade",grade);
        //        response.EnsureSuccessStatusCode();//throws exception if not successful

        //        //Read the respone content
        //        //string json = await response.Content.ReadAsStringAsync();
        //        ////Deserilizes the respone
        //        //int result = JsonConvert.DeserializeObject<int>(json);

        //        return 1;
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        throw ex;
        //    }

        //}
        //public async Task<Grade> GetGradeById(int gradeId)
        //{
        //    Grade grd = null;
        //    var client = httpClient.CreateClient();
        //    client.BaseAddress = new Uri(baseUrl);

        //    try
        //    {
        //        var response = await client.GetAsync($"GetGradeById/{ gradeId}");
        //        response.EnsureSuccessStatusCode();//throws exception if not successful

        //        //Read the respone content
        //        string json = await response.Content.ReadAsStringAsync();
        //        //Deserilizes the respone
        //        grd = JsonConvert.DeserializeObject<Grade>(json);

        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        throw ex;
        //    }
        //    return grd;
        //}

        //public async Task<int> UpdateGrade(int id,Grade grd)
        //{
        //    var client = httpClient.CreateClient();
        //    client.BaseAddress = new Uri(baseUrl);
        //    try
        //    {
        //        HttpResponseMessage response = await client.PutAsJsonAsync($"UpdateGrade/{id}", grd);
        //        response.EnsureSuccessStatusCode();

        //        string json = await response.Content.ReadAsStringAsync();
        //        int result = JsonConvert.DeserializeObject<int>(json);

        //        return result;
        //    }catch (HttpRequestException ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<int> DeleteGrade(int id)
        //{
        //    var client = httpClient.CreateClient();
        //    client.BaseAddress = new Uri(baseUrl);
        //    try
        //    {
        //        HttpResponseMessage response = await client.DeleteAsync($"DeleteGrade/{id}");
        //        response.EnsureSuccessStatusCode();
        //        //string json = await response.Content.ReadAsStringAsync();
        //        //int result = JsonConvert.DeserializeObject<int>(json);
        //        return 1                  ;
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
