using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PetBoarding.Models
{
    public class PetBoarding
    {
        [Required]
        //This code allows to create attributes and behaviours for petboarding website.
        public long id { get; set; }
        [Required]
        //This code allows to generate labels and textboxes for the model.
        [DisplayName("Animal")]
        public string Animal { get; set; }
        [Required]
        [DisplayName("Species")]
        public string Species { get; set; }
        [Required]
        [DisplayName("Age")]
        public string Age { get; set; }
        [Required]
        [DisplayName("Country")]
        public string Country { get; set; }
        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Postcode")]
        public string Postcode { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [Required]
        public Boolean Approved { get; set; }
        public string Description { get; set; }

    }
}