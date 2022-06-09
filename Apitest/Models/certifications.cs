using System;
using System.ComponentModel.DataAnnotations;
namespace Apitest.Models
{
    public class certifications
    {
        [Key]

        public int cert_id { get; set; }

        public string cert_name { get; set; }

        public string cert_institution { get; set; }

        public string cert_description { get; set; }

        public string cert_link { get; set; }
        public Nullable<int> user_id { get; set; }
    }
}
