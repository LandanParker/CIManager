using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;

namespace DataMixer.Managers
{
    public interface IAuthContainerModel
    {
        string SecretKey { get; set; }
        string SecurityAlgorithm { get; set; }
        int ExpireMinutes { get; set; }
        
        IEnumerable<Claim> Claims { get; set; }
    }
}