using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TicketSystemLibrary
{
    public static class PartsHandler
    {
        public static List<PartModel> UpdateStockQuantities(this List<PartModel> stockToBeUpdated, List<PartModel> stockUpdates) {
            foreach ( var part in stockUpdates )
            {
                var partToBeUpdated = stockToBeUpdated.FirstOrDefault(x => x.PartId == part.PartId);
                if ( partToBeUpdated != null )
                { partToBeUpdated.AddToStock(part.Quantity); }
                else
                { stockToBeUpdated.Add(part); }
            }
            var excessStockRemoved = stockToBeUpdated.Where(x => x.Quantity < 0).ToList();
            stockToBeUpdated.RemoveAll(x => x.Quantity <= 0);

            return stockToBeUpdated;
        }

        //public static List<PartModel> ConsolidateDuplicateEntries(this List<PartModel> partsListToConsolidate) {

        //}

        public static List<PartModel> InvertStockQuantities(this List<PartModel> stockToBeUpdated) {
            stockToBeUpdated.ForEach(x => x.Quantity = -x.Quantity);
            return stockToBeUpdated;
        }
    }
}
