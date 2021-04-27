using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (Round.Checked == true)
            {
                FCFS.Checked = false;
                SJF.Checked = false;
                Priority.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(FCFS.Checked==true)
            {
                SJF.Checked = false;
                Priority.Checked = false;
                Round.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (SJF.Checked == true)
            {
                FCFS.Checked = false;
                Priority.Checked = false;
                Round.Checked = false;
                nonPreemptine_sjf.Visible = true;
                Preemptine_sjf.Visible = true;
            }
            else
            {
                nonPreemptine_sjf.Visible = false;
                Preemptine_sjf.Visible = false;
            }
        }

    
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (Priority.Checked == true)
            {
                FCFS.Checked = false;
                SJF.Checked = false;
                Round.Checked = false;
                nonPreemptine_priopity.Visible = true;
                Preemptine_priopity.Visible = true;


            }
            else
            {
                nonPreemptine_priopity.Visible = false;
                Preemptine_priopity.Visible = false;
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Preemptine_priopity_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void nonPreemptine_priopity_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_clk_Click(object sender, EventArgs e)
        {
            Button Average_waiting_button = new Button();
            Average_waiting_button.Text = "Calculate Average Waiting Time";
           // Average_waiting_button.Click += new System.EventHandler((Average_waiting_button)_click);
            this.Controls.Add(Average_waiting_button);
            Average_waiting_button.Location = new Point(530, 197);
            Average_waiting_button.Height = 70;

            Button Gant_chart_buttom = new Button();
            Gant_chart_buttom.Text = "Show Gant Chart ";
            // Average_waiting_button.Click += new System.EventHandler((Average_waiting_button)_click);
            this.Controls.Add(Gant_chart_buttom);
            Gant_chart_buttom.Location = new Point(530, 290);
            Gant_chart_buttom.Height = 50;
            Label BurstLabel = new Label();
            this.Controls.Add(BurstLabel);
            BurstLabel.Text = "Enter Burst Time ";
            BurstLabel.Location = new Point(110, 197);
            Label ArrivalLabel = new Label();
            this.Controls.Add(ArrivalLabel);
            ArrivalLabel.Text = "Enter Arrival Time ";
            ArrivalLabel.Location = new Point(250, 197);

            if (Priority.Checked == true) 
            {
                Label PriorityLabel = new Label();
                this.Controls.Add(PriorityLabel);
                PriorityLabel.Text = "Enter Priority ";
                PriorityLabel.Location = new Point(390, 197);
            }
            

            for (int i = 0; i < Convert.ToInt32(no_of_processes.Text); i++)
            { 
              TextBox Burstboxi = new TextBox();
              this.Controls.Add(Burstboxi);
              Burstboxi.Location = new Point(110, 221+(i*30));
                Label labeli = new Label();
                this.Controls.Add(labeli);
                labeli.Text = "Process " + (i+1)+ " ";
                labeli.Location = new Point(50, 225 + (i * 30));
                TextBox Arrivalboxi = new TextBox();
                this.Controls.Add(Arrivalboxi);
                Arrivalboxi.Location = new Point(250, 221 + (i * 30));
                TextBox priorityboxi = new TextBox();
                this.Controls.Add(priorityboxi);
                priorityboxi.Location = new Point(390, 221 + (i * 30));
                priorityboxi.Visible = false;

                if (Priority.Checked == true)
                {

                    priorityboxi.Visible = true;

                }
                else if (FCFS.Checked==true || SJF.Checked == true || Round.Checked == true)
                {
                    /*TextBox priorityboxi = new TextBox();
                    this.Controls.Add(priorityboxi);
                    priorityboxi.Location = new Point(390, 221 + (i * 30));
                    priorityboxi.Visible = true;*/
                    this.Controls.Remove(priorityboxi);
                    priorityboxi.Dispose();
                }

            }
        }
    }
}
