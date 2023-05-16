namespace Player
{
    partial class Start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.Start_Button = new System.Windows.Forms.Button();
            this.Name_Label = new System.Windows.Forms.Label();
            this.Name_TextBox = new System.Windows.Forms.TextBox();
            this.Welcome_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Start_Button
            // 
            this.Start_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Start_Button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Start_Button.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_Button.Location = new System.Drawing.Point(240, 258);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(109, 39);
            this.Start_Button.TabIndex = 0;
            this.Start_Button.Text = "Start";
            this.Start_Button.UseVisualStyleBackColor = false;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // Name_Label
            // 
            this.Name_Label.AutoSize = true;
            this.Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.Name_Label.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Bold);
            this.Name_Label.ForeColor = System.Drawing.Color.White;
            this.Name_Label.Location = new System.Drawing.Point(129, 215);
            this.Name_Label.Name = "Name_Label";
            this.Name_Label.Size = new System.Drawing.Size(66, 26);
            this.Name_Label.TabIndex = 1;
            this.Name_Label.Text = "Name";
            // 
            // Name_TextBox
            // 
            this.Name_TextBox.BackColor = System.Drawing.SystemColors.Info;
            this.Name_TextBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name_TextBox.Location = new System.Drawing.Point(201, 215);
            this.Name_TextBox.Name = "Name_TextBox";
            this.Name_TextBox.Size = new System.Drawing.Size(248, 26);
            this.Name_TextBox.TabIndex = 2;
            // 
            // Welcome_Label
            // 
            this.Welcome_Label.AutoSize = true;
            this.Welcome_Label.BackColor = System.Drawing.Color.Transparent;
            this.Welcome_Label.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold);
            this.Welcome_Label.ForeColor = System.Drawing.Color.White;
            this.Welcome_Label.Location = new System.Drawing.Point(78, 136);
            this.Welcome_Label.Name = "Welcome_Label";
            this.Welcome_Label.Size = new System.Drawing.Size(438, 44);
            this.Welcome_Label.TabIndex = 3;
            this.Welcome_Label.Text = "Welcome to Connect4 Game!";
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.Welcome_Label);
            this.Controls.Add(this.Name_TextBox);
            this.Controls.Add(this.Name_Label);
            this.Controls.Add(this.Start_Button);
            this.DoubleBuffered = true;
            this.Name = "Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect4 Game ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start_Button;
        private System.Windows.Forms.Label Name_Label;
        private System.Windows.Forms.TextBox Name_TextBox;
        private System.Windows.Forms.Label Welcome_Label;
    }
}

