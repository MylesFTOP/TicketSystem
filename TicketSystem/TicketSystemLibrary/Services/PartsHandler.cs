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
                var partToBeUpdated = stockToBeUpdated.FirstOrDefault(x => x == part);
                if ( partToBeUpdated != null )
                { partToBeUpdated.AddToStock(part.Quantity); }
                else
                { stockToBeUpdated.Add(part); }
            }
            var excessStockRemoved = stockToBeUpdated.Where(x => x.Quantity < 0).ToList();
            stockToBeUpdated.RemoveAll(x => x.Quantity <= 0);

            return stockToBeUpdated;
        }

        public static void ConsolidateDuplicateEntries(this List<PartModel> partsListToConsolidate) {
            var consolidatedPartsList = Factory.CreatePartModelList();
            consolidatedPartsList.UpdateStockQuantities(partsListToConsolidate);
            partsListToConsolidate.Clear();
            partsListToConsolidate.AddRange(consolidatedPartsList);
        }

        public static List<PartModel> InvertStockQuantities(this List<PartModel> stockToBeUpdated) {
            stockToBeUpdated.ForEach(x => x.InvertQuantity());
            return stockToBeUpdated;
        }
    }
}
