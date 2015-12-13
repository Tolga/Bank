namespace SDM.Interfaces
{
    using System.Collections.Generic;
    public interface ICommand
    {
        void Do();
        void Undo();
        List<IOpHistory> History { get; set; }
    }
}
