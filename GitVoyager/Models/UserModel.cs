using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitVoyager.Models
{
    public class UserModel
    {
        public string Login { get; set; }
        public long Id { get; set; }
        public string AvatarUrl { get; set; }
        public string HtmlUrl { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public int PublicRepos { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }

        public UserModel(User user)
        {
            if (user != null)
            {
                Login = user.Login;
                Id = user.Id;
                AvatarUrl = user.AvatarUrl;
                HtmlUrl = user.HtmlUrl;
                Name = user.Name;
                Email = user.Email;
                Bio = user.Bio;
                PublicRepos = user.PublicRepos;
                Followers = user.Followers;
                Following = user.Following;
            }
        }
        public UserModel()
        {
        }
    }


}
