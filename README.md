# YNAB.API.Client.Mock

A mock of the [YNAB.API.Client](https://github.com/tombly/ynab-api-client). Currently includes basic support for getting a budget, a list of accounts, and a list of transactions.

## Usage

Add the nuget to your app:

```shell
dotnet add package Ynab.Api.Client.Mock
```

Import the namespace, instantiate a mock, and call a method.

```csharp
using Ynab.Api.Client.Mock;

...

var mock = new YnabApiClientMock();
var budgets = mock.GetBudgetsAsync();
```

## License

Copyright (c) 2025 Tom Bulatewicz

Licensed under the MIT license