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
        public List<PartModel> PartsRequired { get; private set; } = Factory.CreatePartModelList();
        public List<PartModel> PartsUsed { get; private set; } = Factory.CreatePartModelList();
        public EngineerModel EngineerAttending { get; private set; }
        public List<ShipmentModel> SentShipments { get; set; } = Factory.CreateShipmentModelList();
        public List<TicketModel> LinkedTickets { get; private set; } = Factory.CreateTicketModelList();

        public TaskModel(AssociationHandler handler) {
            _handler = handler;
        }
        public void CreateTask(string title, string description) {
            TaskId = 21; // TODO: Change this to a retrieved ID from a database
            TaskTitle = title;
            TaskDescription = description;
            UpdateStatus("Open");
            TaskCreatedDateTime = TaskUpdatedDateTime;
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
            UpdateStatus("Scheduled");
        }

        public void UpdatePartsRequired(List<PartModel> partsRequired) {
            PartsRequired = partsRequired;
        }

        public void UpdatePartsUsed(List<PartModel> partsUsed) {
            PartsUsed = partsUsed;
        }

        public void CompleteTask(EngineerModel engineer, List<PartModel> partsUsed) {
            UpdateStatus("Completed");
            UpdatePartsUsed(partsUsed);
            engineer.CompleteTaskForEngineer(this);
            TaskCompletedDateTime = TaskUpdatedDateTime;
        }

        private void UpdateStatus(string newStatus) {
            TaskStatus = newStatus;
            UpdateTask();
        }

        public void UpdateTask() {
            TaskUpdatedDateTime = DateTime.UtcNow;
        }
    }
}
