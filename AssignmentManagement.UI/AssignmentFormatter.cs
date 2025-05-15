using AssignmentManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentManagement.UI
{
    public class AssignmentFormatter : IAssignmentFormatter
    {
        public string Format(Assignment assignment)
        {
            return $"[{assignment.Id}] {assignment.Title} - {(assignment.IsCompleted ? "Completed" : "Incomplete")}";
        }
    }
}
