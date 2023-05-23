using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingDataLibrary
{
    public abstract class BaseClass
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; private set; } = DateTime.Now;
    }
}
