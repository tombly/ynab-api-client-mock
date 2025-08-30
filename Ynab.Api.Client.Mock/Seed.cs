using Ynab.Api.Client.Extensions;

namespace Ynab.Api.Client.Mock;

/// <summary>
/// Populates a <see cref="BudgetDetail"/> instance and list of
/// <see cref="TransactionDetail"/> instances with demo data.
/// </summary>
internal class Seed
{
    public BudgetDetail BudgetDetail { get; private set; } = null!;

    public List<TransactionDetail> Transactions { get; private set; } = [];

    // Account IDs.
    private static readonly Guid AccountIdChecking = Guid.NewGuid();
    private static readonly Guid AccountIdSavings = Guid.NewGuid();
    private static readonly Guid AccountId401k = Guid.NewGuid();
    private static readonly Guid AccountIdIRA = Guid.NewGuid();
    private static readonly Guid AccountIdVisa = Guid.NewGuid();

    // Category Group IDs.
    private static readonly Guid CategoryGroupIdFixed = Guid.NewGuid();
    private static readonly Guid CategoryGroupIdVariable = Guid.NewGuid();
    private static readonly Guid CategoryGroupIdGoals = Guid.NewGuid();

    // Category IDs.
    private static readonly Guid CategoryIdCarInsurance = Guid.NewGuid();
    private static readonly Guid CategoryIdElectricity = Guid.NewGuid();
    private static readonly Guid CategoryIdRent = Guid.NewGuid();
    private static readonly Guid CategoryIdInternet = Guid.NewGuid();
    private static readonly Guid CategoryIdPhone = Guid.NewGuid();
    private static readonly Guid CategoryIdPetFood = Guid.NewGuid();
    private static readonly Guid CategoryIdAppSubscriptions = Guid.NewGuid();
    private static readonly Guid CategoryIdTVSubscription = Guid.NewGuid();
    private static readonly Guid CategoryIdDiscretionary = Guid.NewGuid();
    private static readonly Guid CategoryIdVacation = Guid.NewGuid();
    private static readonly Guid CategoryIdTransfer = Guid.NewGuid();

    private static Dictionary<Guid, string> CategoryNamesById { get; } = new Dictionary<Guid, string>
    {
        { CategoryIdCarInsurance, "Car Insurance" },
        { CategoryIdElectricity, "Electricity" },
        { CategoryIdRent, "Rent" },
        { CategoryIdInternet, "Internet" },
        { CategoryIdPhone, "Phone" },
        { CategoryIdPetFood, "Pet Food" },
        { CategoryIdAppSubscriptions, "Apps" },
        { CategoryIdTVSubscription, "TV Subscription" },
        { CategoryIdDiscretionary, "Discretionary" },
        { CategoryIdVacation, "Vacation" },
        { CategoryIdTransfer, "Transfer" }
    };

