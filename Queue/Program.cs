using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var st = new ArrQueue<int>();
            st.Push(5);
            st.Push(4);
            st.Pop();
            st.Pop();
            st.Push(3);
            st.Push(2);
            st.Push(1);
            st.Push(11);
            st.Push(11);
        }
    }
}
