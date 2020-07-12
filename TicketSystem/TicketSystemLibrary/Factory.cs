using System;
using System.Collections.Generic;
using System.Text;
using TicketSystemLibrary.Interfaces;

namespace TicketSystemLibrary
{
    public static class Factory
    {
        public static AssociationHandler CreateAssociationHandler() {
            return new AssociationHandler();
        }

        public static EngineerModel CreateEngineerModel() {
            return new EngineerModel();
        }

        public static PartModel CreatePartModel() {
            return new PartModel();
        }

        public static ShipmentModel CreateShipmentModel() {
            return new ShipmentModel();
        }

        public static IShipmentTracker CreateShipmentTracker() {
            return new MockShipmentTracker();
        }

        public static TaskModel CreateTaskModel() {
            return new TaskModel(CreateAssociationHandler());
        }

        public static TicketModel CreateTicketModel() {
            return new TicketModel(CreateAssociationHandler());
        }

        public static List<PartModel> CreatePartModelList() {
            return new List<PartModel>();
        }

        public static List<ShipmentModel> CreateShipmentModelList() {
            return new List<ShipmentModel>();
        }

        public static List<TaskModel> CreateTaskModelList() {
            return new List<TaskModel>();
        }

        public static List<TicketModel> CreateTicketModelList() {
            return new List<TicketModel>();
        }
    }
}
