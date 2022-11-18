﻿using RentalCarSystem.Infrastructure.Entities.Enum.Car;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarSystem.Infrastructure.Entities
{
    public class Car
    {
        public int Id { get; set; } 

        [Required]
        [MaxLength(8)]
        public string RegNumber { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string Model { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string Make { get; set; } = null!;

        [Required]
        public int MakeYear { get; set; } 

        [Required]
        [MaxLength(20)]
        public string Color { get; set; } = null!;

        [Required]
        [MaxLength(5000)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public GearBox GearBox { get; set; }

        [Required]
        public decimal DailyRate { get; set; }

        [Required]
        public bool IsAvailable { get; set; } = true;

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        public int LocationId { get; set; }

        [ForeignKey(nameof(LocationId))]
        public Location Location { get; set; } = null!;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
