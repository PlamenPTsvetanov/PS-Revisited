﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfExample
{
    public class InfoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            NamesWindow namesWindow = new NamesWindow();
            namesWindow.Show();
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
