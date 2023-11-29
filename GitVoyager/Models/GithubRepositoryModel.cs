using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitVoyager.Models
{
    public class GitHubRepositoryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HtmlUrl { get; set; }
        public bool Private { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public GitHubRepositoryModel(Repository repository)
        {
            if (repository != null)
            {
                Id = repository.Id;
                Name = repository.Name;
                Description = repository.Description;
                HtmlUrl = repository.HtmlUrl;
                Private = repository.Private;
                CreatedAt = repository.CreatedAt.LocalDateTime;
                UpdatedAt = repository.UpdatedAt.LocalDateTime;
            }
        }
        public GitHubRepositoryModel()
        {
        }
    }

}
