using System;

namespace Showcase.Application.Common.Exceptions
{
    public class ResourceConflictException : Exception
    {
        public ResourceConflictException(string name, object key, string message)
            : base($"Conflict detected for \"{name}\" ({key}). {message}")
        {
        }
    }
}
