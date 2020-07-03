using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystemLibrary
{
    public class EngineerModel
    {
        public int EngineerId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomePostcode { get; set; }
        public List<PartModel> PartsInStock { get; set; }
        public List<TaskModel> ScheduledTasks { get; set; }

        public void RemovePartsFromStock(List<PartModel> partsUsed) {
            foreach ( PartModel p in partsUsed )
            {
                p.RemoveFromStock(p.Quantity);
            }
        }
    }
}
