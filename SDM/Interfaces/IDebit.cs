﻿namespace SDM.Interfaces
{
    public interface IDebit
    {
        float Amount { get; set; }
        IOpHistory History { get; set; }
    }
}