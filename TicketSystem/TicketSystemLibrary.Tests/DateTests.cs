using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TicketSystemLibrary;
using TicketSystemLibrary.Interfaces;

namespace TicketSystemLibrary.Tests
{
    public class DateTests
    {
        private readonly IShipmentTracker shipmentTracker = Factory.CreateShipmentTracker();
        private readonly ShipmentModel shipment = Factory.CreateShipmentModel();
        private readonly TaskModel task = Factory.CreateTaskModel();
        private readonly TicketModel ticket = Factory.CreateTicketModel();
        private readonly EngineerModel engineer = Factory.CreateEngineerModel();
        private readonly List<PartModel> partsUsed = Factory.CreatePartModelList();

        [Fact]
        public void ShipmentTracker_ExpectedDeliveryDateShouldReturnADate() {
            var actual = shipmentTracker.GetExpectedDeliveryDate(shipment);
            Assert.IsType<DateTime>(actual);
        }

        [Fact]
        public void TaskModel_UpdateTaskShouldUpdateTaskUpdatedDateTime() {
            var timeBeforeUpdate = task.TaskUpdatedDateTime;
            task.UpdateTask();
            var timeAfterUpdate = task.TaskUpdatedDateTime;
            Assert.NotEqual(timeBeforeUpdate, timeAfterUpdate);
        }

        [Fact]
        public void TicketModel_UpdateTicketShouldUpdateTicketUpdatedDateTime() {
            var timeBeforeUpdate = ticket.TicketUpdatedDateTime;
            ticket.UpdateTicket();
            var timeAfterUpdate = ticket.TicketUpdatedDateTime;
            Assert.NotEqual(timeBeforeUpdate, timeAfterUpdate);
        }

        [Fact]
        public void TaskModel_CreateTaskShouldUpdateTaskDateTimeFields() {
            var timeBeforeUpdate = task.TaskUpdatedDateTime;
            task.CreateTask("title", "description");
            var timeAfterUpdate = task.TaskUpdatedDateTime;
            Assert.NotEqual(timeBeforeUpdate, timeAfterUpdate);
            Assert.Equal(task.TaskCreatedDateTime, task.TaskUpdatedDateTime);
        }

        [Fact]
        public void TicketModel_OpenNewTicketShouldUpdateTicketDateTimeFields() {
            var timeBeforeUpdate = ticket.TicketUpdatedDateTime;
            ticket.OpenNewTicket("title", "description");
            var timeAfterUpdate = ticket.TicketUpdatedDateTime;
            Assert.NotEqual(timeBeforeUpdate, timeAfterUpdate);
            Assert.Equal(ticket.TicketCreatedDateTime, ticket.TicketUpdatedDateTime);
        }

        [Fact]
        public void TaskModel_CompleteTaskForEngineerShouldUpdateTaskDateTimeFields() {
            var timeBeforeUpdate = task.TaskUpdatedDateTime;
            task.CompleteTask(engineer, partsUsed);
            var timeAfterUpdate = task.TaskUpdatedDateTime;
            Assert.NotEqual(timeBeforeUpdate, timeAfterUpdate);
            Assert.Equal(task.TaskUpdatedDateTime, task.TaskCompletedDateTime);
        }

        [Fact]
        public void TicketModel_CloseTicketShouldUpdateTicketDateTimeFields() {
            var timeBeforeUpdate = ticket.TicketUpdatedDateTime;
            ticket.CloseTicket();
            var timeAfterUpdate = ticket.TicketUpdatedDateTime;
            Assert.NotEqual(timeBeforeUpdate, timeAfterUpdate);
            Assert.Equal(ticket.TicketUpdatedDateTime, ticket.TicketClosedDateTime);
        }
    }
}
