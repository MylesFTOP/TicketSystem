using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystemLibrary
{
    public static class Factory
    {
        public static EngineerModel CreateEngineerModel() {
            return new EngineerModel();
        }

        public static AssociationHandler CreateAssociationHandler() {
            return new AssociationHandler();
        }
    }
}
