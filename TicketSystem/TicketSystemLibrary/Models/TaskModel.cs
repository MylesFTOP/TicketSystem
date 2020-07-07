using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystemLibrary
{
    public class TaskModel
    {
        readonly AssociationHandler _handler;

        public int TaskId { get; private set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public string TaskStatus { get; private set; }
        public DateTime TaskCreatedDateTime { get; private set; }
        public DateTime TaskUpdatedDateTime { get; private set; }
        public DateTime? EngineerExpectedArrivalTime { get; set; }
        public DateTime? TaskCompletedDateTime { get; private set; }
        public string TaskLocationPostcode { get; set; }
        public List<PartModel> PartsRequired { get; set; } = new List<PartModel>();
        public List<PartModel> PartsUsed { get; set; } = new List<PartModel>();
        public EngineerModel EngineerAttending { get; set; }
        public List<ShipmentModel> SentShipments { get; set; } = new List<ShipmentModel>();
        public List<TicketModel> LinkedTickets { get; set; } = new List<TicketModel>();

        public TaskModel(AssociationHandler handler) {
            _handler = handler;
        }
        public void CreateTask(string title, string description) {
            TaskId = 21; // TODO: Change this to a retrieved ID from a database
            TaskTitle = title;
            TaskDescription = description;
            TaskStatus = "Open";
            TaskCreatedDateTime = DateTime.UtcNow;
            UpdateTask(TaskCreatedDateTime);
        }

        public void LinkTicket(TicketModel ticket) {
            _handler.LinkTaskAndTicket(this, ticket);
        }
        
        public void UnlinkTicket(TicketModel ticket) {
            _handler.UnlinkTaskAndTicket(this, ticket);
        }

        public void ScheduleTaskToEngineer(EngineerModel engineer, DateTime expectedArrivalTime) {
            EngineerAttending = engineer;
            EngineerExpectedArrivalTime = expectedArrivalTime;
            engineer.ScheduledTasks.Add(this);
            UpdateTask();
        }

        public void UpdatePartsUsed(List<PartModel> partsUsed) {
            PartsUsed = partsUsed;
        }

        public void CompleteTask(EngineerModel engineer, List<PartModel> partsUsed) {
            TaskStatus = "Completed";
            UpdatePartsUsed(partsUsed);
            engineer.CompleteTaskForEngineer(this);
            DateTime currentTime = DateTime.UtcNow;
            TaskCompletedDateTime = currentTime;
            UpdateTask(currentTime);
        }

        public void UpdateTask() {
            TaskUpdatedDateTime = DateTime.UtcNow;
        }

        public void UpdateTask(DateTime currentTime) {
            TaskUpdatedDateTime = currentTime;
        }
    }
}
