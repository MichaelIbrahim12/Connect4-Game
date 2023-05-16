namespace Server
{
    partial class Server
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server));
            this.Rooms_ListBox = new System.Windows.Forms.ListBox();
            this.Players_ListBox = new System.Windows.Forms.ListBox();
            this.Start_Button = new System.Windows.Forms.Button();
            this.Available_Rooms_Label = new System.Windows.Forms.Label();
            this.Players_in_Rooms_Label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Rooms_ListBox
            // 
            this.Rooms_ListBox.FormattingEnabled = true;
            this.Rooms_ListBox.ItemHeight = 16;
            this.Rooms_ListBox.Location = new System.Drawing.Point(52, 95);
            this.Rooms_ListBox.Margin = new System.Windows.Forms.Padding(4);
            this.Rooms_ListBox.Name = "Rooms_ListBox";
            this.Rooms_ListBox.Size = new System.Drawing.Size(182, 324);
            this.Rooms_ListBox.TabIndex = 0;
            // 
            // Players_ListBox
            // 
            this.Players_ListBox.FormattingEnabled = true;
            this.Players_ListBox.ItemHeight = 16;
            this.Players_ListBox.Location = new System.Drawing.Point(568, 95);
            this.Players_ListBox.Margin = new System.Windows.Forms.Padding(4);
            this.Players_ListBox.Name = "Players_ListBox";
            this.Players_ListBox.Size = new System.Drawing.Size(182, 324);
            this.Players_ListBox.TabIndex = 1;
            // 
            // Start_Button
            // 
            this.Start_Button.BackColor = System.Drawing.Color.White;
            this.Start_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Start_Button.BackgroundImage")));
            this.Start_Button.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.Start_Button.ForeColor = System.Drawing.Color.Black;
            this.Start_Button.Location = new System.Drawing.Point(357, 478);
            this.Start_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(89, 41);
            this.Start_Button.TabIndex = 3;
            this.Start_Button.Text = "Start";
            this.Start_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Start_Button.UseVisualStyleBackColor = false;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // Available_Rooms_Label
            // 
            this.Available_Rooms_Label.AutoSize = true;
            this.Available_Rooms_Label.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Available_Rooms_Label.Location = new System.Drawing.Point(48, 64);
            this.Available_Rooms_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Available_Rooms_Label.Name = "Available_Rooms_Label";
            this.Available_Rooms_Label.Size = new System.Drawing.Size(165, 27);
            this.Available_Rooms_Label.TabIndex = 5;
            this.Available_Rooms_Label.Text = "Available Rooms";
            // 
            // Players_in_Rooms_Label
            // 
            this.Players_in_Rooms_Label.AutoSize = true;
            this.Players_in_Rooms_Label.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Players_in_Rooms_Label.Location = new System.Drawing.Point(563, 64);
            this.Players_in_Rooms_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Players_in_Rooms_Label.Name = "Players_in_Rooms_Label";
            this.Players_in_Rooms_Label.Size = new System.Drawing.Size(174, 27);
            this.Players_in_Rooms_Label.TabIndex = 6;
            this.Players_in_Rooms_Label.Text = "Players connected";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(799, 566);
            this.Controls.Add(this.Players_in_Rooms_Label);
            this.Controls.Add(this.Available_Rooms_Label);
            this.Controls.Add(this.Start_Button);
            this.Controls.Add(this.Players_ListBox);
            this.Controls.Add(this.Rooms_ListBox);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect4 Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Rooms_ListBox;
        private System.Windows.Forms.ListBox Players_ListBox;
        private System.Windows.Forms.Button Start_Button;
        private System.Windows.Forms.Label Available_Rooms_Label;
        private System.Windows.Forms.Label Players_in_Rooms_Label;
        private System.Windows.Forms.Timer timer1;
    }
}

