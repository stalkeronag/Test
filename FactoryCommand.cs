﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC
{
    public abstract class FactoryCommand
    {
        public abstract ICommand CreateCommand(string commandString);
    }

}
