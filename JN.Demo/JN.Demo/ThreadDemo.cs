using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JN.Demo
{
    class ThreadDemo
    {
        public ThreadDemo()
        {
            sum = 0;
            thread = new Thread(Check);
            thread.Start();
        }

        public void AsyCheck()
        {
            if (!thread.IsAlive)
            {
                thread = new Thread(Check);
                thread.Start();
            }
        }

        Thread thread;

        public void Check()
        {
            sum++;

        }

        int _sum;
        private object lockObj = new Object();
        public int sum
        {
            get
            {
                return _sum;
            }

            set
            {
                lock (lockObj)
                {
                    _sum = value;
                }
            }
        }


    }
}
