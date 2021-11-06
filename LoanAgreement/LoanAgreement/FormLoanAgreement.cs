using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.BusinessLogic;
using LoanAgreementBusinessLogic.ViewModels;
using LoanAgreementBusinessLogic.Enum;
using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LoanAgreement
{
    public partial class FormLoanAgreement : Form
    {
        public int Id { set { id = value; } }
        private readonly LoanAgreementLogic logic;
        private readonly AgentLogic logicA;
        private readonly CounterpartyLenderLogic logicC;
        private readonly OperationLogic logicO;
        private int? id;

        public FormLoanAgreement(LoanAgreementLogic logic, AgentLogic logicA, CounterpartyLenderLogic logicC, OperationLogic logicO)
        {
            InitializeComponent();
            this.logic = logic;
            this.logicA = logicA;
            this.logicC = logicC;
            this.logicO = logicO;
        }

        LoanAgreementViewModel view;
        OperationViewModel operation;

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

            if (string.IsNullOrEmpty(textBoxPercent1.Text))
            {
                MessageBox.Show("Заполните процент1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (char c in textBoxPercent1.Text)
            {
                if (!char.IsNumber(c) && !(c == ','))
                {
                    MessageBox.Show("Некорректные данные процента1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }              
            }
            if (!Regex.IsMatch(textBoxPercent1.Text, @"[0-9]{1,3}[,][0-9]{2}\z"))
            {
                MessageBox.Show("Процент1 должен содержать 2 цифры после запятой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToDecimal(textBoxPercent1.Text) > 100 || Convert.ToDecimal(textBoxPercent1.Text) <= 0)
            {
                MessageBox.Show("Некорретные данные процента1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxPercent2.Text))
            {
                MessageBox.Show("Заполните процент2", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (char c in textBoxPercent2.Text)
            {
                if (!char.IsNumber(c) && !(c == ','))
                {
                    MessageBox.Show("Некорректные данные процента2", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!Regex.IsMatch(textBoxPercent2.Text, @"[0-9]{1,3}[,][0-9]{2}\z"))
            {
                MessageBox.Show("Процент2 должен содержать 2 цифры после запятой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToDecimal(textBoxPercent2.Text) > 100 || Convert.ToDecimal(textBoxPercent2.Text) <= 0 || Convert.ToDecimal(textBoxPercent2.Text) >= Convert.ToDecimal(textBoxPercent1.Text))
            {
                MessageBox.Show("Некорретные данные процента2, процент2 меньше процента1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxSum.Text))
            {
                MessageBox.Show("Заполните сумму", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (char c in textBoxSum.Text)
            {
                if (!char.IsNumber(c) && !(c == ','))
                {
                    MessageBox.Show("Некорректные данные суммы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!Regex.IsMatch(textBoxSum.Text, @"[0-9]{1,3}[,][0-9]{2}\z"))
            {
                MessageBox.Show("Сумма должна содержать 2 цифры после запятой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToDecimal(textBoxSum.Text) <= 0)
            {
                MessageBox.Show("Некорретные данные суммы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dateTimePickerDateofconclusion.Value == null)
            {
                MessageBox.Show("Заполните дату заключения договора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dateTimePickerDateofmaturity.Value == null)
            {
                MessageBox.Show("Заполните дату истечения договора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dateTimePickerDateofmaturity.Value <= dateTimePickerDateofconclusion.Value)
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
                    RemainingSumofloan = Convert.ToDecimal(textBoxSum.Text),
                    Dateofconclusion = dateTimePickerDateofconclusion.Value,
                    Dateofmaturity = dateTimePickerDateofmaturity.Value
                });

                view = logic.Read(new LoanAgreementBindingModel { Id = id })?[0];

                operation = logicO.Read(new OperationBindingModel { Loanagreementid = view.Id, Operationtype = "Заключение" })?[0];

                if (operation == null || view.Id != operation.Loanagreementid)
                {
                    logicO.CreateOrUpdate(new OperationBindingModel
                    {
                        Loanagreementid = view.Id,
                        Operationtype = OperationType.Заключение.ToString(),
                        Dateofoperation = dateTimePickerDateofconclusion.Value,
                        Sum = Convert.ToDecimal(textBoxSum.Text)
                    });
                }

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
