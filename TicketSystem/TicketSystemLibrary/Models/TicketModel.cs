﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystemLibrary
{
    public class TicketModel
    {
        readonly AssociationHandler _handler;

        public int TicketId { get; private set; }
        public string TicketTitle { get; set; }
        public string TicketDescription { get; set; }
        public string TicketStatus { get; private set; }
        public DateTime TicketCreatedDateTime { get; private set; }
        public DateTime TicketUpdatedDateTime { get; private set; }
        public DateTime? TicketClosedDateTime { get; private set; }
        public List<TaskModel> LinkedTasks { get; set; } = Factory.CreateTaskModelList();

        public TicketModel(AssociationHandler handler) {
            _handler = handler;
        }

        public void OpenNewTicket(string title, string description) {
            TicketId = 21; // TODO: Change this to a retrieved ID from a database
            TicketTitle = title;
            TicketDescription = description;
            TicketStatus = "Open";
            TicketCreatedDateTime = DateTime.UtcNow;
            UpdateTicket(TicketCreatedDateTime);
        }

        public void LinkTasks(TaskModel task) {
            _handler.LinkTaskAndTicket(task, this);
        }

        public void UnlinkTasks(TaskModel task) {
            _handler.UnlinkTaskAndTicket(task, this);
        }

        public void CloseTicket() {
            TicketStatus = "Closed";
            DateTime currentTime = DateTime.UtcNow;
            TicketClosedDateTime = currentTime;
            UpdateTicket(currentTime);
        }

        public void UpdateTicket() {
            TicketUpdatedDateTime = DateTime.UtcNow;
        }

        public void UpdateTicket(DateTime currentTime) {
            TicketUpdatedDateTime = currentTime;
        }
    }
}
