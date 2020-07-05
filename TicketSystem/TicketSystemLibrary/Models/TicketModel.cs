using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystemLibrary
{
    public class TicketModel
    {
        public int TicketId { get; private set; }
        public string TicketTitle { get; set; }
        public string TicketDescription { get; set; }
        public string TicketStatus { get; private set; }
        public DateTime TicketCreatedDateTime { get; private set; }
        public DateTime TicketUpdatedDateTime { get; private set; }
        public DateTime? TicketClosedDateTime { get; private set; }
        public List<TaskModel> LinkedTasks { get; set; }

        public void CreateTicket(string title, string description) {
            TicketId = 21; // TODO: Change this to a retrieved ID from a database
            TicketTitle = title;
            TicketDescription = description;
            TicketStatus = "Open";
            TicketCreatedDateTime = DateTime.UtcNow;
            UpdateTicket();
        }

        public void LinkTasks(TaskModel task, TicketModel currentTicket) {
            AssociationHandler handler = new AssociationHandler();
            handler.LinkTaskAndTicket(task, currentTicket);
        }

        public void UnlinkTasks(TaskModel task, TicketModel currentTicket) {
            AssociationHandler handler = new AssociationHandler();
            handler.UnlinkTaskAndTicket(task, currentTicket);
        }

        public void UpdateTicket() {
            TicketUpdatedDateTime = DateTime.UtcNow;
        }
    }
}
