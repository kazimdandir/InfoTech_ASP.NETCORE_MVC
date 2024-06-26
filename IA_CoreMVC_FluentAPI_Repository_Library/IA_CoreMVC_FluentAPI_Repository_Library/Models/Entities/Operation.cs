﻿using System.ComponentModel.DataAnnotations;

namespace IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities
{
    public class Operation
    {
        public int OperationID { get; set; }

        [Display(Name = "Student")]
        public int? StudentID { get; set; }

        [Display(Name = "Book")]
        public int? BookID { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Purchase date cannot be left blank!")]
        public DateTime? PurchaseDate{ get; set; }

        [Display(Name = "Delivery Date")]
        [DataType(DataType.Date)]
        public DateTime? DeliveryDate{ get; set; }

        public bool? IsDelivered { get; set; }

        public virtual Book? Book { get; set; }
        public virtual Student? Student { get; set; }
    }
}
