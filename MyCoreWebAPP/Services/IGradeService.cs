using Microsoft.AspNetCore.Mvc;
using MyCoreWebAPP.Models;
namespace MyCoreWebAPP.Services;

public interface IGradeService
{
    Task<List<Grade>> GetAllGrades();
    Task<Grade> GetGradeById(int grdId);
    Task<int> UpdateGrade(int id,Grade grd);
    Task<int> AddGrade(Grade grade);
    Task<int> DeleteGrade(int grdId);
}
