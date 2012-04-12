using System;

namespace BdProject
{
    class LibraryDatabaseException : Exception
    {
        private const string DefaultMessage = "A database-related error has occurred";

        public LibraryDatabaseException(String message, Exception innerException = null)
            : base(message, innerException)
        {}

        public LibraryDatabaseException()
            : this(DefaultMessage)
        {}

        public LibraryDatabaseException(Exception innerException)
            : this(DefaultMessage, innerException)
        {}
    }
}
