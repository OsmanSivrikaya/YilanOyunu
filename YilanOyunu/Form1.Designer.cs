
namespace YilanOyunu
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl = new System.Windows.Forms.Panel();
            this.lblPuan = new System.Windows.Forms.Label();
            this.lblPuan2 = new System.Windows.Forms.Label();
            this.lblSure = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timerYılanHaraket = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(26, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 89);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // pnl
            // 
            this.pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl.Location = new System.Drawing.Point(26, 111);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(400, 260);
            this.pnl.TabIndex = 1;
            // 
            // lblPuan
            // 
            this.lblPuan.AutoSize = true;
            this.lblPuan.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPuan.Location = new System.Drawing.Point(35, 13);
            this.lblPuan.Name = "lblPuan";
            this.lblPuan.Size = new System.Drawing.Size(45, 16);
            this.lblPuan.TabIndex = 2;
            this.lblPuan.Text = "Puan :";
            // 
            // lblPuan2
            // 
            this.lblPuan2.AutoSize = true;
            this.lblPuan2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPuan2.Location = new System.Drawing.Point(86, 13);
            this.lblPuan2.Name = "lblPuan2";
            this.lblPuan2.Size = new System.Drawing.Size(15, 16);
            this.lblPuan2.TabIndex = 3;
            this.lblPuan2.Text = "0";
            // 
            // lblSure
            // 
            this.lblSure.AutoSize = true;
            this.lblSure.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblSure.Location = new System.Drawing.Point(397, 13);
            this.lblSure.Name = "lblSure";
            this.lblSure.Size = new System.Drawing.Size(15, 16);
            this.lblSure.TabIndex = 5;
            this.lblSure.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(346, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Süre:";
            // 
            // timerYılanHaraket
            // 
            this.timerYılanHaraket.Tick += new System.EventHandler(this.timerYılanHaraket_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(455, 394);
            this.Controls.Add(this.lblSure);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPuan2);
            this.Controls.Add(this.lblPuan);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Yılan Oyunu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Label lblPuan;
        private System.Windows.Forms.Label lblPuan2;
        private System.Windows.Forms.Label lblSure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerYılanHaraket;
        private System.Windows.Forms.Timer timer1;
    }
}

