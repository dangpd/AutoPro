﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoPro.Common.Attributes.Attributes;

namespace AutoPro.Common.Entities
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [ContactNameNotEmpty]
        public string? ContactName { get; set; }

        [ContactEmailNotEmpty]
        public string? ContactEmail { get; set; }

        [ContactPhoneNotEmpty]
        public string? ContactPhone { get; set; }

        [ContactContentNotEmpty]
        public string? ContactContent { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
