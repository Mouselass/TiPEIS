
namespace LoanAgreement
{
    partial class FormLoanAgreement
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
            this.dateTimePickerDateofconclusion = new System.Windows.Forms.DateTimePicker();
            this.comboBoxAgent = new System.Windows.Forms.ComboBox();
            this.labelAgent = new System.Windows.Forms.Label();
            this.labelDateofmaturity = new System.Windows.Forms.Label();
            this.labelDateofconclusion = new System.Windows.Forms.Label();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.labelMiddlename = new System.Windows.Forms.Label();
            this.textBoxPercent1 = new System.Windows.Forms.TextBox();
            this.labelPercent1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxCounterpartyLender = new System.Windows.Forms.ComboBox();
            this.labelCounterpartyLender = new System.Windows.Forms.Label();
            this.textBoxPercent2 = new System.Windows.Forms.TextBox();
            this.labelPercent2 = new System.Windows.Forms.Label();
            this.dateTimePickerDateofmaturity = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // dateTimePickerDateofconclusion
            // 
            this.dateTimePickerDateofconclusion.Location = new System.Drawing.Point(162, 204);
            this.dateTimePickerDateofconclusion.Name = "dateTimePickerDateofconclusion";
            this.dateTimePickerDateofconclusion.Size = new System.Drawing.Size(158, 20);
            this.dateTimePickerDateofconclusion.TabIndex = 39;
            // 
            // comboBoxAgent
            // 
            this.comboBoxAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAgent.Location = new System.Drawing.Point(162, 58);
            this.comboBoxAgent.Name = "comboBoxAgent";
            this.comboBoxAgent.Size = new System.Drawing.Size(158, 21);
            this.comboBoxAgent.TabIndex = 38;
            // 
            // labelAgent
            // 
            this.labelAgent.AutoSize = true;
            this.labelAgent.Location = new System.Drawing.Point(23, 61);
            this.labelAgent.Name = "labelAgent";
            this.labelAgent.Size = new System.Drawing.Size(39, 13);
            this.labelAgent.TabIndex = 37;
            this.labelAgent.Text = "Агент:";
            // 
            // labelDateofmaturity
            // 
            this.labelDateofmaturity.AutoSize = true;
            this.labelDateofmaturity.Location = new System.Drawing.Point(23, 241);
            this.labelDateofmaturity.Name = "labelDateofmaturity";
            this.labelDateofmaturity.Size = new System.Drawing.Size(91, 13);
            this.labelDateofmaturity.TabIndex = 33;
            this.labelDateofmaturity.Text = "Дата истечения:";
            // 
            // labelDateofconclusion
            // 
            this.labelDateofconclusion.AutoSize = true;
            this.labelDateofconclusion.Location = new System.Drawing.Point(23, 210);
            this.labelDateofconclusion.Name = "labelDateofconclusion";
            this.labelDateofconclusion.Size = new System.Drawing.Size(100, 13);
            this.labelDateofconclusion.TabIndex = 32;
            this.labelDateofconclusion.Text = "Дата заключения:";
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(162, 163);
            this.textBoxSum.MaxLength = 18;
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(158, 20);
            this.textBoxSum.TabIndex = 31;
            // 
            // labelMiddlename
            // 
            this.labelMiddlename.AutoSize = true;
            this.labelMiddlename.Location = new System.Drawing.Point(23, 166);
            this.labelMiddlename.Name = "labelMiddlename";
            this.labelMiddlename.Size = new System.Drawing.Size(94, 13);
            this.labelMiddlename.TabIndex = 30;
            this.labelMiddlename.Text = "Сумма договора:";
            // 
            // textBoxPercent1
            // 
            this.textBoxPercent1.Location = new System.Drawing.Point(162, 90);
            this.textBoxPercent1.MaxLength = 6;
            this.textBoxPercent1.Name = "textBoxPercent1";
            this.textBoxPercent1.Size = new System.Drawing.Size(158, 20);
            this.textBoxPercent1.TabIndex = 29;
            // 
            // labelPercent1
            // 
            this.labelPercent1.AutoSize = true;
            this.labelPercent1.Location = new System.Drawing.Point(23, 93);
            this.labelPercent1.Name = "labelPercent1";
            this.labelPercent1.Size = new System.Drawing.Size(59, 13);
            this.labelPercent1.TabIndex = 28;
            this.labelPercent1.Text = "Процент1:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(215, 305);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 27;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(119, 305);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 26;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // comboBoxCounterpartyLender
            // 
            this.comboBoxCounterpartyLender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCounterpartyLender.Location = new System.Drawing.Point(162, 23);
            this.comboBoxCounterpartyLender.Name = "comboBoxCounterpartyLender";
            this.comboBoxCounterpartyLender.Size = new System.Drawing.Size(158, 21);
            this.comboBoxCounterpartyLender.TabIndex = 41;
            // 
            // labelCounterpartyLender
            // 
            this.labelCounterpartyLender.AutoSize = true;
            this.labelCounterpartyLender.Location = new System.Drawing.Point(23, 26);
            this.labelCounterpartyLender.Name = "labelCounterpartyLender";
            this.labelCounterpartyLender.Size = new System.Drawing.Size(133, 13);
            this.labelCounterpartyLender.TabIndex = 40;
            this.labelCounterpartyLender.Text = "Контрагент-заимодавец:";
            // 
            // textBoxPercent2
            // 
            this.textBoxPercent2.Location = new System.Drawing.Point(162, 125);
            this.textBoxPercent2.MaxLength = 6;
            this.textBoxPercent2.Name = "textBoxPercent2";
            this.textBoxPercent2.Size = new System.Drawing.Size(158, 20);
            this.textBoxPercent2.TabIndex = 43;
            // 
            // labelPercent2
            // 
            this.labelPercent2.AutoSize = true;
            this.labelPercent2.Location = new System.Drawing.Point(23, 128);
            this.labelPercent2.Name = "labelPercent2";
            this.labelPercent2.Size = new System.Drawing.Size(59, 13);
            this.labelPercent2.TabIndex = 42;
            this.labelPercent2.Text = "Процент2:";
            // 
            // dateTimePickerDateofmaturity
            // 
            this.dateTimePickerDateofmaturity.Location = new System.Drawing.Point(162, 235);
            this.dateTimePickerDateofmaturity.Name = "dateTimePickerDateofmaturity";
            this.dateTimePickerDateofmaturity.Size = new System.Drawing.Size(158, 20);
            this.dateTimePickerDateofmaturity.TabIndex = 44;
            // 
            // FormLoanAgreement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 348);
            this.Controls.Add(this.dateTimePickerDateofmaturity);
            this.Controls.Add(this.textBoxPercent2);
            this.Controls.Add(this.labelPercent2);
            this.Controls.Add(this.comboBoxCounterpartyLender);
            this.Controls.Add(this.labelCounterpartyLender);
            this.Controls.Add(this.dateTimePickerDateofconclusion);
            this.Controls.Add(this.comboBoxAgent);
            this.Controls.Add(this.labelAgent);
            this.Controls.Add(this.labelDateofmaturity);
            this.Controls.Add(this.labelDateofconclusion);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.labelMiddlename);
            this.Controls.Add(this.textBoxPercent1);
            this.Controls.Add(this.labelPercent1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Name = "FormLoanAgreement";
            this.Text = "Договор займа";
            this.Load += new System.EventHandler(this.FormLoanAgreement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerDateofconclusion;
        private System.Windows.Forms.ComboBox comboBoxAgent;
        private System.Windows.Forms.Label labelAgent;
        private System.Windows.Forms.Label labelDateofmaturity;
        private System.Windows.Forms.Label labelDateofconclusion;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Label labelMiddlename;
        private System.Windows.Forms.TextBox textBoxPercent1;
        private System.Windows.Forms.Label labelPercent1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxCounterpartyLender;
        private System.Windows.Forms.Label labelCounterpartyLender;
        private System.Windows.Forms.TextBox textBoxPercent2;
        private System.Windows.Forms.Label labelPercent2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateofmaturity;
    }
}