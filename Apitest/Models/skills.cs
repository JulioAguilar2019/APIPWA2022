using System;
using System.ComponentModel.DataAnnotations;
namespace Apitest.Models
{
    public class skills
    {
        [Key]
        public int skill_id { get; set; }

        public string skill_description { get; set; }
        public Nullable<int> user_id { get; set; }
        public virtual users users { get; set; }
    }
}
