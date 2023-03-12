using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC
{
    public class Service
    {
        private Dictionary<int, Executor> dict_executors;

        private IRouter router;

        private IParserCommand parser;
        
        private Service(Dictionary<int, Executor> executors)
        {
            this.dict_executors = executors;
        }

        private Service(Dictionary<int, Executor> executors, IRouter router) : this(executors)
        {
            this.router = router;
            this.router.OnRouteFind += ExecuteByID;
        }

        public Service(Dictionary<int, Executor> dict_executors, IRouter router, IParserCommand parser) : this(dict_executors, router)
        {
            this.parser = parser;
        }

        public void AddExecutor(int id, Executor executor)
        {
            if (!dict_executors.ContainsKey(id))
            {
                dict_executors.Add(id, executor);
            }
            else
            {
                throw new Exception("Executor in the same id exists");
            }
        }

        public void RemoveExecutor(int id)
        {
            if(dict_executors.ContainsKey(id))
            {
                dict_executors.Remove(id);
            }
        }

        private void ExecuteByID(int id)
        {
            if (dict_executors.ContainsKey(id))
            {
                dict_executors[id].Execute();
            }
        }

        public void StopExecutorById(int id)
        {
            if(dict_executors.ContainsKey(id))
            {
                dict_executors[id].Stop();  
            }
        }
    }
}
