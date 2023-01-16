using HappyEstate_EstateAPI.Models.Dto;

namespace HappyEstate_EstateAPI.Data
{
    public static class EstateStore
    {
        public static List<EstateDTO> estateList = new List<EstateDTO>
        {
            new EstateDTO { Id = 1, Name = "Pool View", Sqft=1000, Occupancy=4 },
            new EstateDTO { Id = 2, Name = "Beach View", Sqft=1300, Occupancy=3 }
        };
    }
}
