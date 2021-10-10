using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystemLibrary
{
    public static class Factory
    {
        public static AssociationHandler CreateAssociationHandler() => new AssociationHandler();

        public static EngineerModel CreateEngineerModel() => new EngineerModel();

        public static EngineerStockModel CreateEngineerStockModel() => new EngineerStockModel();

        public static PartModel CreatePartModel() => new PartModel();

        public static ShipmentModel CreateShipmentModel() => new ShipmentModel();

        public static IShipmentTracker CreateShipmentTracker() => new MockShipmentTracker();

        public static TaskModel CreateTaskModel() => new TaskModel(CreateAssociationHandler());

        public static TicketModel CreateTicketModel() => new TicketModel(CreateAssociationHandler());

        public static List<PartModel> CreatePartModelList() => new List<PartModel>();

        public static List<ShipmentModel> CreateShipmentModelList() => new List<ShipmentModel>();

        public static List<TaskModel> CreateTaskModelList() => new List<TaskModel>();

        public static List<TicketModel> CreateTicketModelList() => new List<TicketModel>();
    }
}
