namespace Ynab.Api.Client.Mock;

/// <summary>
/// A program for testing the <see cref="Seed"/> class.
/// </summary>
internal class Program
{
    static void Main(string[] args)
    {
        new Seed().Populate();
    }
}