namespace SDM.Interfaces
{
    using System.Collections.Generic;

    public interface IOperation
    {
        void Execute(Command command, object[] parameters);
        List<IOpHistory> History { get; set; }
    }
}