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
            MindFusion.Gauges.OvalScale ovalScale3 = new MindFusion.Gauges.OvalScale();
            MindFusion.Gauges.MajorTickSettings majorTickSettings3 = new MindFusion.Gauges.MajorTickSettings();
            MindFusion.Gauges.Pointer pointer3 = new MindFusion.Gauges.Pointer();
            MindFusion.Gauges.Range range7 = new MindFusion.Gauges.Range();
            MindFusion.Gauges.Range range8 = new MindFusion.Gauges.Range();
            MindFusion.Gauges.Range range9 = new MindFusion.Gauges.Range();
            MindFusion.Gauges.OvalScale ovalScale4 = new MindFusion.Gauges.OvalScale();
            MindFusion.Gauges.MajorTickSettings majorTickSettings4 = new MindFusion.Gauges.MajorTickSettings();
            MindFusion.Gauges.MiddleTickSettings middleTickSettings2 = new MindFusion.Gauges.MiddleTickSettings();
            MindFusion.Gauges.MinorTickSettings minorTickSettings2 = new MindFusion.Gauges.MinorTickSettings();
            MindFusion.Gauges.Pointer pointer4 = new MindFusion.Gauges.Pointer();
            MindFusion.Gauges.Range range10 = new MindFusion.Gauges.Range();
            MindFusion.Gauges.Range range11 = new MindFusion.Gauges.Range();
            MindFusion.Gauges.Range range12 = new MindFusion.Gauges.Range();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            now_Gauge = new MindFusion.Gauges.WinForms.OvalGauge();
            nowLbl = new Label();
            todayLbl = new Label();
            panel1.SuspendLayout();
            now_Pnl.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Enabled = false;
            richTextBox1.HideSelection = false;
            richTextBox1.Location = new Point(559, 427);
            richTextBox1.Margin = new Padding(2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(234, 73);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            richTextBox1.Visible = false;
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
            timer_Lbl.Location = new Point(698, 22);
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
            time_Lbl.Location = new Point(661, 22);
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
            home_Lbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            home_Lbl.ForeColor = Color.White;
            home_Lbl.Location = new Point(366, 20);
            home_Lbl.Name = "home_Lbl";
            home_Lbl.Size = new Size(56, 21);
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
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            today_Gauge.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            today_Gauge.LicenseKey = null;
            today_Gauge.Location = new Point(514, 146);
            today_Gauge.Name = "today_Gauge";
            majorTickSettings3.Count = 0;
            ovalScale3.MajorTickSettings = majorTickSettings3;
            ovalScale3.Margin = new MindFusion.Thickness(0.075F, 0.075F, 0.075F, 0.075F, true);
            ovalScale3.MaxValue = 10F;
            pointer3.CustomShape = null;
            pointer3.Margin = new MindFusion.Thickness(0F, 0F, 0F, 0F, true);
            pointer3.PointerHeight = new MindFusion.Gauges.Length(20F, MindFusion.Gauges.LengthType.Relative);
            pointer3.PointerWidth = new MindFusion.Gauges.Length(80F, MindFusion.Gauges.LengthType.Relative);
            pointer3.Shape = MindFusion.Gauges.PointerShape.Needle;
            pointer3.Value = 23F;
            ovalScale3.Pointers.Add(pointer3);
            range7.EndWidth = new MindFusion.Gauges.Length(10F);
            range7.Fill = new MindFusion.Drawing.SolidBrush("#FF54B302");
            range7.Margin = new MindFusion.Thickness(0F, 0F, 0F, 0F, true);
            range7.MaxValue = 23F;
            range7.StartWidth = new MindFusion.Gauges.Length(10F);
            range7.Stroke = new MindFusion.Drawing.Pen("0/#FF000000/0/0/0//0/0/10/");
            range8.EndWidth = new MindFusion.Gauges.Length(10F);
            range8.Fill = new MindFusion.Drawing.SolidBrush("#FFFFBF00");
            range8.Margin = new MindFusion.Thickness(0F, 0F, 0F, 0F, true);
            range8.StartWidth = new MindFusion.Gauges.Length(10F);
            range9.EndWidth = new MindFusion.Gauges.Length(10F);
            range9.Fill = new MindFusion.Drawing.SolidBrush("#FFCC0606");
            range9.Margin = new MindFusion.Thickness(0F, 0F, 0F, 0F, true);
            range9.StartWidth = new MindFusion.Gauges.Length(10F);
            ovalScale3.Ranges.Add(range7);
            ovalScale3.Ranges.Add(range8);
            ovalScale3.Ranges.Add(range9);
            ovalScale3.Stroke = new MindFusion.Drawing.Pen("0/#FFD3D3D3/0/0/0//0/0/10/");
            today_Gauge.Scales.Add(ovalScale3);
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
            lblMessageCentreHeading.Location = new Point(351, 349);
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
            lblMsgCentreContent.Location = new Point(339, 364);
            lblMsgCentreContent.Margin = new Padding(2, 0, 2, 0);
            lblMsgCentreContent.Name = "lblMsgCentreContent";
            lblMsgCentreContent.Size = new Size(117, 15);
            lblMsgCentreContent.TabIndex = 7;
            lblMsgCentreContent.Text = "No update to display";
            // 
            // now_Gauge
            // 
            now_Gauge.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            now_Gauge.LicenseKey = null;
            now_Gauge.Location = new Point(107, 146);
            now_Gauge.Name = "now_Gauge";
            majorTickSettings4.Count = 0;
            ovalScale4.MajorTickSettings = majorTickSettings4;
            ovalScale4.Margin = new MindFusion.Thickness(0.075F, 0.075F, 0.075F, 0.075F, true);
            ovalScale4.MaxValue = 0.0035F;
            middleTickSettings2.Count = 0;
            ovalScale4.MiddleTickSettings = middleTickSettings2;
            minorTickSettings2.Count = 0;
            ovalScale4.MinorTickSettings = minorTickSettings2;
            pointer4.CustomShape = null;
            pointer4.Margin = new MindFusion.Thickness(0F, 0F, 0F, 0F, true);
            pointer4.PointerHeight = new MindFusion.Gauges.Length(20F, MindFusion.Gauges.LengthType.Relative);
            pointer4.PointerWidth = new MindFusion.Gauges.Length(80F, MindFusion.Gauges.LengthType.Relative);
            pointer4.Shape = MindFusion.Gauges.PointerShape.Needle;
            pointer4.Value = 23F;
            ovalScale4.Pointers.Add(pointer4);
            range10.EndWidth = new MindFusion.Gauges.Length(10F);
            range10.Fill = new MindFusion.Drawing.SolidBrush("#FF54B302");
            range10.Margin = new MindFusion.Thickness(0F, 0F, 0F, 0F, true);
            range10.MaxValue = 23F;
            range10.StartWidth = new MindFusion.Gauges.Length(10F);
            range10.Stroke = new MindFusion.Drawing.Pen("0/#FF000000/0/0/0//0/0/10/");
            range11.EndWidth = new MindFusion.Gauges.Length(10F);
            range11.Fill = new MindFusion.Drawing.SolidBrush("#FFFFBF00");
            range11.Margin = new MindFusion.Thickness(0F, 0F, 0F, 0F, true);
            range11.StartWidth = new MindFusion.Gauges.Length(10F);
            range12.EndWidth = new MindFusion.Gauges.Length(10F);
            range12.Fill = new MindFusion.Drawing.SolidBrush("#FFCC0606");
            range12.Margin = new MindFusion.Thickness(0F, 0F, 0F, 0F, true);
            range12.StartWidth = new MindFusion.Gauges.Length(10F);
            ovalScale4.Ranges.Add(range10);
            ovalScale4.Ranges.Add(range11);
            ovalScale4.Ranges.Add(range12);
            ovalScale4.ScaleRelativeCenter = (PointF)resources.GetObject("ovalScale4.ScaleRelativeCenter");
            now_Gauge.Scales.Add(ovalScale4);
            now_Gauge.Size = new Size(172, 142);
            now_Gauge.TabIndex = 8;
            now_Gauge.Text = "ovalGauge1";
            // 
            // nowLbl
            // 
            nowLbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            nowLbl.ForeColor = Color.White;
            nowLbl.Location = new Point(81, 291);
            nowLbl.Name = "nowLbl";
            nowLbl.Size = new Size(238, 21);
            nowLbl.TabIndex = 9;
            nowLbl.Text = "0.0001kW/h";
            nowLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // todayLbl
            // 
            todayLbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            todayLbl.ForeColor = Color.White;
            todayLbl.ImageAlign = ContentAlignment.TopLeft;
            todayLbl.Location = new Point(501, 291);
            todayLbl.Margin = new Padding(0);
            todayLbl.Name = "todayLbl";
            todayLbl.Size = new Size(201, 21);
            todayLbl.TabIndex = 10;
            todayLbl.Text = "0.0001kW/h";
            todayLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(789, 483);
            Controls.Add(todayLbl);
            Controls.Add(nowLbl);
            Controls.Add(now_Gauge);
            Controls.Add(lblMsgCentreContent);
            Controls.Add(lblMessageCentreHeading);
            Controls.Add(today_Gauge);
            Controls.Add(panel4);
            Controls.Add(now_Pnl);
            Controls.Add(panel1);
            Controls.Add(richTextBox1);
            Margin = new Padding(2);
            MaximizeBox = false;
            MaximumSize = new Size(805, 522);
            MinimumSize = new Size(805, 522);
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Smart Electric Meter (Client)";
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
        private MindFusion.Gauges.WinForms.OvalGauge now_Gauge;
        private Label nowLbl;
        private Label todayLbl;
    }
}
