namespace Player
{
    partial class ChooseColor
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
            this.Color_Panel = new System.Windows.Forms.Panel();
            this.Red_Button = new System.Windows.Forms.Button();
            this.Green_Button = new System.Windows.Forms.Button();
            this.Yellow_Button = new System.Windows.Forms.Button();
            this.Blue_Button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Color_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Color_Panel
            // 
            this.Color_Panel.Controls.Add(this.Red_Button);
            this.Color_Panel.Controls.Add(this.Green_Button);
            this.Color_Panel.Controls.Add(this.Yellow_Button);
            this.Color_Panel.Controls.Add(this.Blue_Button);
            this.Color_Panel.Location = new System.Drawing.Point(181, 79);
            this.Color_Panel.Margin = new System.Windows.Forms.Padding(4);
            this.Color_Panel.Name = "Color_Panel";
            this.Color_Panel.Size = new System.Drawing.Size(235, 84);
            this.Color_Panel.TabIndex = 13;
            // 
            // Red_Button
            // 
            this.Red_Button.BackColor = System.Drawing.Color.Red;
            this.Red_Button.Location = new System.Drawing.Point(9, 18);
            this.Red_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Red_Button.Name = "Red_Button";
            this.Red_Button.Size = new System.Drawing.Size(57, 45);
            this.Red_Button.TabIndex = 16;
            this.Red_Button.UseVisualStyleBackColor = false;
            this.Red_Button.Click += new System.EventHandler(this.Red_Button_Click);
            // 
            // Green_Button
            // 
            this.Green_Button.BackColor = System.Drawing.Color.DarkGreen;
            this.Green_Button.Location = new System.Drawing.Point(165, 18);
            this.Green_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Green_Button.Name = "Green_Button";
            this.Green_Button.Size = new System.Drawing.Size(60, 45);
            this.Green_Button.TabIndex = 19;
            this.Green_Button.UseVisualStyleBackColor = false;
            this.Green_Button.Click += new System.EventHandler(this.Green_Button_Click);
            // 
            // Yellow_Button
            // 
            this.Yellow_Button.BackColor = System.Drawing.Color.Orange;
            this.Yellow_Button.Location = new System.Drawing.Point(61, 18);
            this.Yellow_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Yellow_Button.Name = "Yellow_Button";
            this.Yellow_Button.Size = new System.Drawing.Size(56, 45);
            this.Yellow_Button.TabIndex = 18;
            this.Yellow_Button.UseVisualStyleBackColor = false;
            this.Yellow_Button.Click += new System.EventHandler(this.Yellow_Button_Click);
            // 
            // Blue_Button
            // 
            this.Blue_Button.BackColor = System.Drawing.Color.Indigo;
            this.Blue_Button.Location = new System.Drawing.Point(113, 18);
            this.Blue_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Blue_Button.Name = "Blue_Button";
            this.Blue_Button.Size = new System.Drawing.Size(53, 45);
            this.Blue_Button.TabIndex = 17;
            this.Blue_Button.UseVisualStyleBackColor = false;
            this.Blue_Button.Click += new System.EventHandler(this.Blue_Button_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(227, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 49);
            this.button1.TabIndex = 14;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChooseColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 393);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Color_Panel);
            this.Name = "ChooseColor";
            this.Text = "ChooseColor";
            this.Color_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Color_Panel;
        private System.Windows.Forms.Button Red_Button;
        private System.Windows.Forms.Button Green_Button;
        private System.Windows.Forms.Button Yellow_Button;
        private System.Windows.Forms.Button Blue_Button;
        private System.Windows.Forms.Button button1;
    }
}