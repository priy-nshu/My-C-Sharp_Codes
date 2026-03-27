using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

    internal class JoinFunctions
    {
    public List<Standard> StandardList;
    public List<Student> StudentList;
    public Student std=new Student();
    public Standard strd=new Standard();

    public void PerformJoin()
    {
        StudentList = std.GetStudents();
        StandardList = strd.CreateStandards();

        //Join Function

        var methodSyntax1 = StandardList.Join(StudentList,

            s1 => s1.StandardID,
            s2 => s2.StandardID,
            (s1, s2) => new { s2.Id, s2.Name, s1.StandardName });

        foreach (var ss in methodSyntax1)
        {
            Console.WriteLine($"Student ID:{ss.Id}, Name: {ss.Name}, Standard Name: {ss.StandardName}");
        }
        Console.WriteLine();
        //Group Join Function

           var methodSyntax2 = StandardList.GroupJoin(StudentList,

            s1 => s1.StandardID,
            s2 => s2.StandardID,
            (s1, StudentGroup) => new { Students=StudentGroup,StandardNm= s1.StandardName });
        Console.WriteLine(methodSyntax2.Count()+"\n");
        foreach (var ss in methodSyntax2)
        {
            Console.WriteLine($"Standard Name :{ss.StandardNm}");
            foreach (var ss2 in ss.Students)
            {
                Console.WriteLine($"Student: {ss2.Name}, Age: {ss2.Age}");
            }
        }
    }
}


