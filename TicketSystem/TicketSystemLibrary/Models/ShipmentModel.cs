using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystemLibrary
{
    public class ShipmentModel
    {
        public int ShipmentInternalId { get; private set; }
        public string ShipmentExternalId { get; set; }
        public string ShipmentCourier { get; set; }
        public string ShipmentStatus { get; set; }
        public DateTime DispatchDate { get; private set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public List<PartModel> PartsInShipment { get; set; } = Factory.CreatePartModelList();
    }
}
