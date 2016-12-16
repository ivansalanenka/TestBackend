using Owin.Server.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Owin.Server.Controllers
{
    public class ProjectInfoController : ApiController
    {
        public ProjectViewModel Get(int projectId)
        {
            var projectScopes =
                DB.ProjectScopes.Where(projectScope => projectScope.ProjectId == projectId)
                .Select(projectScope => new ProjectScopeViewModel
                {
                    Id = projectScope.Id,
                    ScopeId = projectScope.ScopeId,
                    ScopeOwnerId = projectScope.OwnerId,
                    TasksCount = projectScope.TasksCount,
                    CompletedTasksCount = projectScope.CompletedTasksCount,
                    DueDate = projectScope.DueDate.GetDateTimeFormats()[0]
                })
                .ToDictionary(projectScope => DB.Scopes.First(scopes => scopes.Id == projectScope.ScopeId).CategoryId);


            var projectA = DB.Projects.First(project => project.Id == projectId);

            return new ProjectViewModel
                {
                    Id = projectA.Id,
                    Name = projectA.Name,
                    Client = DB.Clients.First(client => client.Id == projectA.ClientId).Name,
                    Market = DB.Markets.First(market => market.Id == projectA.MarketId).Name,
                    OwnerId = projectA.OwnerId,
                    TeamMembersIds = DB.ProjectTeamMembers.Where(tm => tm.ProjectId == projectId).Select(tm => tm.UserId),
                    ProjectScopes = projectScopes,
                    BannerInfo = new BannerInfoViewModel
                    {
                        Url = projectA.BannerInfo.ImageUrl,
                        Position = new PositionViewModel 
                        {
                            Top = projectA.BannerInfo.ImagePosition.Top,
                            Left = projectA.BannerInfo.ImagePosition.Left
                        },
                        Color = projectA.BannerInfo.Color
                    }
                };
        }
    }
}
