using HappyEstate_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HappyEstate_Web.Models.VM
{
    public class EstateNumberCreateVM
    {
        public EstateNumberCreateDTO EstateNumber { get; set; }
        public EstateNumberCreateVM()
        {
            EstateNumber = new EstateNumberCreateDTO();
        }
        [ValidateNever]
        public IEnumerable<SelectListItem> EstateList { get; set; }
    }
}
