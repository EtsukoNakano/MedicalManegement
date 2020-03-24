namespace MedicalManegement
{
    partial class StartMenuForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnJushinsyaKanri = new System.Windows.Forms.Button();
            this.btnYoyakuKanri = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 32F);
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "受診管理システム";
            // 
            // btnJushinsyaKanri
            // 
            this.btnJushinsyaKanri.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnJushinsyaKanri.Location = new System.Drawing.Point(118, 110);
            this.btnJushinsyaKanri.Name = "btnJushinsyaKanri";
            this.btnJushinsyaKanri.Size = new System.Drawing.Size(200, 40);
            this.btnJushinsyaKanri.TabIndex = 1;
            this.btnJushinsyaKanri.Text = "受診者管理";
            this.btnJushinsyaKanri.UseVisualStyleBackColor = true;
            this.btnJushinsyaKanri.Click += new System.EventHandler(this.btnJushinsyaKanri_Click);
            // 
            // btnYoyakuKanri
            // 
            this.btnYoyakuKanri.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnYoyakuKanri.Location = new System.Drawing.Point(118, 193);
            this.btnYoyakuKanri.Name = "btnYoyakuKanri";
            this.btnYoyakuKanri.Size = new System.Drawing.Size(200, 40);
            this.btnYoyakuKanri.TabIndex = 2;
            this.btnYoyakuKanri.Text = "予約管理";
            this.btnYoyakuKanri.UseVisualStyleBackColor = true;
            this.btnYoyakuKanri.Click += new System.EventHandler(this.btnYoyakuKanri_Click);
            // 
            // StartMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 311);
            this.Controls.Add(this.btnYoyakuKanri);
            this.Controls.Add(this.btnJushinsyaKanri);
            this.Controls.Add(this.label1);
            this.Name = "StartMenuForm";
            this.Text = "受診管理システム";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnJushinsyaKanri;
        private System.Windows.Forms.Button btnYoyakuKanri;
    }
}

