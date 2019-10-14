using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesTraining
{
    class Program
    {
        //Declaration
        public delegate void WriterDelegate(string text);

        public static void Write(string text)
        {
            Console.WriteLine(text);
        }

        public static int Sum(int a, int b)
        {
            return a + b;
        }
        static void Main(string[] args)
        {
            //Instantiation
            WriterDelegate writerDelegate = new WriterDelegate(Write);

            //Invocation 
            writerDelegate("Welcome");

            // Delegetes have 2 built in 
            // 1- Func<T> takes up to 16 parameters and return value not void 

            Func<int, int, int> sumDelegate = Sum;

            Console.WriteLine(sumDelegate(10,20));
            Console.WriteLine(sumDelegate(10,20));

            // 2- Action<T> takes up to 16 parameters and not return any thing 

            Action<string> writeDelegate = Write;

            writeDelegate("String Action");



            var executionManager = new ExecutionManager();
            var opManager = new OperationManager(20,10,executionManager);
            var result = opManager.Execute(Operation.Sum);
            Console.WriteLine(result);
            Console.WriteLine(opManager.Execute(Operation.Multiply));


            Console.Read();

        }
    }
}
