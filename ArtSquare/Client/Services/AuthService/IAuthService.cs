using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Client.Services.AuthService
{
    interface IAuthService
    {
        Task GetUserInfo();
    }
}
