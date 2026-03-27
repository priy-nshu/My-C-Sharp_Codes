using System;
using System.Collections;

internal class Assignment1
{
    public void MySortedlist() {
        Employee employee1 = new Employee() { EmpId=001, EmpName="A", EmpDept="IT", Salary=60000 };
        Employee employee2 = new Employee() { EmpId = 002, EmpName = "B", EmpDept = "HR", Salary = 65000 };

        SortedList<int,Employee> sl= new SortedList<int, Employee> 
        {
            {employee1.EmpId, employee1 },
            {employee2.EmpId,employee2 }
        };
        Employee employee3 = new Employee() { EmpId = 003, EmpName = "C", EmpDept = "Finance", Salary = 55000 };
        Employee employee4 = new Employee (){ EmpId = 004, EmpName = "D", EmpDept = "Marketing", Salary = 58000 };

        sl.Add(employee3.EmpId, employee3);
        sl.Add(employee4.EmpId, employee4);

        Console.WriteLine("ForEach Block:\n");
        foreach (var i in sl) 
        {
            Console.WriteLine($"ID: {i.Value.EmpId} ," +
                $" Name: {i.Value.EmpName}," +
                $" Department: { i.Value.EmpDept}," +
                $" Salary: {i.Value.Salary} ");
         }

        Console.WriteLine("\nFor Block:\n");
        for (int i = 0; i < sl.Count; i++)
        {
            Console.WriteLine($"ID: {sl.Values[i].EmpId} ," +
                $" Name: {sl.Values[i].EmpName}," +
                $" Department: {sl.Values[i].EmpDept}," +
                $" Salary: {sl.Values[i].Salary} ");
        }
    }
}

class Employee
{
    public int EmpId { get; set; }
    public string EmpName { get; set; }
    public string EmpDept { get; set; }
    public int Salary { get; set; }
}