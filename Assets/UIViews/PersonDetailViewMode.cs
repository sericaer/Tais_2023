﻿using PropertyChanged;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tais.Views
{
    public class PersonDetailViewMode : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string roleName { get; private set; }

        public int rolePrestige { get; private set; }

        public int roleHeath { get; private set; }

        public int rolePress { get; private set; }

        public PersonDetailViewMode()
        {
            rolePrestige = 12;
        }

        public void Dispose()
        {

        }
    }
}
