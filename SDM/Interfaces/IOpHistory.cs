namespace SDM.Interfaces
{
    using System;

    public interface IOpHistory
    {
        DateTime DateOfExecution { get; set; }
        String Description { get; set; }
    }
}