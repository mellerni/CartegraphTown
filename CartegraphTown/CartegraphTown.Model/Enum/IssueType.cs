namespace CartegraphTown.Model.Enum
{
    using System.ComponentModel;
    
    /// <summary>
    /// Enum of the most common citizen complaints
    /// </summary>
    public enum IssueType
    {
        [Description("")]
        None = 0,

        [Description("Abandoned or Inoperable Vehicle")]
        AbandonedOrInoperableVehicle = 1,

        [Description("Abandoned or Unsafe Structure")]
        AbandonedOrUnsafeStructure = 2,

        [Description("Animal Control")]
        AnimalControl = 3,

        [Description("Fire Hazard")]
        FireHazard = 4,

        [Description("Health Inspector")]
        HealthInspector = 5,

        [Description("Noise")]
        Noise = 6,

        [Description("Open Burning")]
        OpenBurning = 7,

        [Description("Parking Violation")]
        ParkingViolation = 8,

        [Description("Peeling Paint")]
        PeelingPaint = 9,

        [Description("Pest Control")]
        PestControl = 10,

        [Description("Private - Landscape Maintenance")]
        PrivateLandscapeMaintenance = 11,

        [Description("Property Loss")]
        PropertyLoss = 12,

        [Description("Public - Landscape Maintenance")]
        PublicLandscapeMaintenance = 13,

        [Description("Public Right of Way Obstruction")]
        PublicRightOfWayObstruction = 14,

        [Description("Sewer Maintenance")]
        SewerMaintenance = 15,

        [Description("Sidewalk Condition")]
        SidewalkCondition = 16,

        [Description("Stagnant Water or Green Pool")]
        StagnantWaterOrGreenPool = 17,

        [Description("Street Condition")]
        StreetCondition = 18,

        [Description("Street Lights")]
        StreetLights = 19,

        [Description("Street Sign")]
        StreetSign = 20,

        [Description("Trash or Debris")]
        TrashOrDebris = 21,

        [Description("Unpermitted Structure, Addition, or Alteration")]
        UnpermittedStructureOrAlteration = 22,

        [Description("Unsafe Rental Conditions")]
        UnsafeRentalConditions = 23,

        [Description("Broken or Unsecure Fence")]
        UnsecureFence = 24,

        [Description("Vandalism")]
        Vandalism = 25,

        [Description("Water Maintenance")]
        WaterMaintenance = 26,

        [Description("Other")]
        Other = 27,
    }
}
