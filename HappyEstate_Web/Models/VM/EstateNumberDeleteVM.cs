using HappyEstate_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HappyEstate_Web.Models.VM
{
    public class EstateNumberDeleteVM
    {
        public EstateNumberDTO EstateNumber { get; set; }
        public EstateNumberDeleteVM()
        {
            EstateNumber = new EstateNumberDTO();
        }
        [ValidateNever]
        public IEnumerable<SelectListItem> EstateList { get; set; }
    }
}
