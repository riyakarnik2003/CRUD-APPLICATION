using System.Data;
using Microsoft.Data.SqlClient;
namespace CRUDAppUsingAdo.Models
{
    public class StudentDBContext
    {
        string cs = "Data Source=DESKTOP-NQI503K\\SQLEXPRESS;Initial Catalog=CrudDB;Integrated Security=True;Trust Server Certificate=True";
        public List<Student> GetStudents()
        {
            List<Student> StudentsList = new List<Student>();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetTechStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {

                Student student = new Student();

                student.id = Convert.ToInt32(reader.GetValue(0).ToString());
                student.name = reader.GetValue(1)?.ToString() ?? string.Empty;
                student.domain = reader.GetValue(2)?.ToString() ?? string.Empty;

                StudentsList.Add(student);
            }

            con.Close();
            return StudentsList;
        }

        public bool AddStudent(Student student)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spAddTechStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@id", student.id);
            cmd.Parameters.AddWithValue("@name", student.name);
            cmd.Parameters.AddWithValue("@domain", student.domain);

            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i > 0)
            {

                return true;
            }

            else
            {
                return false;
            }


        }


        public bool UpdateStudent(Student student)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spUpdateTechStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@id", student.id);
            cmd.Parameters.AddWithValue("@name", student.name);
            cmd.Parameters.AddWithValue("@domain", student.domain);

            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i > 0)
            {

                return true;
            }

            else
            {
                return false;
            }

        }

        public bool DeleteStudent(int id)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spDeleteTechStudentsNew", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();



            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i > 0)
            {

                return true;
            }

            else
            {
                return false;
            }

        }


    }


    }
