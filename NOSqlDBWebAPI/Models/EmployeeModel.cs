namespace NOSqlDBWebAPI.Models
{
    public class EmployeeModel
    {
        public string? EmployeeId { get; set; }
        public Name? EmployeeName { get; set; }=null;
        public string? Email {  get; set; }
        public Department EmpDepartment {  get; set; }
    }
}
