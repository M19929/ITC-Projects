using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineCourseSystem.Solid
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }

    public enum PaymentStatus { Pending, Paid, Failed }

    public class Payment
    {
        public int Id { get; }
        public Student Student { get; }
        public Course Course { get; }
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string MethodName { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        public Payment(int id, Student student, Course course)
        {
            Id = id;
            Student = student;
            Course = course;
            Amount = course.Price;
            Date = DateTime.Now;
        }
    }

    public interface IPaymentMethod
    {
        string Name { get; }
        bool Pay(decimal amount);
    }

    public class CardPayment : IPaymentMethod
    {
        public string Name => "Card";

        public bool Pay(decimal amount)
        {
            Console.WriteLine($"Paying {amount} by Credit Card...");
            return true;
        }
    }

    public class CashPayment : IPaymentMethod
    {
        public string Name => "Cash";

        public bool Pay(decimal amount)
        {
            Console.WriteLine($"Paying {amount} in Cash...");
            return true;
        }
    }

    public class PayPalPayment : IPaymentMethod
    {
        public string Name => "PayPal";

        public bool Pay(decimal amount)
        {
            Console.WriteLine($"Paying {amount} via PayPal...");
            return true;
        }
    }

    public interface IPaymentPrinter
    {
        void Print(Payment payment);
    }

    public class ConsolePaymentPrinter : IPaymentPrinter
    {
        public void Print(Payment p)
        {
            Console.WriteLine($"Payment #{p.Id} | {p.Student.Name} -> {p.Course.Title} | " +
                              $"{p.Amount} EGP | {p.MethodName} | {p.Status} | {p.Date:g}");
        }
    }

    public interface IPaymentRepository
    {
        void Add(Payment payment);
        IEnumerable<Payment> GetAll();
    }

    public class InMemoryPaymentRepository : IPaymentRepository
    {
        private readonly List<Payment> _payments = new();

        public void Add(Payment payment) => _payments.Add(payment);

        public IEnumerable<Payment> GetAll() => _payments;
    }

    public class PaymentService
    {
        private readonly IPaymentRepository _repository;
        private readonly IPaymentPrinter _printer;
        private int _nextId = 1;

        public PaymentService(IPaymentRepository repository, IPaymentPrinter printer)
        {
            _repository = repository;
            _printer = printer;
        }

        public Payment MakePayment(Student student, Course course, IPaymentMethod method)
        {
            var payment = new Payment(_nextId++, student, course)
            {
                MethodName = method.Name
            };

            payment.Status = method.Pay(payment.Amount)
                ? PaymentStatus.Paid
                : PaymentStatus.Failed;

            _repository.Add(payment);
            _printer.Print(payment);
            return payment;
        }

        public decimal TotalPaid() =>
            _repository.GetAll()
                       .Where(p => p.Status == PaymentStatus.Paid)
                       .Sum(p => p.Amount);
    }

    public class Program
    {
        public static void Main()
        {
            var student = new Student { Id = 1, Name = "Yehia" };
            var course = new Course { Id = 10, Title = "C# Fundamentals", Price = 500 };

            var service = new PaymentService(
                new InMemoryPaymentRepository(),
                new ConsolePaymentPrinter());

            service.MakePayment(student, course, new CardPayment());
            service.MakePayment(student, course, new CashPayment());
            service.MakePayment(student, course, new PayPalPayment());

            Console.WriteLine($"\nTotal paid: {service.TotalPaid()} EGP");
        }
    }
}
