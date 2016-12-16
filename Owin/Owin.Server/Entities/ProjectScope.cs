using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin.Server.Entities
{
    public class ProjectScope
    {
        public int Id { get; set; }
        public int ScopeId { get; set; }
        public int ProjectId { get; set; }
        public int OwnerId { get; set; }
        public int TasksCount { get; set; }
        public int CompletedTasksCount { get; set; }
        public DateTime DueDate { get; set; }
        public int SortOrder { get; set; }
    }
}