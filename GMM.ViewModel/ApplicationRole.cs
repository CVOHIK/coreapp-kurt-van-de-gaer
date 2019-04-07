using Microsoft.AspNetCore.Identity;
using System;

namespace GMM.ViewModel
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() {}

        public ApplicationRole(string pRoleName) : base(pRoleName)
        {

        }

        public ApplicationRole(string pRoleName, string pDescription , DateTime pCreationDate) : base(pRoleName)
        {
            Description = pDescription;
            CreationDate = pCreationDate;
        }

        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
