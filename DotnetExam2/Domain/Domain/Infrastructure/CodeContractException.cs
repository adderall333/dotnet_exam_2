using System;

namespace Core.Infrastructure
{
    public class CodeContractException : Exception
    {
        public CodeContractException(string message) : base(message) { }
    }
}