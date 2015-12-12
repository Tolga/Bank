namespace SDM.Interfaces
{
    public interface ICommand
    {
        void Execute(Commands command);
        Commands Command { get; set; }
    }
}
