using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.BusinessLogic;
using LoanAgreementBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace LoanAgreement
{
    public partial class FormCounterpartyLender : Form
    {
        public int Id { set { id = value; } }
        private readonly CounterpartyLenderLogic logic;
        private int? id;
        private readonly Logger logger;

        public FormCounterpartyLender(CounterpartyLenderLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            logger = LogManager.GetCurrentClassLogger();
        }

        CounterpartyLenderViewModel view;

        private void FormCounterpartyLender_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    view = logic.Read(new CounterpartyLenderBindingModel { Id = id })?[0];

                    if (view != null)
                    {
                        textBoxType.Text = view.Fio;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error("Ошибка");
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxType.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("Не заполнено ФИО контрагента");
                return;
            }
            foreach (char c in textBoxType.Text) 
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c) && !(c == '.'))
                {
                    MessageBox.Show("Некорректные данные ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn("Введены некорректные данные ФИО контрагента");
                    return;
                }
            }
            try
            {

                logic.CreateOrUpdate(new CounterpartyLenderBindingModel
                {
                    Id = id,
                    Fio = textBoxType.Text
                });


                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                logger.Info($"Создан контрагент {textBoxType.Text}");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
