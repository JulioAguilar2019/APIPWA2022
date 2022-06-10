using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Apitest.Models
{
    public class users
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public users()
        {
            this.briefcase = new HashSet<briefcase>();
            this.certifications = new HashSet<certifications>();
            this.skills = new HashSet<skills>();
            this.work_experience = new HashSet<work_experience>();
        }


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


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<briefcase> briefcase { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<certifications> certifications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<skills> skills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<work_experience> work_experience { get; set; }

    }
}
