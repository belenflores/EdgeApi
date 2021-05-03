using EdgeApi.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeApi_API
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(Credentials credentials);
    }
}
