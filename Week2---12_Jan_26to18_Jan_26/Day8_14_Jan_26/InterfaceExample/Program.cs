using System;
using static InterfaceExample.Inter1;

namespace InterfaceExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            C3 obj1 = new C3();

            Inter1 obj2 = obj1;
            obj2.f1();   // Calls Inter1.f1()

            Inter1.Inter2 obj3 = obj1;
            obj3.f1();   // Calls Inter2.f1()
        }
    }
}
