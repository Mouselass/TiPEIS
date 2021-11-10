using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.ViewModels;
using LoanAgreementBusinessLogic.BusinessLogic;
using LoanAgreementBusinessLogic.Enum;
using System;
using System.Data;
using System.Windows.Forms;
using Unity;
using System.Text.RegularExpressions;

namespace LoanAgreement
{
    public partial class FormPostingJournal : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly PostingJournalLogic logic;
        public int OperationId { set { operationId = value; } }
        private int? operationId;

        public FormPostingJournal(PostingJournalLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormOperations_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);

                if (operationId.HasValue)
                {
                    list = logic.Read(new PostingJournalBindingModel { OperationIdReport = operationId });
                }

                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[6].Visible = false;
                    dataGridView.Columns[11].Visible = false;
                    dataGridView.Columns[15].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {
                var list = logic.Read(new PostingJournalBindingModel { DateFrom = dateTimePickerFrom.Value, DateTo = dateTimePickerTo.Value });

                if (operationId.HasValue)
                {
                    list = logic.Read(new PostingJournalBindingModel { OperationIdReport = operationId, DateFrom = dateTimePickerFrom.Value, DateTo = dateTimePickerTo.Value });
                }

                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[6].Visible = false;
                    dataGridView.Columns[11].Visible = false;
                    dataGridView.Columns[15].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
