using Microsoft.Data.SqlClient;
using Student_Information_System.model;
using Student_Information_System.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.repository;

namespace Student_Information_System.repository
{

    public class PaymentRepository : IPaymentRepository
    {
        private readonly SqlConnection _sqlConnection;
        private readonly SqlCommand _cmd;

        public PaymentRepository()
        {
            _sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            _cmd = new SqlCommand();
            _cmd.Connection = _sqlConnection;
        }

        public Student GetStudent(int paymentId)
        {
            Student student = null;
            try
            {
                _sqlConnection.Open();
                _cmd.CommandText = "SELECT student_id FROM Payments WHERE payment_id = @PaymentId";
                _cmd.Parameters.Clear();
                _cmd.Parameters.AddWithValue("@PaymentId", paymentId);

                object result = _cmd.ExecuteScalar();
                if (result != null)
                {
                    int studentId = Convert.ToInt32(result);
                    student = new StudentRepository().DisplayStudentInfo(studentId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }
            return student;
        }

        public decimal GetPaymentAmount(int paymentId)
        {
            decimal amount = 0;
            try
            {
                _sqlConnection.Open();
                _cmd.CommandText = "SELECT amount FROM Payments WHERE payment_id = @PaymentId";
                _cmd.Parameters.Clear();
                _cmd.Parameters.AddWithValue("@PaymentId", paymentId);

                object result = _cmd.ExecuteScalar();
                if (result != null)
                {
                    amount = Convert.ToDecimal(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }
            return amount;
        }

        public DateTime GetPaymentDate(int paymentId)
        {
            DateTime paymentDate = DateTime.MinValue;
            try
            {
                _sqlConnection.Open();
                _cmd.CommandText = "SELECT payment_date FROM Payments WHERE payment_id = @PaymentId";
                _cmd.Parameters.Clear();
                _cmd.Parameters.AddWithValue("@PaymentId", paymentId);

                object result = _cmd.ExecuteScalar();
                if (result != null)
                {
                    paymentDate = Convert.ToDateTime(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }
            return paymentDate;
        }
    }
}
