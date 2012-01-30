using System;

namespace Shariando.Services.Interfaces.Exceptions
{
    public abstract class ShariandoException : Exception
    {
        public abstract string ErrorMessage { get; }
    }
}