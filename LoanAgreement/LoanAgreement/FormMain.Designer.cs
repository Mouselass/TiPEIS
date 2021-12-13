
namespace LoanAgreement
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.контрагентызаимодавцыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.агентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.договорыЗаймаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналОперацийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналПроводокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ведомостьРасходовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ведомостьСуммПолученныхЗаймовЗаПериодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оборотносальдоваяВедомостьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьАрхивБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonAuthorize = new System.Windows.Forms.Button();
            this.labelRole = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.журналОперацийToolStripMenuItem,
            this.журналПроводокToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.создатьАрхивБДToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(886, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.контрагентызаимодавцыToolStripMenuItem,
            this.агентыToolStripMenuItem,
            this.договорыЗаймаToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // контрагентызаимодавцыToolStripMenuItem
            // 
            this.контрагентызаимодавцыToolStripMenuItem.Name = "контрагентызаимодавцыToolStripMenuItem";
            this.контрагентызаимодавцыToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.контрагентызаимодавцыToolStripMenuItem.Text = "Контрагенты-заимодавцы";
            this.контрагентызаимодавцыToolStripMenuItem.Click += new System.EventHandler(this.контрагентызаимодавцыToolStripMenuItem_Click);
            // 
            // агентыToolStripMenuItem
            // 
            this.агентыToolStripMenuItem.Name = "агентыToolStripMenuItem";
            this.агентыToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.агентыToolStripMenuItem.Text = "Агенты";
            this.агентыToolStripMenuItem.Click += new System.EventHandler(this.агентыToolStripMenuItem_Click);
            // 
            // договорыЗаймаToolStripMenuItem
            // 
            this.договорыЗаймаToolStripMenuItem.Name = "договорыЗаймаToolStripMenuItem";
            this.договорыЗаймаToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.договорыЗаймаToolStripMenuItem.Text = "Договоры займа";
            this.договорыЗаймаToolStripMenuItem.Click += new System.EventHandler(this.договорыЗаймаToolStripMenuItem_Click);
            // 
            // журналОперацийToolStripMenuItem
            // 
            this.журналОперацийToolStripMenuItem.Name = "журналОперацийToolStripMenuItem";
            this.журналОперацийToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.журналОперацийToolStripMenuItem.Text = "Журнал операций";
            this.журналОперацийToolStripMenuItem.Click += new System.EventHandler(this.журналОперацийToolStripMenuItem_Click);
            // 
            // журналПроводокToolStripMenuItem
            // 
            this.журналПроводокToolStripMenuItem.Name = "журналПроводокToolStripMenuItem";
            this.журналПроводокToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.журналПроводокToolStripMenuItem.Text = "Журнал проводок";
            this.журналПроводокToolStripMenuItem.Click += new System.EventHandler(this.журналПроводокToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ведомостьРасходовToolStripMenuItem,
            this.ведомостьСуммПолученныхЗаймовЗаПериодToolStripMenuItem,
            this.оборотносальдоваяВедомостьToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // ведомостьРасходовToolStripMenuItem
            // 
            this.ведомостьРасходовToolStripMenuItem.Name = "ведомостьРасходовToolStripMenuItem";
            this.ведомостьРасходовToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.ведомостьРасходовToolStripMenuItem.Text = "Ведомость расходов на получение займов за период";
            this.ведомостьРасходовToolStripMenuItem.Click += new System.EventHandler(this.ведомостьРасходовToolStripMenuItem_Click);
            // 
            // ведомостьСуммПолученныхЗаймовЗаПериодToolStripMenuItem
            // 
            this.ведомостьСуммПолученныхЗаймовЗаПериодToolStripMenuItem.Name = "ведомостьСуммПолученныхЗаймовЗаПериодToolStripMenuItem";
            this.ведомостьСуммПолученныхЗаймовЗаПериодToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.ведомостьСуммПолученныхЗаймовЗаПериодToolStripMenuItem.Text = "Ведомость сумм полученных займов за период";
            this.ведомостьСуммПолученныхЗаймовЗаПериодToolStripMenuItem.Click += new System.EventHandler(this.ведомостьСуммПолученныхЗаймовЗаПериодToolStripMenuItem_Click);
            // 
            // оборотносальдоваяВедомостьToolStripMenuItem
            // 
            this.оборотносальдоваяВедомостьToolStripMenuItem.Name = "оборотносальдоваяВедомостьToolStripMenuItem";
            this.оборотносальдоваяВедомостьToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.оборотносальдоваяВедомостьToolStripMenuItem.Text = "Оборотно-сальдовая ведомость";
            this.оборотносальдоваяВедомостьToolStripMenuItem.Click += new System.EventHandler(this.оборотносальдоваяВедомостьToolStripMenuItem_Click);
            // 
            // создатьАрхивБДToolStripMenuItem
            // 
            this.создатьАрхивБДToolStripMenuItem.Name = "создатьАрхивБДToolStripMenuItem";
            this.создатьАрхивБДToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.создатьАрхивБДToolStripMenuItem.Text = "Создать архив БД";
            this.создатьАрхивБДToolStripMenuItem.Click += new System.EventHandler(this.создатьАрхивБДToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 53);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(886, 465);
            this.dataGridView.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(379, 28);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(119, 22);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "План счетов";
            // 
            // buttonAuthorize
            // 
            this.buttonAuthorize.Location = new System.Drawing.Point(802, 0);
            this.buttonAuthorize.Name = "buttonAuthorize";
            this.buttonAuthorize.Size = new System.Drawing.Size(84, 23);
            this.buttonAuthorize.TabIndex = 3;
            this.buttonAuthorize.Text = "Авторизация";
            this.buttonAuthorize.UseVisualStyleBackColor = true;
            this.buttonAuthorize.Click += new System.EventHandler(this.buttonAuthorize_Click);
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(691, 5);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(0, 13);
            this.labelRole.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 518);
            this.Controls.Add(this.labelRole);
            this.Controls.Add(this.buttonAuthorize);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Главная форма";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem контрагентызаимодавцыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem агентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem договорыЗаймаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналОперацийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналПроводокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ведомостьРасходовToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ToolStripMenuItem ведомостьСуммПолученныхЗаймовЗаПериодToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оборотносальдоваяВедомостьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьАрхивБДToolStripMenuItem;
        private System.Windows.Forms.Button buttonAuthorize;
        private System.Windows.Forms.Label labelRole;
    }
}

