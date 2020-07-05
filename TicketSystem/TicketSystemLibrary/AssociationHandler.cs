using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystemLibrary
{
    public class AssociationHandler
    {
        public void LinkTaskAndTicket(TaskModel task, TicketModel ticket) {
            // TODO: Catch and escape attempted updates when tasks are already linked
            task.LinkedTickets.Add(ticket);
            ticket.LinkedTasks.Add(task);
            task.UpdateTask();
            ticket.UpdateTicket();
        }

        public void UnlinkTaskAndTicket(TaskModel task, TicketModel ticket) {
            task.LinkedTickets.RemoveAll(x => x.TicketId == ticket.TicketId);
            ticket.LinkedTasks.RemoveAll(x => x.TaskId == task.TaskId);
            task.UpdateTask();
            ticket.UpdateTicket();
        }
    }
}
