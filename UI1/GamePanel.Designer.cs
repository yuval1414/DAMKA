
namespace UI
{
    partial class GamePanel
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
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.radioButton6X6 = new System.Windows.Forms.RadioButton();
            this.radioButton8X8 = new System.Windows.Forms.RadioButton();
            this.radioButton10X10 = new System.Windows.Forms.RadioButton();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBoardSize.Location = new System.Drawing.Point(32, 17);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(102, 22);
            this.labelBoardSize.TabIndex = 0;
            this.labelBoardSize.Text = "Board Size:";
            // 
            // radioButton6X6
            // 
            this.radioButton6X6.AutoSize = true;
            this.radioButton6X6.Location = new System.Drawing.Point(66, 54);
            this.radioButton6X6.Margin = new System.Windows.Forms.Padding(5);
            this.radioButton6X6.Name = "radioButton6X6";
            this.radioButton6X6.Size = new System.Drawing.Size(63, 24);
            this.radioButton6X6.TabIndex = 1;
            this.radioButton6X6.TabStop = true;
            this.radioButton6X6.Text = "6X6";
            this.radioButton6X6.UseVisualStyleBackColor = true;
            // 
            // radioButton8X8
            // 
            this.radioButton8X8.AutoSize = true;
            this.radioButton8X8.Location = new System.Drawing.Point(138, 54);
            this.radioButton8X8.Margin = new System.Windows.Forms.Padding(5);
            this.radioButton8X8.Name = "radioButton8X8";
            this.radioButton8X8.Size = new System.Drawing.Size(63, 24);
            this.radioButton8X8.TabIndex = 2;
            this.radioButton8X8.TabStop = true;
            this.radioButton8X8.Text = "8X8";
            this.radioButton8X8.UseVisualStyleBackColor = true;
            // 
            // radioButton10X10
            // 
            this.radioButton10X10.AutoSize = true;
            this.radioButton10X10.Location = new System.Drawing.Point(211, 54);
            this.radioButton10X10.Margin = new System.Windows.Forms.Padding(5);
            this.radioButton10X10.Name = "radioButton10X10";
            this.radioButton10X10.Size = new System.Drawing.Size(81, 24);
            this.radioButton10X10.TabIndex = 3;
            this.radioButton10X10.TabStop = true;
            this.radioButton10X10.Text = "10X10";
            this.radioButton10X10.UseVisualStyleBackColor = true;
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayers.Location = new System.Drawing.Point(32, 92);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(75, 22);
            this.labelPlayers.TabIndex = 4;
            this.labelPlayers.Text = "Players:";
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer1.Location = new System.Drawing.Point(60, 133);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(69, 20);
            this.labelPlayer1.TabIndex = 5;
            this.labelPlayer1.Text = "Player 1:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox1.Location = new System.Drawing.Point(154, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 26);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox2.Enabled = false;
            this.textBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox2.Location = new System.Drawing.Point(154, 162);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(138, 26);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "[Computer]";
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPlayer2.Location = new System.Drawing.Point(36, 164);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(95, 24);
            this.checkBoxPlayer2.TabIndex = 8;
            this.checkBoxPlayer2.Text = "Player 2:";
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);
            // 
            // buttonDone
            // 
            this.buttonDone.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonDone.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.buttonDone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDone.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDone.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonDone.Location = new System.Drawing.Point(188, 206);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(78, 37);
            this.buttonDone.TabIndex = 9;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = false;
            this.buttonDone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonDone_MouseClick);
            // 
            // GamePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(368, 255);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.labelPlayers);
            this.Controls.Add(this.radioButton10X10);
            this.Controls.Add(this.radioButton8X8);
            this.Controls.Add(this.radioButton6X6);
            this.Controls.Add(this.labelBoardSize);
            this.Name = "GamePanel";
            this.Text = "GamePanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.RadioButton radioButton6X6;
        private System.Windows.Forms.RadioButton radioButton8X8;
        private System.Windows.Forms.RadioButton radioButton10X10;
        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.Button buttonDone;
    }
}

