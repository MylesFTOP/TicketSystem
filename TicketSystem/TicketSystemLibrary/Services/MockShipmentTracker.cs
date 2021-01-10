using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystemLibrary
{
    public class MockShipmentTracker : IShipmentTracker
    {
        public DateTime GetExpectedDeliveryDate(ShipmentModel shipment) {
            DateTime expectedDeliveryDate = DateTime.UtcNow;
            return expectedDeliveryDate;
        }
    }
}
