using System.ComponentModel.DataAnnotations;

namespace Apitest.Models
{
    public class users
    {
        [Key]
        public int user_id { get; set; }


        public string user_name { get; set; }

        public string user_photo { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string email { get; set; }

        public string social_net { get; set; }

        public string introduction { get; set; }
        public string grade { get; set; }

        public string profession { get; set; }

        public string university { get; set; }

        public string grade_obj { get; set; }

    }
}
