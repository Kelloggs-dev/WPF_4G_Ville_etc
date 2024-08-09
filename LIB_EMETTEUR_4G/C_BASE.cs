using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace LIB_EMETTEUR_4G
{
    public class C_BASE
    {
        const string Mon_Fichier_Emetteur = "Emetteurs_Reduits_2023.json";
        const string Mon_Fichier_Ville = "cities.json";
        const string Mon_Fichier_Departement = "departments.json";
        const string Mon_Fichier_Region = "regions.json";
        List<C_EMETTEUR> Les_Emetteurs;
        List<C_VILLE> Les_Villes;
        List<C_DEPARTEMENT> Les_Departements;
        List<C_REGION> Les_Regions;

        public void Charge_Data()
        {
            string Data_Emetteur = File.ReadAllText(Mon_Fichier_Emetteur);
            Les_Emetteurs = JsonSerializer.Deserialize<List<C_EMETTEUR>>(Data_Emetteur);
            string Data_Ville = File.ReadAllText(Mon_Fichier_Ville);
            Les_Villes = JsonSerializer.Deserialize<List<C_VILLE>>(Data_Ville);
            string Data_Departement = File.ReadAllText(Mon_Fichier_Departement);
            Les_Departements = JsonSerializer.Deserialize<List<C_DEPARTEMENT>>(Data_Departement);
            string Data_Region = File.ReadAllText(Mon_Fichier_Region);
            Les_Regions = JsonSerializer.Deserialize<List<C_REGION>>(Data_Region);
        }
        public List<C_EMETTEUR> Get_All_Emetteur()
        {
            return Les_Emetteurs;
        }

        public List<C_REGION> Get_All_Region()
        {
            return Les_Regions;
        }

        public List<C_DEPARTEMENT> Get_All_Departement()
        {
            return Les_Departements;
        }

        public List<C_VILLE> Get_All_Villes()
        {
            return Les_Villes;
        }

        public List<C_DEPARTEMENT> Get_Departement_By_Code_Region(string P_Code)
        {
            var Departement_Choisi = new List<C_DEPARTEMENT>();
            foreach (var Le_Departement in Les_Departements)
            {
                if (Le_Departement.region_code == P_Code)
                {
                    Departement_Choisi.Add(Le_Departement);
                }
            }

            return Departement_Choisi;
        }

        public List<C_VILLE> Get_Ville_By_Code_Departement(string P_Code)
        {
            var Villes_Choisi = new List<C_VILLE>();
            foreach (var La_Ville in Les_Villes)
            {
                if (La_Ville.department_code == P_Code)
                {
                    Villes_Choisi.Add(La_Ville);
                }
            }

            return Villes_Choisi;
        }

        public List<C_EMETTEUR> Get_Emetteur_By_Code_Postal(string P_Code)
        {
            List<C_EMETTEUR> Les_antenne = new List<C_EMETTEUR>();
            foreach (var Un_Emetteur in Les_Emetteurs)
            {
                if (Un_Emetteur.CP == P_Code)
                {
                    Les_antenne.Add(Un_Emetteur);
                }
            }
            return Les_antenne;
        }

        public List<C_EMETTEUR> Get_Emetteur_By_Code_Departement(string P_Code)
        {
            var Un_Emetteur = new List<C_EMETTEUR>();
            foreach (var Une_Antenne in Les_Emetteurs)
            {
                if (Une_Antenne.Dpt == P_Code)
                {

                    Un_Emetteur.Add(Une_Antenne);

                }
            }
            return Un_Emetteur;
        }

       
    }
}
