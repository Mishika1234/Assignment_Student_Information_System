using Student_Information_System.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.repository
{
    public interface IPaymentRepository
    {
        Student GetStudent(int paymentId);
        decimal GetPaymentAmount(int paymentId);
        DateTime GetPaymentDate(int paymentId);
       
    }
}
