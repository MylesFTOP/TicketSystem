using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystemLibrary.Interfaces
{
    public interface IShipmentTracker
    {
        DateTime GetExpectedDeliveryDate(ShipmentModel shipment);
    }
}
