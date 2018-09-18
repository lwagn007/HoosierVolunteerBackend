using Microsoft.AspNet.Identity.EntityFramework;
using HoosierVolunteer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoosierVolunteer.Models;

namespace HoosierVolunteer.Contracts
{
    public interface IAdminService
    {
        bool IsAdminUser();
        IEnumerable<ApplicationUser> GetUserList();
        IEnumerable<IdentityRole> GetRolesList();
    }
}
