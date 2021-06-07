using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ABTestRealDB.Entities
{
    [Table("UserActivity", Schema = "ABTestReal")]
    public class UserActivity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        [Column(TypeName="Date")]
        public DateTime RegistrationDate { get; set; }
        
        [Column(TypeName="Date")]
        public DateTime LastActivityDate { get; set; }
    }
}
