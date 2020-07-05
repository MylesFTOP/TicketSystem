﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystemLibrary
{
    public class TaskModel
    {
        public int TaskId { get; private set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public string TaskStatus { get; private set; }
        public DateTime TaskCreatedDateTime { get; private set; }
        public DateTime TaskUpdatedDateTime { get; private set; }
        public DateTime? EngineerExpectedArrivalTime { get; set; }
        public DateTime? TaskCompletedDateTime { get; private set; }
        public string TaskLocationPostcode { get; set; }
        public List<PartModel> PartsRequired { get; set; }
        public List<PartModel> PartsUsed { get; set; }
        public EngineerModel EngineerAttending { get; set; }
        public List<ShipmentModel> SentShipments { get; set; }
        public List<TicketModel> LinkedTickets { get; set; }

        public void CreateTask(string title, string description) {
            TaskId = 21; // TODO: Change this to a retrieved ID from a database
            TaskTitle = title;
            TaskDescription = description;
            TaskStatus = "Open";
            TaskCreatedDateTime = DateTime.UtcNow;
            UpdateTask();
        }

        public void LinkTicket(TaskModel currentTask, TicketModel ticket) {
            AssociationHandler handler = new AssociationHandler();
            handler.LinkTaskAndTicket(currentTask, ticket);
        }
        
        public void UnlinkTicket(TaskModel currentTask, TicketModel ticket) {
            AssociationHandler handler = new AssociationHandler();
            handler.UnlinkTaskAndTicket(currentTask, ticket);
        }

        public void ScheduleTaskToEngineer(EngineerModel engineer, TaskModel currentTask, DateTime expectedArrivalTime) {
            EngineerAttending = engineer;
            EngineerExpectedArrivalTime = expectedArrivalTime;
            engineer.ScheduledTasks.Add(currentTask);
            UpdateTask();
        }

        public void CompleteTask(EngineerModel engineer, TaskModel currentTask, List<PartModel> partsUsed) {
            TaskStatus = "Completed";
            TaskCompletedDateTime = DateTime.UtcNow;
            PartsUsed = partsUsed;
            engineer.ScheduledTasks.RemoveAll(x => x.TaskId == currentTask.TaskId);
            engineer.RemovePartsFromStock(partsUsed);
            UpdateTask();
        }

        public void UpdateTask() {
            TaskUpdatedDateTime = DateTime.UtcNow;
        }
    }
}
