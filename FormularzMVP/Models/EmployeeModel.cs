using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularzMVP.Models
{
    
    public class EmployeeModel
    {
        private string _name;
        private string _surname;
        private decimal _salary;
        private DateTime _birthdate;
        private string _position;
        private string _contract;

        public EmployeeModel(string name, string surname, DateTime birthdate, decimal salary, string position, string contract) 
            {
            Name = name;
            Surname = surname;
            Salary = salary;
            BirthDate = birthdate;
            Position = position;
            Contract = contract;
        }
        public EmployeeModel() { }

        public string Name
        {
            get
            { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(paramName: nameof(Name), message:"Name cannot be empty!");
                }
                _name = value;

            }
        }
        public string Surname
        {
            get
            { return _surname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(paramName: nameof(Surname), message: "Surname cannot be empty!");
                }
                _surname = value;

            }
        }
        public decimal Salary { get { return _salary; } set { _salary = value; } }
        public DateTime BirthDate { get { return _birthdate; } set { _birthdate = value; } }
        public string Position
        {
            get
            { return _position; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(paramName: nameof(Position), message: "Position cannot be empty!");
                }
                _position = value;

            }
        }
        public string Contract 
        { 
            get 
            { return _contract; } 
            set 
            { 
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Błąd");
                }
                _contract = value; 
            } 
        }

        public override string ToString()
        {
            return $"Name: {_name}, Surname: {_surname}, Date of birth: {_birthdate}, Salary: {_salary}, Position: {_position}, Type of contract: {_contract}";
        }
    }

}
