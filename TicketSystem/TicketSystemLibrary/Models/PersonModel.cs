using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystemLibrary.Models
{
    public abstract class PersonModel
    {
        public int PersonId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public void UpdateFirstName(string newFirstName) => 
            FirstName = newFirstName;

        public void UpdateLastName(string newLastName) => 
            LastName = newLastName;
    }
}
