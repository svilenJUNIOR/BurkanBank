using System;

namespace BurkanBankFinalEdition.IN.OUT
{
    public class Writer : IWriter
    {
        public void Write(string input)
        {
             Console.Write(input);
        }

        public void Write(int input)
        {
            Console.Write(input);
        }

        public void Write(double input)
        {
            Console.Write(input);
        }

        public void WriteLine(string input)
        {
             Console.WriteLine(input);
        }

        public void WriteLine(int input)
        {
            Console.Write(input);
        }

        public void WriteLine(double input)
        {
            Console.Write(input);
        }
    }
}
