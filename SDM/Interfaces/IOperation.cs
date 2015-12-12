namespace SDM.Interfaces
{
    using System.Collections.Generic;

    public interface IOperation
    {
        List<IOpHistory> History { get; set; }
        ICommand Commit();
    }
}