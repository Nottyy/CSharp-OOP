using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class StackNode<T>
    {
        public StackNode<T> Next { get; set; }
        public T Value { get; set; }

        public StackNode(T value) {
            this.Value = value;
            this.Next = null;
        }
    }
}
