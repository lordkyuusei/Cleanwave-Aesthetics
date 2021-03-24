using System.Collections.Generic;

namespace Cleanwave.Domain.Entities
{
    public class CHILLWAVE_ALBUM
    {
        public int ID { get; set; }
        public int ID_ARTIST { get; set; }
        public string TITLE { get; set; }
        public List<CHILLWAVE_SONG> SONGS { get; set; }
    }
}
