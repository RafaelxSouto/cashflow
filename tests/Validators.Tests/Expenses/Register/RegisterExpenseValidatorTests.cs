using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using Xunit;

namespace Validators.Tests.Expenses.Register;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Sucess()
    {
        //Arrange -> PREPARAÇÃO DO TESTE
        var validator = new RegisterExpenseValidator();
        var request = new RequestRegisterExpenseJson
        {
            Amount = 100,
            Date = DateTime.Now.AddDays(-1),
            Description = "Bought a new Apple Watch",
            Title = "Apple Watch",
            PaymentsType = CashFlow.Communication.Enums.PaymentsType.CreaditCard
        };

        //Act -> AÇÃO DE TESTE
        var result = validator.Validate(request);

        //Assert -> COMPARAÇÃO DO TESTE
        Assert.True(result.IsValid);
    }
}