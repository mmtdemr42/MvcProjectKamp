using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Talent
    {
        [Key]
        public int TalentID { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(20)]

        public string Surname { get; set; }

        [StringLength(250)]
        public string ImagePath { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(20)]
        public string TalentName_1 { get; set; }
        public int TalentLevel_1 { get; set; }
        [StringLength(20)]
        public string TalentName_2 { get; set; }
        public int TalentLevel_2 { get; set; }
        [StringLength(20)]
        public string TalentName_3 { get; set; }
        public int TalentLevel_3 { get; set; }
        [StringLength(20)]
        public string TalentName_4 { get; set; }
        public int TalentLevel_4 { get; set; }
        [StringLength(20)]
        public string TalentName_5 { get; set; }
        public int TalentLevel_5 { get; set; }
        [StringLength(20)]
        public string TalentName_6 { get; set; }
        public int TalentLevel_6 { get; set; }
        [StringLength(20)]
        public string TalentName_7 { get; set; }
        public int TalentLevel_7 { get; set; }
        [StringLength(20)]
        public string TalentName_8 { get; set; }
        public int TalentLevel_8 { get; set; }
    }
}
