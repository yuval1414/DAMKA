
namespace UI
{
    partial class BoardGame
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
            this.Player1Name = new System.Windows.Forms.Label();
            this.Player2Name = new System.Windows.Forms.Label();
            this.Player1Score = new System.Windows.Forms.Label();
            this.Player2Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Player1Name
            // 
            this.Player1Name.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Player1Name.AutoSize = true;
            this.Player1Name.Location = new System.Drawing.Point(110, 24);
            this.Player1Name.Name = "Player1Name";
            this.Player1Name.Size = new System.Drawing.Size(65, 20);
            this.Player1Name.TabIndex = 0;
            this.Player1Name.Text = "Player1:";
            // 
            // Player2Name
            // 
            this.Player2Name.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Player2Name.AutoSize = true;
            this.Player2Name.Location = new System.Drawing.Point(283, 24);
            this.Player2Name.Name = "Player2Name";
            this.Player2Name.Size = new System.Drawing.Size(65, 20);
            this.Player2Name.TabIndex = 1;
            this.Player2Name.Text = "Player2:";
            // 
            // Player1Score
            // 
            this.Player1Score.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Player1Score.AutoSize = true;
            this.Player1Score.Location = new System.Drawing.Point(192, 24);
            this.Player1Score.Name = "Player1Score";
            this.Player1Score.Size = new System.Drawing.Size(18, 20);
            this.Player1Score.TabIndex = 2;
            this.Player1Score.Text = "0";
            // 
            // Player2Score
            // 
            this.Player2Score.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Player2Score.AutoSize = true;
            this.Player2Score.Location = new System.Drawing.Point(366, 24);
            this.Player2Score.Name = "Player2Score";
            this.Player2Score.Size = new System.Drawing.Size(18, 20);
            this.Player2Score.TabIndex = 3;
            this.Player2Score.Text = "0";
            // 
            // BoardGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(517, 365);
            this.Controls.Add(this.Player2Score);
            this.Controls.Add(this.Player1Score);
            this.Controls.Add(this.Player2Name);
            this.Controls.Add(this.Player1Name);
            this.Name = "BoardGame";
            this.Text = "BoardGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Player1Name;
        private System.Windows.Forms.Label Player2Name;
        private System.Windows.Forms.Label Player1Score;
        private System.Windows.Forms.Label Player2Score;
    }
}