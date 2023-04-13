using FormularzMVP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormularzMVP.Views
{
    public partial class EmployeeView : Form, IEmployeeView
    {
        public EmployeeView()
        {
            InitializeComponent();
            AssociateAndRiseEvent();
        }

        private void AssociateAndRiseEvent()
        {
            buttonAdd.Click += delegate { AddEvent?.Invoke(this, EventArgs.Empty); };
            buttonDelete.Click += delegate { DeleteEvent?.Invoke(this, EventArgs.Empty); };
            buttonSerialize.Click += delegate { SerializeEvent?.Invoke(this, EventArgs.Empty); };
            buttonDeserialize.Click += delegate { DeserializeEvent?.Invoke(this, EventArgs.Empty); };
            buttonEdit.Click += delegate { EditEvent?.Invoke(this, EventArgs.Empty); };
            listBox1.SelectedIndexChanged += delegate { ReadEmplyeeEvent?.Invoke(this, EventArgs.Empty); };
        }

        //Properties
        public string EmployeeName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
        }
        public string EmployeeSurname
        {
            get => textBoxSurname.Text;
            set { textBoxSurname.Text = value; }
        }
        public DateTime EmployeeBirthDate
        {
            get => dateTimePicker.Value;
            set { dateTimePicker.Value = value; }
        }
        public decimal EmployeeSalary
        {
            get => SalaryBox.Value;
            set { SalaryBox.Value = value; }
        }
        public string EmployeePosition
        {
            get => comboBoxPosition.Text;
            set { comboBoxPosition.Text = value; }
        }
        public string EmployeeContract
        {
            get
            {
                foreach (System.Windows.Forms.RadioButton rb in tableLayoutPanel3.Controls.OfType<System.Windows.Forms.RadioButton>())
                {
                    if (rb.Checked)
                    {
                        return rb.Text;
                    }
                }
                return string.Empty;
            }

            set
            {
                foreach (System.Windows.Forms.RadioButton rb in tableLayoutPanel3.Controls.OfType<System.Windows.Forms.RadioButton>())
                {
                    if (rb.Text == value)
                    {
                        rb.Checked = true;
                        break;
                    }
                }
            }
        }
        public ListBox EmployeeList 
        {
            get  { return listBox1; } 
            set { listBox1 = value; }
        }

        //Events
        public event EventHandler AddEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SerializeEvent;
        public event EventHandler DeserializeEvent;
        public event EventHandler EditEvent;
        public event EventHandler ReadEmplyeeEvent;


        //Methods
        public void RaiseErrorName(string message)
        {
            errorProvider.SetError(textBoxName, message);
        }
        public void HideErrorName()
        {
            errorProvider.SetError(textBoxName, string.Empty);
        }
        public void RaiseErrorSurname(string message)
        {
            errorProvider.SetError(textBoxSurname, message);
        }
        public void HideErrorSurname()
        {
            errorProvider.SetError(textBoxSurname, string.Empty);
        }
        public void RaiseErrorPosition(string message)
        {
            errorProvider.SetError(comboBoxPosition, message);
        }
        public void HideErrorPosition()
        {
            errorProvider.SetError(comboBoxPosition, string.Empty);
        }
        public void HideAllErrors()
        {
            errorProvider.Clear();
        }


        //#region TEST
        //private System.Windows.Forms.Timer timer1;

        //private void InitTimer(object sender, EventArgs e)
        //{
        //    timer1 = new System.Windows.Forms.Timer();
        //    timer1.Tick += new EventHandler(timer1_Tick);
        //    timer1.Interval = 100; // in miliseconds
        //    timer1.Start();
        //}
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    Console.WriteLine(comboBox.Text);
        //}
        //#endregion
    }
}
