using System;
using System.Windows.Forms;
using LoanAgreementBusinessLogic.BusinessLogic;
using Unity;


namespace LoanAgreement
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ChartOfAccountsLogic logic;

        public FormMain(ChartOfAccountsLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);

                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void контрагентызаимодавцыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCounterpartyLenders>();
            form.ShowDialog();
        }

        private void агентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAgents>();
            form.ShowDialog();
        }

        private void договорыЗаймаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormLoanAgreements>();
            form.ShowDialog();
        }

        private void журналОперацийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormOperations>();
            form.ShowDialog();
        }
    }
}
