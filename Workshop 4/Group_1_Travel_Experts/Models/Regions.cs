using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 * This app helps doing CRUD operations with the select tables of the 'TravelExperts' database.
 * This entity was created by Entity Framework Core using Database First 
 * Author: Entity Framework Core
 * SAIT, OOSD course, CPRG-207 - Threaded Project (Part 2), Workshop #4 - C#.NET, Group 1
 * When: January-February 2022
 */

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Group_1_Travel_Experts.Models
{
    public partial class Regions
    {
        public Regions()
        {
            BookingDetails = new HashSet<BookingDetails>();
        }

        [Key]
        [StringLength(5)]
        public string RegionId { get; set; }
        [StringLength(25)]
        public string RegionName { get; set; }

        [InverseProperty("Region")]
        public virtual ICollection<BookingDetails> BookingDetails { get; set; }
    }
}
