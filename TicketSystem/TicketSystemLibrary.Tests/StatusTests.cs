using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TicketSystemLibrary.Tests
{
    public class StatusTests
    {
        private readonly TaskModel task = Factory.CreateTaskModel();
        private readonly TicketModel ticket = Factory.CreateTicketModel();
        private readonly EngineerModel engineer = Factory.CreateEngineerModel();
        private readonly List<PartModel> partsUsed = Factory.CreatePartModelList();

        [Fact]
        public void TaskModel_CreateTaskShouldPopulateTaskStatus() {
            var expected = "Open";
            task.CreateTask("title", "description");
            var actual = task.TaskStatus;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TicketModel_OpenNewTicketShouldPopulateTicketStatus() {
            var expected = "Open";
            ticket.OpenNewTicket("title", "description");
            var actual = ticket.TicketStatus;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TaskModel_CompleteTaskShouldUpdateTaskStatus() {
            var expected = "Completed";
            task.CompleteTask(engineer, partsUsed);
            var actual = task.TaskStatus;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TicketModel_CloseTicketShouldUpdateTicketStatus() {
            var expected = "Closed";
            ticket.CloseTicket();
            var actual = ticket.TicketStatus;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TaskModel_ScheduleTaskToEngineerShouldUpdateTicketStatus() {
            var expected = "Scheduled";
            task.ScheduleTaskToEngineer(engineer, DateTime.UtcNow);
            var actual = task.TaskStatus;
            Assert.Equal(expected, actual);
        }
    }
}
