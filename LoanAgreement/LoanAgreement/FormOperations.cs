using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.ViewModels;
using LoanAgreementBusinessLogic.BusinessLogic;
using LoanAgreementBusinessLogic.Enum;
using System;
using System.Data;
using System.Windows.Forms;
using Unity;

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
                    dataGridView.Columns[0].Visible = false;
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

            if (comboBoxType.SelectedItem.ToString() == "Поступление" && string.IsNullOrEmpty(textBoxPaymentSum.Text))
            {
                MessageBox.Show("Заполните сумму поступления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxType.SelectedItem.ToString() == "Поступление" && Convert.ToDecimal(textBoxPaymentSum.Text) > Convert.ToDecimal(textBoxRemaining.Text))
            {
                MessageBox.Show("Сумма поступления должна быть не больше оставшейся", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OperationViewModel conclusionView = logic.Read(new OperationBindingModel { Operationtype = OperationType.Заключение.ToString(), Loanagreementid = Convert.ToInt32(comboBoxLoanAgreement.SelectedValue) })?[0];
            if (conclusionView == null && comboBoxType.SelectedItem.ToString() == "Поступление")
            {
                MessageBox.Show("Договор должен быть заключен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OperationViewModel closedView = logic.Read(new OperationBindingModel { Operationtype = OperationType.Закрытие.ToString(), Loanagreementid = Convert.ToInt32(comboBoxLoanAgreement.SelectedValue) })?[0];
            if (closedView != null && comboBoxType.SelectedItem.ToString() == "Поступление")
            {
                MessageBox.Show("Договор должен быть не закрыт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                view = logicL.Read(new LoanAgreementBindingModel { Id = Convert.ToInt32(comboBoxLoanAgreement.SelectedValue) })?[0];

                if (view != null && comboBoxType.SelectedItem.ToString() == "Поступление")
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
                }

                logic.CreateOrUpdate(new OperationBindingModel
                {
                    Operationtype = comboBoxType.SelectedItem.ToString(),
                    Dateofoperation = dateTimePickerDateofconclusion.Value,
                    Sum = Convert.ToDecimal(textBoxPaymentSum.Text),
                    Loanagreementid = (int)comboBoxLoanAgreement.SelectedValue
                });

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

                    if (operationView.Operationtype == "Заключение")
                    {
                        MessageBox.Show("Операцию заключения невозможно редактировать", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (operationView != null)
                    {
                        comboBoxLoanAgreement.SelectedValue = operationView.Loanagreementid;
                        dateTimePickerDateofconclusion.Text = operationView.Dateofoperation.ToString();
                        if (operationView.Operationtype == "Поступление")
                        {
                            comboBoxType.SelectedIndex = 0;
                            textBoxSum.Text = operationView.Sum.ToString();
                        }
                        if (operationView.Operationtype == "Закрытие")
                        {
                            comboBoxType.SelectedIndex = 1;
                            textBoxSum.Text = operationView.Sum.ToString();
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
                        logic.Delete(new OperationBindingModel { Id = id });
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
            if (comboBoxType.SelectedItem != null && comboBoxType.SelectedItem.ToString() == "Поступление")
            {
                labelPaymentSum.Visible = true;
                labelRemaining.Visible = true;
                textBoxPaymentSum.Visible = true;
                textBoxRemaining.Visible = true;

                view = logicL.Read(new LoanAgreementBindingModel { Id = Convert.ToInt32(comboBoxLoanAgreement.SelectedValue) })?[0];
                operationView = logic.Read(new OperationBindingModel { Loanagreementid = Convert.ToInt32(comboBoxLoanAgreement.SelectedValue), Operationtype = "Поступление"})?[0];

                if (view != null)
                {
                    textBoxRemaining.Text = view.RemainingSumofloan.ToString();
                }
                //if (operationView == null)
                //{
                //    textBoxRemaining.Text = view.Sumofloan.ToString();
                //}
                //else
                //{
                //    textBoxRemaining.Text = remainingSum.ToString();
                //}
            }
            else 
            {
                labelPaymentSum.Visible = false;
                labelRemaining.Visible = false;
                textBoxPaymentSum.Visible = false;
                textBoxRemaining.Visible = false;
            }
        }
    }
}
