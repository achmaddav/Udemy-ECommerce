﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
	public class OrderDetail
	{
		public int ID { get; set; }
		public int OrderID { get; set; }

		[ForeignKey("OrderID")]
		[ValidateNever]
		public OrderHeader OrderHeader { get; set; }

        [Required]
        public int ProductID { get; set; }

		[ForeignKey("ProductID")]
		[ValidateNever]
		public Product Product { get; set; }

		public int Count { get; set; }
		public double Price { get; set; }
    }
}
