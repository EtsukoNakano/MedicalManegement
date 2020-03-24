namespace MedicalManegement
{
    partial class YoyakuKanriForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbYoyakuID = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbYoyakuTime = new System.Windows.Forms.ComboBox();
            this.btnYoyakuKensaku = new System.Windows.Forms.Button();
            this.btnYoyakuTouroku = new System.Windows.Forms.Button();
            this.cmbYoyakuName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSinryoka = new System.Windows.Forms.ComboBox();
            this.dtpYoyakuDay = new System.Windows.Forms.DateTimePicker();
            this.lblTourokuTitle = new System.Windows.Forms.Label();
            this.lblYobidasiTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 32F);
            this.label1.Location = new System.Drawing.Point(148, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "＜予約管理＞";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label2.Location = new System.Drawing.Point(13, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "患者ID";
            // 
            // cmbYoyakuID
            // 
            this.cmbYoyakuID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYoyakuID.FormattingEnabled = true;
            this.cmbYoyakuID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cmbYoyakuID.Location = new System.Drawing.Point(80, 88);
            this.cmbYoyakuID.Margin = new System.Windows.Forms.Padding(4);
            this.cmbYoyakuID.MaxLength = 3;
            this.cmbYoyakuID.Name = "cmbYoyakuID";
            this.cmbYoyakuID.Size = new System.Drawing.Size(200, 24);
            this.cmbYoyakuID.TabIndex = 2;
            this.cmbYoyakuID.UseWaitCursor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.lblName.Location = new System.Drawing.Point(16, 131);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 16);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "氏　名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label4.Location = new System.Drawing.Point(13, 213);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "予約日";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label3.Location = new System.Drawing.Point(16, 252);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "時　間";
            // 
            // cmbYoyakuTime
            // 
            this.cmbYoyakuTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYoyakuTime.FormattingEnabled = true;
            this.cmbYoyakuTime.Location = new System.Drawing.Point(80, 249);
            this.cmbYoyakuTime.Margin = new System.Windows.Forms.Padding(4);
            this.cmbYoyakuTime.Name = "cmbYoyakuTime";
            this.cmbYoyakuTime.Size = new System.Drawing.Size(200, 24);
            this.cmbYoyakuTime.TabIndex = 6;
            // 
            // btnYoyakuKensaku
            // 
            this.btnYoyakuKensaku.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnYoyakuKensaku.Location = new System.Drawing.Point(331, 88);
            this.btnYoyakuKensaku.Margin = new System.Windows.Forms.Padding(4);
            this.btnYoyakuKensaku.Name = "btnYoyakuKensaku";
            this.btnYoyakuKensaku.Size = new System.Drawing.Size(225, 53);
            this.btnYoyakuKensaku.TabIndex = 1;
            this.btnYoyakuKensaku.Text = "予約検索 / 削除";
            this.btnYoyakuKensaku.UseVisualStyleBackColor = true;
            this.btnYoyakuKensaku.Click += new System.EventHandler(this.btnYoyakuKensaku_Click);
            // 
            // btnYoyakuTouroku
            // 
            this.btnYoyakuTouroku.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnYoyakuTouroku.Location = new System.Drawing.Point(61, 295);
            this.btnYoyakuTouroku.Margin = new System.Windows.Forms.Padding(4);
            this.btnYoyakuTouroku.Name = "btnYoyakuTouroku";
            this.btnYoyakuTouroku.Size = new System.Drawing.Size(225, 53);
            this.btnYoyakuTouroku.TabIndex = 7;
            this.btnYoyakuTouroku.Text = "新規登録 / 予約票出力";
            this.btnYoyakuTouroku.UseVisualStyleBackColor = true;
            this.btnYoyakuTouroku.Click += new System.EventHandler(this.btnYoyakuTouroku_Click);
            // 
            // cmbYoyakuName
            // 
            this.cmbYoyakuName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYoyakuName.FormattingEnabled = true;
            this.cmbYoyakuName.Location = new System.Drawing.Point(80, 128);
            this.cmbYoyakuName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbYoyakuName.Name = "cmbYoyakuName";
            this.cmbYoyakuName.Size = new System.Drawing.Size(200, 24);
            this.cmbYoyakuName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "診療科";
            // 
            // cmbSinryoka
            // 
            this.cmbSinryoka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSinryoka.FormattingEnabled = true;
            this.cmbSinryoka.ItemHeight = 16;
            this.cmbSinryoka.Location = new System.Drawing.Point(80, 168);
            this.cmbSinryoka.Name = "cmbSinryoka";
            this.cmbSinryoka.Size = new System.Drawing.Size(200, 24);
            this.cmbSinryoka.TabIndex = 4;
            // 
            // dtpYoyakuDay
            // 
            this.dtpYoyakuDay.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.dtpYoyakuDay.Location = new System.Drawing.Point(80, 208);
            this.dtpYoyakuDay.Name = "dtpYoyakuDay";
            this.dtpYoyakuDay.Size = new System.Drawing.Size(200, 23);
            this.dtpYoyakuDay.TabIndex = 5;
            // 
            // lblTourokuTitle
            // 
            this.lblTourokuTitle.AutoSize = true;
            this.lblTourokuTitle.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.lblTourokuTitle.Location = new System.Drawing.Point(72, 63);
            this.lblTourokuTitle.Name = "lblTourokuTitle";
            this.lblTourokuTitle.Size = new System.Drawing.Size(208, 22);
            this.lblTourokuTitle.TabIndex = 10;
            this.lblTourokuTitle.Text = "予約新規登録フォーム";
            // 
            // lblYobidasiTitle
            // 
            this.lblYobidasiTitle.AutoSize = true;
            this.lblYobidasiTitle.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.lblYobidasiTitle.Location = new System.Drawing.Point(355, 63);
            this.lblYobidasiTitle.Name = "lblYobidasiTitle";
            this.lblYobidasiTitle.Size = new System.Drawing.Size(176, 22);
            this.lblYobidasiTitle.TabIndex = 11;
            this.lblYobidasiTitle.Text = "予約情報呼び出し";
            // 
            // YoyakuKanriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.lblYobidasiTitle);
            this.Controls.Add(this.lblTourokuTitle);
            this.Controls.Add(this.dtpYoyakuDay);
            this.Controls.Add(this.cmbSinryoka);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbYoyakuName);
            this.Controls.Add(this.btnYoyakuTouroku);
            this.Controls.Add(this.btnYoyakuKensaku);
            this.Controls.Add(this.cmbYoyakuTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cmbYoyakuID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "YoyakuKanriForm";
            this.Text = "予約管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbYoyakuID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbYoyakuTime;
        private System.Windows.Forms.Button btnYoyakuKensaku;
        private System.Windows.Forms.Button btnYoyakuTouroku;
        private System.Windows.Forms.ComboBox cmbYoyakuName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSinryoka;
        private System.Windows.Forms.DateTimePicker dtpYoyakuDay;
        private System.Windows.Forms.Label lblTourokuTitle;
        private System.Windows.Forms.Label lblYobidasiTitle;
    }
}