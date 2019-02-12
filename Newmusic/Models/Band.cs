using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newmusic.Models
{
    public class Band
    {
        [Key]
        public int Id { get; set; }

        public string BandName { get; set; }

        public string RequestId { get; set; }

        public string Genre { get; set; }

        public int BandSize { get; set; }

        public string Experience { get; set; }

        public string Bio { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



        //[NotMapped]
        //public List<BandMember> BandMembers { get; set; }

        //public IList<BandMemberBand> BandMemberBands { get; set; }
        //public ICollection<Reservation> Reservations { get; set; }


    }
}
