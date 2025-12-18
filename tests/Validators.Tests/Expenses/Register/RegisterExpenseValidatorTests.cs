using System.Data;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Exception;
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
    [Fact]
    public void Error_Title_Empty()
    {
        //Arrange -> PREPARAÇÃO DO TESTE
        var validator = new RegisterExpenseValidator();
        var request = new RequestRegisterExpenseJsonBuilder().Build();
        request.Title = string.Empty;
        

        //Act -> AÇÃO DE TESTE
        var result = validator.Validate(request);

        //Assert -> COMPARAÇÃO DO TESTE
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorMessage.Equals("blablabla")).And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
    }
    
    [Fact]
    public void Error_Date_Future()
    {
        //Arrange -> PREPARAÇÃO DO TESTE
        var validator = new RegisterExpenseValidator();
        var request = new RequestRegisterExpenseJsonBuilder().Build();
        request.Date = DateTime.UtcNow.AddDays(-1);
        

        //Act -> AÇÃO DE TESTE
        var result = validator.Validate(request);

        //Assert -> COMPARAÇÃO DO TESTE
        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .ContainSingle(e => e.ErrorMessage.Equals(ResourceErrorMessages.EXPENSES_CANNOT_FOR_THE_FUTURE));
    }
}