using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void Notify(object t,EventArgs e); //delegate
public class ProcessBussinessLogic
{
    public event Notify ProcessCompleted;
    public void StartProcess()
    {
        Console.WriteLine("Process Started");
        Console.WriteLine("Publisher Process Completed!");
        OnProcessCompleted(EventArgs.Empty);
    }
    protected virtual void OnProcessCompleted(EventArgs e) 
    { //if ProcessCompleted is not null then call Delegate
        ProcessCompleted?.Invoke(this,e);
    }

}
