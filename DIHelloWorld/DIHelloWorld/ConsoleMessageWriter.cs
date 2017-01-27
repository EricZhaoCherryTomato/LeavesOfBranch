using System;

namespace DIHelloWorld
{
    internal class ConsoleMessageWriter : IMessageWriter
    {
        public void Write(string helloDi)
        {
            Console.WriteLine(helloDi);
        }
    }
}