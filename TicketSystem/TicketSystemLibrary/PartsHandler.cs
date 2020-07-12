using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystemLibrary
{
    public static class PartsHandler
    {
        public static List<PartModel> UpdateStockQuantities(this List<PartModel> stockToBeUpdated, List<PartModel> stockUpdates) {
            foreach ( var part in stockUpdates )
            {
                var partToBeUpdated = stockToBeUpdated.FirstOrDefault(x => x.PartId == part.PartId);
                if ( partToBeUpdated != null )
                { partToBeUpdated.Quantity += part.Quantity; }
                else
                { stockToBeUpdated.Add(part); }
            }
            stockToBeUpdated.RemoveAll(x => x.Quantity <= 0);

            return stockToBeUpdated;
        }
    }
}
