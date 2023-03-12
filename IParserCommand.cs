﻿using MyRPC.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC
{
    public interface IParserCommand
    {
        public CommandData Parse(string str); 
    }
}
