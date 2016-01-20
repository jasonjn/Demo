using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JN.Demo
{
    class StackFrameDemo
    {
        public static void test()
        {
            StackFrame fr = new StackFrame(1, true);
            StackTrace st = new StackTrace(fr);
            EventLog.WriteEntry(fr.GetMethod().Name,
                                st.ToString(),
                                EventLogEntryType.Warning);


        }

    }
}
