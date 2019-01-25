using System;
using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Collections.ObjectModel;


namespace SolarLunarName.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                

                InitialSessionState initial = InitialSessionState.CreateDefault();
                initial.ImportPSModule(new[] { @"C:\Users\Craig\Source\Repos\SolarLunarName\C#\SolarLunarName\SolarLunarName.PoSH\bin\Debug\netstandard2.0\SolarLunarName.PoSH.dll" });
                Runspace runspace = RunspaceFactory.CreateRunspace(initial);
                runspace.Open();
                RunspaceInvoke invoker = new RunspaceInvoke(runspace);
                Collection<PSObject> results = invoker.Invoke("Get-Date | Get-SolarLunarName -debug");


                Console.ReadKey();
            }

            
        }
    }
}