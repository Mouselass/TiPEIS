using System;
using System.Windows.Forms;
using LoanAgreementBusinessLogic.BusinessLogic;


namespace LoanAgreement
{
    public partial class FormMain : Form
    {
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

    }
}
