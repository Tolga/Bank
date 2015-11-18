namespace SDM.Interfaces
{
    public interface IDebit : IAccount
	{
		float AllowedDebit { get; set; }
		float CurrentPossibleDebit { get; set; }

	}
}

