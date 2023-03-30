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
        }

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
            get => comboBox.Text;
            set { comboBox.Text = value; }
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


        public event EventHandler AddEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SerializeEvent;
        public event EventHandler DeserializeEvent;


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
