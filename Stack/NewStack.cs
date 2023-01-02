using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class NewStack<T>
    {
        private StackNode<T> First { get; set; }

        public NewStack()
        {
            this.First = null;
        }

        public void Add(T value)
        {
            var newNode = new StackNode<T>(value);

            if (this.First == null)
            {
                this.First = newNode;
            }
            else
            {
                newNode.Next = this.First;
                this.First = newNode;
            }
        }

        public T Peek()
        {
            return this.First.Value;
        }

        public T Pop()
        {
            var poppedValue = this.First.Value;
            this.First = this.First.Next;

            return poppedValue;
        }

        public void printStack()
        {
            var sb = new StringBuilder();
            var firstNode = this.First;
            while (firstNode != null)
            {
                sb.Append($" {firstNode.Value}");

                if (firstNode.Next == null)
                {
                    break;
                }
                else
                {
                    firstNode = firstNode.Next;
                }
            }

            Console.WriteLine(sb);
        }
    }
}
