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

        public void UpdatePartId(int newId) {
            PartId = newId;
        }

        public void AddToStock (int quantityToAdd) {
            Quantity += quantityToAdd;
        }

        public void RemoveFromStock (int quantityToRemove) {
            Quantity -= quantityToRemove;
            if ( Quantity < 0 )
            {
                Console.WriteLine($"More items removed than were originally reported present. Please check stock.");
            }
            CheckMinimumStock();
        }

        public void CheckMinimumStock() {
            if ( Quantity <= MinimumStock )
            {
                Console.WriteLine($"Insufficient stock of { PartTitle }. Please order replacement.");
            }
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as PartModel);
        }

        public bool Equals(PartModel partModel)
        {
            if (Object.ReferenceEquals(partModel, null))
                return false;
            if (Object.ReferenceEquals(this, partModel))
                return true;
            if (this.GetType() != partModel.GetType())
                return false;
            return this.PartId == partModel.PartId; 
        }

        public static bool operator ==(PartModel leftHandPart, PartModel rightHandPart)
        {
            if (Object.ReferenceEquals(leftHandPart, null))
            {
                if (Object.ReferenceEquals(rightHandPart, null))
                { return true; }
                return false;
            }
            return leftHandPart.Equals(rightHandPart); 
        }

        public static bool operator !=(PartModel leftHandPart, PartModel rightHandPart)
        { return !(leftHandPart == rightHandPart); }
    }
}
