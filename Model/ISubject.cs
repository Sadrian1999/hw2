﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Model
{
    public interface ISubject
    {
        void Notify();
        void Subscribe(IObserver observer);
        void UnSubscribe(IObserver observer);
    }
}
