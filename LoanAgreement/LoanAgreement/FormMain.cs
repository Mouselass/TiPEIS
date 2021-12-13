using System;
using System.Windows.Forms;
using LoanAgreementBusinessLogic.BusinessLogic;
using LoanAgreementBusinessLogic.Enum;
using Unity;
using NLog;

namespace LoanAgreement
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ChartOfAccountsLogic logic;

        private BackUpAbstractLogic backUp;

        private readonly Logger logger;

        public FormMain(ChartOfAccountsLogic logic, BackUpAbstractLogic backUp)
        {
            InitializeComponent();
            this.logic = logic;
            this.backUp = backUp;
            logger = LogManager.GetCurrentClassLogger();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            labelRole.Text = "Неавторизовано";
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
                logger.Error("Ошибка");
            }
        }

        private void контрагентызаимодавцыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {
                var form = Container.Resolve<FormCounterpartyLenders>();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void агентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {
                var form = Container.Resolve<FormAgents>();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void договорыЗаймаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {
                var form = Container.Resolve<FormLoanAgreements>();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void журналОперацийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {
                var form = Container.Resolve<FormOperations>();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void журналПроводокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {
                var form = Container.Resolve<FormPostingJournal>();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ведомостьСуммПолученныхЗаймовЗаПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {
                var form = Container.Resolve<FormReportSums>();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ведомостьРасходовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {
                var form = Container.Resolve<FormReportCosts>();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void оборотносальдоваяВедомостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {
                var form = Container.Resolve<FormReportPostingJournal>();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void создатьАрхивБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {
                if (Program.User.Role == UserRole.Администратор.ToString())
                {
                    try
                    {
                        if (backUp != null)
                        {
                            var fbd = new FolderBrowserDialog();
                            if (fbd.ShowDialog() == DialogResult.OK)
                            {
                                backUp.CreateArchive(fbd.SelectedPath);
                                MessageBox.Show("Архив создан", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                logger.Info("Архив создан");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.Error("Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Создать архив БД может только администратор", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn("Создать архив БД может только администратор");
                }

            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAuthorize_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAuthorize>();
            form.ShowDialog();
            if (Program.User != null)
            {
                labelRole.Text = Program.User.Role;
            }           
        }
    }
}
