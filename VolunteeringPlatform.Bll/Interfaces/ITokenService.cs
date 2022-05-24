using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteeringPlatform.Bll.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateAccessToken(string username);
    }
}
