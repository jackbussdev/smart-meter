namespace AdminClient
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
            tabPage2 = new TabPage();
            groupBox1 = new GroupBox();
            tbMessageContent = new TextBox();
            label1 = new Label();
            label2 = new Label();
            cbMessageTargetRegion = new ComboBox();
            button1 = new Button();
            tabControl1 = new TabControl();
            tabPage2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2);
            tabPage2.Size = new Size(245, 279);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Message Centre";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(cbMessageTargetRegion);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(tbMessageContent);
            groupBox1.Location = new Point(4, 4);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(228, 157);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Message Sending";
            // 
            // tbMessageContent
            // 
            tbMessageContent.Location = new Point(4, 96);
            tbMessageContent.Margin = new Padding(2);
            tbMessageContent.Name = "tbMessageContent";
            tbMessageContent.Size = new Size(214, 23);
            tbMessageContent.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 23);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 1;
            label1.Text = "Region";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 79);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 1;
            label2.Text = "Message Content";
            // 
            // cbMessageTargetRegion
            // 
            cbMessageTargetRegion.FormattingEnabled = true;
            cbMessageTargetRegion.Items.AddRange(new object[] { "GLOBAL" });
            cbMessageTargetRegion.Location = new Point(4, 44);
            cbMessageTargetRegion.Margin = new Padding(2);
            cbMessageTargetRegion.Name = "cbMessageTargetRegion";
            cbMessageTargetRegion.Size = new Size(214, 23);
            cbMessageTargetRegion.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(4, 125);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(213, 20);
            button1.TabIndex = 3;
            button1.Text = "Send Message";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(8, 7);
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(253, 307);
            tabControl1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(267, 321);
            Controls.Add(tabControl1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "Form1";
            tabPage2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private ComboBox cbMessageTargetRegion;
        private Label label2;
        private Label label1;
        private TextBox tbMessageContent;
        private Button button1;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Region;
        private DataGridViewTextBoxColumn Message;
        private Button btnDeleteMessage;
    }
}
