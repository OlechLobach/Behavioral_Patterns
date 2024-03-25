using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern
{

    public class PaymentRequest
    {
        public decimal Amount { get; set; }
        public bool IsConfirmed { get; set; }
    }

    public abstract class PaymentHandler
    {
        protected PaymentHandler Successor;

        public void SetSuccessor(PaymentHandler successor)
        {
            Successor = successor;
        }

        public abstract void HandlePayment(PaymentRequest request);
    }

    public class FundsAvailabilityHandler : PaymentHandler
    {
        public override void HandlePayment(PaymentRequest request)
        {
            if (request.Amount <= 1000)
            {
                Console.WriteLine("Checking funds availability...");
                request.IsConfirmed = true;
            }
            else if (Successor != null)
            {
                Successor.HandlePayment(request);
            }
        }
    }

    public class SmsConfirmationHandler : PaymentHandler
    {
        public override void HandlePayment(PaymentRequest request)
        {
            if (request.Amount <= 5000)
            {
                Console.WriteLine("Sending SMS confirmation...");
                request.IsConfirmed = true;
            }
            else if (Successor != null)
            {
                Successor.HandlePayment(request);
            }
        }
    }

    public class AppConfirmationHandler : PaymentHandler
    {
        public override void HandlePayment(PaymentRequest request)
        {
            Console.WriteLine("Sending app confirmation...");
            request.IsConfirmed = true;
        }
    }
}
