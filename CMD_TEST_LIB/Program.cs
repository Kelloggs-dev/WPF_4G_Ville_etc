using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LIB_EMETTEUR_4G;

namespace CMD_TEST_LIB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                C_BASE La_Base = new C_BASE();
                La_Base.Charge_Data();

                //var Les_Emetteur = La_Base.Get_All_Emetteur();
                //for (int Index = 0; Index < Les_Emetteur.Count; Index++)
                //{
                //    Console.WriteLine(Les_Emetteur[Index]);
                //}

                //var Les_Emetteur_2 = La_Base.Get_Emetteur_By_Code_Postal("13200");
                //for (int Index = 0; Index < Les_Emetteur_2.Count; Index++)
                //{
                //    Console.WriteLine(Les_Emetteur_2[Index]);
                //}

                var Les_Region = La_Base.Get_All_Region();

                for (int Index = 0; Index < Les_Region.Count; Index++)
                {
                    Console.WriteLine(Les_Region[Index]);
                }

                //var Les_Emetteur_3 = La_Base.Get_Emetteur_By_Code_Departement("13");
                //for (int Index = 0; Index < Les_Emetteur_3.Count; Index++)
                //{
                //    Console.WriteLine(Les_Emetteur_3[Index]);
                //}

            }
            catch (Exception P_Erreur)
            {

                Console.WriteLine(P_Erreur.Message);
            }
        }
    }
}
