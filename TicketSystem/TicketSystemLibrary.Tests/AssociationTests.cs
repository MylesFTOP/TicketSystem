using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TicketSystemLibrary.Tests
{
    public class AssociationTests
    {
        private readonly TaskModel task = new TaskModel();
        private readonly TicketModel ticket = new TicketModel();

        [Fact]
        public void Task_LinkingShouldIncreaseTicketListLength() {
            var expected = task.LinkedTickets.Count + 1;
            task.LinkTicket(task, ticket);
            var actual = task.LinkedTickets.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Task_UnlinkingShouldDecreaseTicketListLength() {
            task.LinkedTickets.Add(ticket);
            var expected = task.LinkedTickets.Count - 1;
            task.UnlinkTicket(task, ticket);
            var actual = task.LinkedTickets.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ticket_LinkingShouldIncreaseTaskListLength() {
            var expected = ticket.LinkedTasks.Count + 1;
            ticket.LinkTasks(task, ticket);
            var actual = ticket.LinkedTasks.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ticket_UnlinkingShouldDecreaseTaskListLength() {
            ticket.LinkedTasks.Add(task);
            var expected = ticket.LinkedTasks.Count - 1;
            ticket.UnlinkTasks(task, ticket);
            var actual = ticket.LinkedTasks.Count;
            Assert.Equal(expected, actual);
        }
    }
}
