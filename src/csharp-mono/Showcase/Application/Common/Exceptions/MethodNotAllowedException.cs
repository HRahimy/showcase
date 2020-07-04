using System;

namespace Showcase.Application.Common.Exceptions
{
    public class MethodNotAllowedException : Exception
    {
        public MethodNotAllowedException(string name, object key, string message)
            : base($"Execution of operation \"{name}\" ({key}) not allowed. {message}")
        {
        }
    }
}
