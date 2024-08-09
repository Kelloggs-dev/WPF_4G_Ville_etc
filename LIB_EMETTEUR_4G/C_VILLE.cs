using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_EMETTEUR_4G
{
    public class C_VILLE
    {
        public int id { get; set; }
        public string department_code { get; set; }
        public string insee_code { get; set; }
        public string zip_code { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public double gps_lat { get; set; }
        public double gps_lng { get; set; }
    }
}
