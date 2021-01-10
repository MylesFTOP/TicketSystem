using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystemLibrary
{
    public interface IShipmentTracker
    {
        DateTime GetExpectedDeliveryDate(ShipmentModel shipment);
    }
}
