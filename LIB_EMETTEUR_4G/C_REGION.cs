﻿namespace LIB_EMETTEUR_4G
{
    public class C_REGION
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public override string ToString()
        {
            return $"{name}";
        }
    }
}
