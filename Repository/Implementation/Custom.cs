using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class Custom : ICustom
    {
        private int counter = 0;
        public void Increment()
        {
            counter++;
            Console.WriteLine(counter);
        }
    }
}
