using Student_Information_System.model;
using Student_Information_System.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.service
{
    public class PaymentRepositoryService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentRepositoryService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public void GetStudent()
        {
            Console.Write("Enter Payment ID: ");
            int paymentId;
            if (!int.TryParse(Console.ReadLine(), out paymentId))
            {
                Console.WriteLine("Invalid Payment ID. Please enter a valid number.");
                return;
            }

            var student = _paymentRepository.GetStudent(paymentId);
            if (student != null)
            {
                Console.WriteLine($"Student ID: {student.StudentID}");
                Console.WriteLine($"First Name: {student.FirstName}");
                Console.WriteLine($"Last Name: {student.LastName}");
                Console.WriteLine($"Date of Birth: {student.DateOfBirth.ToShortDateString()}");
                Console.WriteLine($"Email: {student.Email}");
                Console.WriteLine($"Phone Number: {student.PhoneNumber}");
            }
            else
            {
                Console.WriteLine($"No student found for Payment ID {paymentId}");
            }
        }

        public void GetPaymentAmount()
        {
            Console.Write("Enter Payment ID: ");
            int paymentId;
            if (!int.TryParse(Console.ReadLine(), out paymentId))
            {
                Console.WriteLine("Invalid Payment ID. Please enter a valid number.");
                return;
            }

            var amount = _paymentRepository.GetPaymentAmount(paymentId);
            Console.WriteLine($"Payment Amount: {amount}");
        }

        public void GetPaymentDate()
        {
            Console.Write("Enter Payment ID: ");
            int paymentId;
            if (!int.TryParse(Console.ReadLine(), out paymentId))
            {
                Console.WriteLine("Invalid Payment ID. Please enter a valid number.");
                return;
            }

            var date = _paymentRepository.GetPaymentDate(paymentId);
            Console.WriteLine($"Payment Date: {date.ToShortDateString()}");
        }
    }
}