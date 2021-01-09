using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketSystemLibrary
{
    public class EngineerModel
    {
        public int EngineerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string HomePostcode { get; private set; }
        public List<PartModel> PartsInStock { get; private set; } = Factory.CreatePartModelList();
        public List<PartModel> AdditionalPartsRequired { get; private set; } = Factory.CreatePartModelList();
        public List<TaskModel> ScheduledTasks { get; private set; } = Factory.CreateTaskModelList();

        public void UpdateFirstName(string newFirstName) {
            FirstName = newFirstName;
        }
        
        public void UpdateLastName(string newLastName) {
            LastName = newLastName;
        }
        
        public void UpdateHomePostcode(string newHomePostcode) {
            HomePostcode = newHomePostcode;
        }

        public void AddPartsToStock(List<PartModel> partsSent) {
            PartsInStock.UpdateStockQuantities(partsSent);
        }

        public void RemovePartsFromStock(List<PartModel> partsUsed) {
            partsUsed.InvertStockQuantities();
            PartsInStock.UpdateStockQuantities(partsUsed);
        }

        public List<PartModel> DetermineRequiredPartsForScheduledTasks() {
            List<PartModel> requiredParts = ScheduledTasks.SelectMany(x => x.PartsRequired).ToList();
            return requiredParts;
        }

        public void DetermineAdditionalPartsRequired() {
            var additionalPartsRequired = DetermineRequiredPartsForScheduledTasks();
            var partsInStock = PartsInStock;
            partsInStock.InvertStockQuantities();
            AdditionalPartsRequired = additionalPartsRequired.UpdateStockQuantities(partsInStock);
        }

        public void CompleteTaskForEngineer(TaskModel currentTask) {
            ScheduledTasks.RemoveAll(x => x.TaskId == currentTask.TaskId);
            RemovePartsFromStock(currentTask.PartsUsed);
        }
    }
}
