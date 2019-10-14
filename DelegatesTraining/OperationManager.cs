using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesTraining
{
    public enum Operation
    {
        Sum,
        Subtract,
        Multiply
    }

    public class ExecutionManager
    {
        public  Dictionary<Operation,Func<dynamic>> FuncExecute { get; set; }
        private Func<dynamic> _sum;
        private Func<dynamic> _subtract;
        private Func<dynamic> _multiply;

        public ExecutionManager()
        {
            FuncExecute = new Dictionary<Operation, Func<dynamic>>(3);
        }

        public void PopulateFunctions(Func<dynamic> sum, Func<dynamic> subtract, Func<dynamic> multiply)
        {
            _subtract = subtract;
            _sum = sum;
            _multiply = multiply;
        }

        public void PrepareExecution()
        {
            FuncExecute.Add(Operation.Sum,_sum);
            FuncExecute.Add(Operation.Multiply,_multiply);
            FuncExecute.Add(Operation.Subtract,_subtract);
        }
    }

    public class OperationManager
    {
        private int _first;
        private int _second;
        private readonly ExecutionManager _executionManager;

        public OperationManager(int first, int second,ExecutionManager executionManager)
        {
            _first = first;
            _second = second;
            _executionManager = executionManager;
            _executionManager.PopulateFunctions(Sum,Subtract,Multiply);
            _executionManager.PrepareExecution();
        }
        private dynamic Sum()
        {
            return "Sum"+_first + _second;
        }

        private dynamic Subtract()
        {
            return _first - _second;
        }

        private dynamic Multiply()
        {
            return _first * _second;
        }

        public dynamic Execute(Operation operation)
        {
            return _executionManager.FuncExecute.ContainsKey(operation)
                ? _executionManager.FuncExecute[operation]()
                : -1;
        }

    }


}
