using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class TaskApplicatioException : Exception
    {
        public TaskApplicatioException(string message) : base(message) { }

    }
}
