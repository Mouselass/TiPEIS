
namespace LoanAgreement
{
    partial class FormAgent
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.labelFIO = new System.Windows.Forms.Label();
            this.textBoxPost = new System.Windows.Forms.TextBox();
            this.labelPost = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(191, 72);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(110, 72);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // textBoxType
            // 
            this.textBoxType.Location = new System.Drawing.Point(86, 12);
            this.textBoxType.MaxLength = 50;
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.Size = new System.Drawing.Size(250, 20);
            this.textBoxType.TabIndex = 12;
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Location = new System.Drawing.Point(12, 15);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(37, 13);
            this.labelFIO.TabIndex = 11;
            this.labelFIO.Text = "ФИО:";
            // 
            // textBoxPost
            // 
            this.textBoxPost.Location = new System.Drawing.Point(86, 46);
            this.textBoxPost.MaxLength = 50;
            this.textBoxPost.Name = "textBoxPost";
            this.textBoxPost.Size = new System.Drawing.Size(250, 20);
            this.textBoxPost.TabIndex = 16;
            // 
            // labelPost
            // 
            this.labelPost.AutoSize = true;
            this.labelPost.Location = new System.Drawing.Point(12, 49);
            this.labelPost.Name = "labelPost";
            this.labelPost.Size = new System.Drawing.Size(68, 13);
            this.labelPost.TabIndex = 15;
            this.labelPost.Text = "Должность:";
            // 
            // FormAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 109);
            this.Controls.Add(this.textBoxPost);
            this.Controls.Add(this.labelPost);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxType);
            this.Controls.Add(this.labelFIO);
            this.Name = "FormAgent";
            this.Text = "Агент";
            this.Load += new System.EventHandler(this.FormAgent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.TextBox textBoxPost;
        private System.Windows.Forms.Label labelPost;
    }
}