using MarienProject.Api.Models;
using MarienProject.Api.Repositories.Contracts;
using MarienProject.Models.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MarienProject.Api.Repositories;

public class UserRepository: IUserRepository
{
    private readonly MarienPharmacyContext _dbFarmaciaContext;
    public UserRepository(MarienPharmacyContext dbFarmaciaContext)
    {
        _dbFarmaciaContext = dbFarmaciaContext;
    }

    public async Task<bool> RegisterUser(UserRegisterRequestDto request)
    {
        using (var transaction = _dbFarmaciaContext.Database.BeginTransaction())
        {
            try
            {
                // Verifica si el nombre de usuario ya está en uso
                if (_dbFarmaciaContext.UserProfiles.Any(u => u.UserName == request.UserName))
                {
                    return false; // El nombre de usuario ya está en uso
                }

                // Registra al usuario
                var firstNames = new SqlParameter("@FirstNames", request.FirstNames);
                var lastNames = new SqlParameter("@LastNames", request.LastNames);
                var emailAddress = new SqlParameter("@EmailAddress", request.EmailAddress);
                var dni = new SqlParameter("@Dni", request.Dni);
                var phone = new SqlParameter("@Phone", request.Phone);
                var roleId = new SqlParameter("@RoleId", request.RoleId);
                var state = new SqlParameter("@State", request.State);
                var userName = new SqlParameter("@UserName", request.UserName);
                var userPassword = new SqlParameter("@UserPassword", request.Password);
                var imageProfile = new SqlParameter("@ImageProfile", request.ProfileImage);

                await _dbFarmaciaContext.Database.ExecuteSqlRawAsync(
                "EXEC CreateGeneralUser @FirstNames, @LastNames, @EmailAddress, @Dni, @Phone, @RoleId, @State, @UserName, @UserPassword, @ImageProfile",
                firstNames, lastNames, emailAddress, dni, phone, roleId, state, userName, userPassword, imageProfile);

                await _dbFarmaciaContext.SaveChangesAsync();

                transaction.Commit(); // Confirmar la transacción si todo ha ido bien
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occurred while register the user: " + ex.Message);
                transaction.Rollback(); // Deshacer la transacción si hay un error
                return false;
            }
        };
    }
}
