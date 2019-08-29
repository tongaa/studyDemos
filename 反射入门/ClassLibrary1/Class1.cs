using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 这是 demo用的类库
namespace ClassLibrary1
{
    public class People
    {
        private string name = null;
        public People() { }
        public People(string strName)
        {
            name = strName;
        }
        public void Say()
        {
            if (name == null)
            {
                Console.WriteLine("hi~~");
            }
            Console.WriteLine("hi" + name);
        }
    }
    public class Man
    {
        void Eat() { Console.WriteLine("EAT"); }
    }
}
