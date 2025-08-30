namespace Ynab.Api.Client.Mock;

internal static class SeedExtensions
{
    /// <summary>
    /// Converts a decimal amount to YNAB milliunits (amount * 1000, rounded).
    /// </summary>
    internal static int ToMilliunits(this decimal amount)
    {
        return (int)Math.Round(amount * 1000);
    }

    /// <summary>
    /// Randomizes an amount by a percentage (positive or negative).
    /// </summary>
    internal static decimal Randomize(this decimal amount, decimal percentage, bool allowSignChange)
    {
        var random = new Random();
        decimal factor;
        if (allowSignChange)
        {
            // Random between -percentage and +percentage.
            factor = 1 + ((decimal)random.NextDouble() * 2 - 1) * percentage;
        }
        else
        {
            // Random between 0 and +percentage.
            factor = 1 + ((decimal)random.NextDouble()) * percentage;
        }
        return amount * factor;
    }
}