using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC
{
    public abstract class Executor
    {
        protected List<string> envs = new List<string>();

        public abstract void Execute();

        public abstract void Stop();
    }
}
