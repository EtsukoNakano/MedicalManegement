namespace MedicalManegement
{
    partial class IchiranKensaku
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
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGenderSinryoka = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBirthYoyaku = new System.Windows.Forms.Label();
            this.txtKensakuID = new System.Windows.Forms.TextBox();
            this.txtKensakuName = new System.Windows.Forms.TextBox();
            this.cmbGenderSinryoka = new System.Windows.Forms.ComboBox();
            this.dtpBirthYoyakuFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpBirthYoyakuTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.lblList = new System.Windows.Forms.Label();
            this.btnKensaku = new System.Windows.Forms.Button();
            this.rdoReverse = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(12, 30);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 21;
            this.dgvList.Size = new System.Drawing.Size(776, 273);
            this.dgvList.TabIndex = 0;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(40, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "患者ＩＤ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label2.Location = new System.Drawing.Point(192, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "氏　名";
            // 
            // lblGenderSinryoka
            // 
            this.lblGenderSinryoka.AutoSize = true;
            this.lblGenderSinryoka.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.lblGenderSinryoka.Location = new System.Drawing.Point(550, 341);
            this.lblGenderSinryoka.Name = "lblGenderSinryoka";
            this.lblGenderSinryoka.Size = new System.Drawing.Size(51, 16);
            this.lblGenderSinryoka.TabIndex = 3;
            this.lblGenderSinryoka.Text = "性　別";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label3.Location = new System.Drawing.Point(21, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(734, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "※検索条件を指定する場合は、いずれかを入力して「検索」ボタンを押してください※";
            // 
            // lblBirthYoyaku
            // 
            this.lblBirthYoyaku.AutoSize = true;
            this.lblBirthYoyaku.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.lblBirthYoyaku.Location = new System.Drawing.Point(24, 381);
            this.lblBirthYoyaku.Name = "lblBirthYoyaku";
            this.lblBirthYoyaku.Size = new System.Drawing.Size(72, 16);
            this.lblBirthYoyaku.TabIndex = 5;
            this.lblBirthYoyaku.Text = "生年月日";
            // 
            // txtKensakuID
            // 
            this.txtKensakuID.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.txtKensakuID.Location = new System.Drawing.Point(102, 338);
            this.txtKensakuID.MaxLength = 3;
            this.txtKensakuID.Name = "txtKensakuID";
            this.txtKensakuID.Size = new System.Drawing.Size(71, 23);
            this.txtKensakuID.TabIndex = 1;
            // 
            // txtKensakuName
            // 
            this.txtKensakuName.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.txtKensakuName.Location = new System.Drawing.Point(249, 338);
            this.txtKensakuName.MaxLength = 20;
            this.txtKensakuName.Name = "txtKensakuName";
            this.txtKensakuName.Size = new System.Drawing.Size(284, 23);
            this.txtKensakuName.TabIndex = 2;
            // 
            // cmbGenderSinryoka
            // 
            this.cmbGenderSinryoka.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.cmbGenderSinryoka.FormattingEnabled = true;
            this.cmbGenderSinryoka.Items.AddRange(new object[] {
            "男性",
            "女性",
            "その他"});
            this.cmbGenderSinryoka.Location = new System.Drawing.Point(607, 342);
            this.cmbGenderSinryoka.Name = "cmbGenderSinryoka";
            this.cmbGenderSinryoka.Size = new System.Drawing.Size(181, 24);
            this.cmbGenderSinryoka.TabIndex = 3;
            // 
            // dtpBirthYoyakuFrom
            // 
            this.dtpBirthYoyakuFrom.CalendarFont = new System.Drawing.Font("MS UI Gothic", 12F);
            this.dtpBirthYoyakuFrom.Location = new System.Drawing.Point(102, 381);
            this.dtpBirthYoyakuFrom.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpBirthYoyakuFrom.Name = "dtpBirthYoyakuFrom";
            this.dtpBirthYoyakuFrom.Size = new System.Drawing.Size(200, 19);
            this.dtpBirthYoyakuFrom.TabIndex = 4;
            this.dtpBirthYoyakuFrom.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // dtpBirthYoyakuTo
            // 
            this.dtpBirthYoyakuTo.CalendarFont = new System.Drawing.Font("MS UI Gothic", 12F);
            this.dtpBirthYoyakuTo.Location = new System.Drawing.Point(333, 381);
            this.dtpBirthYoyakuTo.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpBirthYoyakuTo.Name = "dtpBirthYoyakuTo";
            this.dtpBirthYoyakuTo.Size = new System.Drawing.Size(200, 19);
            this.dtpBirthYoyakuTo.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label5.Location = new System.Drawing.Point(309, 387);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "～";
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.lblList.Location = new System.Drawing.Point(12, 5);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(164, 22);
            this.lblList.TabIndex = 10;
            this.lblList.Text = "受診者情報一覧";
            // 
            // btnKensaku
            // 
            this.btnKensaku.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnKensaku.Location = new System.Drawing.Point(553, 398);
            this.btnKensaku.Name = "btnKensaku";
            this.btnKensaku.Size = new System.Drawing.Size(235, 40);
            this.btnKensaku.TabIndex = 7;
            this.btnKensaku.Text = "検索";
            this.btnKensaku.UseVisualStyleBackColor = true;
            this.btnKensaku.Click += new System.EventHandler(this.btnKensaku_Click);
            // 
            // rdoReverse
            // 
            this.rdoReverse.AutoSize = true;
            this.rdoReverse.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.rdoReverse.Location = new System.Drawing.Point(553, 376);
            this.rdoReverse.Name = "rdoReverse";
            this.rdoReverse.Size = new System.Drawing.Size(188, 20);
            this.rdoReverse.TabIndex = 6;
            this.rdoReverse.TabStop = true;
            this.rdoReverse.Text = "患者IDの降順で表示する";
            this.rdoReverse.UseVisualStyleBackColor = true;
            // 
            // IchiranKensaku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rdoReverse);
            this.Controls.Add(this.btnKensaku);
            this.Controls.Add(this.lblList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpBirthYoyakuTo);
            this.Controls.Add(this.dtpBirthYoyakuFrom);
            this.Controls.Add(this.cmbGenderSinryoka);
            this.Controls.Add(this.txtKensakuName);
            this.Controls.Add(this.txtKensakuID);
            this.Controls.Add(this.lblBirthYoyaku);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblGenderSinryoka);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvList);
            this.Name = "IchiranKensaku";
            this.Text = "一覧検索";
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGenderSinryoka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBirthYoyaku;
        private System.Windows.Forms.TextBox txtKensakuID;
        private System.Windows.Forms.TextBox txtKensakuName;
        private System.Windows.Forms.ComboBox cmbGenderSinryoka;
        private System.Windows.Forms.DateTimePicker dtpBirthYoyakuFrom;
        private System.Windows.Forms.DateTimePicker dtpBirthYoyakuTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.Button btnKensaku;
        private System.Windows.Forms.RadioButton rdoReverse;
    }
}