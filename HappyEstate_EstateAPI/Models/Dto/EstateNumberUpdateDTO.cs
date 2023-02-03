using System.ComponentModel.DataAnnotations;

namespace HappyEstate_EstateAPI.Models.Dto
{
    public class EstateNumberUpdateDTO
    {
        [Required]
        public int EstateNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}
