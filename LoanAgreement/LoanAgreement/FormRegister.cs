using System;
using System.Windows.Forms;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.BusinessLogic;
using NLog;

namespace LoanAgreement
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private readonly UserLogic logic;

        private readonly Logger logger;

        public FormRegister(UserLogic logic)
        {
            InitializeComponent();
            comboBoxRole.Items.AddRange(new string[] { "Администратор", "Пользователь" });
            this.logic = logic;
            logger = LogManager.GetCurrentClassLogger();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
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
            if (comboBoxRole.SelectedItem == null)
            {
                MessageBox.Show("Выберите роль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("Не выбрана роль");
                return;
            }

            try
            {
                UserBindingModel model = new UserBindingModel
                {                   
                    Login = textBoxLogin.Text,
                    Password = textBoxPassword.Text,
                    Role = comboBoxRole.SelectedItem.ToString()
                };
                logic.CreateOrUpdate(model);
                logger.Info($"Создан пользователь {textBoxLogin.Text} с ролью {comboBoxRole.SelectedItem}");
                DialogResult = DialogResult.OK;
                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Error("Ошибка");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
