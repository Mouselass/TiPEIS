using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.ViewModels;
using LoanAgreementBusinessLogic.BusinessLogic;
using Microsoft.Reporting.WinForms;

namespace LoanAgreement
{
    public partial class FormReportPostingJournal : Form
    {
        private readonly ReportLogic logic;
        private readonly ChartOfAccountsLogic logicC;

        public FormReportPostingJournal(ReportLogic logic, ChartOfAccountsLogic logicC)
        {
            InitializeComponent();
            this.logic = logic;
            this.logicC = logicC;            
        }

        private void FormReportPostingJournal_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var list = logicC.Read(null);
            if (list != null)
            {
                comboBoxAccounts.DisplayMember = "AccountNumber";
                comboBoxAccounts.ValueMember = "Id";
                comboBoxAccounts.DataSource = list;
                comboBoxAccounts.SelectedItem = null;
            }
        }
       
        private void buttonMake_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value >= dateTimePickerTo.Value)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            try
            {
                int? account = null;
                if (comboBoxAccounts.SelectedValue != null)
                    account = Convert.ToInt32(comboBoxAccounts.SelectedValue);

                reportViewer.LocalReport.DataSources.Clear();
                ReportParameter parameter = new ReportParameter("ReportParameterPeriod",
                "c " + dateTimePickerFrom.Value.ToShortDateString() +
                " по " + dateTimePickerTo.Value.ToShortDateString());
                reportViewer.LocalReport.SetParameters(parameter);
                var dataSource = logic.GetReportPostingJournals(new ReportBindingModel
                {
                    DateFrom = dateTimePickerFrom.Value,
                    DateTo = dateTimePickerTo.Value,
                    ChartOfAccount = account,
                    ChartOfAccountName = ((ChartOfAccountsViewModel)comboBoxAccounts.SelectedItem)?.AccountNumber
                });
                ReportDataSource source = new ReportDataSource("DataSetPostingJournal", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
