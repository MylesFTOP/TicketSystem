using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystemLibrary
{
    public class TaskModel
    {
        public int TaskId { get; private set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public string TaskStatus { get; private set; }
        public DateTime TaskCreatedDateTime { get; private set; }
        public DateTime TaskUpdatedDateTime { get; private set; }
        public DateTime? TaskCompletedDateTime { get; private set; }
        public string TaskLocationPostcode { get; set; }
        public List<PartModel> PartsRequired { get; set; }
        public EngineerModel EngineerAttending { get; set; }
        public List<TicketModel> LinkedTickets { get; set; }
        public void CreateTask(string title, string description) {
            TaskId = 21; // TODO: Change this to a retrieved ID from a database
            TaskTitle = title;
            TaskDescription = description;
            TaskStatus = "Open";
            TaskCreatedDateTime = DateTime.UtcNow;
            TaskUpdatedDateTime = TaskCreatedDateTime;
        }
    }
}
