using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketSystemLibrary.Models;

namespace TicketSystemLibrary
{
    public class EngineerModel : PersonModel
    {
        public int EngineerId { get; private set; }
        public string BasePostcode { get; private set; }
        public EngineerStockModel PartStock { get; private set; } = Factory.CreateEngineerStockModel();
        public List<TaskModel> ScheduledTasks { get; private set; } = Factory.CreateTaskModelList();

        public void UpdateBasePostcode(string newBasePostcode) => 
            BasePostcode = newBasePostcode;

        public void AddPartsToStock(List<PartModel> partsSent) => 
            PartStock.AddPartsToStock(partsSent);

        public void RemovePartsFromStock(List<PartModel> partsUsed) => 
            PartStock.RemovePartsFromStock(partsUsed);

        public List<PartModel> DetermineRequiredPartsForScheduledTasks() =>
            PartStock.DetermineRequiredPartsForScheduledTasks(ScheduledTasks);

        public void UpdateAdditionalPartsRequired() => 
            PartStock.UpdateAdditionalPartsRequired(ScheduledTasks);

        public void CompleteTaskForEngineer(TaskModel currentTask) {
            ScheduledTasks.RemoveAll(x => x.TaskId == currentTask.TaskId);
            RemovePartsFromStock(currentTask.PartsUsed);
        }
    }
}
