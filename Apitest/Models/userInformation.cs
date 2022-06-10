using System;

namespace Apitest.Models
{
    public class userInformation
    {

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

        //briefcase

        public string proyect_name { get; set; }

        public string proyect_rol { get; set; }

        public string summary { get; set; }

        public string responsabilities { get; set; }

        public string used_tech { get; set; }

        //skills

        public string skill_description { get; set; }

        //certifications

        public string cert_name { get; set; }

        public string cert_institution { get; set; }

        public string cert_description { get; set; }

        public string cert_link { get; set; }

        //work experience

        public string work_exp_description { get; set; }

        public Nullable<System.DateTime> date_init { get; set; }

        public Nullable<System.DateTime> date_fin { get; set; }
    }
}
