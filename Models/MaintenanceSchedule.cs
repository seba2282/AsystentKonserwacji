using System;

namespace AsystentKonserwacji.Models
{
    public class MaintenanceSchedule
    {
        public int Id { get; set; }
        public int LubricationPointId { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public DateTime NextMaintenanceDate { get; set; }

        public LubricationPoint? LubricationPoint { get; set; }
    }
}