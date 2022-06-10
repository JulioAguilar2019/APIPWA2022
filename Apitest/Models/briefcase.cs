using System;
using System.ComponentModel.DataAnnotations;

namespace Apitest.Models
{
    public class briefcase

    {
        [Key]
        public int bc_id { get; set; }

        public string proyect_name { get; set; }

        public string proyect_rol { get; set; }

        public string summary { get; set; }

        public string responsabilities { get; set; }

        public string used_tech { get; set; }
        public Nullable<int> user_id { get; set; }
        public virtual users users { get; set; }
    }
}
