namespace Ynab.Api.Client.Mock;

/// <summary>
/// A mock implementation of the YNAB API client.
/// </summary>
public class YnabApiClientMock : IYnabApiClient
{
    private readonly Seed _seed;

    public YnabApiClientMock()
    {
        _seed = new Seed();
        _seed.Populate();
    }

    public string BaseUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Task<AccountResponse> CreateAccountAsync(string budget_id, PostAccountWrapper body)
    {
        throw new NotImplementedException();
    }

    public Task<AccountResponse> CreateAccountAsync(string budget_id, PostAccountWrapper body, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ScheduledTransactionResponse> CreateScheduledTransactionAsync(string budget_id, PostScheduledTransactionWrapper body)
    {
        throw new NotImplementedException();
    }

    public Task<ScheduledTransactionResponse> CreateScheduledTransactionAsync(string budget_id, PostScheduledTransactionWrapper body, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<SaveTransactionsResponse> CreateTransactionAsync(string budget_id, PostTransactionsWrapper body)
    {
        throw new NotImplementedException();
    }

    public Task<SaveTransactionsResponse> CreateTransactionAsync(string budget_id, PostTransactionsWrapper body, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionResponse> DeleteTransactionAsync(string budget_id, string transaction_id)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionResponse> DeleteTransactionAsync(string budget_id, string transaction_id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<AccountResponse> GetAccountByIdAsync(string budget_id, Guid account_id)
    {
        throw new NotImplementedException();
    }

    public Task<AccountResponse> GetAccountByIdAsync(string budget_id, Guid account_id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<AccountsResponse> GetAccountsAsync(string budget_id, long? last_knowledge_of_server)
    {
        return GetAccountsAsync(budget_id, last_knowledge_of_server, CancellationToken.None);
    }

    public Task<AccountsResponse> GetAccountsAsync(string budget_id, long? last_knowledge_of_server, CancellationToken cancellationToken)
    {
        return Task.FromResult(new AccountsResponse
        {
            Data = new AccountsData
            {
                Accounts = _seed.BudgetDetail.Accounts!
            }
        });
    }

    public Task<BudgetDetailResponse> GetBudgetByIdAsync(string budget_id, long? last_knowledge_of_server)
    {
        return GetBudgetByIdAsync(budget_id, last_knowledge_of_server, CancellationToken.None);
    }

    public Task<BudgetDetailResponse> GetBudgetByIdAsync(string budget_id, long? last_knowledge_of_server, CancellationToken cancellationToken)
    {
        return Task.FromResult(new BudgetDetailResponse
        {
            Data = new BudgetDetailData
            {
                Budget = _seed.BudgetDetail
            }
        });
    }

    public Task<MonthDetailResponse> GetBudgetMonthAsync(string budget_id, DateTimeOffset month)
    {
        throw new NotImplementedException();
    }

    public Task<MonthDetailResponse> GetBudgetMonthAsync(string budget_id, DateTimeOffset month, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<MonthSummariesResponse> GetBudgetMonthsAsync(string budget_id, long? last_knowledge_of_server)
    {
        throw new NotImplementedException();
    }

    public Task<MonthSummariesResponse> GetBudgetMonthsAsync(string budget_id, long? last_knowledge_of_server, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BudgetSummaryResponse> GetBudgetsAsync(bool? include_accounts)
    {
        return GetBudgetsAsync(include_accounts, CancellationToken.None);
    }

    /// <summary>
    /// Returns a list of all budgets. The include_accounts parameter is not
    /// currently supported.
    /// </summary>
    public Task<BudgetSummaryResponse> GetBudgetsAsync(bool? include_accounts, CancellationToken cancellationToken)
    {
        return Task.FromResult(new BudgetSummaryResponse
        {
            Data = new BudgetSummaryData
            {
                Budgets =
                [
                    _seed.BudgetDetail
                ]
            }
        });
    }

    public Task<BudgetSettingsResponse> GetBudgetSettingsByIdAsync(string budget_id)
    {
        throw new NotImplementedException();
    }

    public Task<BudgetSettingsResponse> GetBudgetSettingsByIdAsync(string budget_id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CategoriesResponse> GetCategoriesAsync(string budget_id, long? last_knowledge_of_server)
    {
        throw new NotImplementedException();
    }

    public Task<CategoriesResponse> GetCategoriesAsync(string budget_id, long? last_knowledge_of_server, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryResponse> GetCategoryByIdAsync(string budget_id, string category_id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryResponse> GetCategoryByIdAsync(string budget_id, string category_id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryResponse> GetMonthCategoryByIdAsync(string budget_id, DateTimeOffset month, string category_id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryResponse> GetMonthCategoryByIdAsync(string budget_id, DateTimeOffset month, string category_id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PayeeResponse> GetPayeeByIdAsync(string budget_id, string payee_id)
    {
        throw new NotImplementedException();
    }

    public Task<PayeeResponse> GetPayeeByIdAsync(string budget_id, string payee_id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PayeeLocationResponse> GetPayeeLocationByIdAsync(string budget_id, string payee_location_id)
    {
        throw new NotImplementedException();
    }

    public Task<PayeeLocationResponse> GetPayeeLocationByIdAsync(string budget_id, string payee_location_id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PayeeLocationsResponse> GetPayeeLocationsAsync(string budget_id)
    {
        throw new NotImplementedException();
    }

    public Task<PayeeLocationsResponse> GetPayeeLocationsAsync(string budget_id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PayeeLocationsResponse> GetPayeeLocationsByPayeeAsync(string budget_id, string payee_id)
    {
        throw new NotImplementedException();
    }

    public Task<PayeeLocationsResponse> GetPayeeLocationsByPayeeAsync(string budget_id, string payee_id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PayeesResponse> GetPayeesAsync(string budget_id, long? last_knowledge_of_server)
    {
        throw new NotImplementedException();
    }

    public Task<PayeesResponse> GetPayeesAsync(string budget_id, long? last_knowledge_of_server, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ScheduledTransactionResponse> GetScheduledTransactionByIdAsync(string budget_id, string scheduled_transaction_id)
    {
        throw new NotImplementedException();
    }

    public Task<ScheduledTransactionResponse> GetScheduledTransactionByIdAsync(string budget_id, string scheduled_transaction_id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ScheduledTransactionsResponse> GetScheduledTransactionsAsync(string budget_id, long? last_knowledge_of_server)
    {
        throw new NotImplementedException();
    }

    public Task<ScheduledTransactionsResponse> GetScheduledTransactionsAsync(string budget_id, long? last_knowledge_of_server, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionResponse> GetTransactionByIdAsync(string budget_id, string transaction_id)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionResponse> GetTransactionByIdAsync(string budget_id, string transaction_id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionsResponse> GetTransactionsAsync(string budget_id, DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server)
    {
        return GetTransactionsAsync(budget_id, since_date, type, last_knowledge_of_server, CancellationToken.None);
    }

    public Task<TransactionsResponse> GetTransactionsAsync(string budget_id, DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server, CancellationToken cancellationToken)
    {
        return Task.FromResult(new TransactionsResponse
        {
            Data = new TransactionsData
            {
                Transactions = _seed.Transactions
            }
        });
    }

    public Task<TransactionsResponse> GetTransactionsByAccountAsync(string budget_id, string account_id, DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionsResponse> GetTransactionsByAccountAsync(string budget_id, string account_id, DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<HybridTransactionsResponse> GetTransactionsByCategoryAsync(string budget_id, string category_id, DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server)
    {
        throw new NotImplementedException();
    }

    public Task<HybridTransactionsResponse> GetTransactionsByCategoryAsync(string budget_id, string category_id, DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<HybridTransactionsResponse> GetTransactionsByMonthAsync(string budget_id, string month, DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server)
    {
        throw new NotImplementedException();
    }

    public Task<HybridTransactionsResponse> GetTransactionsByMonthAsync(string budget_id, string month, DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<HybridTransactionsResponse> GetTransactionsByPayeeAsync(string budget_id, string payee_id, DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server)
    {
        throw new NotImplementedException();
    }

    public Task<HybridTransactionsResponse> GetTransactionsByPayeeAsync(string budget_id, string payee_id, DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<UserResponse> GetUserAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserResponse> GetUserAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionsImportResponse> ImportTransactionsAsync(string budget_id)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionsImportResponse> ImportTransactionsAsync(string budget_id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<SaveCategoryResponse> UpdateCategoryAsync(string budget_id, string category_id, PatchCategoryWrapper body)
    {
        throw new NotImplementedException();
    }

    public Task<SaveCategoryResponse> UpdateCategoryAsync(string budget_id, string category_id, PatchCategoryWrapper body, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<SaveCategoryResponse> UpdateMonthCategoryAsync(string budget_id, DateTimeOffset month, string category_id, PatchMonthCategoryWrapper body)
    {
        throw new NotImplementedException();
    }

    public Task<SaveCategoryResponse> UpdateMonthCategoryAsync(string budget_id, DateTimeOffset month, string category_id, PatchMonthCategoryWrapper body, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<SavePayeeResponse> UpdatePayeeAsync(string budget_id, string payee_id, PatchPayeeWrapper body)
    {
        throw new NotImplementedException();
    }

    public Task<SavePayeeResponse> UpdatePayeeAsync(string budget_id, string payee_id, PatchPayeeWrapper body, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionResponse> UpdateTransactionAsync(string budget_id, string transaction_id, PutTransactionWrapper body)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionResponse> UpdateTransactionAsync(string budget_id, string transaction_id, PutTransactionWrapper body, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<SaveTransactionsResponse> UpdateTransactionsAsync(string budget_id, PatchTransactionsWrapper body)
    {
        throw new NotImplementedException();
    }

    public Task<SaveTransactionsResponse> UpdateTransactionsAsync(string budget_id, PatchTransactionsWrapper body, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}