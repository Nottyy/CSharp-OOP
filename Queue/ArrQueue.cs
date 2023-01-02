using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class ArrQueue<T>
    {
        const int MAX_CAPACITY = 4;

        private int size;
        private int startIndex;
        private int endIndex;
        private T[] buffer;

        public ArrQueue()
        {
            this.size = 0;
            this.startIndex = 0;
            this.endIndex = 0;
            this.buffer = null;
        }

        public void Push(T value)
        {
            // resize
            
            if (buffer == null)
            {
                buffer = new T[MAX_CAPACITY];
            }
            if (size == buffer.Length)
            {
                this.Resize(buffer.Length * 2);
            }

            buffer[endIndex] = value;
            endIndex = this.NextIndex(endIndex);
            size++;
        }

        public void Pop()
        {
            buffer[startIndex] = default(T);
            startIndex = this.NextIndex(startIndex);
            size--;
        }

        public int Size => this.size;

        public void printQueue()
        {
            var newBuffer = new T[buffer.Length];
            var sb = new StringBuilder();

            for (int i = 0, j = startIndex; i < size; i++, j = this.NextIndex(j))
            {
                newBuffer[i] = buffer[j];
                sb.Append($" {newBuffer[i]}");
            }

            Console.WriteLine(sb);
        }

        private int NextIndex(int index)
        {
            index++;

            if (index == this.buffer.Length)
            {
                index = 0;
            }

            return index;
        }
        private void Resize(int newSize)
        {
            var newBuffer = new T[newSize];

            for (int i = 0, j = startIndex ; i < size; i++, j = this.NextIndex(j))
            {
                newBuffer[i] = buffer[j];
            }

            endIndex = buffer.Length;
            startIndex = 0;
            buffer = newBuffer;
        }
    }
}
