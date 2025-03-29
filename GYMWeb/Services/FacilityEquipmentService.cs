using System;

namespace GYMWeb.Services
{
    public class FacilityEquipmentService
    {
        public bool RecordMaintenanceCheck(string equipmentId, string conditionNotes)
        {
            return !string.IsNullOrWhiteSpace(equipmentId);
        }
    }
}
