using System;
using System.ComponentModel.DataAnnotations;

namespace Apitest.Models
{
    public class work_experience
    {
        [Key]
        public int work_exp_id { get; set; }

        public string work_exp_description { get; set; }

        public Nullable<System.DateTime> date_init { get; set; }

        public Nullable<System.DateTime> date_fin { get; set; }
        public Nullable<int> user_id { get; set; }

    }
}
