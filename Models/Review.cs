using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace reviews.Models
{
    public abstract class BaseEntity {}
    public class Review : BaseEntity
    {
        [Key]
        public int reviewid {get;set;}

        [MinLength(5)]
        [Required (ErrorMessage = "Please fill out field")]
        [Display(Name = "Name: ")]
        public string reviewer {get;set;}
        
        [Required]
        [Display(Name = "Restaurant: ")]
        public string restaurant {get;set;}

        [MinLength(10)]
        [Display(Name = "Review: ")]
        public string reviewtext {get;set;}

        [DataType(DataType.Date)]
        [InThePast(MinAge = 0, MaxAge = 150, ErrorMessage="Date of visit must be in the past")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [Required]
        public DateTime dateofvisit {get;set;}

        [Range(1,4)]
        [Required]        
        public int stars {get;set;}

    }
    // custom validation for checking DOB, 150 years ago to today
    public class InThePastAttribute : ValidationAttribute
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var val = (DateTime)value;

            if (val.AddYears(MinAge) > DateTime.Now)
                return false;

            return (val.AddYears(MaxAge) > DateTime.Now);
        }
    }

   
}