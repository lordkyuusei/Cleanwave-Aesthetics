using System.Collections.Generic;

namespace Cleanwave.Domain.Entities
{
    public class CHILLWAVE_ARTIST
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public List<CHILLWAVE_ALBUM> ALBUMS { get; set; }
    }
}
