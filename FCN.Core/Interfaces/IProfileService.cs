using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FCN.Core.Interfaces
{
    public interface IProfileService
    {
        public bool IsLoggedIn { get; set; }
        public string GetKey(); // Returns API Key
        Task<bool> LogInWithKeyAsync(string key); // Return if success
        IAuthor GetUserMe(); // Get current user
    }
}
