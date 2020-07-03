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
    }
}
