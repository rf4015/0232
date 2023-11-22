using MarienProject.Models.Dtos;
using MarienProject.Web.Services.Contracts;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MarienProject.Web.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly HttpClient _httpClient;
		private readonly IAuthenticationService _authenticationService;

        public EmployeeService(HttpClient httpClient, IAuthenticationService authenticationService)
		{
			_httpClient = httpClient;
			_authenticationService = authenticationService;

        }

        public async Task<bool> CreateEmployee(EmployeeDto employeeDto)
        {
            try
            {
                // Agrega el token de acceso a las cabeceras de la solicitud
                await _authenticationService.AddAuthorizationHeader(_httpClient);

                var response = await _httpClient.PostAsJsonAsync("api/CreateEmployee", employeeDto);

                if (response.IsSuccessStatusCode)
                {
                    return true; // O cualquier lógica que determines para indicar éxito
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    // Token de acceso expirado, intenta refrescar el token
                    var refreshTokenSuccess = await _authenticationService.RefreshToken();

                    if (refreshTokenSuccess)
                    {
                        // Intenta nuevamente la solicitud original con el nuevo token de acceso
                        await _authenticationService.AddAuthorizationHeader(_httpClient);
                        var retryResponse = await _httpClient.PostAsJsonAsync("api/CreateEmployee", employeeDto);

                        if (retryResponse.IsSuccessStatusCode)
                        {
                            return true; // O cualquier lógica que determines para indicar éxito
                        }
                        else
                        {
                            // Maneja casos de error específicos de la segunda solicitud
                            return false; // O cualquier lógica que determines para indicar error
                        }
                    }
                }

                // Maneja otros casos de error
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Http status code: {response.StatusCode} Message: {message}");

                return false; // O cualquier lógica que determines para indicar error
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; // O cualquier lógica que determines para indicar error
            }
        }
        public async Task<List<EmployeeDto>> GetAllEmployee()
        {
            try
            {
                // Agrega el token de acceso a las cabeceras de la solicitud
                await _authenticationService.AddAuthorizationHeader(_httpClient);

                // Realiza la solicitud para obtener todos los empleados
                var response = await _httpClient.GetAsync($"api/GetAllEmployee");

                if (response.IsSuccessStatusCode)
                {
                    // Si la solicitud es exitosa y hay datos disponibles
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<EmployeeDto>().ToList();
                    }

                    // Lee y devuelve la lista de empleados desde la respuesta
                    return await response.Content.ReadFromJsonAsync<List<EmployeeDto>>();
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    // Token de acceso expirado, intenta refrescar el token
                    var refreshTokenSuccess = await _authenticationService.RefreshToken();

                    if (refreshTokenSuccess)
                    {
                        // Intenta nuevamente la solicitud original con el nuevo token de acceso
                        await _authenticationService.AddAuthorizationHeader(_httpClient);
                        var retryResponse = await _httpClient.GetAsync($"api/GetAllEmployee");

                        if (retryResponse.IsSuccessStatusCode)
                        {
                            return await retryResponse.Content.ReadFromJsonAsync<List<EmployeeDto>>();
                        }
                        else
                        {
                            // Maneja casos de error específicos de la segunda solicitud
                            return new List<EmployeeDto>(); // o cualquier valor que desees devolver en caso de error
                        }
                    }
                }

                // Maneja otros casos de error
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Http status code: {response.StatusCode} Message: {message}");

                // Devuelve un valor que indica un error
                return new List<EmployeeDto>(); // o cualquier valor que desees devolver en caso de error
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                // Devuelve un valor que indica un error
                return new List<EmployeeDto>(); // o cualquier valor que desees devolver en caso de error
            }
        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            try
            {
                // Agrega el token de acceso a las cabeceras de la solicitud
                await _authenticationService.AddAuthorizationHeader(_httpClient);

                var response = await _httpClient.GetAsync($"api/GetProductById/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(EmployeeDto);
                    }

                    return await response.Content.ReadFromJsonAsync<EmployeeDto>();
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    // Token de acceso expirado, intenta refrescar el token
                    var refreshTokenSuccess = await _authenticationService.RefreshToken();

                    if (refreshTokenSuccess)
                    {
                        // Intenta nuevamente la solicitud original con el nuevo token de acceso
                        await _authenticationService.AddAuthorizationHeader(_httpClient);
                        var retryResponse = await _httpClient.GetAsync($"api/GetProductById/{id}");

                        if (retryResponse.IsSuccessStatusCode)
                        {
                            return await retryResponse.Content.ReadFromJsonAsync<EmployeeDto>();
                        }
                        else
                        {
                            // Maneja casos de error específicos de la segunda solicitud
                            return default(EmployeeDto); // o cualquier valor que desees devolver en caso de error
                        }
                    }
                }

                // Maneja otros casos de error
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Http status code: {response.StatusCode} Message: {message}");

                // Devuelve un valor que indica un error
                return default(EmployeeDto); // o cualquier valor que desees devolver en caso de error
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                // Devuelve un valor que indica un error
                return default(EmployeeDto); // o cualquier valor que desees devolver en caso de error
            }
        }
        public async Task<bool> UpdateEmployee(EmployeeDto employeeDto)
        {
            try
            {
                // Agrega el token de acceso a las cabeceras de la solicitud
                await _authenticationService.AddAuthorizationHeader(_httpClient);

                var response = await _httpClient.PutAsJsonAsync("api/UpdateEmployee", employeeDto);

                if (response.IsSuccessStatusCode)
                {
                    return true; // O cualquier lógica que determines para indicar éxito
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    // Token de acceso expirado, intenta refrescar el token
                    var refreshTokenSuccess = await _authenticationService.RefreshToken();

                    if (refreshTokenSuccess)
                    {
                        // Intenta nuevamente la solicitud original con el nuevo token de acceso
                        await _authenticationService.AddAuthorizationHeader(_httpClient);
                        var retryResponse = await _httpClient.PutAsJsonAsync("api/UpdateEmployee", employeeDto);

                        if (retryResponse.IsSuccessStatusCode)
                        {
                            return true; // O cualquier lógica que determines para indicar éxito
                        }
                        else
                        {
                            // Maneja casos de error específicos de la segunda solicitud
                            return false; // O cualquier lógica que determines para indicar error
                        }
                    }
                }

                // Maneja otros casos de error
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Http status code: {response.StatusCode} Message: {message}");

                return false; // O cualquier lógica que determines para indicar error
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; // O cualquier lógica que determines para indicar error
            }
        }
        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                // Agrega el token de acceso a las cabeceras de la solicitud
                await _authenticationService.AddAuthorizationHeader(_httpClient);

                var response = await _httpClient.DeleteAsync($"api/DeleteEmployee/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return true; // O cualquier lógica que determines para indicar éxito
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    // Token de acceso expirado, intenta refrescar el token
                    var refreshTokenSuccess = await _authenticationService.RefreshToken();

                    if (refreshTokenSuccess)
                    {
                        // Intenta nuevamente la solicitud original con el nuevo token de acceso
                        await _authenticationService.AddAuthorizationHeader(_httpClient);
                        var retryResponse = await _httpClient.DeleteAsync($"api/DeleteEmployee/{id}");

                        if (retryResponse.IsSuccessStatusCode)
                        {
                            return true; // O cualquier lógica que determines para indicar éxito
                        }
                        else
                        {
                            // Maneja casos de error específicos de la segunda solicitud
                            return false; // O cualquier lógica que determines para indicar error
                        }
                    }
                }

                // Maneja otros casos de error
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Http status code: {response.StatusCode} Message: {message}");

                return false; // O cualquier lógica que determines para indicar error
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; // O cualquier lógica que determines para indicar error
            }
        }
    }
}
