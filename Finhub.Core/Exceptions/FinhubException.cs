using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finhub.Core.Exceptions
{
    public class FinhubException : Exception
    {
        public FinhubException(string? message) : base(message) { }

        public FinhubException() : base() { }

    }
}
