namespace SDM
{
    using System;
    using Interfaces;

    class OperationHistory : IOperationHistory
    {
        public OperationHistory(string details, bool result, DateTime dateTime)
        {
            Details = details;
            Result = result;
            DateOfExecution = dateTime;
        }

        public string Details { get; set; }
        public bool Result { get; set; }
        public DateTime DateOfExecution { get; set; }
    }
}
