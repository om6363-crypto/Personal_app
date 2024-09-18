using Npgsql;
using System.Data.Common;
using System.Data;
using Personal_Project.Models;
using Personal_Project.DAO;
using Personal_Project.Helper;

namespace Personal_Project.DAO
{
    public class PersonalImpl : IPersonalDao
    {
        NpgsqlConnection _connection;
         private readonly DeleteHandler _deleteHandler;

        public PersonalImpl(NpgsqlConnection connection)
        {
            _connection = connection;
            _deleteHandler = new DeleteHandler();
        }
        public async Task<List<PersonalData>> GetAllPersonal_Project(string baseUri)
        {
            string query = "select * from Personal_info;";
            List<PersonalData> Personal_ProjectList = new List<PersonalData>();
            PersonalData Personal_Project = null;
            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Personal_Project = new PersonalData();
                            Personal_Project.Id = Convert.ToInt32(reader["id"]);
                            Personal_Project.Name = reader["name"].ToString();
                            Personal_Project.DateOfBirth = reader["dob"].ToString();
                            Personal_Project.ResidentialAddress = reader["residential_address"].ToString();
                            Personal_Project.PermanentAddress = reader["permanent_address"].ToString();
                            Personal_Project.MobileNumber = reader["phone_number"].ToString();
                            Personal_Project.Email = reader["email"].ToString();
                            Personal_Project.MaritalStatus = reader["marital_status"].ToString();
                            Personal_Project.Gender = reader["gender"].ToString();
                            Personal_Project.Occupation = reader["occupation"].ToString();
                            Personal_Project.AadharCard = reader["aadhar_card"].ToString();
                            Personal_Project.PanCard = reader["pan_card"].ToString();
                            Personal_Project.ImageUrl = baseUri + reader["image"].ToString();
                            Personal_ProjectList.Add(Personal_Project);
                        }
                    }
                    reader.Close();
                    return Personal_ProjectList;
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine("-------------Exception Get All Personal Information---------------" + e.Message);
            }
            return Personal_ProjectList;
        }

        public async Task<int> InsertPersonalDetails(InsertData Personal_Project, string imageName)
        {
            int rowInserted = 0;
            string message;
            string insertQuery = $"INSERT INTO Personal_info (name, dob, residential_address, permanent_address, phone_number, email, marital_status, gender, occupation, aadhar_card, pan_card, image) VALUES ( '{Personal_Project.Name}', '{Personal_Project.DateOfBirth}', '{Personal_Project.ResidentialAddress}', '{Personal_Project.PermanentAddress}', '{Personal_Project.MobileNumber}', '{Personal_Project.EmailAddress}', '{Personal_Project.MaritalStatus}', '{Personal_Project.Gender}', '{Personal_Project.Occupation}', '{Personal_Project.AadharCard}', '{Personal_Project.PanCard}', 'static/images/{imageName}');";
            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery, _connection);
                    insertCommand.CommandType = CommandType.Text;
                    rowInserted = await insertCommand.ExecuteNonQueryAsync();
                }
            }
            catch (NpgsqlException e)
            {
                message = e.Message;
                Console.WriteLine("---------Exception Insert Player--------------\n" + message);
            }
            return rowInserted;
        }

        public async Task<bool> DeleteUserById(int id)
        {
            string selectQuery = "SELECT image FROM Personal_info WHERE id = @Id;";
            string deleteQuery = "DELETE FROM Personal_info WHERE id = @Id;";
            string imageName = null;

            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();

                    using (NpgsqlCommand selectCommand = new NpgsqlCommand(selectQuery, _connection))
                    {
                        selectCommand.Parameters.AddWithValue("Id", id);
                        using (var reader = await selectCommand.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                imageName = reader["image"].ToString();
                            }
                        }
                    }
                    using (NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteQuery, _connection))
                    {
                        deleteCommand.Parameters.AddWithValue("Id", id);
                        int result = await deleteCommand.ExecuteNonQueryAsync();

                        if (result > 0 && imageName != null)
                        {
                            bool imageDeleted = _deleteHandler.DeleteImage(imageName);
                            if (imageDeleted)
                            {
                                Console.WriteLine("Image deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Image deletion failed or file not found.");
                            }
                            return true;
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine("Exception while deleting record: " + ex.Message);
            }

            return false;  // Deletion failed
        }
        public async Task<int> UpdateUserDetails(int id, string newPhoneNumber, string newPermanentAddress)
        {
            int rowsAffected = 0;
            string updateQuery = "UPDATE Personal_info SET phone_number = @phone_number, permanent_address = @permanent_address WHERE id = @id";
            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, _connection);
                    updateCommand.Parameters.AddWithValue("@phone_number", newPhoneNumber);
                    updateCommand.Parameters.AddWithValue("@permanent_address", newPermanentAddress);
                    updateCommand.Parameters.AddWithValue("@id", id);
                    rowsAffected = await updateCommand.ExecuteNonQueryAsync();
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine("---------Exception in UpdateUserDetails--------------\n" + e.Message);
            }
            return rowsAffected;
        }
    }
}