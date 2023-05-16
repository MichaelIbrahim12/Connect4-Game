namespace Player
{
    partial class Rooms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rooms));
            this.Players_Label = new System.Windows.Forms.Label();
            this.Players_ListBox = new System.Windows.Forms.ListBox();
            this.Rooms_Label = new System.Windows.Forms.Label();
            this.Rooms_ListBox = new System.Windows.Forms.ListBox();
            this.Create_Button = new System.Windows.Forms.Button();
            this.Play_Button = new System.Windows.Forms.Button();
            this.Color_Panel = new System.Windows.Forms.Panel();
            this.Red_Button = new System.Windows.Forms.Button();
            this.Green_Button = new System.Windows.Forms.Button();
            this.Yellow_Button = new System.Windows.Forms.Button();
            this.Blue_Button = new System.Windows.Forms.Button();
            this.Disk_Color_Label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Color_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Players_Label
            // 
            this.Players_Label.AutoSize = true;
            this.Players_Label.BackColor = System.Drawing.Color.Transparent;
            this.Players_Label.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Bold);
            this.Players_Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Players_Label.Location = new System.Drawing.Point(419, 55);
            this.Players_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Players_Label.Name = "Players_Label";
            this.Players_Label.Size = new System.Drawing.Size(92, 32);
            this.Players_Label.TabIndex = 8;
            this.Players_Label.Text = "Players";
            // 
            // Players_ListBox
            // 
            this.Players_ListBox.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Players_ListBox.FormattingEnabled = true;
            this.Players_ListBox.ItemHeight = 21;
            this.Players_ListBox.Location = new System.Drawing.Point(424, 89);
            this.Players_ListBox.Margin = new System.Windows.Forms.Padding(4);
            this.Players_ListBox.Name = "Players_ListBox";
            this.Players_ListBox.Size = new System.Drawing.Size(277, 256);
            this.Players_ListBox.TabIndex = 7;
            // 
            // Rooms_Label
            // 
            this.Rooms_Label.AutoSize = true;
            this.Rooms_Label.BackColor = System.Drawing.Color.Transparent;
            this.Rooms_Label.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Bold);
            this.Rooms_Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Rooms_Label.Location = new System.Drawing.Point(64, 55);
            this.Rooms_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Rooms_Label.Name = "Rooms_Label";
            this.Rooms_Label.Size = new System.Drawing.Size(89, 32);
            this.Rooms_Label.TabIndex = 6;
            this.Rooms_Label.Text = "Rooms";
            // 
            // Rooms_ListBox
            // 
            this.Rooms_ListBox.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Rooms_ListBox.FormattingEnabled = true;
            this.Rooms_ListBox.ItemHeight = 21;
            this.Rooms_ListBox.Location = new System.Drawing.Point(69, 89);
            this.Rooms_ListBox.Margin = new System.Windows.Forms.Padding(4);
            this.Rooms_ListBox.Name = "Rooms_ListBox";
            this.Rooms_ListBox.Size = new System.Drawing.Size(277, 256);
            this.Rooms_ListBox.TabIndex = 5;
            this.Rooms_ListBox.SelectedIndexChanged += new System.EventHandler(this.Rooms_ListBox_SelectedIndexChanged);
            // 
            // Create_Button
            // 
            this.Create_Button.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.Create_Button.Location = new System.Drawing.Point(272, 55);
            this.Create_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Create_Button.Name = "Create_Button";
            this.Create_Button.Size = new System.Drawing.Size(76, 32);
            this.Create_Button.TabIndex = 9;
            this.Create_Button.Text = "Create";
            this.Create_Button.UseVisualStyleBackColor = true;
            this.Create_Button.Click += new System.EventHandler(this.Create_Button_Click);
            // 
            // Play_Button
            // 
            this.Play_Button.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Play_Button.Location = new System.Drawing.Point(607, 357);
            this.Play_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Play_Button.Name = "Play_Button";
            this.Play_Button.Size = new System.Drawing.Size(96, 44);
            this.Play_Button.TabIndex = 10;
            this.Play_Button.Text = "Play";
            this.Play_Button.UseVisualStyleBackColor = true;
            this.Play_Button.Click += new System.EventHandler(this.Play_Button_Click);
            // 
            // Color_Panel
            // 
            this.Color_Panel.Controls.Add(this.Red_Button);
            this.Color_Panel.Controls.Add(this.Green_Button);
            this.Color_Panel.Controls.Add(this.Yellow_Button);
            this.Color_Panel.Controls.Add(this.Blue_Button);
            this.Color_Panel.Location = new System.Drawing.Point(69, 389);
            this.Color_Panel.Margin = new System.Windows.Forms.Padding(4);
            this.Color_Panel.Name = "Color_Panel";
            this.Color_Panel.Size = new System.Drawing.Size(172, 52);
            this.Color_Panel.TabIndex = 11;
            // 
            // Red_Button
            // 
            this.Red_Button.BackColor = System.Drawing.Color.Red;
            this.Red_Button.Location = new System.Drawing.Point(4, 7);
            this.Red_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Red_Button.Name = "Red_Button";
            this.Red_Button.Size = new System.Drawing.Size(40, 37);
            this.Red_Button.TabIndex = 16;
            this.Red_Button.UseVisualStyleBackColor = false;
            // 
            // Green_Button
            // 
            this.Green_Button.BackColor = System.Drawing.Color.DarkGreen;
            this.Green_Button.Location = new System.Drawing.Point(124, 7);
            this.Green_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Green_Button.Name = "Green_Button";
            this.Green_Button.Size = new System.Drawing.Size(40, 37);
            this.Green_Button.TabIndex = 19;
            this.Green_Button.UseVisualStyleBackColor = false;
            // 
            // Yellow_Button
            // 
            this.Yellow_Button.BackColor = System.Drawing.Color.Orange;
            this.Yellow_Button.Location = new System.Drawing.Point(44, 7);
            this.Yellow_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Yellow_Button.Name = "Yellow_Button";
            this.Yellow_Button.Size = new System.Drawing.Size(40, 37);
            this.Yellow_Button.TabIndex = 18;
            this.Yellow_Button.UseVisualStyleBackColor = false;
            // 
            // Blue_Button
            // 
            this.Blue_Button.BackColor = System.Drawing.Color.DarkBlue;
            this.Blue_Button.Location = new System.Drawing.Point(84, 7);
            this.Blue_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Blue_Button.Name = "Blue_Button";
            this.Blue_Button.Size = new System.Drawing.Size(40, 37);
            this.Blue_Button.TabIndex = 17;
            this.Blue_Button.UseVisualStyleBackColor = false;
            // 
            // Disk_Color_Label
            // 
            this.Disk_Color_Label.AutoSize = true;
            this.Disk_Color_Label.BackColor = System.Drawing.Color.Transparent;
            this.Disk_Color_Label.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Bold);
            this.Disk_Color_Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Disk_Color_Label.Location = new System.Drawing.Point(65, 356);
            this.Disk_Color_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Disk_Color_Label.Name = "Disk_Color_Label";
            this.Disk_Color_Label.Size = new System.Drawing.Size(132, 32);
            this.Disk_Color_Label.TabIndex = 20;
            this.Disk_Color_Label.Text = "Disk Color";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Rooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(779, 567);
            this.Controls.Add(this.Disk_Color_Label);
            this.Controls.Add(this.Color_Panel);
            this.Controls.Add(this.Play_Button);
            this.Controls.Add(this.Create_Button);
            this.Controls.Add(this.Players_Label);
            this.Controls.Add(this.Players_ListBox);
            this.Controls.Add(this.Rooms_Label);
            this.Controls.Add(this.Rooms_ListBox);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Rooms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect4 Game";
            this.Color_Panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Players_Label;
        private System.Windows.Forms.ListBox Players_ListBox;
        private System.Windows.Forms.Label Rooms_Label;
        private System.Windows.Forms.ListBox Rooms_ListBox;
        private System.Windows.Forms.Button Create_Button;
        private System.Windows.Forms.Button Play_Button;
        private System.Windows.Forms.Panel Color_Panel;
        private System.Windows.Forms.Button Red_Button;
        private System.Windows.Forms.Button Green_Button;
        private System.Windows.Forms.Button Yellow_Button;
        private System.Windows.Forms.Button Blue_Button;
        private System.Windows.Forms.Label Disk_Color_Label;
        private System.Windows.Forms.Timer timer1;
    }
}