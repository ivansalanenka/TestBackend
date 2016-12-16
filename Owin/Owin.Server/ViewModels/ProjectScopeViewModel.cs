using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Owin.Server.ViewModels
{
    [DataContract]
    public class ProjectScopeViewModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "scopeId")]
        public int ScopeId { get; set; }

        [DataMember(Name = "scopeOwnerId")]
        public int ScopeOwnerId { get; set; }

        [DataMember(Name = "tasksCount")]
        public int TasksCount { get; set; }

        [DataMember(Name = "completedTasksCount")]
        public int CompletedTasksCount { get; set; }

        [DataMember(Name = "dueDate")]
        public string DueDate { get; set; }
    }
}