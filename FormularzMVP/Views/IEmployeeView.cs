﻿using FormularzMVP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormularzMVP.Views
{
    public interface IEmployeeView
    {
        //Prop
        string EmployeeName { get; set; }
        string EmployeeSurname { get; set; }
        DateTime EmployeeBirthDate { get; set; }
        decimal EmployeeSalary { get; set; }
        string EmployeePosition { get; set; }
        string EmployeeContract { get; set; }
        ListBox EmployeeList { get; set; }

        //Events
        event EventHandler AddEvent;
        event EventHandler DeleteEvent;
        event EventHandler SerializeEvent;
        event EventHandler DeserializeEvent;
        event EventHandler EditEvent;
        event EventHandler ReadEmplyeeEvent;

        //Methods
        void RaiseErrorName(string message);
        void HideErrorName();
        void RaiseErrorSurname(string message);
        void HideErrorSurname();
        void RaiseErrorPosition(string message);
        void HideErrorPosition();
        void HideAllErrors();

    }
}
