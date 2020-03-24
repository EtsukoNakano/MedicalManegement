namespace MedicalManegement
{
    partial class JusinsyaKanriForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbID = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtKeika = new System.Windows.Forms.TextBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.btnTouroku = new System.Windows.Forms.Button();
            this.btnAny = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtZipcode = new System.Windows.Forms.MaskedTextBox();
            this.txtHokensyo = new System.Windows.Forms.MaskedTextBox();
            this.txtTel = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 32F);
            this.label1.Location = new System.Drawing.Point(123, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "＜受診者管理＞";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label2.Location = new System.Drawing.Point(9, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(502, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "※患者情報を削除・修正する場合にだけ患者IDを選択してください※　患者ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label3.Location = new System.Drawing.Point(146, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "保険証番号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label4.Location = new System.Drawing.Point(12, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "氏名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label5.Location = new System.Drawing.Point(458, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "性別";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label6.Location = new System.Drawing.Point(12, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "郵便番号";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label7.Location = new System.Drawing.Point(12, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "住所";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label8.Location = new System.Drawing.Point(298, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "電話番号";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label9.Location = new System.Drawing.Point(12, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "治療経過";
            // 
            // cmbID
            // 
            this.cmbID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbID.FormattingEnabled = true;
            this.cmbID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cmbID.Location = new System.Drawing.Point(488, 78);
            this.cmbID.Name = "cmbID";
            this.cmbID.Size = new System.Drawing.Size(72, 20);
            this.cmbID.TabIndex = 1;
            this.cmbID.UseWaitCursor = true;
            this.cmbID.Leave += new System.EventHandler(this.cmbID_Leave);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(34, 134);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(209, 19);
            this.txtName.TabIndex = 2;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(34, 226);
            this.txtAddress.MaxLength = 50;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(526, 19);
            this.txtAddress.TabIndex = 9;
            // 
            // txtKeika
            // 
            this.txtKeika.Location = new System.Drawing.Point(34, 272);
            this.txtKeika.MaxLength = 100;
            this.txtKeika.Name = "txtKeika";
            this.txtKeika.Size = new System.Drawing.Size(526, 19);
            this.txtKeika.TabIndex = 10;
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "男性",
            "女性",
            "その他"});
            this.cmbGender.Location = new System.Drawing.Point(488, 133);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(72, 20);
            this.cmbGender.TabIndex = 4;
            // 
            // btnTouroku
            // 
            this.btnTouroku.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnTouroku.Location = new System.Drawing.Point(360, 309);
            this.btnTouroku.Name = "btnTouroku";
            this.btnTouroku.Size = new System.Drawing.Size(200, 40);
            this.btnTouroku.TabIndex = 11;
            this.btnTouroku.Text = "登録/修正";
            this.btnTouroku.UseVisualStyleBackColor = true;
            this.btnTouroku.Click += new System.EventHandler(this.btnTouroku_Click);
            // 
            // btnAny
            // 
            this.btnAny.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnAny.Location = new System.Drawing.Point(34, 309);
            this.btnAny.Name = "btnAny";
            this.btnAny.Size = new System.Drawing.Size(200, 40);
            this.btnAny.TabIndex = 12;
            this.btnAny.Text = "一覧表示/削除";
            this.btnAny.UseVisualStyleBackColor = true;
            this.btnAny.Click += new System.EventHandler(this.btnAny_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label10.Location = new System.Drawing.Point(12, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(434, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "新規登録の場合は氏名以降の項目をすべて入力・選択してください";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label11.Location = new System.Drawing.Point(458, 164);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 12;
            this.label11.Text = "担当医";
            // 
            // txtDoctor
            // 
            this.txtDoctor.Location = new System.Drawing.Point(488, 183);
            this.txtDoctor.MaxLength = 20;
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(72, 19);
            this.txtDoctor.TabIndex = 8;
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.dtpBirthday.Location = new System.Drawing.Point(301, 134);
            this.dtpBirthday.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(130, 19);
            this.dtpBirthday.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label12.Location = new System.Drawing.Point(268, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 16);
            this.label12.TabIndex = 15;
            this.label12.Text = "生年月日";
            // 
            // txtZipcode
            // 
            this.txtZipcode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtZipcode.Location = new System.Drawing.Point(34, 183);
            this.txtZipcode.Mask = "000-0000";
            this.txtZipcode.Name = "txtZipcode";
            this.txtZipcode.Size = new System.Drawing.Size(100, 19);
            this.txtZipcode.TabIndex = 5;
            // 
            // txtHokensyo
            // 
            this.txtHokensyo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtHokensyo.Location = new System.Drawing.Point(167, 183);
            this.txtHokensyo.Mask = "99000000";
            this.txtHokensyo.Name = "txtHokensyo";
            this.txtHokensyo.Size = new System.Drawing.Size(100, 19);
            this.txtHokensyo.TabIndex = 6;
            // 
            // txtTel
            // 
            this.txtTel.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTel.Location = new System.Drawing.Point(331, 183);
            this.txtTel.Mask = "00000000009";
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(100, 19);
            this.txtTel.TabIndex = 7;
            // 
            // JusinsyaKanriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtHokensyo);
            this.Controls.Add(this.txtZipcode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtpBirthday);
            this.Controls.Add(this.txtDoctor);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnAny);
            this.Controls.Add(this.btnTouroku);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.txtKeika);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmbID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "JusinsyaKanriForm";
            this.Text = "受診者管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtKeika;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Button btnTouroku;
        private System.Windows.Forms.Button btnAny;
        private System.Windows.Forms.ComboBox cmbID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox txtZipcode;
        private System.Windows.Forms.MaskedTextBox txtHokensyo;
        private System.Windows.Forms.MaskedTextBox txtTel;
    }
}