using HappyEstate_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HappyEstate_Web.Models.VM
{
    public class EstateNumberUpdateVM
    {
        public EstateNumberUpdateDTO EstateNumber { get; set; }
        public EstateNumberUpdateVM()
        {
            EstateNumber = new EstateNumberUpdateDTO();
        }
        [ValidateNever]
        public IEnumerable<SelectListItem> EstateList { get; set; }
    }
}
