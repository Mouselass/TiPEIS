using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.BusinessLogic;
using LoanAgreementBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace LoanAgreement
{
    public partial class FormLoanAgreement : Form
    {
        public int Id { set { id = value; } }
        private readonly LoanAgreementLogic logic;
        private readonly AgentLogic logicA;
        private readonly CounterpartyLenderLogic logicC;
        private int? id;

        public FormLoanAgreement(LoanAgreementLogic logic, AgentLogic logicA, CounterpartyLenderLogic logicC)
        {
            InitializeComponent();
            this.logic = logic;
            this.logicA = logicA;
            this.logicC = logicC;
        }

        LoanAgreementViewModel view;

        private void FormLoanAgreement_Load(object sender, EventArgs e)
        {
            try
            {
                var listAgent = logicA.Read(null);

                foreach (var item in listAgent)
                {
                    comboBoxAgent.DisplayMember = "Fio";
                    comboBoxAgent.ValueMember = "Id";
                    comboBoxAgent.DataSource = listAgent;
                    comboBoxAgent.SelectedItem = null;
                }

                var listCounterpartyLender = logicC.Read(null);

                foreach (var item in listCounterpartyLender)
                {
                    comboBoxCounterpartyLender.DisplayMember = "Fio";
                    comboBoxCounterpartyLender.ValueMember = "Id";
                    comboBoxCounterpartyLender.DataSource = listCounterpartyLender;
                    comboBoxCounterpartyLender.SelectedItem = null;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (id.HasValue)
            {
                try
                {
                    view = logic.Read(new LoanAgreementBindingModel { Id = id })?[0];

                    if (view != null)
                    {
                        textBoxPercent1.Text = view.Percent1.ToString("f2");
                        textBoxPercent2.Text = view.Percent2.ToString("f2");
                        textBoxSum.Text = view.Sumofloan.ToString("f2");
                        comboBoxAgent.SelectedValue = view.Agentid;
                        comboBoxCounterpartyLender.SelectedValue = view.Counterpartylenderid;
                        dateTimePickerDateofconclusion.Text = view.Dateofconclusion.ToString();
                        dateTimePickerDateofmaturity.Text = view.Dateofmaturity.ToString();
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
            if (string.IsNullOrEmpty(textBoxPercent1.Text))
            {
                MessageBox.Show("Заполните процент1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int numPercent1 = 0;
            bool flagPercent1 = false;
            foreach (char c in textBoxPercent1.Text)
            {
                if (!char.IsNumber(c) && !(c == ','))
                {
                    MessageBox.Show("Некорректные данные процента1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (flagPercent1 && !(c == ','))
                {
                    numPercent1 += 1;
                }
                if ((c == ',') || (c == '.'))
                {
                    flagPercent1 = true;
                }
               
            }
            if (numPercent1 != 2)
            {
                MessageBox.Show("Процент1 должен содержать 2 цифры после запятой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToDecimal(textBoxPercent1.Text) > 100 || Convert.ToDecimal(textBoxPercent1.Text) < 0)
            {
                MessageBox.Show("Некорретные данные процента1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxPercent2.Text))
            {
                MessageBox.Show("Заполните процент2", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int numPercent2 = 0;
            bool flagPercent2 = false;
            foreach (char c in textBoxPercent2.Text)
            {
                if (!char.IsNumber(c) && !(c == ','))
                {
                    MessageBox.Show("Некорректные данные процента2", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (flagPercent2 && !(c == ','))
                {
                    numPercent2 += 1;
                }
                if ((c == ',') || (c == '.'))
                {
                    flagPercent2 = true;
                }
            }
            if (numPercent2 != 2)
            {
                MessageBox.Show("Процент2 должен содержать 2 цифры после запятой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToDecimal(textBoxPercent2.Text) > 100 || Convert.ToDecimal(textBoxPercent2.Text) < 0 || Convert.ToDecimal(textBoxPercent2.Text) >= Convert.ToDecimal(textBoxPercent1.Text))
            {
                MessageBox.Show("Некорретные данные процента2, процент2 меньше процента1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxSum.Text))
            {
                MessageBox.Show("Заполните сумму", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int numSum = 0;
            bool flagSum = false;
            foreach (char c in textBoxSum.Text)
            {
                if (!char.IsNumber(c) && !(c == ','))
                {
                    MessageBox.Show("Некорректные данные суммы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (flagSum && !(c == ','))
                {
                    numSum += 1;
                }
                if ((c == ',') || (c == '.'))
                {
                    flagSum = true;
                }
            }
            if (numSum != 2)
            {
                MessageBox.Show("Сумма должна содержать 2 цифры после запятой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToDecimal(textBoxSum.Text) < 0)
            {
                MessageBox.Show("Некорретные данные суммы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxAgent.SelectedValue == null)
            {
                MessageBox.Show("Выберите агента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxCounterpartyLender.SelectedValue == null)
            {
                MessageBox.Show("Выберите контрагента-заимодавца", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dateTimePickerDateofconclusion.Value == null)
            {
                MessageBox.Show("Заполните дату заключения договора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (dateTimePickerDateofconclusion.Value < DateTime.Today)
            //{
            //    MessageBox.Show("Неверная дата заключения договора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (dateTimePickerDateofmaturity.Value == null)
            {
                MessageBox.Show("Заполните дату истечения договора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dateTimePickerDateofmaturity.Value < DateTime.Today || dateTimePickerDateofmaturity.Value <= dateTimePickerDateofconclusion.Value)
            {
                MessageBox.Show("Неверная дата истечения договора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                logic.CreateOrUpdate(new LoanAgreementBindingModel
                {
                    Id = id,
                    Agentid = Convert.ToInt32(comboBoxAgent.SelectedValue),
                    Counterpartylenderid = Convert.ToInt32(comboBoxCounterpartyLender.SelectedValue),
                    Percent1 = Convert.ToDecimal(textBoxPercent1.Text),
                    Percent2 = Convert.ToDecimal(textBoxPercent2.Text),
                    Sumofloan = Convert.ToDecimal(textBoxSum.Text),
                    Dateofconclusion = dateTimePickerDateofconclusion.Value,
                    Dateofmaturity = dateTimePickerDateofmaturity.Value
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
