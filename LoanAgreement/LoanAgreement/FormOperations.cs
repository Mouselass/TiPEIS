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
    public partial class FormOperations : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly OperationLogic logic;
        private readonly LoanAgreementLogic logicL;

        public FormOperations(OperationLogic logic, LoanAgreementLogic logicL)
        {
            InitializeComponent();
            this.logic = logic;
            this.logicL = logicL;
            comboBoxType.Items.Add(OperationType.Поступление);
            comboBoxType.Items.Add(OperationType.Закрытие);
        }

        LoanAgreementViewModel view;
        OperationViewModel operationView;
        bool update = false;
        int updateId = -1;

        private void FormOperations_Load(object sender, EventArgs e)
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
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                var listLoanagreement = logicL.Read(null);

                foreach (var item in listLoanagreement)
                {
                    comboBoxLoanAgreement.DisplayMember = "Id";
                    comboBoxLoanAgreement.ValueMember = "Id";
                    comboBoxLoanAgreement.DataSource = listLoanagreement;
                    comboBoxLoanAgreement.SelectedItem = null;
                }

                comboBoxType.SelectedIndex = -1;
                textBoxSum.Text = "";
                textBoxPaymentSum.Text = "0";

                labelPaymentSum.Visible = false;
                labelRemaining.Visible = false;
                textBoxPaymentSum.Visible = false;
                textBoxRemaining.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxLoanAgreement.SelectedValue == null)
            {
                MessageBox.Show("Выберите договор займа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxType.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип операции", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxType.SelectedItem.ToString() == OperationType.Поступление.ToString() && string.IsNullOrEmpty(textBoxPaymentSum.Text))
            {
                MessageBox.Show("Заполните сумму поступления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxType.SelectedItem.ToString() == OperationType.Поступление.ToString() && Convert.ToDecimal(textBoxPaymentSum.Text) > Convert.ToDecimal(textBoxRemaining.Text))
            {
                MessageBox.Show("Сумма поступления должна быть не больше оставшейся", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OperationViewModel conclusionView = logic.Read(new OperationBindingModel { Operationtype = OperationType.Заключение.ToString(), Loanagreementid = Convert.ToInt32(comboBoxLoanAgreement.SelectedValue) })?[0];
            if (conclusionView == null && comboBoxType.SelectedItem.ToString() == OperationType.Поступление.ToString())
            {
                MessageBox.Show("Договор должен быть заключен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OperationViewModel closedView = logic.Read(new OperationBindingModel { Operationtype = OperationType.Закрытие.ToString(), Loanagreementid = Convert.ToInt32(comboBoxLoanAgreement.SelectedValue) })?[0];
            if (closedView != null && comboBoxType.SelectedItem.ToString() == OperationType.Поступление.ToString())
            {
                MessageBox.Show("Договор должен быть не закрыт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxType.SelectedItem.ToString() == OperationType.Поступление.ToString() && Convert.ToDecimal(textBoxPaymentSum.Text) <= 0)
            {
                MessageBox.Show("Сумма поступления должна быть положительной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxType.SelectedItem.ToString() == OperationType.Поступление.ToString())
            {
                foreach (char c in textBoxPaymentSum.Text)
                {
                    if (!char.IsNumber(c) && !(c == ','))
                    {
                        MessageBox.Show("Некорректные данные суммы платежа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (comboBoxType.SelectedItem.ToString() == OperationType.Поступление.ToString() && !Regex.IsMatch(textBoxPaymentSum.Text, @"[0-9]{1,15}[,][0-9]{2}\z"))
            {
                MessageBox.Show("Сумма платежа должна содержать 2 цифры после запятой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxType.SelectedItem.ToString() == OperationType.Закрытие.ToString() && Convert.ToDecimal(textBoxRemaining.Text) != 0)
            {
                MessageBox.Show("Закрыт может быть договор с нулевой оставшейся суммой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxType.SelectedItem.ToString() == OperationType.Закрытие.ToString() && conclusionView.Dateofoperation > dateTimePickerDateofconclusion.Value)
            {
                MessageBox.Show("Дата закрытия не может быть раньше заключения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxType.SelectedItem.ToString() == OperationType.Поступление.ToString() && conclusionView.Dateofoperation > dateTimePickerDateofconclusion.Value)
            {
                MessageBox.Show("Дата поступления не может быть раньше заключения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                view = logicL.Read(new LoanAgreementBindingModel { Id = Convert.ToInt32(comboBoxLoanAgreement.SelectedValue) })?[0];

                if (!update)
                {
                    if (view != null && comboBoxType.SelectedItem.ToString() == OperationType.Поступление.ToString())
                    {
                        logicL.CreateOrUpdate(new LoanAgreementBindingModel
                        {
                            Id = view.Id,
                            Agentid = view.Agentid,
                            Counterpartylenderid = view.Counterpartylenderid,
                            Percent1 = view.Percent1,
                            Percent2 = view.Percent2,
                            Sumofloan = view.Sumofloan,
                            RemainingSumofloan = view.RemainingSumofloan - Convert.ToDecimal(textBoxPaymentSum.Text),
                            Dateofconclusion = view.Dateofconclusion,
                            Dateofmaturity = view.Dateofmaturity
                        });

                        logic.CreateOrUpdate(new OperationBindingModel
                        {
                            Operationtype = comboBoxType.SelectedItem.ToString(),
                            Dateofoperation = dateTimePickerDateofconclusion.Value,
                            Sum = Convert.ToDecimal(textBoxPaymentSum.Text),
                            Loanagreementid = (int)comboBoxLoanAgreement.SelectedValue
                        });
                    }

                    if (view != null && comboBoxType.SelectedItem.ToString() == OperationType.Закрытие.ToString())
                    {
                        if (view.Dateofmaturity >= dateTimePickerDateofconclusion.Value.Date)
                        {
                            logic.CreateOrUpdate(new OperationBindingModel
                            {
                                Operationtype = comboBoxType.SelectedItem.ToString(),
                                Dateofoperation = dateTimePickerDateofconclusion.Value,
                                Sum = view.Sumofloan + view.Sumofloan * (view.Percent2 / 100),
                                Loanagreementid = (int)comboBoxLoanAgreement.SelectedValue
                            });
                        }

                        if (view.Dateofmaturity < dateTimePickerDateofconclusion.Value.Date)
                        {
                            logic.CreateOrUpdate(new OperationBindingModel
                            {
                                Operationtype = comboBoxType.SelectedItem.ToString(),
                                Dateofoperation = dateTimePickerDateofconclusion.Value,
                                Sum = view.Sumofloan + view.Sumofloan * (view.Percent1 / 100),
                                Loanagreementid = (int)comboBoxLoanAgreement.SelectedValue
                            });
                        }
                    }
                }

                if (update)
                {
                    operationView = logic.Read(new OperationBindingModel { Id = updateId })?[0];

                    if (view != null && comboBoxType.SelectedItem.ToString() == OperationType.Поступление.ToString())
                    {
                        logicL.CreateOrUpdate(new LoanAgreementBindingModel
                        {
                            Id = view.Id,
                            Agentid = view.Agentid,
                            Counterpartylenderid = view.Counterpartylenderid,
                            Percent1 = view.Percent1,
                            Percent2 = view.Percent2,
                            Sumofloan = view.Sumofloan,
                            RemainingSumofloan = view.RemainingSumofloan - Convert.ToDecimal(textBoxPaymentSum.Text),
                            Dateofconclusion = view.Dateofconclusion,
                            Dateofmaturity = view.Dateofmaturity
                        });

                        logic.CreateOrUpdate(new OperationBindingModel
                        {
                            Id = operationView.Id,
                            Operationtype = comboBoxType.SelectedItem.ToString(),
                            Dateofoperation = dateTimePickerDateofconclusion.Value,
                            Sum = Convert.ToDecimal(textBoxPaymentSum.Text),
                            Loanagreementid = (int)comboBoxLoanAgreement.SelectedValue
                        });
                    }

                    if (view != null && comboBoxType.SelectedItem.ToString() == OperationType.Закрытие.ToString())
                    {
                        if (view.Dateofmaturity >= dateTimePickerDateofconclusion.Value.Date)
                        {
                            logic.CreateOrUpdate(new OperationBindingModel
                            {
                                Operationtype = comboBoxType.SelectedItem.ToString(),
                                Dateofoperation = dateTimePickerDateofconclusion.Value,
                                Sum = view.Sumofloan + view.Sumofloan * (view.Percent2 / 100),
                                Loanagreementid = (int)comboBoxLoanAgreement.SelectedValue
                            });
                        }

                        if (view.Dateofmaturity < dateTimePickerDateofconclusion.Value.Date)
                        {
                            logic.CreateOrUpdate(new OperationBindingModel
                            {
                                Operationtype = comboBoxType.SelectedItem.ToString(),
                                Dateofoperation = dateTimePickerDateofconclusion.Value,
                                Sum = view.Sumofloan + view.Sumofloan * (view.Percent1 / 100),
                                Loanagreementid = (int)comboBoxLoanAgreement.SelectedValue
                            });
                        }
                    }

                    update = false;
                }

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                try
                {
                    operationView = logic.Read(new OperationBindingModel { Id = (int)dataGridView.SelectedRows[0].Cells[0].Value })?[0];

                    if (operationView.Operationtype == OperationType.Заключение.ToString())
                    {
                        MessageBox.Show("Операцию заключения невозможно редактировать", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (operationView != null)
                    {
                        OperationViewModel closeOperation = logic.Read(new OperationBindingModel { Loanagreementid = operationView.Loanagreementid, Operationtype = OperationType.Закрытие.ToString() })?[0];
                        if (closeOperation != null && operationView.Operationtype != OperationType.Закрытие.ToString())
                        {
                            MessageBox.Show("Нельзя изменить операцию закрытого договора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        comboBoxLoanAgreement.SelectedValue = operationView.Loanagreementid;
                        view = logicL.Read(new LoanAgreementBindingModel { Id = Convert.ToInt32(comboBoxLoanAgreement.SelectedValue) })?[0];

                        dateTimePickerDateofconclusion.Text = operationView.Dateofoperation.ToString();
                        update = true;
                        updateId = (int)dataGridView.SelectedRows[0].Cells[0].Value;
                        if (operationView.Operationtype == OperationType.Поступление.ToString())
                        {
                            view = logicL.Read(new LoanAgreementBindingModel { Id = operationView.Loanagreementid })?[0];
                            logicL.CreateOrUpdate(new LoanAgreementBindingModel
                            {
                                Id = view.Id,
                                Agentid = view.Agentid,
                                Counterpartylenderid = view.Counterpartylenderid,
                                Percent1 = view.Percent1,
                                Percent2 = view.Percent2,
                                Sumofloan = view.Sumofloan,
                                RemainingSumofloan = view.RemainingSumofloan + operationView.Sum,
                                Dateofconclusion = view.Dateofconclusion,
                                Dateofmaturity = view.Dateofmaturity
                            });
                            comboBoxType.SelectedIndex = 0;
                            textBoxSum.Text = view.Sumofloan.ToString();
                            textBoxPaymentSum.Text = operationView.Sum.ToString();
                            textBoxRemaining.Text = view.RemainingSumofloan.ToString();
                            comboBoxLoanAgreement_SelectedIndexChanged(sender, e);
                        }
                        if (operationView.Operationtype == OperationType.Закрытие.ToString())
                        {
                            comboBoxType.SelectedIndex = 1;
                            textBoxSum.Text = view.Sumofloan.ToString();
                            textBoxPaymentSum.Text = "0";
                            textBoxRemaining.Text = view.RemainingSumofloan.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        operationView = logic.Read(new OperationBindingModel { Id = id })?[0];
                        if (operationView.Operationtype == OperationType.Заключение.ToString())
                        {
                            MessageBox.Show("Нельзя удалить операцию заключения договора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        OperationViewModel closeOperation = logic.Read(new OperationBindingModel { Loanagreementid = operationView.Loanagreementid, Operationtype = OperationType.Закрытие.ToString() })?[0];
                        if (closeOperation != null && operationView.Operationtype != OperationType.Закрытие.ToString())
                        {
                            MessageBox.Show("Нельзя удалить операцию закрытого договора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        logic.Delete(new OperationBindingModel { Id = id });
                        if (operationView.Operationtype == OperationType.Поступление.ToString())
                        {
                            view = logicL.Read(new LoanAgreementBindingModel { Id = operationView.Loanagreementid })?[0];
                            logicL.CreateOrUpdate(new LoanAgreementBindingModel
                            {
                                Id = view.Id,
                                Agentid = view.Agentid,
                                Counterpartylenderid = view.Counterpartylenderid,
                                Percent1 = view.Percent1,
                                Percent2 = view.Percent2,
                                Sumofloan = view.Sumofloan,
                                RemainingSumofloan = view.RemainingSumofloan + operationView.Sum,
                                Dateofconclusion = view.Dateofconclusion,
                                Dateofmaturity = view.Dateofmaturity
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void comboBoxLoanAgreement_Format(object sender, ListControlConvertEventArgs e)
        {
            string id = ((LoanAgreementViewModel)e.ListItem).Id.ToString();
            string dateOfConclusion = ((LoanAgreementViewModel)e.ListItem).Dateofconclusion.ToShortDateString();
            e.Value = "Договор № " + id + " от " + dateOfConclusion;
        }

        private void comboBoxLoanAgreement_SelectedIndexChanged(object sender, EventArgs e)
        {
            view = logicL.Read(new LoanAgreementBindingModel { Id = Convert.ToInt32(comboBoxLoanAgreement.SelectedValue) })?[0];
            textBoxSum.Text = "0";
            if (view != null)
            {
                textBoxSum.Text = view.Sumofloan.ToString();
            }
            comboBoxType_SelectedIndexChanged(sender, e);
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedItem != null && comboBoxType.SelectedItem.ToString() == OperationType.Поступление.ToString())
            {
                labelPaymentSum.Visible = true;
                labelRemaining.Visible = true;
                textBoxPaymentSum.Visible = true;
                textBoxRemaining.Visible = true;

                view = logicL.Read(new LoanAgreementBindingModel { Id = Convert.ToInt32(comboBoxLoanAgreement.SelectedValue) })?[0];

                if (view != null)
                {
                    textBoxRemaining.Text = view.RemainingSumofloan.ToString();
                }
            }
            else if (comboBoxType.SelectedItem != null && comboBoxType.SelectedItem.ToString() == OperationType.Закрытие.ToString())
            {
                labelPaymentSum.Visible = false;
                labelRemaining.Visible = true;
                textBoxPaymentSum.Visible = false;
                textBoxRemaining.Visible = true;

                view = logicL.Read(new LoanAgreementBindingModel { Id = Convert.ToInt32(comboBoxLoanAgreement.SelectedValue) })?[0];

                if (view != null)
                {
                    textBoxRemaining.Text = view.RemainingSumofloan.ToString();
                }
            }
            else 
            {
                labelPaymentSum.Visible = false;
                labelRemaining.Visible = false;
                textBoxPaymentSum.Visible = false;
                textBoxRemaining.Visible = false;
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {
                var list = logic.Read(new OperationBindingModel { DateFrom = dateTimePickerFrom.Value, DateTo = dateTimePickerTo.Value });
                if (comboBoxLoanAgreement.SelectedValue != null)
                {
                    list = logic.Read(new OperationBindingModel { ReportLoanagreementid = Convert.ToInt32(comboBoxLoanAgreement.SelectedValue), 
                        DateFrom = dateTimePickerFrom.Value, DateTo = dateTimePickerTo.Value });
                }

                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                var listLoanagreement = logicL.Read(null);

                foreach (var item in listLoanagreement)
                {
                    comboBoxLoanAgreement.DisplayMember = "Id";
                    comboBoxLoanAgreement.ValueMember = "Id";
                    comboBoxLoanAgreement.DataSource = listLoanagreement;
                    comboBoxLoanAgreement.SelectedItem = null;
                }

                comboBoxType.SelectedIndex = -1;
                textBoxSum.Text = "";
                textBoxPaymentSum.Text = "0";

                labelPaymentSum.Visible = false;
                labelRemaining.Visible = false;
                textBoxPaymentSum.Visible = false;
                textBoxRemaining.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
