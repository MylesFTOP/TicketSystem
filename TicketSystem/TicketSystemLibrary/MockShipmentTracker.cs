using System;
using System.Collections.Generic;
using System.Text;
using TicketSystemLibrary.Interfaces;

namespace TicketSystemLibrary
{
    public class MockShipmentTracker : IShipmentTracker
    {
        public DateTime GetExpectedDeliveryDate(ShipmentModel shipment) {
            throw new NotImplementedException();
        }
    }
}
