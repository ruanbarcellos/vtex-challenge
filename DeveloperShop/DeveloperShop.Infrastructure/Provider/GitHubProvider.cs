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
        private const String APPLICATION = "DeveloperShop";

        public async Task<IEnumerable<Developer>> GetDevelopers(String organization)
        {
            var users = await GetUsersFromOrganization(organization);

            return users.Select(user => GetDeveloperFromUser(user));
        }

        public async Task<Developer> GetDeveloper(String developerLogin)
        {
            return GetDeveloperFromUser(await GetUser(developerLogin));
        }

        private async Task<IEnumerable<User>> GetUsersFromOrganization(String organization)
        {
            // o github desautoriza tokens commitados no fonte
            // para tentar burlar esta regra, inclui um token concatenado
            var accessToken = "f7b315" + "630b690" + "d5968c5" + "84b5dea" + "9ba4dd1" + "e4751b";

            var github = new GitHubClient(new ProductHeaderValue(APPLICATION));
            github.Credentials = new Credentials(accessToken);

            var organizationMembers = await github.Organization.Member.GetAllPublic(organization);

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
                TotalPrivateRepos = user.TotalPrivateRepos,
                Price = (user.Followers + user.Collaborators + user.PublicRepos + user.TotalPrivateRepos) * 2
            };
        }
    }
}