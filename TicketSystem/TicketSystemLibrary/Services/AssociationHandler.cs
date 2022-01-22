namespace TicketSystemLibrary
{
    public class AssociationHandler
    {
        public void LinkTaskAndTicket(TaskModel task, TicketModel ticket) {
            // TODO: Catch and escape attempted updates when tasks are already linked
            task.LinkedTickets.Add(ticket);
            task.UpdateTask();

            ticket.LinkedTasks.Add(task);
            ticket.UpdateTicket();
        }

        public void UnlinkTaskAndTicket(TaskModel task, TicketModel ticket) {
            task.LinkedTickets.RemoveAll(x => x.TicketId == ticket.TicketId);
            task.UpdateTask();

            ticket.LinkedTasks.RemoveAll(x => x.TaskId == task.TaskId);
            ticket.UpdateTicket();
        }
    }
}
