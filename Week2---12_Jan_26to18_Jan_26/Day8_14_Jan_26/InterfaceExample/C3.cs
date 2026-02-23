using System;

namespace InterfaceExample
{
    interface Inter1
    {
        void f1();

        interface Inter2
        {
            void f1();
        }
    }

    class C3 : Inter1, Inter1.Inter2
    {
        void Inter1.f1()
        {
            Console.WriteLine("Method from Interface 1");
        }

        void Inter1.Inter2.f1()
        {
            Console.WriteLine("Method from Interface 2");
        }
    }
}
