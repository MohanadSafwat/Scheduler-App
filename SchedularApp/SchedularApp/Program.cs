using System;

namespace SchedularApp
{
    class Program
    {
        private static void Quick_Sort(double[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }

        }

        private static int Partition(double[] arr, int left, int right)
        {
            double pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    double temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;


                }
                else
                {
                    return right;
                }
            }
        }

        public static void Main()
        {
            int numberOfProcesses, pre, numberOfRemainProcesses;
            Console.WriteLine("Please enter 1 if Non Preemptive and zero if Preemptive");
            pre = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter number of the processes");
            numberOfProcesses = Convert.ToInt32(Console.ReadLine());

            Process[] ProcessesArr = new Process[numberOfProcesses];
            numberOfRemainProcesses = numberOfProcesses;

            for (int i = 0; i < numberOfProcesses; i++)
            {
                int arrival, burst, priority;
                Console.WriteLine("Please enter arrival time of process " + (i + 1));

                arrival = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter burst time of process " + (i + 1));
                burst = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter priority of process " + (i + 1));
                priority = Convert.ToInt32(Console.ReadLine());

                ProcessesArr[i] = new Process(arrival, burst, priority);

            }

            Process firstProcess = new Process();
            Process nextProcess = new Process();
            Process inProcess = new Process();


            int numberOfFirstProcess = 0;
            int numberOfNextProcess = 0;
            int numberOfInProcess = 0;

            double[] arrivalTimes = new double[numberOfProcesses];
            Quick_Sort(arrivalTimes, 0, arrivalTimes.Length - 1);

            double timeNow = arrivalTimes[0];
            firstProcess = ProcessesArr[0];



            if (pre == 1)
            {
                if (numberOfProcesses > 1)
                {
                    for (int i = 1; i < numberOfProcesses; i++)
                    {

                        if (firstProcess.Arrival > ProcessesArr[i].Arrival)
                        {
                            firstProcess = ProcessesArr[i];
                            numberOfFirstProcess = i;
                            timeNow = firstProcess.Arrival;

                        }
                        else if (firstProcess.Arrival == ProcessesArr[i].Arrival)
                        {
                            if (firstProcess.Priority > ProcessesArr[i].Priority)
                            {
                                firstProcess = ProcessesArr[i];
                                numberOfFirstProcess = i;
                                timeNow = firstProcess.Arrival;
                            }
                        }
                    }

                }
                else
                {
                    firstProcess = ProcessesArr[0];
                    numberOfFirstProcess = 0;
                    timeNow = firstProcess.Arrival;
                }


                ProcessesArr[numberOfFirstProcess].Departure = timeNow;
                timeNow += ProcessesArr[numberOfFirstProcess].Burst;
                ProcessesArr[numberOfFirstProcess].TurnAround = timeNow;
                numberOfRemainProcesses--;
                ProcessesArr[numberOfFirstProcess].Status = "done";


                bool flagNext = true;


                while (numberOfRemainProcesses > 0)
                {
                    for (int i = 0; i < numberOfProcesses; i++)
                    {
                        if (ProcessesArr[i].Status != "done" || ProcessesArr[i].Arrival > timeNow)
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

                    ProcessesArr[numberOfNextProcess].Departure = timeNow;
                    timeNow += ProcessesArr[numberOfNextProcess].Burst;
                    ProcessesArr[numberOfNextProcess].TurnAround = timeNow;
                    ProcessesArr[numberOfNextProcess].Status = "done";

                    numberOfRemainProcesses--;
                    flagNext = true;
                }

            }
            else if (pre == 0)
            {



                //if (numberOfProcesses > 1)
                //{
                //    for (int i = 1; i < numberOfProcesses; i++)
                //    {

                //        if (firstProcess.Arrival > ProcessesArr[i].Arrival)
                //        {
                //            firstProcess = ProcessesArr[i];
                //            numberOfFirstProcess = i;
                //            timeNow = firstProcess.Arrival;

                //        }
                //        else if (firstProcess.Arrival == ProcessesArr[i].Arrival)
                //        {
                //            if (firstProcess.Priority > ProcessesArr[i].Priority)
                //            {
                //                firstProcess = ProcessesArr[i];
                //                numberOfFirstProcess = i;
                //                timeNow = firstProcess.Arrival;
                //            }
                //        }
                //    }

                //}
                //else
                //{
                //    firstProcess = ProcessesArr[0];
                //    numberOfFirstProcess = 0;
                //    timeNow = firstProcess.Arrival;
                //}

                //ProcessesArr[numberOfFirstProcess].Departure = timeNow;
                //timeNow += ProcessesArr[numberOfFirstProcess].Burst;
                //ProcessesArr[numberOfFirstProcess].TurnAround = timeNow;
                //numberOfRemainProcesses--;
                //ProcessesArr[numberOfFirstProcess].Status = "done";

                bool flagNext = true;

                while (numberOfRemainProcesses > 0)
                {
                    for (int j = 0; j < arrivalTimes.Length; j++)
                    {
                        for (int i = 0; i < numberOfProcesses; i++)
                        {
                            if (ProcessesArr[i].Status != "done" || ProcessesArr[i].Arrival > timeNow)
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
                            ProcessesArr[numberOfNextProcess].Departure = timeNow;
                        }
                        if (j != arrivalTimes.Length - 1)
                        {
                            if (arrivalTimes[j + 1] - arrivalTimes[j] >= ProcessesArr[numberOfInProcess].Remaining)
                            {
                                timeNow += arrivalTimes[j + 1] - arrivalTimes[j];
                                break;
                            }
                            else
                            {
                                timeNow += arrivalTimes[j + 1] - arrivalTimes[j];
                                ProcessesArr[numberOfInProcess].Remaining = arrivalTimes[j + 1] - arrivalTimes[j];
                                ProcessesArr[numberOfInProcess].Status = "waiting";
                            }
                        }
                        flagNext = true;


                    }
                    timeNow += ProcessesArr[numberOfInProcess].Remaining;
                    ProcessesArr[numberOfNextProcess].TurnAround = timeNow;
                    ProcessesArr[numberOfNextProcess].Status = "done";

                    numberOfRemainProcesses--;
                    flagNext = true;
                }



            }

            double totalWait = 0;

            for (int i = 1; i <= numberOfProcesses; i++)
            {
                totalWait += ProcessesArr[i - 1].WaitingTime();
                Console.WriteLine("process: " + i);
                Console.WriteLine("from: " + ProcessesArr[i - 1].Departure + " to: " + ProcessesArr[i - 1].TurnAround);

            }

            Console.WriteLine("avg wait: " + totalWait / numberOfProcesses);









        }
    }


}
