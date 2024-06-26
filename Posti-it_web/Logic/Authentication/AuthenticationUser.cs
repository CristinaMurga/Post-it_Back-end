﻿using System.Security.Principal;

namespace Posti_it_web.Logic.Authentication
{
    public class AuthenticationUser : IIdentity
    {
        public AuthenticationUser(string? name, string? authenticationType, bool isAuthenticated)
        {
            Name = name;
            AuthenticationType = authenticationType;
            IsAuthenticated = isAuthenticated;
        }
        public string? AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }

        public string? Name { get; set; }
    }
}
