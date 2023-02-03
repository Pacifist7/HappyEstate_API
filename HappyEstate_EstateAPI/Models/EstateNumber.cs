﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyEstate_EstateAPI.Models
{
    public class EstateNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EstateNo { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