    public void Populate()
    {
        // Create a budget.
        BudgetDetail = Seeder.CreateBudget("My Budget");

        // Create budget groups.
        Seeder.AddCategoryGroup(BudgetDetail, CategoryGroupIdFixed, "Fixed Expenses");
        Seeder.AddCategoryGroup(BudgetDetail, CategoryGroupIdVariable, "Variable Expenses");
        Seeder.AddCategoryGroup(BudgetDetail, CategoryGroupIdGoals, "Goals");

        // Create accounts.
        Seeder.AddAccount(BudgetDetail, AccountType.Checking, "CASH - Checking Account", AccountIdChecking);
        Seeder.AddAccount(BudgetDetail, AccountType.Savings, "CASH - Savings Account", AccountIdSavings);
        Seeder.AddAccount(BudgetDetail, AccountType.OtherAsset, "RET - 401k", AccountId401k);
        Seeder.AddAccount(BudgetDetail, AccountType.OtherAsset, "RET - IRA", AccountIdIRA);
        Seeder.AddAccount(BudgetDetail, AccountType.LineOfCredit, "LOC - Visa Card", AccountIdVisa);

        // Create fixed expense categories.
        Seeder.AddCategory(BudgetDetail, "Car Insurance", CategoryIdCarInsurance, CategoryGroupIdFixed, 900, TargetOffsetType.InSixMonths, 1, 6, 5);
        Seeder.AddCategory(BudgetDetail, "Electricity", CategoryIdElectricity, CategoryGroupIdFixed, 75, TargetOffsetType.NextMonth, 1, 1, 17);
        Seeder.AddCategory(BudgetDetail, "Rent", CategoryIdRent, CategoryGroupIdFixed, 1400, TargetOffsetType.NextMonth, 1, 1, 1);
        Seeder.AddCategory(BudgetDetail, "Internet", CategoryIdInternet, CategoryGroupIdFixed, 95, TargetOffsetType.NextMonth, 1, 1, 3);
        Seeder.AddCategory(BudgetDetail, "Phone", CategoryIdPhone, CategoryGroupIdFixed, 80, TargetOffsetType.NextMonth, 1, 1, 18);
        Seeder.AddCategory(BudgetDetail, "Pet Food", CategoryIdPetFood, CategoryGroupIdFixed, 40, TargetOffsetType.NextMonth, 1, 1, 9);
        Seeder.AddCategory(BudgetDetail, "Apps", CategoryIdAppSubscriptions, CategoryGroupIdFixed, 40, TargetOffsetType.NextMonth, 1, 1, 4);
        Seeder.AddCategory(BudgetDetail, "TV Subscription", CategoryIdTVSubscription, CategoryGroupIdFixed, 105, TargetOffsetType.NextMonth, 1, 1, 1);

        // Create variable expense categories.
        Seeder.AddCategory(BudgetDetail, "Discretionary", CategoryIdDiscretionary, CategoryGroupIdVariable, 900, TargetOffsetType.NextMonth, 1, 1, 1);

        // Create goal categories.
        Seeder.AddCategory(BudgetDetail, "Vacation", CategoryIdVacation, CategoryGroupIdGoals, 900, TargetOffsetType.InAYear, 13, 1, 1);

        // Create transactions for each account.
        var checkingAccount = BudgetDetail.Accounts!.First(a => a.Id == AccountIdChecking);
        Seeder.AddStartingBalance(Transactions, checkingAccount, 5000);
        Seeder.AddTransactions(Transactions, checkingAccount, CategoryNamesById, [
            new SeedTransactionModel { Payee = "Employer",  DaysOfMonth = [1, 15], Amount = 2000 },
            new SeedTransactionModel { Payee = "Check", Memo = "Rent", CategoryId = CategoryIdRent, DaysOfMonth = [1], Amount = -1800 }
        ]);

        var savingsAccount = BudgetDetail.Accounts!.First(a => a.Id == AccountIdSavings);
        Seeder.AddStartingBalance(Transactions, savingsAccount, 10000);
        Seeder.AddTransactions(Transactions, savingsAccount, CategoryNamesById, [
            new SeedTransactionModel { DaysOfMonth = [28], Amount = 100, RandomnessPercentage = 2m },
        ]);

        var four01Account = BudgetDetail.Accounts!.First(a => a.Id == AccountId401k);
        Seeder.AddStartingBalance(Transactions, four01Account, 100000);
        Seeder.AddTransactions(Transactions, four01Account, CategoryNamesById, [
            new SeedTransactionModel { DaysOfMonth = [20], Amount = 700, RandomnessPercentage = 5m, AllowSignChange = true }
        ]);

        var iraAccount = BudgetDetail.Accounts!.First(a => a.Id == AccountIdIRA);
        Seeder.AddStartingBalance(Transactions, iraAccount, 55000);
        Seeder.AddTransactions(Transactions, iraAccount, CategoryNamesById, [
            new SeedTransactionModel { DaysOfMonth = [20], Amount = 200, RandomnessPercentage = 5m, AllowSignChange = true }
        ]);

        var visaAccount = BudgetDetail.Accounts!.First(a => a.Id == AccountIdVisa);
        Seeder.AddStartingBalance(Transactions, visaAccount, 0);
        Seeder.AddTransactions(Transactions, visaAccount, CategoryNamesById, [

            // Fixed expenses.
            new SeedTransactionModel { Payee = "Acme Power Co.", CategoryId = CategoryIdElectricity, DaysOfMonth = [1], Amount = -50 },
            new SeedTransactionModel { Payee = "Comcast", CategoryId = CategoryIdInternet, DaysOfMonth = [1], Amount = -100 },
            new SeedTransactionModel { Payee = "AT&T", CategoryId = CategoryIdPhone, DaysOfMonth = [1], Amount = -75 },
            new SeedTransactionModel { Payee = "PetSmart", CategoryId = CategoryIdPetFood, DaysOfMonth = [1], Amount = -40 },
            new SeedTransactionModel { Payee = "Apple", CategoryId = CategoryIdAppSubscriptions, DaysOfMonth = [1], Amount = -10 },
            new SeedTransactionModel { Payee = "Netflix", CategoryId = CategoryIdTVSubscription, DaysOfMonth = [1], Amount = -15 },
            new SeedTransactionModel { Payee = "Geico", Memo = "Car Insurance", CategoryId = CategoryIdCarInsurance, DaysOfMonth = [5], Amount = -90 },

            // Variable expenses.
            new SeedTransactionModel { Payee = "Exxon", Memo = "Car", CategoryId = CategoryIdDiscretionary, DaysOfMonth = [5, 20], Amount = -105, RandomnessPercentage = 0.5m },
            new SeedTransactionModel { Payee = "AMC Theaters", Memo = "Entertainment", CategoryId = CategoryIdDiscretionary, DaysOfMonth = [5, 20], Amount = -45, RandomnessPercentage = 0.5m },
            new SeedTransactionModel { Payee = "Dominos", Memo = "Restaurants", CategoryId = CategoryIdDiscretionary, DaysOfMonth = [1, 15], Amount = -25, RandomnessPercentage = 0.5m },
            new SeedTransactionModel { Payee = "Starbucks", Memo = "Restaurants", CategoryId = CategoryIdDiscretionary, DaysOfMonth = [3, 6, 9, 15, 20], Amount = -15, RandomnessPercentage = 0.5m },
            new SeedTransactionModel { Payee = "Safeway", Memo = "Groceries", CategoryId = CategoryIdDiscretionary, DaysOfMonth = [3, 15, 25], Amount = -150, RandomnessPercentage = 0.5m },
            new SeedTransactionModel { Payee = "Gap", Memo = "Clothing", CategoryId = CategoryIdDiscretionary, DaysOfMonth = [8, 22], Amount = -60, RandomnessPercentage = 0.4m },
            new SeedTransactionModel { Payee = "Old Navy", Memo = "Clothing", CategoryId = CategoryIdDiscretionary, DaysOfMonth = [12], Amount = -45, RandomnessPercentage = 0.4m },
            new SeedTransactionModel { Payee = "Local Bar", Memo = "Restaurants", CategoryId = CategoryIdDiscretionary, DaysOfMonth = [7, 21, 28], Amount = -35, RandomnessPercentage = 0.5m },
            new SeedTransactionModel { Payee = "Ticketmaster", Memo = "Entertainment", CategoryId = CategoryIdDiscretionary, DaysOfMonth = [18], Amount = -120, RandomnessPercentage = 0.6m },
            new SeedTransactionModel { Payee = "Barnes & Noble", Memo = "Assorted", CategoryId = CategoryIdDiscretionary, DaysOfMonth = [14, 27], Amount = -30, RandomnessPercentage = 0.3m },
            new SeedTransactionModel { Payee = "Uber", Memo = "Assorted", CategoryId = CategoryIdDiscretionary, DaysOfMonth = [2, 10, 16, 24], Amount = -20, RandomnessPercentage = 0.5m },
            new SeedTransactionModel { Payee = "Guitar Center", Memo = "Assorted", CategoryId = CategoryIdDiscretionary, DaysOfMonth = [11], Amount = -75, RandomnessPercentage = 0.4m },
            new SeedTransactionModel { Payee = "Home Depot", Memo = "Assorted", CategoryId = CategoryIdDiscretionary, DaysOfMonth = [11], Amount = -100, RandomnessPercentage = 0.4m },
        ]);

        Seeder.AddCreditCardPayments(Transactions, visaAccount, checkingAccount);

        // Print a summary to the console that lists all transactions grouped by account.
        var groupedTransactions = Transactions.GroupBy(t => t.Account_name);
        foreach (var group in groupedTransactions)
        {
            Console.WriteLine($"Account: {group.Key}");
            foreach (var transaction in group.OrderBy(t => t.Date))
            {
                Console.WriteLine($" - {transaction.Date}: {transaction.Payee_name}: {transaction.Amount.FromMilliunits()}");
            }
        }
    }
}