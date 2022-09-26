using Microsoft.AspNetCore.Identity;

namespace MetaData.Models
{
    public class UserD:IdentityUser
    {
        public UserD()
        {
            Infos = new List<MainInfo>();
        }
        public int _Id { get; set; }
        public List<MainInfo> Infos { get; set; }

    }
}
