using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Web_053504_Belko.Entities;
using Microsoft.AspNetCore.Hosting;

namespace Web_053504_Belko.Controllers
{
    public class AvatarController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        IWebHostEnvironment _env;

        public AvatarController(UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }

        public async Task<FileResult> GetAvatar()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.avatar != null)
                return File(user.avatar, "Image/...");
            else
            {
                var avatarPath = "/Images/Avatar.png";

                return File(_env.WebRootFileProvider
                .GetFileInfo(avatarPath)
               .CreateReadStream(), "Image/...");
            }
        }
    }
}
