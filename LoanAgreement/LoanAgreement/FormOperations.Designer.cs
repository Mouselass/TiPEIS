
namespace LoanAgreement
{
    partial class FormOperations
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
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.labelType = new System.Windows.Forms.Label();
            this.dateTimePickerDateofconclusion = new System.Windows.Forms.DateTimePicker();
            this.labelDateofconclusion = new System.Windows.Forms.Label();
            this.labelLoanAgreement = new System.Windows.Forms.Label();
            this.comboBoxLoanAgreement = new System.Windows.Forms.ComboBox();
            this.labelSum = new System.Windows.Forms.Label();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.labelPaymentSum = new System.Windows.Forms.Label();
            this.textBoxPaymentSum = new System.Windows.Forms.TextBox();
            this.labelRemaining = new System.Windows.Forms.Label();
            this.textBoxRemaining = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(664, 311);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 23);
            this.buttonDel.TabIndex = 29;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.ButtonDel_Click);
            // 
            // buttonUpd
            // 
            this.buttonUpd.Location = new System.Drawing.Point(664, 268);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(75, 23);
            this.buttonUpd.TabIndex = 28;
            this.buttonUpd.Text = "Изменить";
            this.buttonUpd.UseVisualStyleBackColor = true;
            this.buttonUpd.Click += new System.EventHandler(this.ButtonUpd_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(664, 227);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 27;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(2, 72);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(649, 377);
            this.dataGridView.TabIndex = 26;
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(752, 112);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(170, 21);
            this.comboBoxType.TabIndex = 30;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(661, 115);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(80, 13);
            this.labelType.TabIndex = 31;
            this.labelType.Text = "Тип операции:";
            // 
            // dateTimePickerDateofconclusion
            // 
            this.dateTimePickerDateofconclusion.Location = new System.Drawing.Point(752, 150);
            this.dateTimePickerDateofconclusion.Name = "dateTimePickerDateofconclusion";
            this.dateTimePickerDateofconclusion.Size = new System.Drawing.Size(170, 20);
            this.dateTimePickerDateofconclusion.TabIndex = 41;
            // 
            // labelDateofconclusion
            // 
            this.labelDateofconclusion.AutoSize = true;
            this.labelDateofconclusion.Location = new System.Drawing.Point(661, 156);
            this.labelDateofconclusion.Name = "labelDateofconclusion";
            this.labelDateofconclusion.Size = new System.Drawing.Size(36, 13);
            this.labelDateofconclusion.TabIndex = 40;
            this.labelDateofconclusion.Text = "Дата:";
            // 
            // labelLoanAgreement
            // 
            this.labelLoanAgreement.AutoSize = true;
            this.labelLoanAgreement.Location = new System.Drawing.Point(661, 76);
            this.labelLoanAgreement.Name = "labelLoanAgreement";
            this.labelLoanAgreement.Size = new System.Drawing.Size(54, 13);
            this.labelLoanAgreement.TabIndex = 42;
            this.labelLoanAgreement.Text = "Договор:";
            // 
            // comboBoxLoanAgreement
            // 
            this.comboBoxLoanAgreement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLoanAgreement.FormattingEnabled = true;
            this.comboBoxLoanAgreement.Location = new System.Drawing.Point(752, 73);
            this.comboBoxLoanAgreement.Name = "comboBoxLoanAgreement";
            this.comboBoxLoanAgreement.Size = new System.Drawing.Size(170, 21);
            this.comboBoxLoanAgreement.TabIndex = 43;
            this.comboBoxLoanAgreement.SelectedIndexChanged += new System.EventHandler(this.comboBoxLoanAgreement_SelectedIndexChanged);
            this.comboBoxLoanAgreement.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.comboBoxLoanAgreement_Format);
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(661, 189);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(44, 13);
            this.labelSum.TabIndex = 44;
            this.labelSum.Text = "Сумма:";
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(752, 189);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.ReadOnly = true;
            this.textBoxSum.Size = new System.Drawing.Size(170, 20);
            this.textBoxSum.TabIndex = 45;
            // 
            // labelPaymentSum
            // 
            this.labelPaymentSum.AutoSize = true;
            this.labelPaymentSum.Location = new System.Drawing.Point(794, 227);
            this.labelPaymentSum.Name = "labelPaymentSum";
            this.labelPaymentSum.Size = new System.Drawing.Size(111, 13);
            this.labelPaymentSum.TabIndex = 46;
            this.labelPaymentSum.Text = "Сумма поступления:";
            this.labelPaymentSum.Visible = false;
            // 
            // textBoxPaymentSum
            // 
            this.textBoxPaymentSum.Location = new System.Drawing.Point(797, 254);
            this.textBoxPaymentSum.Name = "textBoxPaymentSum";
            this.textBoxPaymentSum.Size = new System.Drawing.Size(125, 20);
            this.textBoxPaymentSum.TabIndex = 47;
            this.textBoxPaymentSum.Visible = false;
            // 
            // labelRemaining
            // 
            this.labelRemaining.AutoSize = true;
            this.labelRemaining.Location = new System.Drawing.Point(794, 290);
            this.labelRemaining.Name = "labelRemaining";
            this.labelRemaining.Size = new System.Drawing.Size(109, 13);
            this.labelRemaining.TabIndex = 48;
            this.labelRemaining.Text = "Оставшаяся сумма:";
            this.labelRemaining.Visible = false;
            // 
            // textBoxRemaining
            // 
            this.textBoxRemaining.Location = new System.Drawing.Point(797, 314);
            this.textBoxRemaining.Name = "textBoxRemaining";
            this.textBoxRemaining.ReadOnly = true;
            this.textBoxRemaining.Size = new System.Drawing.Size(125, 20);
            this.textBoxRemaining.TabIndex = 49;
            this.textBoxRemaining.Visible = false;
            // 
            // FormOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 450);
            this.Controls.Add(this.textBoxRemaining);
            this.Controls.Add(this.labelRemaining);
            this.Controls.Add(this.textBoxPaymentSum);
            this.Controls.Add(this.labelPaymentSum);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.comboBoxLoanAgreement);
            this.Controls.Add(this.labelLoanAgreement);
            this.Controls.Add(this.dateTimePickerDateofconclusion);
            this.Controls.Add(this.labelDateofconclusion);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonUpd);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormOperations";
            this.Text = "Журнал операций";
            this.Load += new System.EventHandler(this.FormOperations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateofconclusion;
        private System.Windows.Forms.Label labelDateofconclusion;
        private System.Windows.Forms.Label labelLoanAgreement;
        private System.Windows.Forms.ComboBox comboBoxLoanAgreement;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Label labelPaymentSum;
        private System.Windows.Forms.TextBox textBoxPaymentSum;
        private System.Windows.Forms.Label labelRemaining;
        private System.Windows.Forms.TextBox textBoxRemaining;
    }
}