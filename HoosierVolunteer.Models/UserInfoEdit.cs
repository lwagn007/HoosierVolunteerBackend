using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoosierVolunteer.Models
{
    public class UserInfoEdit
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public bool IsOrganization { get; set; }

        public string OrganizationName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string State { get; set; }

        public string Address { get; set; }
    }
}
