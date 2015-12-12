namespace SDM.Interfaces
{
    using System.Collections.Generic;
    public interface ICommand
    {
        void Execute();
        void Cancel();
        List<IOpHistory> History { get; set; }
    }
}
