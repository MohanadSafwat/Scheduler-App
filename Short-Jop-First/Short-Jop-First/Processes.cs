using System;
using System.Collections.Generic;
using System.Text;

namespace Short_Jop_First
{
    class Processes
    {
        private string Type_Of_schedular;
        private int No_of_processes;
        private double[] cpu_burst_time = new double[100];
        private string[] temp = new string[100];
        private int[] temp2 = new int[100];
        private double[] temp4 = new double[100];
        private double result=0;
        private double temp1 = 0;
        



        public Processes(string aType_Of_schedular, int aNo_of_processes)
        {
            Type_Of_schedular = aType_Of_schedular;
            No_of_processes = aNo_of_processes;
        }
        public void entering_data()
        {
            for (int i = 0; i < No_of_processes; i++)
            {
                Console.Write("please enter The burst time Of process " + (i + 1) + ": ");
                cpu_burst_time[i] = Convert.ToDouble(Console.ReadLine());
                temp[i] = Convert.ToString(cpu_burst_time[i]) + "+" + Convert.ToString((i + 1));
            }
        }
        public void arrange_process()
        {
            for (int i = 0; i < No_of_processes; i++)
            {
                for (int j = i + 1; j < No_of_processes; j++)
                {
                    if (cpu_burst_time[i] > cpu_burst_time[j])
                    {
                        temp1 = cpu_burst_time[i];
                        cpu_burst_time[i] = cpu_burst_time[j];
                        cpu_burst_time[j] = temp1;

                    }

                }
               
                for (int j = 0; j < No_of_processes; j++)
                {
                    if (cpu_burst_time[i] == Convert.ToDouble(temp[j].Substring(0, temp[j].IndexOf("+"))))
                    {
                        temp2[i] = Convert.ToInt32(temp[j].Substring(temp[j].IndexOf("+")));
                    }
                }
            }
        }

        public void Calc_printing() 
        {
            

            for (int i=0;i<No_of_processes;i++)
            {
                temp4[0] = 0;
                 temp4[i+1]=temp4[i]+ cpu_burst_time[i];


                Console.Write("process " + temp2[i]+'\n');
                Console.Write("From "+ temp4[i] + "      To "+ temp4[i+1] +'\n' );
            }

        }
        
        public double averge_wait() 
        {
            for (int i = 0; i < No_of_processes; i++)
            {
                result=result+temp4[i];   
            }
            return (result/(No_of_processes));
        }
    }
}
        





    

