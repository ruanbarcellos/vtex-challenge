using System;

namespace DeveloperShop.Domain.Entity
{
    public class Developer
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Double Price { get; set; }

        public String AvatarUrl { get; set; }
        public Int32 Collaborators { get; set; }
        public Int32 Followers { get; set; }
        public Int32 PublicRepos { get; set; }
        public Int32 TotalPrivateRepos { get; set; }
    }
}