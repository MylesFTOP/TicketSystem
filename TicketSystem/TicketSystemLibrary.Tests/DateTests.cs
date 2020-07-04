using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TicketSystemLibrary;

namespace TicketSystemLibrary.Tests
{
    public class DateTests
    {
        private readonly MockShipmentTracker shipmentTracker = new MockShipmentTracker();
        private readonly ShipmentModel shipment = new ShipmentModel();

        [Fact]
        public void ShipmentTracker_ExpectedDeliveryDateShouldReturnADate() {
            var actual = shipmentTracker.GetExpectedDeliveryDate(shipment);
            Assert.IsType<DateTime>(actual);
        }
    }
}
