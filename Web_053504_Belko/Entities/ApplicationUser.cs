using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Web_053504_Belko.Entities
{
    public class ApplicationUser: IdentityUser
    { 
        public byte[] avatar { get; set; }
    }
}
