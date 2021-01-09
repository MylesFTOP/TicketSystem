using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystemLibrary
{
    public class ShipmentModel
    {
        public int ShipmentInternalId { get; private set; }
        public string ShipmentExternalId { get; private set; }
        public string ShipmentCourier { get; private set; }
        public string ShipmentStatus { get; private set; }
        public DateTime DispatchDate { get; private set; }
        public DateTime? ExpectedDeliveryDate { get; private set; }
        public DateTime? ActualDeliveryDate { get; private set; }
        public List<PartModel> PartsInShipment { get; private set; } = Factory.CreatePartModelList();

        // External Id given by courier
        public void UpdateShipmentExternalId(string shipmentExternalId) {
            ShipmentExternalId = shipmentExternalId;
        }

        public void UpdateShipmentCourier(string shipmentCourier) {
            ShipmentCourier = shipmentCourier;
        }
    }
}
