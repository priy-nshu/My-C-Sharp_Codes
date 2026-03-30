using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
<<<<<<< HEAD
    public class InvalidLanguageException : Exception
    {
        public InvalidLanguageException() : base("The language is INVALID.Please enter a valid Language") { }

    }
=======
        public class InvalidLanguageException :Exception
        {
            public InvalidLanguageException() : base("The language is Invalid.Please enter a valid Language") { }

        }
>>>>>>> ca973e6edfc4a47fab7f244dfc44b86289a76d21

    public class InvalidDurationException : Exception
    {
        public InvalidDurationException() : base("The duration us Invalid. Please ebnter a valid duration") { }
    }
}
