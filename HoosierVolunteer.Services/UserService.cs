using HoosierVolunteer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoosierVolunteer.Services
{
    public class UserService
    {
        private readonly Guid _creatorId;

        public UserService(Guid creatorId)
        {
            _creatorId = creatorId;
        }

        public UserInfoEdit GetUserById(Guid userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .AspNetUsers
                    .Single(e => Guid.Parse(e.Id) == _creatorId);
                return
                    new UserInfoEdit
                    {
                        Id = Guid.Parse(entity.Id),
                        Email = entity.Email,
                        IsOrganization = entity.IsOrganization,
                        OrganizationName = entity.OrganizationName,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Phone = entity.Phone,
                        State = entity.State,
                        Address = entity.Address,
                    };
            }
        }
    }
}
