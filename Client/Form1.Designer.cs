﻿namespace Client
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
            MindFusion.Gauges.OvalScale ovalScale1 = new MindFusion.Gauges.OvalScale();
            MindFusion.Gauges.Pointer pointer1 = new MindFusion.Gauges.Pointer();
            MindFusion.Gauges.Range range1 = new MindFusion.Gauges.Range();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            button2 = new Button();
            panel1 = new Panel();
            panel3 = new Panel();
            home_Lbl = new Label();
            now_Pnl = new Panel();
            Now_lbl = new Label();
            panel4 = new Panel();
            Today_lbl = new Label();
            today_Gauge = new MindFusion.Gauges.WinForms.OvalGauge();
            panel1.SuspendLayout();
            now_Pnl.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(554, 293);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(148, 74);
            button1.TabIndex = 0;
            button1.Text = "test thar mf";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(273, 294);
            richTextBox1.Margin = new Padding(2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(234, 73);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // button2
            // 
            button2.Location = new Point(89, 293);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(148, 74);
            button2.TabIndex = 2;
            button2.Text = "Mash that value";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(163, 163, 163);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(home_Lbl);
            panel1.Location = new Point(0, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(796, 61);
            panel1.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Location = new Point(390, 60);
            panel3.Name = "panel3";
            panel3.Size = new Size(403, 56);
            panel3.TabIndex = 5;
            // 
            // home_Lbl
            // 
            home_Lbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            home_Lbl.AutoSize = true;
            home_Lbl.Font = new Font("Segoe UI", 12F);
            home_Lbl.ForeColor = Color.White;
            home_Lbl.Location = new Point(366, 20);
            home_Lbl.Name = "home_Lbl";
            home_Lbl.Size = new Size(52, 21);
            home_Lbl.TabIndex = 0;
            home_Lbl.Text = "Home";
            home_Lbl.Click += label1_Click;
            // 
            // now_Pnl
            // 
            now_Pnl.BackColor = Color.FromArgb(143, 183, 188);
            now_Pnl.Controls.Add(Now_lbl);
            now_Pnl.Location = new Point(0, 86);
            now_Pnl.Name = "now_Pnl";
            now_Pnl.Size = new Size(396, 56);
            now_Pnl.TabIndex = 4;
            // 
            // Now_lbl
            // 
            Now_lbl.AutoSize = true;
            Now_lbl.Font = new Font("Segoe UI", 10F);
            Now_lbl.ForeColor = Color.White;
            Now_lbl.Location = new Point(176, 19);
            Now_lbl.Name = "Now_lbl";
            Now_lbl.Size = new Size(37, 19);
            Now_lbl.TabIndex = 0;
            Now_lbl.Text = "Now";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(4, 136, 153);
            panel4.Controls.Add(Today_lbl);
            panel4.Location = new Point(393, 86);
            panel4.Name = "panel4";
            panel4.Size = new Size(396, 56);
            panel4.TabIndex = 5;
            // 
            // Today_lbl
            // 
            Today_lbl.AutoSize = true;
            Today_lbl.Font = new Font("Segoe UI", 10F);
            Today_lbl.ForeColor = Color.White;
            Today_lbl.Location = new Point(187, 19);
            Today_lbl.Name = "Today_lbl";
            Today_lbl.Size = new Size(45, 19);
            Today_lbl.TabIndex = 0;
            Today_lbl.Text = "Today";
            // 
            // today_Gauge
            // 
            today_Gauge.LicenseKey = null;
            today_Gauge.Location = new Point(514, 146);
            today_Gauge.Name = "today_Gauge";
            ovalScale1.Margin = new MindFusion.Thickness(0.075F, 0.075F, 0.075F, 0.075F, true);
            ovalScale1.MaxValue = 30F;
            pointer1.CustomShape = null;
            pointer1.Margin = new MindFusion.Thickness(0F, 0F, 0F, 0F, true);
            pointer1.PointerHeight = new MindFusion.Gauges.Length(20F, MindFusion.Gauges.LengthType.Relative);
            pointer1.PointerWidth = new MindFusion.Gauges.Length(80F, MindFusion.Gauges.LengthType.Relative);
            pointer1.Shape = MindFusion.Gauges.PointerShape.Needle;
            pointer1.Value = 23F;
            ovalScale1.Pointers.Add(pointer1);
            range1.Fill = new MindFusion.Drawing.SolidBrush("#FF54B302");
            range1.Margin = new MindFusion.Thickness(0F, 0F, 0F, 0F, true);
            range1.MaxValue = 23F;
            range1.Stroke = new MindFusion.Drawing.Pen("0/#FF000000/0/0/0//0/0/10/");
            ovalScale1.Ranges.Add(range1);
            ovalScale1.Stroke = new MindFusion.Drawing.Pen("0/#FFD3D3D3/0/0/0//0/0/10/");
            today_Gauge.Scales.Add(ovalScale1);
            today_Gauge.Size = new Size(172, 142);
            today_Gauge.TabIndex = 6;
            today_Gauge.Text = "ovalGauge1";
            today_Gauge.Click += ovalGauge1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(789, 378);
            Controls.Add(today_Gauge);
            Controls.Add(panel4);
            Controls.Add(now_Pnl);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            now_Pnl.ResumeLayout(false);
            now_Pnl.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private RichTextBox richTextBox1;
        private Button button2;
        private Panel panel1;
        private Label home_Lbl;
        private Panel panel3;
        private Panel now_Pnl;
        private Panel panel4;
        private Label Now_lbl;
        private Label Today_lbl;
        private MindFusion.Gauges.WinForms.OvalGauge today_Gauge;
    }
}
