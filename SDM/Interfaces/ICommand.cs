namespace SDM.Interfaces
{
    using System.Collections.Generic;
    public interface ICommand
    {
        void Execute();
        List<IOpHistory> History { get; set; }
    }
}
