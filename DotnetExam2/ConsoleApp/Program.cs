using System;
using Core;
using Core.Entities;
using Core.Services;
using Core.ValueObjects;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var applicationResult = LoanApplication.Create(
                EnterFullName(),
                EnterPassport(),
                EnterAge(),
                EnterLoanAmount(),
                EnterPurpose(),
                EnterJob(),
                EnterDeposit(),
                EnterCriminalRecord(),
                EnterOtherCredits()
            );

            if (applicationResult.Failure)
            {
                Console.WriteLine(applicationResult.Error);
            }
            else
            {
                var answer = LoanApplicationService.GetAnswer(applicationResult.Value);
                Console.WriteLine(answer.Points >= 80
                    ? $"Approved ({answer.Points} points). Percentage rate: {answer.PercentageRate}."
                    : $"Rejected ({answer.Points} points).");
            }
        }

        private static FullNameDto EnterFullName()
        {
            Console.WriteLine("First name");
            var firstName = Console.ReadLine();
            
            Console.WriteLine("Middle name");
            var middleName = Console.ReadLine();
            
            Console.WriteLine("Last name");
            var lastName = Console.ReadLine();

            return new FullNameDto(firstName, middleName, lastName);
        }

        private static PassportDto EnterPassport()
        {
            Console.WriteLine("Number");
            var number = Console.ReadLine();
            
            Console.WriteLine("Series");
            var series = Console.ReadLine();
            
            Console.WriteLine("Issued by");
            var issuedBy = Console.ReadLine();
            
            Console.WriteLine("Residence");
            var residence = Console.ReadLine();

            return new PassportDto(number, series, issuedBy, residence);
        }

        private static AgeDto EnterAge()
        {
            Console.WriteLine("Age");
            return new AgeDto(Console.ReadLine());
        }
        
        private static LoanAmountDto EnterLoanAmount()
        {
            Console.WriteLine("LoanAmount");
            return new LoanAmountDto(Console.ReadLine());
        }
        
        private static PurposeDto EnterPurpose()
        {
            Console.WriteLine("Purpose (consumer loan: 0, realty: 1, re-crediting: 2)");
            return new PurposeDto(Console.ReadLine());
        }
        
        private static JobDto EnterJob()
        {
            Console.WriteLine("Job (none: 0, contract: 1, self-employeed: 2, freelance: 3, retiree: 4)");
            return new JobDto(Console.ReadLine());
        }
        
        private static DepositDto EnterDeposit()
        {
            Console.WriteLine("Deposit (none: 0, realty: 1, car: 2, surety: 3)");
            return new DepositDto(Console.ReadLine());
        }
        
        private static CriminalRecordDto EnterCriminalRecord()
        {
            Console.WriteLine("Criminal record (yes: y, no: n)");
            return new CriminalRecordDto(Console.ReadLine());
        }
        
        private static OtherCreditsDto EnterOtherCredits()
        {
            Console.WriteLine("Other credits (yes: y, no: n)");
            return new OtherCreditsDto(Console.ReadLine());
        }
    }
}