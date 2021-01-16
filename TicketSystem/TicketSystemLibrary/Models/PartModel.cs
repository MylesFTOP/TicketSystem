﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketSystemLibrary
{
    public class PartModel
    {
        public int PartId { get; private set; }
        public string PartTitle { get; private set; }
        public string PartDescription { get; private set; }
        public int Quantity { get; set; }
        public int MinimumStock { get; private set; }

        public void UpdatePartId(int newId) {
            PartId = newId;
        }

        public void UpdatePartTitle(string newPartTitle) {
            PartTitle = newPartTitle;
        }
        
        public void UpdatePartDescription(string newPartDescription) {
            PartDescription = newPartDescription;
        }

        public void SetMinimumStock(int minimumStock) {
            MinimumStock = minimumStock;
        }

        public void AddToStock (int quantityToAdd) {
            Quantity += quantityToAdd;
        }

        public void InvertQuantity () {
            Quantity = -Quantity;
        }

        public void RemoveFromStock (int quantityToRemove) {
            if ( Quantity < quantityToRemove )
            {
                throw new ArgumentOutOfRangeException(
                    paramName: "quantityToRemove",
                    message: "More items removed than were originally reported present. Please check stock.");
            }
            Quantity -= quantityToRemove;
            CheckMinimumStock();
        }

        public void CheckMinimumStock() {
            if ( Quantity <= MinimumStock )
            {
                Console.WriteLine($"Insufficient stock of { PartTitle }. Please order replacement.");
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as PartModel);
        }

        public bool Equals(PartModel partModel) {
            if (partModel is null) {
                return false;
            }

            if (Object.ReferenceEquals(this, partModel)) {
                return true;
            }

            if (this.GetType() != partModel.GetType()) {
                return false;
            }

            return this.PartId == partModel.PartId; 
        }

        public override int GetHashCode() {
            return HashCode.Combine(PartId);
        }

        public static bool operator ==(PartModel leftHandPart, PartModel rightHandPart) {
            if (leftHandPart is null)
            {
                if (rightHandPart is null)
                { return true; }
                return false;
            }
            return leftHandPart.Equals(rightHandPart); 
        }

        public static bool operator !=(PartModel leftHandPart, PartModel rightHandPart)
        { return !(leftHandPart == rightHandPart); }
    }
}
