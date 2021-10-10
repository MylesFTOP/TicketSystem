using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystemLibrary
{
    public class EngineerStockModel
    {
        public List<PartModel> PartsInStock { get; private set; } = Factory.CreatePartModelList();

        public void AddPartsToStock(List<PartModel> partsSent) {
            PartsInStock.UpdateStockQuantities(partsSent);
        }

        public void RemovePartsFromStock(List<PartModel> partsUsed)
        {
            partsUsed.InvertStockQuantities();
            PartsInStock.UpdateStockQuantities(partsUsed);
        }
    }
}
