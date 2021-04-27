
namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.FCFS = new System.Windows.Forms.CheckBox();
            this.SJF = new System.Windows.Forms.CheckBox();
            this.Round = new System.Windows.Forms.CheckBox();
            this.Priority = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.no_of_processes = new System.Windows.Forms.TextBox();
            this.Preemptine_sjf = new System.Windows.Forms.RadioButton();
            this.nonPreemptine_sjf = new System.Windows.Forms.RadioButton();
            this.nonPreemptine_priopity = new System.Windows.Forms.RadioButton();
            this.Preemptine_priopity = new System.Windows.Forms.RadioButton();
            this.btn_clk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(32, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "The Type of Schedular :";
            // 
            // FCFS
            // 
            this.FCFS.AccessibleName = "FCFS";
            this.FCFS.AutoSize = true;
            this.FCFS.Location = new System.Drawing.Point(265, 29);
            this.FCFS.Name = "FCFS";
            this.FCFS.Size = new System.Drawing.Size(52, 19);
            this.FCFS.TabIndex = 1;
            this.FCFS.Text = "FCFS";
            this.FCFS.UseVisualStyleBackColor = true;
            this.FCFS.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // SJF
            // 
            this.SJF.AccessibleName = "SJF";
            this.SJF.AutoSize = true;
            this.SJF.Location = new System.Drawing.Point(265, 54);
            this.SJF.Name = "SJF";
            this.SJF.Size = new System.Drawing.Size(42, 19);
            this.SJF.TabIndex = 2;
            this.SJF.Text = "SJF";
            this.SJF.UseVisualStyleBackColor = true;
            this.SJF.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // Round
            // 
            this.Round.AccessibleName = "Round";
            this.Round.AutoSize = true;
            this.Round.Location = new System.Drawing.Point(266, 165);
            this.Round.Name = "Round";
            this.Round.Size = new System.Drawing.Size(95, 19);
            this.Round.TabIndex = 3;
            this.Round.Text = "Round Robin";
            this.Round.UseVisualStyleBackColor = true;
            this.Round.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // Priority
            // 
            this.Priority.AccessibleName = "Priority";
            this.Priority.AutoSize = true;
            this.Priority.Location = new System.Drawing.Point(265, 107);
            this.Priority.Name = "Priority";
            this.Priority.Size = new System.Drawing.Size(126, 19);
            this.Priority.TabIndex = 4;
            this.Priority.Text = "Priority Scheduling";
            this.Priority.UseVisualStyleBackColor = true;
            this.Priority.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(381, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "No. of Processes : ";
            // 
            // no_of_processes
            // 
            this.no_of_processes.Location = new System.Drawing.Point(560, 29);
            this.no_of_processes.Name = "no_of_processes";
            this.no_of_processes.Size = new System.Drawing.Size(63, 23);
            this.no_of_processes.TabIndex = 6;
            // 
            // Preemptine_sjf
            // 
            this.Preemptine_sjf.AutoSize = true;
            this.Preemptine_sjf.Location = new System.Drawing.Point(265, 79);
            this.Preemptine_sjf.Name = "Preemptine_sjf";
            this.Preemptine_sjf.Size = new System.Drawing.Size(85, 19);
            this.Preemptine_sjf.TabIndex = 8;
            this.Preemptine_sjf.TabStop = true;
            this.Preemptine_sjf.Text = "Preemptive";
            this.Preemptine_sjf.UseVisualStyleBackColor = true;
            this.Preemptine_sjf.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // nonPreemptine_sjf
            // 
            this.nonPreemptine_sjf.AutoSize = true;
            this.nonPreemptine_sjf.Location = new System.Drawing.Point(396, 79);
            this.nonPreemptine_sjf.Name = "nonPreemptine_sjf";
            this.nonPreemptine_sjf.Size = new System.Drawing.Size(113, 19);
            this.nonPreemptine_sjf.TabIndex = 9;
            this.nonPreemptine_sjf.TabStop = true;
            this.nonPreemptine_sjf.Text = "Non-Preemptive";
            this.nonPreemptine_sjf.UseVisualStyleBackColor = true;
            // 
            // nonPreemptine_priopity
            // 
            this.nonPreemptine_priopity.AutoSize = true;
            this.nonPreemptine_priopity.Location = new System.Drawing.Point(396, 136);
            this.nonPreemptine_priopity.Name = "nonPreemptine_priopity";
            this.nonPreemptine_priopity.Size = new System.Drawing.Size(113, 19);
            this.nonPreemptine_priopity.TabIndex = 10;
            this.nonPreemptine_priopity.TabStop = true;
            this.nonPreemptine_priopity.Text = "Non-Preemptive";
            this.nonPreemptine_priopity.UseVisualStyleBackColor = true;
            this.nonPreemptine_priopity.CheckedChanged += new System.EventHandler(this.nonPreemptine_priopity_CheckedChanged);
            // 
            // Preemptine_priopity
            // 
            this.Preemptine_priopity.AutoSize = true;
            this.Preemptine_priopity.Location = new System.Drawing.Point(266, 135);
            this.Preemptine_priopity.Name = "Preemptine_priopity";
            this.Preemptine_priopity.Size = new System.Drawing.Size(85, 19);
            this.Preemptine_priopity.TabIndex = 11;
            this.Preemptine_priopity.TabStop = true;
            this.Preemptine_priopity.Text = "Preemptive";
            this.Preemptine_priopity.UseVisualStyleBackColor = true;
            this.Preemptine_priopity.CheckedChanged += new System.EventHandler(this.Preemptine_priopity_CheckedChanged);
            // 
            // btn_clk
            // 
            this.btn_clk.Location = new System.Drawing.Point(537, 107);
            this.btn_clk.Name = "btn_clk";
            this.btn_clk.Size = new System.Drawing.Size(95, 48);
            this.btn_clk.TabIndex = 12;
            this.btn_clk.Text = "Click to Show Fields";
            this.btn_clk.UseVisualStyleBackColor = true;
            this.btn_clk.Click += new System.EventHandler(this.btn_clk_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(662, 413);
            this.Controls.Add(this.btn_clk);
            this.Controls.Add(this.Preemptine_priopity);
            this.Controls.Add(this.nonPreemptine_priopity);
            this.Controls.Add(this.nonPreemptine_sjf);
            this.Controls.Add(this.Preemptine_sjf);
            this.Controls.Add(this.no_of_processes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Priority);
            this.Controls.Add(this.Round);
            this.Controls.Add(this.SJF);
            this.Controls.Add(this.FCFS);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fill Inputs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox FCFS;
        private System.Windows.Forms.CheckBox SJF;
        private System.Windows.Forms.CheckBox Round;
        private System.Windows.Forms.CheckBox Priority;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox no_of_processes;
        private System.Windows.Forms.RadioButton Preemptine_sjf;
        private System.Windows.Forms.RadioButton nonPreemptine_sjf;
        private System.Windows.Forms.RadioButton nonPreemptine_priopity;
        private System.Windows.Forms.RadioButton Preemptine_priopity;
        private System.Windows.Forms.Button btn_clk;
    }
}

