using DBSD_00013782_00013940_00014016.DAL.Models;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Common;

namespace DBSD_00013782_00013940_00014016.DAL
{
    public class EmployeeRepository: IEmployeeRepository
    {
        /*private string ConnString => WebConfigurationManager.ConnectionStrings["SoyConString"].ConnectionString;*/

        public readonly string _connStr;

        public EmployeeRepository(string connStr)
        {
            _connStr = connStr;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        //Get All employees method
        public IList<Employee> GetAll()
        {
            var employees = new List<Employee>();
            using (var conn = new SqlConnection(_connStr))
            {
                var cmd = conn.CreateCommand();
                {
                    cmd.CommandText = @"SELECT [EmployeeID]
                                             ,[FirstName]
                                             ,[LastName]
                                             ,[BirthDate]
                                             ,[PhoneNumber]
                                             ,[Position]
                                             ,[Email]
                                            FROM [dbo].[Employee]
                                             ";

                    conn.Open();
                    var rdr = cmd.ExecuteReader();
                    {
                        while (rdr.Read())
                        {
                            var emp = new Employee()
                            {
                                EmployeeId = rdr.GetInt32("EmployeeID"),
                                FirstName = rdr.GetString("FirstName"),
                                LastName = rdr.GetString("LastName"),
                                BirthDate = rdr.IsDBNull("BirthDate") ? null : (DateTime?) rdr["BirthDate"],
                                PhoneNumber = rdr.GetString("PhoneNumber"),
                                Position = rdr.GetString("Position"),
                                Email =  rdr.GetString("Email")
                            };
                                /*if (!rdr.IsDBNull(rdr.GetOrdinal("BirthDate")))
                                    emp.BirthDate = rdr.GetDateTime(rdr.GetOrdinal("BirthDate"));

                                if (!rdr.IsDBNull(rdr.GetOrdinal("PhoneNumber")))
                                    emp.PhoneNumber = rdr.GetString(rdr.GetOrdinal("PhoneNumber"));

                                emp.Position = rdr.GetString(rdr.GetOrdinal("Position"));

                                emp.Email = rdr.GetString(rdr.GetOrdinal("Email"));*/

                                employees.Add(emp);
                            }

                        return employees;
                    }


                }
            }
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Employee emp)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                INSERT INTO [dbo].[Employee] (
                    [FirstName],
                    [LastName],
                    [BirthDate],
                    [PhoneNumber],
                    [Position],
                    [Email]
                ) VALUES (
                    @FirstName,
                    @LastName,
                    @BirthDate,
                    @PhoneNumber,
                    @Position,
                    @Email
                );";

                    // Parameters
                    cmd.Parameters.AddWithValue("@FirstName", emp.FirstName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", emp.LastName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@BirthDate", emp.BirthDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneNumber", emp.PhoneNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Position", emp.Position ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", emp.Email ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void Update(Employee emp)
        {
            throw new NotImplementedException();
        }
    }

      


        //Insert new employee method

        /*public void Insert(Employee emp)
        {
            using (var conn = new SqlConnection(ConnString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Employee]
                                        ([FirstName]
                                         ,[LastName]
                                         ,[BirthDate]
                                         ,[PhoneNumber]
                                         ,[Position]
                                         ,[Photo]
                                         ,[Email]
                                         ,[Password]
                                          )
                                   VALUES
                                               (
                                                 @FirstName
                                                ,@LastName
                                                ,@BirthDate
                                                ,@PhoneNumber
                                                ,@Position
                                                ,@Photo
                                                ,@Email
                                                ,convert(varchar(256), hashbytes('SHA2_256', @Password) ,2)
                                        )";

                    var pFirstName = cmd.CreateParameter();
                    pFirstName.ParameterName = "@FirstName";
                    pFirstName.Value = emp.FirstName;
                    pFirstName.Direction = ParameterDirection.Input;
                    pFirstName.DbType = DbType.AnsiString;
                    cmd.Parameters.Add(pFirstName);

                    cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                    cmd.Parameters.AddWithValue("@BirthDate", (object)emp.BirthDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneNumber", emp.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Position", emp.Position);

                    cmd.Parameters.AddWithValue("@Photo", (object)emp.Photo ?? SqlBinary.Null);
                    cmd.Parameters.AddWithValue("@Email", emp.Email);
                    cmd.Parameters.AddWithValue("@Password", emp.Password);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }*/

       
}

