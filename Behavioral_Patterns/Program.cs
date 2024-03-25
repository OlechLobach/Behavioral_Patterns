using ChainOfResponsibilityPattern;


namespace MainProject { 
class Program
{
    static void Main(string[] args)
    {
        PaymentHandler fundsHandler = new FundsAvailabilityHandler();
        PaymentHandler smsHandler = new SmsConfirmationHandler();
        PaymentHandler appHandler = new AppConfirmationHandler();

        fundsHandler.SetSuccessor(smsHandler);
        smsHandler.SetSuccessor(appHandler);

        PaymentRequest request1 = new PaymentRequest { Amount = 500 };
        fundsHandler.HandlePayment(request1);
        Console.WriteLine($"Payment 1 confirmed: {request1.IsConfirmed}");

        PaymentRequest request2 = new PaymentRequest { Amount = 5000 };
        fundsHandler.HandlePayment(request2);
        Console.WriteLine($"Payment 2 confirmed: {request2.IsConfirmed}");

        PaymentRequest request3 = new PaymentRequest { Amount = 10000 };
        fundsHandler.HandlePayment(request3);
        Console.WriteLine($"Payment 3 confirmed: {request3.IsConfirmed}");
    }
}
}