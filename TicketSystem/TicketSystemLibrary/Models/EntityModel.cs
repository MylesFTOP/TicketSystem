using System;

namespace TicketSystemLibrary
{
    public class EntityModel
    {
        public int Id { get; set; }
        public override bool Equals(object obj)
            => this.Equals(obj as EntityModel);

        public bool Equals(EntityModel entityModel)
        {
            if (entityModel is null)
                return false;

            if (Object.ReferenceEquals(this, entityModel))
                return true;

            return this.Id == entityModel.Id;
        }

        public override int GetHashCode()
            => HashCode.Combine(Id);

        public static bool operator ==(EntityModel leftHandPart, EntityModel rightHandPart)
            => leftHandPart is null ? rightHandPart is null : leftHandPart.Equals(rightHandPart);

        public static bool operator !=(EntityModel leftHandPart, EntityModel rightHandPart)
            => !(leftHandPart == rightHandPart);
    }
}