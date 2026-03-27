using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    public class InvalidLanguageException : Exception
    {
        public InvalidLanguageException() : base("The language is INVALID.Please enter a valid Language") { }

    }

    public class InvalidDurationException : Exception
    {
        public InvalidDurationException() : base("The duration us Invalid. Please ebnter a valid duration") { }
    }
}
