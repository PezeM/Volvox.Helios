using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Volvox.Helios.Web.ViewModels.Settings
{
    public class LookingForGroupAddSessionViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortId { get; set; }
        public bool HasMaximumCapacity { get; set; }
        public int MaximumMembers { get; set; }
        public bool RestrictRoles { get; set; }
        public List<LookingForGroupRoleViewModel> RestrictedRoles { get; set; }
        
    }
}
