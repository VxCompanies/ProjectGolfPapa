﻿using System;
using System.Windows.Input;

namespace ProjectGolfPapa.ViewModels.Command;

public abstract class CommandBase : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public virtual bool CanExecute(object? parameter) => true;

    public abstract void Execute(object? parameter);
}
