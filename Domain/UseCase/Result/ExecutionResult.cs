using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Result
{
    public class ExecutionResult
    {
        private static readonly ExecutionResult _success = new ExecutionResult { Succeeded = true };
        private readonly List<ExecutionError> _errors = new List<ExecutionError>();

        public bool Succeeded { get; protected set; }
        public IEnumerable<ExecutionError> Errors => _errors;

        public static ExecutionResult Success => _success;

        public static ExecutionResult Failed(params ExecutionError[] errors)
        {
            var result = new ExecutionResult { Succeeded = false };
            if (errors != null)
            {
                result._errors.AddRange(errors);
            }
            return result;
        }
    }
}
