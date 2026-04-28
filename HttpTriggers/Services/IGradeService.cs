using HttpTriggers.Models;
using Microsoft.AspNetCore.Mvc;
namespace HttpTriggers.Services;

public interface IGradeService
{
    Task<List<Grade>> GetAllGrades();

    //Task<Grade> GetGradeById(int grdId);
    //Task<int> UpdateGrade(int id,Grade grd);
    //Task<int> AddGrade(Grade grade);
    //Task<int> DeleteGrade(int grdId);
}
