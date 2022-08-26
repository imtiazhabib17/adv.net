using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IAuth2
    {
        Token Authenticate(Account ac);
        bool IsAuthenticated(string token);
        bool Logout(string token);
    }
}
