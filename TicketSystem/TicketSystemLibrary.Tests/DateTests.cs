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
        private readonly IShipmentTracker shipmentTracker = new MockShipmentTracker();
        private readonly ShipmentModel shipment = new ShipmentModel();
        private readonly TaskModel task = new TaskModel();
        private readonly TicketModel ticket = new TicketModel();

        [Fact]
        public void ShipmentTracker_ExpectedDeliveryDateShouldReturnADate() {
            var actual = shipmentTracker.GetExpectedDeliveryDate(shipment);
            Assert.IsType<DateTime>(actual);
        }

        [Fact]
        public void UpdateTask_ShouldUpdateTaskUpdatedDateTime() {
            var timeBeforeUpdate = task.TaskUpdatedDateTime;
            task.UpdateTask();
            var timeAfterUpdate = task.TaskUpdatedDateTime;
            Assert.NotEqual(timeBeforeUpdate, timeAfterUpdate);
        }

        [Fact]
        public void UpdateTicket_ShouldUpdateTicketUpdatedDateTime() {
            var timeBeforeUpdate = ticket.TicketUpdatedDateTime;
            ticket.UpdateTicket();
            var timeAfterUpdate = ticket.TicketUpdatedDateTime;
            Assert.NotEqual(timeBeforeUpdate, timeAfterUpdate);
        }
    }
}
