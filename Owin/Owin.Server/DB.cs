using Owin.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin.Server
{
    public static class DB
    {
        public static Random random = new Random(DateTime.Now.Millisecond);
        public static List<User> Users { get; set; }
        public static List<Category> Categories { get; set; }
        public static List<Scope> Scopes { get; set; }
        public static List<ProjectType> ProjectTypes { get; set; }
        public static List<Client> Clients { get; set; }
        public static List<Region> Regions { get; set; }
        public static List<Market> Markets { get; set; }
        public static List<ClientMarket> ClientMarkets { get; set; }
        public static List<Brand> Brands { get; set; }
        public static List<Product> Products { get; set; }
        public static List<Project> Projects { get; set; }
        public static List<ProjectScope> ProjectScopes { get; set; }
        public static List<ProjectTeamMember> ProjectTeamMembers { get; set; }

        public static int GetRandomExcept(int maxValue, IEnumerable<int> except)
        {
            int result = 0;

            do
            {
                result = random.Next(maxValue);
            } while (except.Contains(result));

            return result;
        }

        static DB()
        {
            

            //Users
            Users = new List<User> { 
                new User { Id = 0 , FirstName = "Empire", LastName="Trooper", AvatarUrl = "img/avatar1.jpg" },
                new User { Id = 1 , FirstName = "Orange", LastName="Guy", AvatarUrl = "img/avatar2.jpg" },
                new User { Id = 2 , FirstName = "Super", LastName="Beard", AvatarUrl = "img/avatar3.jpg" },
                new User { Id = 3 , FirstName = "Awesome", LastName="Guy", AvatarUrl = "img/avatar4.jpg" },
                new User { Id = 4 , FirstName = "Glass", LastName="Guy", AvatarUrl = "img/avatar5.jpg" },
                new User { Id = 5 , FirstName = "Bowling", LastName="Ball", AvatarUrl = "img/avatar6.jpg" },
                new User { Id = 6 , FirstName = "Mario", LastName="Luigi", AvatarUrl = "img/avatar7.jpg" },
                new User { Id = 7 , FirstName = "Thrust", LastName="Me", AvatarUrl = "img/avatar8.jpg" },
                new User { Id = 8 , FirstName = "Ordinary", LastName="Jester", AvatarUrl = "img/avatar9.jpg" },
                new User { Id = 9 , FirstName = "Anonymous", LastName="Guy", AvatarUrl = "img/avatar10.jpg" },
                new User { Id = 10 , FirstName = "Boba", LastName="Fett", AvatarUrl = "img/avatar11.jpg" }
            };

            //Categories
            Categories = new List<Category> {
                new Category(){Id = 0, Name = "initiate", Color="#407F91"},
                new Category(){Id = 1, Name = "identity", Color="#1B2326"},
                new Category(){Id = 2, Name = "insight & inspiration", Color="#7E2447"},
                new Category(){Id = 3, Name = "strategy", Color="#D83554"},
                new Category(){Id = 4, Name = "planning implementation", Color="#AFAFAF"},
                new Category(){Id = 5, Name = "investment & executation", Color="#4EABB3"},
                new Category(){Id = 6, Name = "measurement & optimization", Color="#A12B4B"},
                new Category(){Id = 7, Name = "administration", Color="#42183E"}
            };

            //Scopes
            Scopes = new List<Scope> { 
                new Scope{Id = 0,  Name = "Client Brief/Opportunity", IconId = "fa-child", CategoryId = 0},
                new Scope{Id = 1,  Name = "Mediabrands Collaboration", IconId = "fa-child", CategoryId = 0},
                new Scope{Id = 2,  Name = "Business Opportunity", IconId = "fa-child", CategoryId = 1},
                new Scope{Id = 3,  Name = "Audience Opportunity", IconId = "fa-child", CategoryId = 1},
                new Scope{Id = 4,  Name = "Audience Profiling", IconId = "fa-child", CategoryId = 2},
                new Scope{Id = 5,  Name = "Audience Empaty", IconId = "fa-child", CategoryId = 2},
                new Scope{Id = 6,  Name = "Key Inspiration", IconId = "fa-child", CategoryId = 2},
                new Scope{Id = 7,  Name = "Partner Strategy", IconId = "fa-child", CategoryId = 3},
                new Scope{Id = 8,  Name = "Content Strategy", IconId = "fa-child", CategoryId = 3},
                new Scope{Id = 9,  Name = "Channel Plans", IconId = "fa-child", CategoryId = 4},
                new Scope{Id = 10, Name = "Investment Allocations", IconId = "fa-child", CategoryId = 4},
                new Scope{Id = 11, Name = "Paid Media Buying", IconId = "fa-child", CategoryId = 5},
                new Scope{Id = 12, Name = "Social Activation", IconId = "fa-child", CategoryId = 5},
                new Scope{Id = 13, Name = "Programmatic Activation", IconId = "fa-child", CategoryId = 6},
                new Scope{Id = 14, Name = "Content Activation & Creation", IconId = "fa-child", CategoryId = 6},
                new Scope{Id = 15, Name = "Real time optimization", IconId = "fa-child", CategoryId = 6},
                new Scope{Id = 16, Name = "ROI", IconId = "fa-child", CategoryId = 7},
                new Scope{Id = 17, Name = "Plans and Flowcharts", IconId = "fa-child", CategoryId = 7},
                new Scope{Id = 18, Name = "Ambitions", IconId = "fa-child", CategoryId = 7}
            };

            //ProjectTypes
            ProjectTypes = new List<ProjectType>
            {
                new ProjectType{Id = 0, Name = "Project Type 1"},
                new ProjectType{Id = 1, Name = "Project Type 2"},
                new ProjectType{Id = 2, Name = "Project Type 3"},
                new ProjectType{Id = 3, Name = "Project Type 4"},
                new ProjectType{Id = 4, Name = "Project Type 5"}
            };

            //Clients
            Clients = new List<Client> {
                new Client{ Id = 0, Name = "Coca-Cola"},
                new Client{ Id = 1, Name = "McDonalds"},
                new Client{ Id = 2, Name = "Mercedes"},
                new Client{ Id = 3, Name = "Ford"}
            };

            //Regions
            Regions = new List<Region> { 
                new Region{Id = 0 , Name = "North America" },
                new Region{Id = 1 , Name = "South America" },
                new Region{Id = 2 , Name = "Europe" },
                new Region{Id = 3 , Name = "Asia" }
            };

            //Markers
            Markets = new List<Market>
            {
                new Market{Id = 0 , Name = "US", RegionId = 0},
                new Market{Id = 1 , Name = "Canada", RegionId = 0},
                new Market{Id = 2 , Name = "Mexico", RegionId = 0},

                new Market{Id = 3 , Name = "Agertina", RegionId = 1},
                new Market{Id = 4 , Name = "Brazil", RegionId = 1},
                new Market{Id = 5 , Name = "Colombia", RegionId = 1},

                new Market{Id = 6 , Name = "Belarus", RegionId = 2},
                new Market{Id = 7 , Name = "England", RegionId = 2},
                new Market{Id = 8 , Name = "Poland", RegionId = 2},

                new Market{Id = 9 , Name = "China", RegionId = 3},
                new Market{Id = 10 , Name = "Japan", RegionId = 3},
                new Market{Id = 11 , Name = "India", RegionId = 3}
            };

            //ClientMarkets
            ClientMarkets = new List<ClientMarket>();

            int marketIndex = 0;
            foreach (var client in Clients)
            {
                for (int i = 0; i < 5; i++)
                {
                    int overflow = marketIndex - (Markets.Count - 1);
                    if (overflow > 0)
                    {
                        marketIndex = overflow;
                    }

                    ClientMarkets.Add(new ClientMarket { ClientId = client.Id, MarketId = Markets[marketIndex].Id });

                    marketIndex += 5;
                }
            }

            //Brands
            Brands = new List<Brand>();

            int brandId = 0;
            foreach (Client client in Clients)
            {
                for (int i = 0; i < 10; i++)
                {
                    Brands.Add(new Brand { Id = brandId, Name = client.Name + " Brand " + (i + 1), ClientId = client.Id });
                    brandId++;
                }
            }

            //Products
            Products = new List<Product>();

            int productId = 0;
            foreach (var brand in Brands)
            {
                for (int i = 0; i < 10; i++)
                {
                    Products.Add(new Product { Id = productId, Name = brand.Name + " Product " + (i + 1), BrandId = brand.Id });
                    productId++;
                }
            }

            
            //Project            
            

            Project formulaProject = new Project 
            {
                Id = 0,
                Name = "Formula 1 project",
                ClientId = Clients[random.Next(Clients.Count)].Id,
                MarketId = Markets[random.Next(Markets.Count)].Id,
                OwnerId = Users[random.Next(Users.Count)].Id,
                ProductId = Products[random.Next(Products.Count)].Id,
                ProjectTypeId = ProjectTypes[random.Next(ProjectTypes.Count)].Id,
                BannerInfo = new ProjectBannerInfo
                {
                    ImageUrl = "img/announcement4.jpg",
                    ImagePosition = new Position { Top = 0, Left = 100 },
                    Color = "#af4486"
                }
            };

            //ProjectTeamMembers
            ProjectTeamMembers = new List<ProjectTeamMember>();
            for (int i = 0; i < 5; i++)
            {
                ProjectTeamMembers.Add(new ProjectTeamMember 
                {
                    ProjectId = formulaProject.Id,
                    UserId = GetRandomExcept(Users.Count, ProjectTeamMembers.Select(ptm => ptm.UserId))
                });
            }

            //ProjectScopes
            ProjectScopes = new List<ProjectScope>();

            for (int i = 0; i < 10; i++)
            {
                int tasksCount = random.Next(20);
                int completedTasksCount = random.Next(tasksCount);

                ProjectScopes.Add(new ProjectScope 
                {
                    Id = i,
                    ProjectId = formulaProject.Id,
                    ScopeId = Scopes[random.Next(Scopes.Count)].Id,
                    OwnerId = Users[random.Next(Users.Count)].Id,
                    TasksCount = tasksCount,
                    CompletedTasksCount = completedTasksCount,
                    SortOrder = i,
                    DueDate = DateTime.Now.AddDays(random.Next(Users.Count))
                });
            }

            //Projects
            Projects = new List<Project>{formulaProject};
        }
    }
}