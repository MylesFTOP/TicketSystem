using System.Collections.Generic;

namespace TicketSystemLibrary
{
    public class StockCollectionModel
    {
        public List<PartModel> PartsInStock { get; private set; } = Factory.CreatePartModelList();

        public void AddPartsToStock(List<PartModel> partsSent) =>
            PartsInStock.UpdateStockQuantities(partsSent);

        public void RemovePartsFromStock(List<PartModel> partsUsed) {
            partsUsed.InvertStockQuantities();
            PartsInStock.UpdateStockQuantities(partsUsed);
        }
    }
}