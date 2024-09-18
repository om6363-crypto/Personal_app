using System.Collections.Generic;
using Personal_Project.Models;

namespace Personal_Project.DAO
{
    public interface IPersonalDao
    {
        Task<List<PersonalData>> GetAllPersonal_Project(string baseUri);
        Task<int> InsertPersonalDetails(InsertData Personal_Project, string imageName);
        Task<bool> DeleteUserById(int id);
        Task<int> UpdateUserDetails(int id, string newPhoneNumber, string newPermanentAddress);
    }
}
