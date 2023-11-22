using MarienProject.Models.Dtos.JWT;
using MarienProject.Web.Services.Contracts;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net;
using System.Net.Http.Headers;

namespace MarienProject.Web.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
        private readonly IEncryptionService _encryptionService;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(HttpClient httpClient, IJSRuntime jsRuntime,
            IEncryptionService encryptionService, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
            _encryptionService = encryptionService;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<string> GetUserRole()
        {
            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authenticationState.User;

            var result = user.FindFirst(ClaimTypes.Role);
            return result.Value;
        }
        public async Task<bool> Login(string username, string password)
        {
            var request = new AuthorizationRequestDto
            {
                UserName = username,
                Key = password
            };

            var response = await _httpClient.PostAsJsonAsync("api/session/login", request);

            if (response.IsSuccessStatusCode)
            {
                var authResponse = await response.Content.ReadFromJsonAsync<AuthorizationResponseDto>();

                // Almacena el token de acceso y el token de actualización
                StoreTokens(authResponse.Token, authResponse.RefreshToken);

                return true;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // Token de acceso expirado, intenta refrescar el token
                var refreshTokenSuccess = await RefreshToken();

                if (refreshTokenSuccess)
                {
                    // Intenta nuevamente la solicitud original
                    var retryResponse = await _httpClient.PostAsJsonAsync("api/session/login", request);

                    if (retryResponse.IsSuccessStatusCode)
                    {
                        var authResponse = await retryResponse.Content.ReadFromJsonAsync<AuthorizationResponseDto>();

                        // Almacena el token de acceso y el token de actualización
                        StoreTokens(authResponse.Token, authResponse.RefreshToken);

                        return true;
                    }
                }
            }

            return false;
        }
        public async Task<bool> RefreshToken()
        {
            // Obtiene el token de actualización almacenado
            var refreshToken = GetRefreshToken();

            if (string.IsNullOrEmpty(refreshToken))
            {
                // No hay token de actualización, el usuario necesita iniciar sesión nuevamente
                return false;
            }

            var request = new RefreshTokenRequestDto
            {
                //We must validate this.
                TokenExpired = GetAccessToken(), // Token de acceso actual
                RefreshToken = refreshToken
            };

            var response = await _httpClient.PostAsJsonAsync("api/session/getRefreshToken", request);

            if (response.IsSuccessStatusCode)
            {
                var authResponse = await response.Content.ReadFromJsonAsync<AuthorizationResponseDto>();

                // Almacena el nuevo token de acceso y el nuevo token de actualización
                StoreTokens(authResponse.Token, authResponse.RefreshToken);

                return true;
            }

            return false;
        }
        public async Task AddAuthorizationHeader(HttpClient httpClient)
        {
            // Obtiene el token de acceso actual
            var accessToken = GetAccessToken();

            // Agrega el token de acceso a las cabeceras de la solicitud
            if (!string.IsNullOrEmpty(accessToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
        }


        // Métodos auxiliares para el almacenamiento de tokens
        private async Task StoreTokens(string accessToken, string refreshToken)
        {
            // Verifica que el token de acceso no esté vacío
            if (!string.IsNullOrEmpty(accessToken))
            {
                try
                {
                    // Cifra el token de acceso
                    string encryptedAccessToken = _encryptionService.Encrypt(accessToken);

                    // Almacena el token cifrado en el almacenamiento local (localStorage)
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "access_token", encryptedAccessToken);
                }
                catch (Exception ex)
                {
                    // Maneja cualquier excepción que pueda ocurrir al intentar acceder al JSRuntime.
                    // Puedes personalizar esto según tus necesidades.
                    Console.WriteLine($"Error al almacenar el token de acceso cifrado: {ex.Message}");
                }
            }

            // Verifica que el token de actualización no esté vacío
            if (!string.IsNullOrEmpty(refreshToken))
            {
                try
                {
                    // Cifra el token de actualización
                    string encryptedRefreshToken = _encryptionService.Encrypt(refreshToken);

                    // Almacena el token cifrado en el almacenamiento local (localStorage)
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "refresh_token", encryptedRefreshToken);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al almacenar el token de actualización cifrado: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Obtiene el token de acceso desde el almacenamiento local.
        /// </summary>
        /// <returns>El token de acceso almacenado o null si no está presente.</returns>
        public string GetAccessToken()
        {
            try
            {
                // Intenta obtener el token de acceso desde el almacenamiento local (sessionStorage)
                return _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "access_token").Result;
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir al intentar acceder al JSRuntime.
                // Puedes personalizar esto según tus necesidades.
                Console.WriteLine($"Error al obtener el token de acceso: {ex.Message}");
                return null;
            }
        }
        /// <summary>
        /// Obtiene el token de actualización desde el almacenamiento local.
        /// </summary>
        /// <returns>El token de actualización almacenado o null si no está presente.</returns>
        public string GetRefreshToken()
        {
            try
            {
                // Intenta obtener el token de actualización desde el almacenamiento local (sessionStorage)
                return _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "refresh_token").Result;
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir al intentar acceder al JSRuntime.
                // Puedes personalizar esto según tus necesidades.
                Console.WriteLine($"Error al obtener el token de actualización: {ex.Message}");
                return null;
            }
        }

    }
}
