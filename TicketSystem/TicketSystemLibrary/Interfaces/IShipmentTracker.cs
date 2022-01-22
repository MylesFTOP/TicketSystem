using System;

namespace TicketSystemLibrary
{
    public interface IShipmentTracker
    {
        DateTime GetExpectedDeliveryDate(ShipmentModel shipment);
    }
}
