using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CommonTestUtilities.Requests;
using FluentAssertions;
using Xunit;

namespace Validators.Tests.Expenses.Register;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Sucess()
    {
        //Arrange -> PREPARAÇÃO DO TESTE
        var validator = new RegisterExpenseValidator();
        var request = new RequestRegisterExpenseJsonBuilder().Build();
        

        //Act -> AÇÃO DE TESTE
        var result = validator.Validate(request);

        //Assert -> COMPARAÇÃO DO TESTE
        result.IsValid.Should().BeTrue();
    }
}