using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var st = new NewStack<int>();
            st.Add(1);
            st.Add(2);
            st.Add(3);
            st.Add(4);
            st.Add(5);
            st.printStack();
            Console.WriteLine(st.Peek());
            st.Pop();
            st.printStack();
        }


    }
}
