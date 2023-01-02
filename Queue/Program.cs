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
            st.printQueue();

            st.Push(4);
            st.printQueue();

            st.Pop();
            st.printQueue();

            st.Pop();
            st.printQueue();

            st.Push(3);
            st.printQueue();

            st.Push(2);
            st.printQueue();

            st.Push(1);
            st.printQueue();

            st.Push(11);
            st.printQueue();

            st.Push(44);
            st.printQueue();

            st.Pop();
            st.printQueue();

        }
    }
}
