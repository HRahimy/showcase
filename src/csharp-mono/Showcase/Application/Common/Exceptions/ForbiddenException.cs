using System;

namespace Showcase.Application.Common.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException(string name, object key, string message)
            : base($"Execution of operation \"{name}\" ({key}) is forbidden. {message}")
        {

        }
    }
}
