using System;

namespace HT
{
    public class Refl
    {
        void Main(string[] args)
        {
            Console.WriteLine(Output());
            Console.WriteLine(AddInts(1, 2));
        }

        public string Output()
        {
            return "Test-Output";
        }

        public int AddInts(int i1, int i2)
        {
            return i1 + i2;
        }
    }
}