namespace SDM
{
    using System;
    using Interfaces;

    class OpHistory : IOpHistory
    {
        public OpHistory(String description, DateTime dateTime)
        {
            DateOfExecution = dateTime;
            Description = description;
        }

        public DateTime DateOfExecution { get; set; }
        public String Description { get; set; }
    }
}
