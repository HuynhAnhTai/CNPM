using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
    public class StudentDAO
    {
        private StudentHelper studentHelper;

        public StudentDAO()
        {
            studentHelper = new StudentHelper();
        }

        public List<Student> GetAll()
        {
            return null;
        }

        public Student GetById(int id)
        {
            return null;
        }

        public bool DeleteById(int id)
        {
            String sql = "delete from student where maso = @id";

            SqlParameter param1 = new SqlParameter("@id", id);
            SqlParameter[] parameters = { param1 }; // you may add more params

            int rows = studentHelper.ExcuteNonQuery(sql, parameters);

            return rows == 1;
        }

        public bool AddStudent(Student student)
        {
            String sql = "insert into student values(@name,@birth,@gender,@email)";

            SqlParameter param1 = new SqlParameter("@name",student.Name);
            SqlParameter param2 = new SqlParameter("@birth", student.Birth);
            SqlParameter param3 = new SqlParameter("@gender", student.isMale);
            SqlParameter param4 = new SqlParameter("@email", student.Mail);
            SqlParameter[] parameters = { param1, param2, param3, param4 }; // you may add more params

            int rows =  studentHelper.ExcuteNonQuery(sql,parameters);
            return rows == 1;
        }

        public bool UpdateStudent(Student student)
        {
            String sql = "UPDATE student SET hoTen = @name, ngaySinh = @birth, gioiTinh = @gender, email = @email WHERE maso = @id";

            SqlParameter param1 = new SqlParameter("@name", student.Name);
            SqlParameter param2 = new SqlParameter("@birth", student.Birth);
            SqlParameter param3 = new SqlParameter("@gender", student.isMale);
            SqlParameter param4 = new SqlParameter("@email", student.Mail);
            SqlParameter param5 = new SqlParameter("@id", student.ID);

            SqlParameter[] parameters = { param1, param2, param3, param4, param5 };
            int rows = studentHelper.ExcuteNonQuery(sql, parameters);
            return rows == 1;
        }
    }
}
