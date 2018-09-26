using HoosierVolunteer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

namespace HoosierVolunteer.Services
{
    public class UserService
    {
        private readonly Guid _creatorId;

        public UserService(Guid creatorId)
        {
            _creatorId = creatorId;
        }

        public bool SetRole(string newRole)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.AddToRole(_creatorId.ToString(), "SuperAdmin");
            return true;
        }

        public UserInfoEdit GetUserById(Guid userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .Single(e => e.Id == _creatorId.ToString());
                return
                    new UserInfoEdit
                    {
                        Id = Guid.Parse(entity.Id),
                        Email = entity.Email,
                        IsOrganization = entity.IsOrganization,
                        OrganizationName = entity.OrganizationName,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        PhoneNumber = entity.PhoneNumber,
                        State = entity.State,
                        Address = entity.Address,
                        Zip = entity.Zip,
                        City = entity.City
                    };
            }
        }

        public bool UpdateUser(UserInfoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .Single(e => e.Id == _creatorId.ToString());

                entity.Email = model.Email;
                entity.OrganizationName = model.OrganizationName;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.PhoneNumber = model.PhoneNumber;
                entity.State = model.State;
                entity.Address = model.Address;
                entity.Zip = model.Zip;
                entity.City = model.City;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
