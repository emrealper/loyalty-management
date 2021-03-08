using Application.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
  
        public class MachineDateTime : IDateTime
        {
            public DateTime Now => DateTime.Now;

          
        }
    
}
