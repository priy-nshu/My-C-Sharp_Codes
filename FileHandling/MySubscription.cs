using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MySubscription 
{
    public void MyProcess()
    {
        ProcessBussinessLogic bussinessLogic = new ProcessBussinessLogic();
        bussinessLogic.ProcessCompleted += bl_ProcessCompleted;
        bussinessLogic.StartProcess();
    }
    public static void bl_ProcessCompleted(object sender,EventArgs eA)
    {
        Console.WriteLine($"Notification: Process Completed by: {sender}");
    }
}
