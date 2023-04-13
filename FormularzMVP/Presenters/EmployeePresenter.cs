using FormularzMVP.Models;
using FormularzMVP.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Globalization;

namespace FormularzMVP.Presenters
{
    public class EmployeePresenter
    {
        private IEmployeeView _view;

        public EmployeePresenter(IEmployeeView view)
        {
            _view = view;
            _view.AddEvent += AddEmployee;
            _view.DeleteEvent += DeleteEmployee;
            _view.SerializeEvent += SerializeEmployees;
            _view.DeserializeEvent += DeserializeEmployees;
            _view.EditEvent += EditEmployee;
            _view.ReadEmplyeeEvent += ReadEmployee;
        }

        private void ReadEmployee(object sender, EventArgs e)
        {
            if(_view.EmployeeList.SelectedItem is EmployeeModel model)
            {
                _view.HideAllErrors();
                _view.EmployeeName = model.Name;
                _view.EmployeeSurname = model.Surname;
                _view.EmployeeBirthDate = model.BirthDate;
                _view.EmployeeSalary = model.Salary;
                _view.EmployeePosition = model.Position;
                _view.EmployeeContract = model.Contract;
            }
        }

        private void SerializeEmployees(object sender, EventArgs e)
        {
            List<EmployeeModel> list = new List<EmployeeModel>();
            foreach (var item in _view.EmployeeList.Items)
            {
                list.Add((EmployeeModel)item);
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "File XML (.xml)|.xml";
            string path = string.Empty;
            if (saveFileDialog.ShowDialog() == DialogResult.OK) 
            { 
                path = saveFileDialog.FileName; 
            }

            if (!string.IsNullOrEmpty(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<EmployeeModel>));
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    serializer.Serialize(fileStream, list);
                }
            }

            
        }

        private void DeserializeEmployees(object sender, EventArgs e)
        {
            List<EmployeeModel> list = new List<EmployeeModel>();

            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "File XML (.xml)|*.xml";
            string path = string.Empty;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }
            if (!string.IsNullOrEmpty(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof (List<EmployeeModel>));
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    list = (List<EmployeeModel>)serializer.Deserialize(fileStream);
                }
                _view.EmployeeList.Items.Clear();
                foreach (var item in list)
                {
                    _view.EmployeeList.Items.Add(item);
                }

            }
        }

        private void AddEmployee(object sender, EventArgs e)
        {
            EmployeeModel model = CreateEmployee(); 
            if (model != null)
            {
                _view.EmployeeList.Items.Add(model);
            }
           
        }
        private EmployeeModel CreateEmployee()
        {
            try
            {
                EmployeeModel model = new EmployeeModel(_view.EmployeeName, _view.EmployeeSurname, _view.EmployeeBirthDate, _view.EmployeeSalary, _view.EmployeePosition, _view.EmployeeContract);
          
                _view.HideAllErrors();
                return model;
            }
            catch (ArgumentNullException error)
            {
                string errorMessage = error.Message.Substring(0, error.Message.IndexOf("!") + 1);
                Console.WriteLine(error.ParamName);
                if (error.ParamName == "Name")
                {
                    _view.RaiseErrorName(errorMessage);
                }
                else { _view.HideErrorName(); }
                if (error.ParamName == "Surname")
                {
                    _view.RaiseErrorSurname(errorMessage);
                }
                else { _view.HideErrorSurname(); }
                if (error.ParamName == "Position")
                {
                    _view.RaiseErrorPosition(errorMessage);
                }
                else { _view.HideErrorPosition(); }

                return null;
            }
        }
        private void DeleteEmployee(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedObject = _view.EmployeeList.SelectedItems;
            if(_view.EmployeeList.SelectedIndex != -1)
            {
                for (int i = 0; i < selectedObject.Count; i++)
                {
                    _view.EmployeeList.Items.Remove(selectedObject[i]);
                }
            }
            
        }



        private void EditEmployee(object sender, EventArgs e)
        {
            EmployeeModel editedEmployee = CreateEmployee();
            if(editedEmployee != null) 
            {
                _view.EmployeeList.Items[_view.EmployeeList.SelectedIndex] = editedEmployee;
            }

        }



    }
}
