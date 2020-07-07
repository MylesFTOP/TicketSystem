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
        public List<PartModel> PartsInStock { get; set; } = new List<PartModel>();
        public List<TaskModel> ScheduledTasks { get; set; } = new List<TaskModel>();

        public void AddPartsToStock(List<PartModel> partsSent) {
            var partsToAdd = partsSent.Where(x => !PartsInStock.Any(y => y.PartId == x.PartId));

            foreach ( var partToAdd in partsToAdd )
            { PartsInStock.Add(partToAdd); }

            // TODO: Check equality of partId so that the right parts get updated
            foreach ( PartModel p in partsSent )
            { p.AddToStock(p.Quantity); }
        }

        public void RemovePartsFromStock(List<PartModel> partsUsed) {
            foreach ( PartModel p in partsUsed )
            {
                p.RemoveFromStock(p.Quantity);
            }
        }   
    }
}
