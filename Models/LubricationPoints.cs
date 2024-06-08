using System;
using System.Collections.Generic;

namespace AsystentKonserwacji.Models
{
    public class LubricationPoint
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Interval { get; set; }

        public Machine Machine { get; set; }
        public ICollection<MaintenanceSchedule> MaintenanceSchedules { get; set; }
    }
}