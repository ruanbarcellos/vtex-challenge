using DeveloperShop.Domain.Entity;
using DeveloperShop.Domain.Provider;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperShop.Infrastructure.Provider
{
    public class GitHubProvider : IGitHubProvider
    {
        //private const String ORGANIZATION = "Angular";
        //private const String ORGANIZATION = "twbs";
        //private const String ORGANIZATION = "eellak";
        private const String ORGANIZATION = "yeoman";
        //private const String ORGANIZATION = "grunt";
        //private const String ORGANIZATION = "mpc-hc";
        private const String APPLICATION = "DeveloperShop";
        private const String ACCESS_TOKEN = "031af671e9bd0a0c42b9a2545c9a505243e6ff01";

        public async Task<IEnumerable<Developer>> GetDevelopers()
        {
            var users = await GetUsersFromOrganization();

            return users.Select(user => GetDeveloperFromUser(user));
        }

        public async Task<Developer> GetDeveloper(String developerLogin)
        {
            return GetDeveloperFromUser(await GetUser(developerLogin));
        }

        private async Task<IEnumerable<User>> GetUsersFromOrganization()
        {
            var github = new GitHubClient(new ProductHeaderValue(APPLICATION));
            github.Credentials = new Credentials(ACCESS_TOKEN);

            var organizationMembers = await github.Organization.Member.GetAllPublic(ORGANIZATION);

            IList<User> users = new List<User>();
            foreach (var member in organizationMembers)
            {
                var user = await github.User.Get(member.Login);
                if (user != null)
                {
                    users.Add(user);
                }
            }

            return users;
        }

        private async Task<User> GetUser(String userLogin)
        {
            var github = new GitHubClient(new ProductHeaderValue(APPLICATION));
            github.Credentials = new Credentials(ACCESS_TOKEN);

            return await github.User.Get(userLogin);
        }

        private Developer GetDeveloperFromUser(User user)
        {
            return new Developer
            {
                AvatarUrl = user.AvatarUrl,
                Collaborators = user.Collaborators,
                Followers = user.Followers,
                Id = user.Id,
                Name = String.IsNullOrWhiteSpace(user.Name) ? user.Login : user.Name,
                PublicRepos = user.PublicRepos,
                TotalPrivateRepos = user.TotalPrivateRepos
            };
        }
    }
}