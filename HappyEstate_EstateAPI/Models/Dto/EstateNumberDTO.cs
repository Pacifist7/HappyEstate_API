﻿using System.ComponentModel.DataAnnotations;

namespace HappyEstate_EstateAPI.Models.Dto
{
    public class EstateNumberDTO
    {

        [Required]
        public int EstateNo { get; set; }
        [Required]
        public int EstateID { get; set; }
        public string SpecialDetails { get; set; }
    }
}
