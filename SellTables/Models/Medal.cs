﻿
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SellTables.Models
{
    public class Medal
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUri { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }

        public Medal() {
            Users = new List<ApplicationUser>();
        }

    }
}