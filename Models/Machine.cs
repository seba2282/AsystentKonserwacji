using System.Collections.Generic;

namespace AsystentKonserwacji.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<LubricationPoint>? LubricationPoints { get; set; }
    }
}