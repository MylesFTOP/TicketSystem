using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketSystemLibrary
{
    public class EngineerStockModel
    {
        public int OwningEngineerId { get; set; }
        public List<PartModel> PartsInStock { get; private set; } = Factory.CreatePartModelList();
        public List<PartModel> AdditionalPartsRequired { get; set; } = Factory.CreatePartModelList();

        public void AddPartsToStock(List<PartModel> partsSent) => 
            PartsInStock.UpdateStockQuantities(partsSent);

        public void RemovePartsFromStock(List<PartModel> partsUsed) {
            partsUsed.InvertStockQuantities();
            PartsInStock.UpdateStockQuantities(partsUsed);
        }

        public List<PartModel> DetermineRequiredPartsForScheduledTasks(List<TaskModel> tasks) {
            var partsRequired = tasks.SelectMany(x => x.PartsRequired).ToList();
            partsRequired.ConsolidateDuplicateEntries();
            return partsRequired;
        }

        public void DetermineAdditionalPartsRequired(List<TaskModel> tasks) {
            var additionalPartsRequired = DetermineRequiredPartsForScheduledTasks(tasks);
            AdditionalPartsRequired = additionalPartsRequired.UpdateStockQuantities(
                PartsInStock.InvertStockQuantities());
        }
    }
}
