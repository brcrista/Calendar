using System;

namespace Calendar.ObjectModel.DataProviders
{
    /// <summary>
    /// An exception type that is thrown when the state of the database
    /// is not recognized as valid by the application layer.
    /// </summary>
    public class DataConsistencyException : Exception
    {
        public DataConsistencyException(string message)
            : base(message)
        {
        }
    }
}
