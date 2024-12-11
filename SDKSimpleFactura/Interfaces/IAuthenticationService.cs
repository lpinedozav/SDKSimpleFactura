using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GetTokenAsync();
    }
}