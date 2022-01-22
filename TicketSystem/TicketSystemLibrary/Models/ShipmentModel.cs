using System;
using System.Collections.Generic;

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
        public void UpdateShipmentExternalId(string shipmentExternalId) => 
            ShipmentExternalId = shipmentExternalId;

        public void UpdateShipmentCourier(string shipmentCourier) => 
            ShipmentCourier = shipmentCourier;

        public void UpdateShipmentStatus(string newStatus) => 
            ShipmentStatus = newStatus;

        public void UpdateExpectedDeliveryDate(DateTime expectedDeliveryDate) => 
            ExpectedDeliveryDate = expectedDeliveryDate;

        public void UpdateActualDeliveryDate(DateTime actualDeliveryDate) => 
            ActualDeliveryDate = actualDeliveryDate;

        public void AddPartsToShipment(List<PartModel> partsToAdd) => 
            PartsInShipment.UpdateStockQuantities(partsToAdd);

        public void RemovePartsFromShipment(List<PartModel> partsToRemove) => 
            AddPartsToShipment(partsToRemove.InvertStockQuantities());

        public TimeSpan CalculateDeliveryPerformance() {
            if (ExpectedDeliveryDate is null || ActualDeliveryDate is null) {
                throw new ArgumentNullException(nameof(CalculateDeliveryPerformance));
            }
            return (DateTime)ExpectedDeliveryDate - (DateTime)ActualDeliveryDate;
        }
    }
}
