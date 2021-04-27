using System;


namespace SchedularApp
{
    class Process
    {
        private double arrival_time;
        private double departure_time;
        private double execution_time;
        private double burst_time;
        private double priority;
        private double turnaround_time;
        private string status;
        private double remainingTime;

        public double Arrival
        {
            set { arrival_time = value; }
            get { return arrival_time; }
        }
        public double Burst
        {
            set { burst_time = value; }
            get { return burst_time; }
        }
        public double Priority
        {
            set { priority = value; }
            get { return priority; }
        }
        public double TurnAround
        {
            set { turnaround_time = value; }
            get { return turnaround_time; }
        }
        public double Execution
        {
            set { execution_time = value; }
            get { return execution_time; }
        }
        public double Departure
        {
            set { departure_time = value; }
            get { return departure_time; }
        }
        public string Status
        {
            set { status = value; }
            get { return status; }
        }
        public double Remaining
        {
            set { remainingTime = value; }
            get { return remainingTime; }
        }
        public double WaitingTime()
        {
            return (turnaround_time - burst_time);
        }
        public Process()
        {
        }
        public Process(double arrival, double burst)
        {
            arrival_time = arrival;
            burst_time = burst;
            status = "active";
            remainingTime = burst;
        }
        public Process(double arrival, double burst, double p)
        {
            arrival_time = arrival;
            burst_time = burst;
            priority = p;
            status = "active";
            remainingTime = burst;
        }
    }
}
