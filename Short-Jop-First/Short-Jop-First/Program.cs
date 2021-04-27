using System;

namespace Short_Jop_First
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please Enter The Type of Schedular : ");
            string y = Console.ReadLine();
            Console.Write("Please Enter The No. of Processes : ");
            int x = Convert.ToInt32( Console.ReadLine());
            Processes mainprocess = new Processes(y,x);
            mainprocess.entering_data();
            mainprocess.arrange_process();
            mainprocess.Calc_printing();
            Console.Write("The average waiting time is : "+mainprocess.averge_wait());
        }
    }
}
