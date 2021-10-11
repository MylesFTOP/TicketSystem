using System.Collections.Generic;
using System.Linq;

namespace TicketSystemLibrary
{
    public class EngineerStockModel : StockCollectionModel
    {
        public int OwningEngineerId { get; set; }
        public List<PartModel> AdditionalPartsRequired { get; set; } = Factory.CreatePartModelList();

        public void UpdateAdditionalPartsRequired(List<TaskModel> tasks) {
            var additionalPartsRequired = DetermineRequiredPartsForScheduledTasks(tasks);
            AdditionalPartsRequired = additionalPartsRequired.UpdateStockQuantities(
                PartsInStock.InvertStockQuantities());
        }

        public List<PartModel> DetermineRequiredPartsForScheduledTasks(List<TaskModel> tasks) {
            var partsRequired = tasks.SelectMany(x => x.PartsRequired).ToList();
            partsRequired.ConsolidateDuplicateEntries();
            return partsRequired;
        }
    }
}
