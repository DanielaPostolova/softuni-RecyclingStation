using System;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal
{
    class ConsoleRenderer : IConsoleRenderer
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}