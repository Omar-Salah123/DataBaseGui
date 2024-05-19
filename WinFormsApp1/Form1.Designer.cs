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
            ListBox2 = new ListBox();
            ListBox1 = new ListBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ListBox3 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            listBox5 = new ListBox();
            label5 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            button4 = new Button();
            textBox2 = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // ListBox2
            // 
            ListBox2.FormattingEnabled = true;
            ListBox2.ItemHeight = 15;
            ListBox2.Location = new Point(210, 213);
            ListBox2.Name = "ListBox2";
            ListBox2.Size = new Size(295, 94);
            ListBox2.TabIndex = 1;
            ListBox2.SelectedIndexChanged += ListBox2_SelectedIndexChanged_1;
            // 
            // ListBox1
            // 
            ListBox1.FormattingEnabled = true;
            ListBox1.ItemHeight = 15;
            ListBox1.Location = new Point(210, 28);
            ListBox1.Name = "ListBox1";
            ListBox1.Size = new Size(295, 154);
            ListBox1.TabIndex = 2;
            ListBox1.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(210, 383);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(430, 383);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "remove";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(631, 224);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 5;
            button3.Text = "Modify";
            button3.UseVisualStyleBackColor = true;
            // 
            // ListBox3
            // 
            ListBox3.FormattingEnabled = true;
            ListBox3.ItemHeight = 15;
            ListBox3.Location = new Point(611, 88);
            ListBox3.Name = "ListBox3";
            ListBox3.Size = new Size(120, 94);
            ListBox3.TabIndex = 6;
            ListBox3.SelectedIndexChanged += ListBox3_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(611, 51);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 7;
            label1.Text = "ID";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(210, 9);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 8;
            label2.Text = "Tables";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(210, 195);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 9;
            label3.Text = "records";
            // 
            // listBox5
            // 
            listBox5.FormattingEnabled = true;
            listBox5.ItemHeight = 15;
            listBox5.Location = new Point(24, 88);
            listBox5.Name = "listBox5";
            listBox5.Size = new Size(120, 94);
            listBox5.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(713, 51);
            label5.Name = "label5";
            label5.Size = new Size(18, 15);
            label5.TabIndex = 13;
            label5.Text = "ID";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(620, 195);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(557, 198);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 15;
            label4.Text = "Value=";
            label4.Click += label4_Click;
            // 
            // button4
            // 
            button4.Location = new Point(49, 310);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 16;
            button4.Text = "Load";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(210, 354);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(75, 23);
            textBox2.TabIndex = 17;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(178, 357);
            label6.Name = "label6";
            label6.Size = new Size(26, 15);
            label6.TabIndex = 18;
            label6.Text = "ID=";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(textBox2);
            Controls.Add(button4);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(listBox5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ListBox3);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(ListBox1);
            Controls.Add(ListBox2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ListBox2;
        private ListBox ListBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private ListBox ListBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox listBox5;
        private Label label5;
        private TextBox textBox1;
        private Label label4;
        private Button button4;
        private TextBox textBox2;
        private Label label6;
    }
}
