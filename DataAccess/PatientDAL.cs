using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BizObject;


namespace DataAccess
{
    public class PatientDAL
    {
        // Decalring the connection string
        static string conn_string = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        //Creating sql connection
        static SqlConnection sql_con = new SqlConnection(conn_string);

        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns>Dataset of Patients</returns>
        public static DataSet GetPatients()
        {
            // creating a data adapater
            SqlDataAdapter data_adapter = new SqlDataAdapter("getpatients", sql_con);

            //stored procedure is the way to get data
            data_adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            //creating a data set
            DataSet dataset = new DataSet();

            // populate the dataSet with the results of the SelectCommand of the DataAdapter
            data_adapter.Fill(dataset, "patients");
            
            return dataset;
        }

        /// <summary>
        /// Get a particular patient
        /// </summary>
        /// <returns>Returns a patient</returns>
        public Patient GetPatient(int patientID)
        {
            try
            {
                // Open the sql connection
                sql_con.Open();

                // Creating the Sql Command
                SqlCommand cmd = new SqlCommand("getpatient", sql_con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientID", patientID);

                //Sql data reader
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // New patient object
                    Patient patient = new Patient();

                    // Initialize values
                    patient.Username = dr["uname"].ToString();
                    patient.Password = dr["password"].ToString();
                    patient.Email = dr["email"].ToString();
                    patient.Gender = dr["gender"].ToString();

                    return patient;
                }
            }
            catch(SqlException e)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                // Closing the connection
                sql_con.Close();
            }
            return null;
        }
        
        /// <summary>
        /// Add a new patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public string Add_patient(Patient patient)
        {
            try
            {
                // Open the sql connection
                sql_con.Open();

                // Creating the Sql Command
                SqlCommand cmd = new SqlCommand("addpatient",sql_con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Passing parameters
                cmd.Parameters.AddWithValue("@uname", patient.Username);
                cmd.Parameters.AddWithValue("@password", patient.Password);
                cmd.Parameters.AddWithValue("@email", patient.Email);
                cmd.Parameters.AddWithValue("@gender", patient.Gender);

                //Execute query
                cmd.ExecuteNonQuery();

                // Returns null because success
                return null;
            }
            catch (SqlException e)
            {
                return null;
            }
            catch (Exception ex)
            {
                // returns an error message
                return ex.Message;
            }
            finally
            {
                sql_con.Close();
            }
        }
        

        /// <summary>
        /// Delete a patiend
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns>message if an error occured</returns>
        public static string DeletePatient(int patientId)
        {
            try
            {
                // Open the sql connection
                sql_con.Open();

                // Creating the Sql Command
                SqlCommand cmd = new SqlCommand("deletepatient", sql_con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Passing parameters
                cmd.Parameters.AddWithValue("@patientId", patientId);

                //Execute query
                cmd.ExecuteNonQuery();

                // Returns null because success
                return null;
            }
            catch (SqlException e)
            {
                return null;
            }
            catch (Exception ex)
            {
                // returns an error message
                return ex.Message;
            }
            finally
            {
                sql_con.Close();
            }
        }

        public string UpdatePatient(Patient patient)
        {
            try
            {
                // Open the sql connection
                sql_con.Open();

                // Creating the Sql Command
                SqlCommand cmd = new SqlCommand("updatepatient", sql_con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Passing parameters
                cmd.Parameters.AddWithValue("@uname", patient.Username);
                cmd.Parameters.AddWithValue("@password", patient.Password);
                cmd.Parameters.AddWithValue("@email", patient.Email);
                cmd.Parameters.AddWithValue("@gender", patient.Gender);

                //Execute query
                cmd.ExecuteNonQuery();

                // Returns null because success
                return null;
            }
            catch (SqlException e)
            {
                return null;
            }
            catch (Exception ex)
            {
                // returns an error message
                return ex.Message;
            }
            finally
            {
                sql_con.Close();
            }
        }
    }
}
