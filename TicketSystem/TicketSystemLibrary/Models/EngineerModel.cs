using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketSystemLibrary
{
    public class EngineerModel
    {
        public int EngineerId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomePostcode { get; set; }
        public List<PartModel> PartsInStock { get; private set; } = Factory.CreatePartModelList();
        public List<TaskModel> ScheduledTasks { get; set; } = Factory.CreateTaskModelList();

        public void AddPartsToStock(List<PartModel> partsSent) {
            PartsInStock.UpdateStockQuantities(partsSent);
        }

        public void RemovePartsFromStock(List<PartModel> partsUsed) {
            partsUsed.InvertStockQuantities();
            PartsInStock.UpdateStockQuantities(partsUsed);
        }

        public void CompleteTaskForEngineer(TaskModel currentTask) {
            ScheduledTasks.RemoveAll(x => x.TaskId == currentTask.TaskId);
            RemovePartsFromStock(currentTask.PartsUsed);
        }
    }
}
