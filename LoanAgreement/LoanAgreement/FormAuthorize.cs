using System;
using System.Windows.Forms;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.BusinessLogic;
using Unity;
using NLog;

namespace LoanAgreement
{
    public partial class FormAuthorize : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly UserLogic logic;

        private readonly Logger logger;

        public FormAuthorize(UserLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            logger = LogManager.GetCurrentClassLogger();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Заполните логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("Не заполнен логин");
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("Не заполнен пароль");
                return;
            }

            var user = logic.Read(new UserBindingModel { Login = textBoxLogin.Text, Password = textBoxPassword.Text })?[0];
            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("Неверный логин или пароль");
                return;
            }
            Program.User = user;
            logger.Info($"Успешная авторизация пользователя {textBoxLogin.Text}");

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRegister>();
            form.ShowDialog();
        }
    }
}
