using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketSystemLibrary
{
    public class PartModel
    {
        public int PartId { get; private set; }
        public string PartTitle { get; set; }
        public string PartDescription { get; set; }
        public int Quantity { get; set; }
        public int MinimumStock { get; set; }

        public void AddToStock (int quantityToAdd) {
            Quantity += quantityToAdd;
        }

        public void RemoveFromStock (int quantityToRemove) {
            Quantity -= quantityToRemove;
            CheckMinimumStock();
        }

        public void CheckMinimumStock() {
            if ( Quantity <= MinimumStock )
            {
                Console.WriteLine($"Insufficient stock of { PartTitle }. Please order replacement.");
            }
        }

        public bool Equals(PartModel partModel) {
            if ( this.PartId == partModel.PartId )
            { return true; }
            return false;
        }
    }
}
