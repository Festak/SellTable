﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SellTables.Models
{
    public class Medal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public string Description { get; set; }
        public string ImageUri { get; set; }
    }
}