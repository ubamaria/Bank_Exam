using Bank_DAL.BindingModel;
using Bank_DAL.Interface;
using Bank_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace BankView
{
    public partial class FormDeposit : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IBankLogic bank;

        private readonly IDepositLogic deposit;

        private int? id;
        public FormDeposit(IBankLogic bank, IDepositLogic deposit)
        {
            InitializeComponent();
            this.bank = bank;
            this.deposit = deposit;
        }


        private void FormDeposit_Load(object sender, EventArgs e)
        {
            List<BankViewModel> list = bank.Read(null);
            if (list != null)
            {
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
                comboBox1.DataSource = list;
                comboBox1.SelectedItem = null;
            }
            if (id.HasValue)
            {
                try
                {
                    var view = deposit.Read(new DepositBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBox1.Text = view.ClientFIO;
                        textBox2.Text = view.SizeDeposit.ToString();
                        textBox3.Text = view.Email;
                        dateTimePicker1.Value = view.DateOpened;
                        textBox4.Text = view.TypeValue;


                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Введите ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Выберите банк", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {

                deposit.CreateOrUpdate(new DepositBindingModel()
                {
                    Id = id,
                    ClientFIO = textBox1.Text,
                    SizeDeposit = Convert.ToInt32(textBox2.Text),
                    Email = textBox2.Text,
                    DateOpened = dateTimePicker1.Value,
                    TypeValue = textBox2.Text,
                    BankId = Convert.ToInt32(comboBox1.SelectedValue)
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
