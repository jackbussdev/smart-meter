namespace Client
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
            components = new System.ComponentModel.Container();
            MindFusion.Gauges.OvalScale ovalScale1 = new MindFusion.Gauges.OvalScale();
            MindFusion.Gauges.Pointer pointer1 = new MindFusion.Gauges.Pointer();
            MindFusion.Gauges.Range range1 = new MindFusion.Gauges.Range();
            MindFusion.Gauges.Range range2 = new MindFusion.Gauges.Range();
            MindFusion.Gauges.Range range3 = new MindFusion.Gauges.Range();
            richTextBox1 = new RichTextBox();
            panel1 = new Panel();
            timer_Lbl = new Label();
            clock_Lbl = new Label();
            time_Lbl = new Label();
            panel3 = new Panel();
            home_Lbl = new Label();
            now_Pnl = new Panel();
            Now_lbl = new Label();
            panel4 = new Panel();
            Today_lbl = new Label();
            today_Gauge = new MindFusion.Gauges.WinForms.OvalGauge();
            clock_Tmr = new System.Windows.Forms.Timer(components);
            lblMessageCentreHeading = new Label();
            lblMsgCentreContent = new Label();
            panel1.SuspendLayout();
            now_Pnl.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(273, 294);
            richTextBox1.Margin = new Padding(2, 2, 2, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(234, 73);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(163, 163, 163);
            panel1.Controls.Add(timer_Lbl);
            panel1.Controls.Add(clock_Lbl);
            panel1.Controls.Add(time_Lbl);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(home_Lbl);
            panel1.Location = new Point(0, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(796, 61);
            panel1.TabIndex = 3;
            // 
            // timer_Lbl
            // 
            timer_Lbl.AutoSize = true;
            timer_Lbl.Font = new Font("Segoe UI", 10F);
            timer_Lbl.ForeColor = Color.White;
            timer_Lbl.Location = new Point(698, 23);
            timer_Lbl.Name = "timer_Lbl";
            timer_Lbl.Size = new Size(79, 19);
            timer_Lbl.TabIndex = 8;
            timer_Lbl.Text = "placeholder";
            // 
            // clock_Lbl
            // 
            clock_Lbl.AutoSize = true;
            clock_Lbl.Font = new Font("Segoe UI", 10F);
            clock_Lbl.ForeColor = Color.White;
            clock_Lbl.Location = new Point(702, 23);
            clock_Lbl.Name = "clock_Lbl";
            clock_Lbl.Size = new Size(0, 19);
            clock_Lbl.TabIndex = 7;
            // 
            // time_Lbl
            // 
            time_Lbl.AutoSize = true;
            time_Lbl.Font = new Font("Segoe UI", 10F);
            time_Lbl.ForeColor = Color.White;
            time_Lbl.Location = new Point(661, 23);
            time_Lbl.Name = "time_Lbl";
            time_Lbl.Size = new Size(41, 19);
            time_Lbl.TabIndex = 6;
            time_Lbl.Text = "Time:";
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
            range2.Fill = new MindFusion.Drawing.SolidBrush("#FFFFBF00");
            range2.Margin = new MindFusion.Thickness(0F, 0F, 0F, 0F, true);
            range3.Fill = new MindFusion.Drawing.SolidBrush("#FFCC0606");
            range3.Margin = new MindFusion.Thickness(0F, 0F, 0F, 0F, true);
            ovalScale1.Ranges.Add(range1);
            ovalScale1.Ranges.Add(range2);
            ovalScale1.Ranges.Add(range3);
            ovalScale1.Stroke = new MindFusion.Drawing.Pen("0/#FFD3D3D3/0/0/0//0/0/10/");
            today_Gauge.Scales.Add(ovalScale1);
            today_Gauge.Size = new Size(172, 142);
            today_Gauge.TabIndex = 6;
            today_Gauge.Text = "ovalGauge1";
            today_Gauge.Click += ovalGauge1_Click;
            // 
            // clock_Tmr
            // 
            clock_Tmr.Enabled = true;
            clock_Tmr.Tick += clock_Tmr_Tick;
            // 
            // lblMessageCentreHeading
            // 
            lblMessageCentreHeading.AutoSize = true;
            lblMessageCentreHeading.ForeColor = Color.GhostWhite;
            lblMessageCentreHeading.Location = new Point(21, 164);
            lblMessageCentreHeading.Margin = new Padding(2, 0, 2, 0);
            lblMessageCentreHeading.Name = "lblMessageCentreHeading";
            lblMessageCentreHeading.Size = new Size(94, 15);
            lblMessageCentreHeading.TabIndex = 7;
            lblMessageCentreHeading.Text = "Message Centre:";
            // 
            // lblMsgCentreContent
            // 
            lblMsgCentreContent.AutoSize = true;
            lblMsgCentreContent.ForeColor = Color.GhostWhite;
            lblMsgCentreContent.Location = new Point(21, 185);
            lblMsgCentreContent.Margin = new Padding(2, 0, 2, 0);
            lblMsgCentreContent.Name = "lblMsgCentreContent";
            lblMsgCentreContent.Size = new Size(117, 15);
            lblMsgCentreContent.TabIndex = 7;
            lblMsgCentreContent.Text = "No update to display";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(789, 378);
            Controls.Add(lblMsgCentreContent);
            Controls.Add(lblMessageCentreHeading);
            Controls.Add(today_Gauge);
            Controls.Add(panel4);
            Controls.Add(now_Pnl);
            Controls.Add(panel1);
            Controls.Add(richTextBox1);
            Margin = new Padding(2, 2, 2, 2);
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
            PerformLayout();
        }

        #endregion
        private RichTextBox richTextBox1;
        private Panel panel1;
        private Label home_Lbl;
        private Panel panel3;
        private Panel now_Pnl;
        private Panel panel4;
        private Label Now_lbl;
        private Label Today_lbl;
        private MindFusion.Gauges.WinForms.OvalGauge today_Gauge;
        private Label time_Lbl;
        private Label clock_Lbl;
        private System.Windows.Forms.Timer clock_Tmr;
        private Label timer_Lbl;
        private Label lblMessageCentreHeading;
        private Label lblMsgCentreContent;
    }
}
