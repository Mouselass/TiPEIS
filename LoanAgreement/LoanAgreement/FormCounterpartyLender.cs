using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.BusinessLogic;
using LoanAgreementBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace LoanAgreement
{
    public partial class FormCounterpartyLender : Form
    {
        public int Id { set { id = value; } }
        private readonly CounterpartyLenderLogic logic;
        private int? id;

        public FormCounterpartyLender(CounterpartyLenderLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
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
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxType.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (char c in textBoxType.Text) 
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c) && !(c == '.'))
                {
                    MessageBox.Show("Некорректные данные ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
