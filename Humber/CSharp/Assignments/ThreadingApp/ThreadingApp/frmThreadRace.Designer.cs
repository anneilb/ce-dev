
using System.Drawing;
using System.Threading;
using System.Diagnostics;

namespace ThreadingApp
{

    partial class frmThreadRace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblWinner = new System.Windows.Forms.Label();
            this.pnlThread3 = new ThreadingApp.ProgressPanel();
            this.pnlThread2 = new ThreadingApp.ProgressPanel();
            this.pnlThread1 = new ThreadingApp.ProgressPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thread 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Thread 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Thread 3";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(252, 16);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(252, 44);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblWinner
            // 
            this.lblWinner.AutoSize = true;
            this.lblWinner.Location = new System.Drawing.Point(248, 100);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(0, 13);
            this.lblWinner.TabIndex = 8;
            // 
            // pnlThread3
            // 
            this.pnlThread3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThread3.Location = new System.Drawing.Point(164, 16);
            this.pnlThread3.Name = "pnlThread3";
            this.pnlThread3.Progress = 0;
            this.pnlThread3.ProgressColour = null;
            this.pnlThread3.Size = new System.Drawing.Size(56, 188);
            this.pnlThread3.TabIndex = 2;
            // 
            // pnlThread2
            // 
            this.pnlThread2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThread2.Location = new System.Drawing.Point(92, 16);
            this.pnlThread2.Name = "pnlThread2";
            this.pnlThread2.Progress = 0;
            this.pnlThread2.ProgressColour = null;
            this.pnlThread2.Size = new System.Drawing.Size(56, 188);
            this.pnlThread2.TabIndex = 1;
            // 
            // pnlThread1
            // 
            this.pnlThread1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThread1.Location = new System.Drawing.Point(20, 16);
            this.pnlThread1.Name = "pnlThread1";
            this.pnlThread1.Progress = 0;
            this.pnlThread1.ProgressColour = null;
            this.pnlThread1.Size = new System.Drawing.Size(56, 188);
            this.pnlThread1.TabIndex = 0;
            // 
            // frmThreadRace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 250);
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlThread3);
            this.Controls.Add(this.pnlThread2);
            this.Controls.Add(this.pnlThread1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmThreadRace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thread Race";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ThreadingApp.ProgressPanel pnlThread1;
        private ThreadingApp.ProgressPanel pnlThread2;
        private ThreadingApp.ProgressPanel pnlThread3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblWinner;
    }


    public class ProgressPanel : System.Windows.Forms.Panel
    {
        public delegate void ProgresFinishedHandler(string strThreadName);
        public event ProgresFinishedHandler ProgressFinished;
        
        private int m_intProgress;
        private System.Drawing.Brush m_ProgressColour;        

        public int Progress
        {
            get{ return m_intProgress;}
            
            set 
            {
                Trace.WriteLine(this.Name + " progress = " + (value));

                if (value >= this.ClientRectangle.Height)
                {
                    //We need to finish progress evenly otherwise rectangle 
                    //will disappear if drawn beyond client area of control
                    //ClientRectangle.Height is the exact amount to fill the entire panel
                    m_intProgress = this.ClientRectangle.Height;
                    this.Invalidate();
                    OnProgressFinished();
                }
                else
                {
                    m_intProgress = value;
                    this.Invalidate();
                }                
            }
        }

        public System.Drawing.Brush ProgressColour
        {
            get { return m_ProgressColour; }
            set { m_ProgressColour = value; }
        }

        private void DisplayProgress(System.Windows.Forms.PaintEventArgs e)
        {
            //From Help: The client area of a control is the bounds of the control, 
            //minus the nonclient elements such as scroll bars, borders, title bars, and menus.                       
            Rectangle r = this.ClientRectangle;     
            
            if (m_intProgress <= r.Height)
            {
                Graphics g = e.Graphics;
                g.FillRectangle(m_ProgressColour, r.Location.X, r.Bottom - m_intProgress, r.Width, m_intProgress);
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (m_intProgress >= this.Height)
            {
                return;
            }
            else if ((m_intProgress > 0) && (m_intProgress < this.Height))
            {
                DisplayProgress(e);
                base.OnPaint(e);
            }
        }

        private void OnProgressFinished()
        {
            if (ProgressFinished != null)
            {
                //raise event up to form, indicating that progress is finished
                ProgressFinished(Thread.CurrentThread.Name);   
            }
        }

    }
     

}