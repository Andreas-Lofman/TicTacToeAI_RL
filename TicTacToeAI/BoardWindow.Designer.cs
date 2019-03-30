namespace TicTacToeAI
{
    partial class BoardWindow
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.button_1 = new System.Windows.Forms.Button();
            this.button_2 = new System.Windows.Forms.Button();
            this.button_3 = new System.Windows.Forms.Button();
            this.button_4 = new System.Windows.Forms.Button();
            this.button_5 = new System.Windows.Forms.Button();
            this.button_6 = new System.Windows.Forms.Button();
            this.button_7 = new System.Windows.Forms.Button();
            this.button_8 = new System.Windows.Forms.Button();
            this.button_9 = new System.Windows.Forms.Button();
            this.AnnouncerLabel = new System.Windows.Forms.Label();
            this.EndGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(118, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(583, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome! What do you want to do?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Lucida Fax", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(164, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 101);
            this.button1.TabIndex = 3;
            this.button1.Text = "Play with AI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Lucida Fax", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(423, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 101);
            this.button2.TabIndex = 4;
            this.button2.Text = "Learn the AI";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(320, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 27);
            this.label3.TabIndex = 9;
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(132, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(532, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "Running 100000 out of 100000 episodes";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Lucida Fax", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(292, 312);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(197, 48);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Visible = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // button_1
            // 
            this.button_1.Font = new System.Drawing.Font("Lucida Handwriting", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_1.Location = new System.Drawing.Point(245, 211);
            this.button_1.Name = "button_1";
            this.button_1.Size = new System.Drawing.Size(98, 95);
            this.button_1.TabIndex = 11;
            this.button_1.UseVisualStyleBackColor = true;
            this.button_1.Visible = false;
            this.button_1.Click += new System.EventHandler(this.button_1_Click);
            // 
            // button_2
            // 
            this.button_2.Font = new System.Drawing.Font("Lucida Handwriting", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_2.Location = new System.Drawing.Point(349, 212);
            this.button_2.Name = "button_2";
            this.button_2.Size = new System.Drawing.Size(98, 95);
            this.button_2.TabIndex = 12;
            this.button_2.UseVisualStyleBackColor = true;
            this.button_2.Visible = false;
            this.button_2.Click += new System.EventHandler(this.button_2_Click);
            // 
            // button_3
            // 
            this.button_3.Font = new System.Drawing.Font("Lucida Handwriting", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_3.Location = new System.Drawing.Point(453, 212);
            this.button_3.Name = "button_3";
            this.button_3.Size = new System.Drawing.Size(98, 95);
            this.button_3.TabIndex = 13;
            this.button_3.UseVisualStyleBackColor = true;
            this.button_3.Visible = false;
            this.button_3.Click += new System.EventHandler(this.button_3_Click);
            // 
            // button_4
            // 
            this.button_4.Font = new System.Drawing.Font("Lucida Handwriting", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_4.Location = new System.Drawing.Point(245, 312);
            this.button_4.Name = "button_4";
            this.button_4.Size = new System.Drawing.Size(98, 95);
            this.button_4.TabIndex = 14;
            this.button_4.UseVisualStyleBackColor = true;
            this.button_4.Visible = false;
            this.button_4.Click += new System.EventHandler(this.button_4_Click);
            // 
            // button_5
            // 
            this.button_5.Font = new System.Drawing.Font("Lucida Handwriting", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_5.Location = new System.Drawing.Point(349, 313);
            this.button_5.Name = "button_5";
            this.button_5.Size = new System.Drawing.Size(98, 95);
            this.button_5.TabIndex = 15;
            this.button_5.UseVisualStyleBackColor = true;
            this.button_5.Visible = false;
            this.button_5.Click += new System.EventHandler(this.button_5_Click);
            // 
            // button_6
            // 
            this.button_6.Font = new System.Drawing.Font("Lucida Handwriting", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_6.Location = new System.Drawing.Point(453, 313);
            this.button_6.Name = "button_6";
            this.button_6.Size = new System.Drawing.Size(98, 95);
            this.button_6.TabIndex = 16;
            this.button_6.UseVisualStyleBackColor = true;
            this.button_6.Visible = false;
            this.button_6.Click += new System.EventHandler(this.button_6_Click);
            // 
            // button_7
            // 
            this.button_7.Font = new System.Drawing.Font("Lucida Handwriting", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_7.Location = new System.Drawing.Point(245, 413);
            this.button_7.Name = "button_7";
            this.button_7.Size = new System.Drawing.Size(98, 95);
            this.button_7.TabIndex = 17;
            this.button_7.UseVisualStyleBackColor = true;
            this.button_7.Visible = false;
            this.button_7.Click += new System.EventHandler(this.button_7_Click);
            // 
            // button_8
            // 
            this.button_8.Font = new System.Drawing.Font("Lucida Handwriting", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_8.Location = new System.Drawing.Point(349, 414);
            this.button_8.Name = "button_8";
            this.button_8.Size = new System.Drawing.Size(98, 95);
            this.button_8.TabIndex = 18;
            this.button_8.UseVisualStyleBackColor = true;
            this.button_8.Visible = false;
            this.button_8.Click += new System.EventHandler(this.button_8_Click);
            // 
            // button_9
            // 
            this.button_9.Font = new System.Drawing.Font("Lucida Handwriting", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_9.Location = new System.Drawing.Point(453, 414);
            this.button_9.Name = "button_9";
            this.button_9.Size = new System.Drawing.Size(98, 95);
            this.button_9.TabIndex = 19;
            this.button_9.UseVisualStyleBackColor = true;
            this.button_9.Visible = false;
            this.button_9.Click += new System.EventHandler(this.button_9_Click);
            // 
            // AnnouncerLabel
            // 
            this.AnnouncerLabel.AutoSize = true;
            this.AnnouncerLabel.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnnouncerLabel.Location = new System.Drawing.Point(593, 346);
            this.AnnouncerLabel.Name = "AnnouncerLabel";
            this.AnnouncerLabel.Size = new System.Drawing.Size(159, 27);
            this.AnnouncerLabel.TabIndex = 20;
            this.AnnouncerLabel.Text = "Player won!";
            this.AnnouncerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AnnouncerLabel.Visible = false;
            this.AnnouncerLabel.Click += new System.EventHandler(this.AnnouncerLabel_Click);
            // 
            // EndGameButton
            // 
            this.EndGameButton.Font = new System.Drawing.Font("Lucida Fax", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndGameButton.Location = new System.Drawing.Point(86, 330);
            this.EndGameButton.Name = "EndGameButton";
            this.EndGameButton.Size = new System.Drawing.Size(108, 61);
            this.EndGameButton.TabIndex = 21;
            this.EndGameButton.Text = "End game";
            this.EndGameButton.UseVisualStyleBackColor = true;
            this.EndGameButton.Visible = false;
            this.EndGameButton.Click += new System.EventHandler(this.EndGameButton_Click);
            // 
            // BoardWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 526);
            this.Controls.Add(this.EndGameButton);
            this.Controls.Add(this.AnnouncerLabel);
            this.Controls.Add(this.button_9);
            this.Controls.Add(this.button_8);
            this.Controls.Add(this.button_7);
            this.Controls.Add(this.button_6);
            this.Controls.Add(this.button_5);
            this.Controls.Add(this.button_4);
            this.Controls.Add(this.button_3);
            this.Controls.Add(this.button_2);
            this.Controls.Add(this.button_1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "BoardWindow";
            this.ShowIcon = false;
            this.Text = "Tic-Tac-Toe";
            this.Load += new System.EventHandler(this.BoardWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button button_1;
        private System.Windows.Forms.Button button_2;
        private System.Windows.Forms.Button button_3;
        private System.Windows.Forms.Button button_4;
        private System.Windows.Forms.Button button_5;
        private System.Windows.Forms.Button button_6;
        private System.Windows.Forms.Button button_7;
        private System.Windows.Forms.Button button_8;
        private System.Windows.Forms.Button button_9;
        private System.Windows.Forms.Label AnnouncerLabel;
        private System.Windows.Forms.Button EndGameButton;
    }
}