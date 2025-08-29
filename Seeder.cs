namespace Ynab.Api.Client.Mock;

/// <summary>
/// Provides functionality for seeding demo data.
/// </summary>
internal static class Seeder
{
    internal static BudgetDetail CreateBudget(string name)
    {
        return new BudgetDetail
        {
            Name = name,
            Id = Guid.NewGuid()
        };
    }

    internal static void AddAccount(BudgetDetail budget, AccountType type, string name, Guid accountId)
    {
        budget.Accounts ??= [];
        var account = new Account
        {
            Id = accountId,
            Name = name,
            Type = type,
            Debt_interest_rates = [],
            Debt_escrow_amounts = []
        };
        budget.Accounts.Add(account);
    }

    internal static void AddCategoryGroup(BudgetDetail budget, Guid id, string name)
    {
        budget.Category_groups ??= [];
        var group = new CategoryGroup
        {
            Id = id,
            Name = name
        };
        budget.Category_groups.Add(group);
    }

    internal static void AddCategory(BudgetDetail budget, string name, Guid id, Guid groupId, decimal target, TargetOffsetType targetOffset, int cadence, int frequency, int day)
    {
        budget.Categories ??= [];
        var category = new Category
        {
            Id = id,
            Name = name,
            Category_group_id = groupId,
            Goal_target = target.ToMilliunits(),
            Goal_target_month = TargetOffsetToDateTimeOffset(targetOffset),
            Goal_cadence = cadence,
            Goal_cadence_frequency = frequency,
            Goal_day = day
        };
        budget.Categories.Add(category);
    }

    internal static void AddStartingBalance(List<TransactionDetail> transactions, Account account, decimal amount)
    {
        var start = CalcStartDate();
        transactions.Add(
            new()
            {
                Id = $"{account.Id}-starting-balance",
                Account_id = account.Id,
                Account_name = account.Name,
                Date = start,
                Amount = amount.ToMilliunits(),
                Memo = "Starting Balance"
            });
    }

    internal static void AddTransactions(List<TransactionDetail> transactions, Account account, Dictionary<Guid, string> CategoryNames, SeedTransactionModel[] entries)
    {
        var start = CalcStartDate();
        for (var m = 0; m < 12; m++)
        {
            var date = start.AddMonths(m);
            var year = date.Year;
            var month = date.Month;

            foreach (var entry in entries)
            {
                foreach (var day in entry.DaysOfMonth)
                {
                    var paycheckDate = new DateTime(year, month, day);
                    transactions.Add(new TransactionDetail
                    {
                        Id = $"{month}-{year}-{day}",
                        Payee_name = entry.Payee,
                        Memo = entry.Memo,
                        Category_id = entry.CategoryId,
                        Category_name = entry.CategoryId == Guid.Empty ? string.Empty : CategoryNames[entry.CategoryId],
                        Account_id = account.Id,
                        Account_name = account.Name,
                        Date = paycheckDate,
                        Amount = entry.Amount.Randomize(entry.RandomnessPercentage, entry.AllowSignChange).ToMilliunits()
                    });
                }
            }
        }
    }

    internal static void AddCreditCardPayments(List<TransactionDetail> transactions, Account creditCardAccount, Account paymentAccount)
    {
        var start = CalcStartDate();
        for (var m = 0; m < 12; m++)
        {
            var date = start.AddMonths(m);
            var year = date.Year;
            var month = date.Month;

            // Sum up the charges for the month.
            var charges = transactions
                .Where(t => t.Account_id == creditCardAccount.Id && t.Date.Year == year && t.Date.Month == month)
                .Sum(t => t.Amount);

            // Create a payment transaction.
            var paymentDate = new DateTime(year, month, 28);
            transactions.Add(new TransactionDetail
            {
                Id = $"payment-{month}-{year}",
                Payee_name = $"{creditCardAccount.Name} Payment",
                Memo = "Credit Card Payment",
                Category_id = Guid.Empty,
                Category_name = string.Empty,
                Account_id = paymentAccount.Id,
                Account_name = paymentAccount.Name,
                Date = paymentDate,
                Amount = charges
            });

            transactions.Add(new TransactionDetail
            {
                Id = $"payment-credit-{month}-{year}",
                Payee_name = "Credit Card Payment",
                Memo = $"Payment from {paymentAccount.Name}",
                Category_id = Guid.Empty,
                Category_name = string.Empty,
                Account_id = creditCardAccount.Id,
                Account_name = creditCardAccount.Name,
                Date = paymentDate,
                Amount = -charges
            });
        }
    }

    private static DateTimeOffset TargetOffsetToDateTimeOffset(TargetOffsetType targetOffset)
    {
        var now = DateTimeOffset.Now;
        return targetOffset switch
        {
            TargetOffsetType.NextMonth => new DateTimeOffset(now.Year, now.Month, 1, 0, 0, 0, TimeSpan.Zero).AddMonths(1),
            TargetOffsetType.InSixMonths => new DateTimeOffset(now.Year, now.Month, 1, 0, 0, 0, TimeSpan.Zero).AddMonths(6),
            TargetOffsetType.InAYear => new DateTimeOffset(now.Year, now.Month, 1, 0, 0, 0, TimeSpan.Zero).AddMonths(12),
            _ => throw new ArgumentOutOfRangeException(nameof(targetOffset), targetOffset, null)
        };
    }

    private static DateTime CalcStartDate()
    {
        var date = DateTime.Now - new TimeSpan(365 * 12, 0, 0);
        return new DateTime(date.Year, date.Month, 1);
    }
}