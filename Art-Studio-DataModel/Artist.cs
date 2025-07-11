using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Studio_DataModel
{
    public class Artist
    {
        public int ArtistId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }

        public string PhoneNumber { get; set; }

        public string MembershipStatus { get; set; }

        public string MembershipType { get; set; }

        public DateTime JoinDate { get; set; }

        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        public string PreferredMediums { get; set; }

        public string Notes { get; set; }
    }
}
