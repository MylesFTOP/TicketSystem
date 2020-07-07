using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TicketSystemLibrary.Tests
{
    public class AssociationTests
    {
        private readonly TaskModel task = Factory.CreateTaskModel();
        private readonly TicketModel ticket = Factory.CreateTicketModel();
        private readonly EngineerModel engineer = Factory.CreateEngineerModel();

        [Fact]
        public void Task_LinkingShouldIncreaseTicketListLength() {
            var expected = task.LinkedTickets.Count + 1;
            task.LinkTicket(ticket);
            var actual = task.LinkedTickets.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Task_UnlinkingShouldDecreaseTicketListLength() {
            task.LinkedTickets.Add(ticket);
            var expected = task.LinkedTickets.Count - 1;
            task.UnlinkTicket(ticket);
            var actual = task.LinkedTickets.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ticket_LinkingShouldIncreaseTaskListLength() {
            var expected = ticket.LinkedTasks.Count + 1;
            ticket.LinkTasks(task);
            var actual = ticket.LinkedTasks.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ticket_UnlinkingShouldDecreaseTaskListLength() {
            ticket.LinkedTasks.Add(task);
            var expected = ticket.LinkedTasks.Count - 1;
            ticket.UnlinkTasks(task);
            var actual = ticket.LinkedTasks.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Task_SchedulingTaskToEngineerShouldAddEngineer() {
            task.ScheduleTaskToEngineer(engineer, DateTime.UtcNow);
            Assert.IsType<EngineerModel>(task.EngineerAttending);
        }

        [Fact]
        public void Engineer_SchedulingEngineerToTaskShouldAddItem() {
            var expected = engineer.ScheduledTasks.Count + 1;
            task.ScheduleTaskToEngineer(engineer, DateTime.UtcNow);
            var actual = engineer.ScheduledTasks.Count;
            Assert.Equal(expected, actual);
        }
    }
}
