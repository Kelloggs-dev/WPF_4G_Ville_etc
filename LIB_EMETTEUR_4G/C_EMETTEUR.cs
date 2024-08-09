using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_EMETTEUR_4G
{
    public class C_EMETTEUR
    {
        public int Id { get; set; }
        public string Adm { get; set; }
        public int Sup { get; set; }
        public string Sys { get; set; }
        public string Dpt { get; set; }
        public string CP { get; set; }
        public string Type { get; set; }
        public string Adr { get; set; }
        public double[] XY { get; set; }
        public string Etat { get; set; }

        public override string ToString()
        {
            return $"CP : {CP,10}   Departement : {Dpt,10}   Operateur : {Adm,20}  Type : {Type,5}   X :{XY[0],10}  Y : {XY[1],10}   Etat : {Etat,10}";
        }
    }
}
