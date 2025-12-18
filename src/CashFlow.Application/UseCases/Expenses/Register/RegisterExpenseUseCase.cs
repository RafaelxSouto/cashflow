using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validade(request);
        
        return new ResponseRegisteredExpenseJson();
    }

    private void Validade(RequestRegisterExpenseJson request)
    {
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (titleIsEmpty)
        {
            throw new ArgumentException("The title is required.");
        }

        if (request.Amount <= 0)
        {
            throw new ArgumentException("The amount must be greater than zero.");
        }
        
        var result = DateTime.Compare(request.Date, DateTime.UtcNow);
        if (result > 0)
        {
            throw new ArgumentException("Expenses cannot be for the future.");
        }

        var paymentsTypeIsValid = Enum.IsDefined(typeof(PaymentsType), request.PaymentsType);
        if (paymentsTypeIsValid)
        {
            throw new ArgumentException("Payments Type is invalid.");
        }
    }
}