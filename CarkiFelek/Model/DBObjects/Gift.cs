﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarkiFelek.Model.DBObjects
{
    public class Gift
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string GiftName { get; set; }
        public int Possibility { get; set; }
        public bool CanGetPoint { get; set; }
    }
}
