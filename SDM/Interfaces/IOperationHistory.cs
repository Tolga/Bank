namespace SDM.Interfaces
{
    using System;

    public interface IOperationHistory
    {
        string Details { get; set; }
        bool Result { get; set; }
        DateTime DateOfExecution { get; set; }
    }
}