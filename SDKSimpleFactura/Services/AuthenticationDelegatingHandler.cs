using SDKSimpleFactura.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SDKSimpleFactura.Services
{
    public class AuthenticationDelegatingHandler : DelegatingHandler
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationDelegatingHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _authenticationService.GetTokenAsync();
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
