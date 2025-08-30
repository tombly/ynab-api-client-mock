namespace Ynab.Api.Client.Mock;

internal class SeedTransactionModel
{
    public string Payee { get; set; } = string.Empty;
    public string Memo { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public int[] DaysOfMonth { get; set; } = [];
    public decimal Amount { get; set; }
    public decimal RandomnessPercentage { get; set; }
    public bool AllowSignChange { get; set; }
}
