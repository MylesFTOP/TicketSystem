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
        private readonly List<PartModel> partsUsed = Factory.CreatePartModelList();

        [Fact]
        public void TaskModel_LinkingShouldIncreaseTicketListLength() {
            var expected = task.LinkedTickets.Count + 1;
            task.LinkTicket(ticket);
            var actual = task.LinkedTickets.Count;
            Assert.Equal(expected, actual);
        }
        
        [Fact(Skip = "TaskModel needs equality function first")]
        public void TaskModel_LinkingDuplicatesShouldNotIncreaseTicketListLength() {
            var expected = task.LinkedTickets.Count;
            var actual = task.LinkedTickets.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TaskModel_UnlinkingShouldDecreaseTicketListLength() {
            task.LinkedTickets.Add(ticket);
            var expected = task.LinkedTickets.Count - 1;
            task.UnlinkTicket(ticket);
            var actual = task.LinkedTickets.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TicketModel_LinkingShouldIncreaseTaskListLength() {
            var expected = ticket.LinkedTasks.Count + 1;
            ticket.LinkTasks(task);
            var actual = ticket.LinkedTasks.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TicketModel_UnlinkingShouldDecreaseTaskListLength() {
            ticket.LinkedTasks.Add(task);
            var expected = ticket.LinkedTasks.Count - 1;
            ticket.UnlinkTasks(task);
            var actual = ticket.LinkedTasks.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TaskModel_SchedulingTaskToEngineerShouldAddEngineer() {
            task.ScheduleTaskToEngineer(engineer, DateTime.UtcNow);
            Assert.IsType<EngineerModel>(task.EngineerAttending);
        }

        [Fact]
        public void EngineerModel_SchedulingEngineerToTaskShouldAddItem() {
            var expected = engineer.ScheduledTasks.Count + 1;
            task.ScheduleTaskToEngineer(engineer, DateTime.UtcNow);
            var actual = engineer.ScheduledTasks.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EngineerModel_CompleteTaskShouldRemoveTaskFromEngineersScheduledTasks() {
            var expected = false;
            engineer.CompleteTaskForEngineer(task);
            var actual = engineer.ScheduledTasks.Contains(task);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TaskModel_CompleteTaskShouldRemoveTaskFromEngineersScheduledTasks() {
            var expected = false;
            task.CompleteTask(engineer, partsUsed);
            var actual = engineer.ScheduledTasks.Contains(task);
            Assert.Equal(expected, actual);
        }
    }
}
