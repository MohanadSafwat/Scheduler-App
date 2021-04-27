using System;
using System.Collections.Generic;

namespace SchedularApp
{
    class Program
    {



        public static void Main()
        {
            int numberOfProcesses, preemtiveBool, numberOfRemainProcesses, priorityBool;
            Console.WriteLine("Please enter 1 if priority and 0 if sjf");
            priorityBool = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter 0 if Non Preemptive and 1 if Preemptive");
            preemtiveBool = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter number of the processes");
            numberOfProcesses = Convert.ToInt32(Console.ReadLine());

            Process[] ProcessesArr = new Process[numberOfProcesses];
            numberOfRemainProcesses = numberOfProcesses;

            double[,] timeLine = new double[200, 3];
            int countTimeLine = 0;

            if (priorityBool == 0)
            {
                for (int i = 0; i < numberOfProcesses; i++)
                {
                    int arrival, burst;
                    Console.WriteLine("Please enter arrival time of process " + (i + 1));

                    arrival = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Please enter burst time of process " + (i + 1));
                    burst = Convert.ToInt32(Console.ReadLine());

                    

                    ProcessesArr[i] = new Process(arrival, burst);

                }
            }
            else
            {


                //for (int i = 0; i < numberOfProcesses; i++)
                //{
                //    int arrival, burst, priority;
                //    Console.WriteLine("Please enter arrival time of process " + (i + 1));

                //    arrival = Convert.ToInt32(Console.ReadLine());

                //    Console.WriteLine("Please enter burst time of process " + (i + 1));
                //    burst = Convert.ToInt32(Console.ReadLine());

                //    Console.WriteLine("Please enter priority of process " + (i + 1));
                //    priority = Convert.ToInt32(Console.ReadLine());

                //    ProcessesArr[i] = new Process(arrival, burst, priority);

                //}
            }
            ProcessesArr[0] = new Process(0, 1, 2);
            ProcessesArr[1] = new Process(1, 7, 6);
            ProcessesArr[2] = new Process(2, 3, 3);
            ProcessesArr[3] = new Process(3, 6, 5);
            ProcessesArr[4] = new Process(4, 5, 4);
            ProcessesArr[5] = new Process(5, 15, 10);
            ProcessesArr[6] = new Process(6, 8, 9);

            Process firstProcess = new Process();
            Process nextProcess = new Process();
            Process inProcess = new Process();


            int numberOfFirstProcess = 0;
            int numberOfNextProcess = 0;
            int numberOfInProcess = 0;

            double[] arrivalTimes = new double[numberOfProcesses];
            int countUniqueArray = 0;

            for (int i = 0; i < arrivalTimes.Length; i++)
            {
                arrivalTimes[i] = ProcessesArr[i].Arrival;
            }
            for (int i = 0; i < arrivalTimes.Length; i++)
            {
                bool isDuplicate = false;
                for (int j = 0; j < i; j++)
                {
                    if (arrivalTimes[i] == arrivalTimes[j])
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    countUniqueArray++;

                }
            }
            double[] arrivalTimesUnique = new double[countUniqueArray];
            countUniqueArray = 0;

            for (int i = 0; i < arrivalTimes.Length; i++)
            {
                bool isDuplicate = false;
                for (int j = 0; j < i; j++)
                {
                    if (arrivalTimes[i] == arrivalTimes[j])
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    arrivalTimesUnique[countUniqueArray] = arrivalTimes[i];
                    countUniqueArray++;

                }
            }

            Array.Sort(arrivalTimesUnique);

            double timeNow = arrivalTimesUnique[0];
            firstProcess = ProcessesArr[0];

            //for (int i = 0; i < arrivalTimesUnique.Length; i++)
            //{
            //    Console.WriteLine(arrivalTimesUnique[i]);
            //}

            if (priorityBool == 1)
            {

                if (preemtiveBool == 0)
                {




                    bool flagNext = true;


                    while (numberOfRemainProcesses > 0)
                    {
                        for (int i = 0; i < numberOfProcesses; i++)
                        {
                            if (ProcessesArr[i].Status != "done" && ProcessesArr[i].Arrival <= timeNow)
                            {

                                if (flagNext)
                                {
                                    nextProcess = ProcessesArr[i];
                                    numberOfNextProcess = i;
                                    flagNext = false;
                                }
                                if (nextProcess.Priority > ProcessesArr[i].Priority)
                                {

                                    nextProcess = ProcessesArr[i];
                                    numberOfNextProcess = i;

                                }
                            }
                        }

                        ProcessesArr[numberOfNextProcess].Execution = timeNow;
                        timeNow += ProcessesArr[numberOfNextProcess].Burst;
                        ProcessesArr[numberOfNextProcess].Departure = timeNow;
                        ProcessesArr[numberOfNextProcess].TurnAround = ProcessesArr[numberOfNextProcess].Departure - ProcessesArr[numberOfNextProcess].Arrival;
                        ProcessesArr[numberOfNextProcess].Status = "done";
                        timeLine[countTimeLine, 0] = numberOfNextProcess;
                        timeLine[ countTimeLine,1] = ProcessesArr[numberOfNextProcess].Execution;
                        timeLine[countTimeLine, 2] = ProcessesArr[numberOfNextProcess].Departure;
                        countTimeLine++;


                        numberOfRemainProcesses--;
                        flagNext = true;
                    }

                }
                else if (preemtiveBool == 1)
                {

                    bool flagNext = true;

                    while (numberOfRemainProcesses > 0)
                    {
                        for (int j = 0; j < arrivalTimesUnique.Length; j++)
                        {
                            for (int i = 0; i < numberOfProcesses; i++)
                            {
                                if (ProcessesArr[i].Status != "done" && ProcessesArr[i].Arrival <= timeNow)
                                {

                                    if (flagNext)
                                    {
                                        inProcess = ProcessesArr[i];
                                        numberOfInProcess = i;
                                        flagNext = false;
                                    }
                                    if (inProcess.Priority > ProcessesArr[i].Priority)
                                    {

                                        inProcess = ProcessesArr[i];
                                        numberOfInProcess = i;

                                    }
                                }
                            }
                            if (String.Compare(ProcessesArr[numberOfInProcess].Status, "waiting") != 0)
                            {
                                ProcessesArr[numberOfInProcess].Execution = timeNow;
                            }
                            if (j == arrivalTimesUnique.Length - 1 && ProcessesArr[numberOfInProcess].Remaining != 0)
                            {
                                j = 0;
                            }
                            if (numberOfRemainProcesses != 1)
                            {
                                if (j != arrivalTimesUnique.Length - 1)
                                {
                                    if (arrivalTimesUnique[j + 1] - arrivalTimesUnique[j] >= ProcessesArr[numberOfInProcess].Remaining)
                                    {
                                        timeLine[countTimeLine, 0] = numberOfInProcess;
                                        timeLine[countTimeLine, 1] = timeNow;
                                        timeNow += ProcessesArr[numberOfInProcess].Remaining;
                                        ProcessesArr[numberOfInProcess].Remaining = 0;
                                        timeLine[countTimeLine, 2] = timeNow;
                                        if (countTimeLine != 0)
                                        {
                                            if (timeLine[countTimeLine - 1, 0] != timeLine[countTimeLine, 0])
                                            {
                                                countTimeLine++;
                                            }
                                        }
                                        else {

                                            countTimeLine++; }
                                        break;
                                    }
                                    else
                                    {
                                        timeLine[countTimeLine, 0] = numberOfInProcess;
                                        timeLine[countTimeLine, 1] = timeNow;
                                        timeNow += arrivalTimesUnique[j + 1] - arrivalTimesUnique[j];
                                        ProcessesArr[numberOfInProcess].Remaining -= arrivalTimesUnique[j + 1] - arrivalTimesUnique[j];
                                        ProcessesArr[numberOfInProcess].Status = "waiting";
                                        timeLine[countTimeLine, 2] = timeNow;
                                        if (countTimeLine != 0)
                                        {
                                            if (timeLine[countTimeLine - 1, 0] != timeLine[countTimeLine, 0])
                                            {
                                                countTimeLine++;
                                            }
                                        }
                                        else {
                                           
                                            countTimeLine++;
                                        }



                                    }
                                }
                            }
                            else
                            {
                                timeLine[countTimeLine, 0] = numberOfInProcess;
                                timeLine[countTimeLine, 1] = timeNow;
                                timeNow += ProcessesArr[numberOfInProcess].Remaining;
                                ProcessesArr[numberOfInProcess].Remaining = 0;
                                timeLine[countTimeLine, 2] = timeNow;
                                countTimeLine++;
                                break;

                            }
                            flagNext = true;


                        }
                        ProcessesArr[numberOfInProcess].Departure = timeNow;
                        ProcessesArr[numberOfInProcess].TurnAround = ProcessesArr[numberOfInProcess].Departure - ProcessesArr[numberOfInProcess].Arrival;
                        ProcessesArr[numberOfInProcess].Status = "done";

                        numberOfRemainProcesses--;
                        flagNext = true;
                    }





                }
            }
            else if (priorityBool == 0)
            {
                if (preemtiveBool == 0)
                {

                    bool flagNext = true;


                    while (numberOfRemainProcesses > 0)
                    {
                        for (int i = 0; i < numberOfProcesses; i++)
                        {
                            if (ProcessesArr[i].Status != "done" && ProcessesArr[i].Arrival <= timeNow)
                            {

                                if (flagNext)
                                {
                                    nextProcess = ProcessesArr[i];
                                    numberOfNextProcess = i;
                                    flagNext = false;
                                }
                                if (nextProcess.Burst > ProcessesArr[i].Burst)
                                {

                                    nextProcess = ProcessesArr[i];
                                    numberOfNextProcess = i;

                                }
                            }
                        }

                        ProcessesArr[numberOfNextProcess].Execution = timeNow;
                        timeNow += ProcessesArr[numberOfNextProcess].Burst;
                        ProcessesArr[numberOfNextProcess].Departure = timeNow;
                        ProcessesArr[numberOfNextProcess].TurnAround = ProcessesArr[numberOfNextProcess].Departure - ProcessesArr[numberOfNextProcess].Arrival;
                        ProcessesArr[numberOfNextProcess].Status = "done";
                        numberOfRemainProcesses--;
                        timeLine[countTimeLine, 0] = numberOfNextProcess;
                        timeLine[countTimeLine, 1] = ProcessesArr[numberOfNextProcess].Execution;
                        timeLine[countTimeLine, 2] = ProcessesArr[numberOfNextProcess].Departure;
                        countTimeLine++;

                        flagNext = true;
                    }
                }
                else if (preemtiveBool == 1)
                {

                    bool flagNext = true;

                    while (numberOfRemainProcesses > 0)
                    {
                        for (int j = 0; j < arrivalTimesUnique.Length; j++)
                        {
                            for (int i = 0; i < numberOfProcesses; i++)
                            {
                                if (ProcessesArr[i].Status != "done" && ProcessesArr[i].Arrival <= timeNow)
                                {

                                    if (flagNext)
                                    {
                                        inProcess = ProcessesArr[i];
                                        numberOfInProcess = i;
                                        flagNext = false;
                                    }
                                    if (inProcess.Burst > ProcessesArr[i].Burst)
                                    {

                                        inProcess = ProcessesArr[i];
                                        numberOfInProcess = i;

                                    }
                                }
                            }
                            if (String.Compare(ProcessesArr[numberOfInProcess].Status, "waiting") != 0)
                            {
                                ProcessesArr[numberOfInProcess].Execution = timeNow;
                            }
                            if (j == arrivalTimesUnique.Length - 1 && ProcessesArr[numberOfInProcess].Remaining != 0)
                            {
                                j = 0;
                            }
                            if (numberOfRemainProcesses != 1)
                            {
                                if (j != arrivalTimesUnique.Length - 1)
                                {
                                    if (arrivalTimesUnique[j + 1] - arrivalTimesUnique[j] >= ProcessesArr[numberOfInProcess].Remaining)
                                    {
                                        timeLine[countTimeLine, 0] = numberOfInProcess;
                                        timeLine[countTimeLine, 1] = timeNow;
                                        timeNow += ProcessesArr[numberOfInProcess].Remaining;
                                        ProcessesArr[numberOfInProcess].Remaining = 0;
                                        timeLine[countTimeLine, 2] = timeNow;
                                        if (countTimeLine != 0)
                                        {
                                            if (timeLine[countTimeLine - 1, 0] != timeLine[countTimeLine, 0])
                                            {
                                                countTimeLine++;
                                            }
                                        }
                                        else
                                        {

                                            countTimeLine++;
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        timeLine[countTimeLine, 0] = numberOfInProcess;
                                        timeLine[countTimeLine, 1] = timeNow;
                                        timeNow += arrivalTimesUnique[j + 1] - arrivalTimesUnique[j];
                                        ProcessesArr[numberOfInProcess].Remaining -= arrivalTimesUnique[j + 1] - arrivalTimesUnique[j];
                                        ProcessesArr[numberOfInProcess].Status = "waiting";
                                        timeLine[countTimeLine, 2] = timeNow;
                                        if (countTimeLine != 0)
                                        {
                                            if (timeLine[countTimeLine - 1, 0] != timeLine[countTimeLine, 0])
                                            {
                                                countTimeLine++;
                                            }
                                        }
                                        else
                                        {

                                            countTimeLine++;
                                        }

                                    }
                                }
                            }
                            else
                            {
                                timeLine[countTimeLine, 0] = numberOfInProcess;
                                timeLine[countTimeLine, 1] = timeNow;
                                timeNow += ProcessesArr[numberOfInProcess].Remaining;
                                ProcessesArr[numberOfInProcess].Remaining = 0;
                                timeLine[countTimeLine, 2] = timeNow;
                                countTimeLine++;
                                break;

                            }

                            flagNext = true;


                        }

                        ProcessesArr[numberOfInProcess].Departure = timeNow;
                        ProcessesArr[numberOfInProcess].TurnAround = ProcessesArr[numberOfInProcess].Departure - ProcessesArr[numberOfInProcess].Arrival;
                        ProcessesArr[numberOfInProcess].Status = "done";


                        numberOfRemainProcesses--;
                        flagNext = true;
                    }
                }

            }
            double[,] timeLineFinal = new double[countTimeLine ,3];
            for (int i = 0; i < countTimeLine; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    timeLineFinal[i,j] = timeLine[i,j];
                }


            }

            double totalWait = 0;

            //for (int i = 1; i <= numberOfProcesses; i++)
            //{
            //    totalWait += ProcessesArr[i - 1].WaitingTime();
            //    Console.WriteLine("process: " + i);
            //    Console.WriteLine("from: " + ProcessesArr[i - 1].Execution + " to: " + ProcessesArr[i - 1].Departure);

            //}
            for (int i = 0; i < countTimeLine; i++)
            {
                Console.WriteLine("process: " + timeLine[i, 0]);
                Console.WriteLine("from: " + timeLine[i, 1] + " to: " + timeLine[i, 2]);
            }

            //Console.WriteLine("avg wait: " + totalWait / numberOfProcesses);





        }
    }

        

        }
    



