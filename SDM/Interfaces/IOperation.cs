namespace SDM.Interfaces
{
    using System.Collections.Generic;

    public interface IOperation
    {
        void Do();
        void Undo();
        List<IOpHistory> History { get; set; }
    }
}