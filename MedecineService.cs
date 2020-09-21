using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MedProject.Model
{
    public class MedecineService
    {
        string jsonFilePath = @"C:\Users\Developer\source\repos\MedProject\Med.json";
        public List<Medecine> GetMedecines()
        {
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                var jsonToreturn = JsonConvert.DeserializeObject<List<Medecine>>(json);
                return jsonToreturn;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool AddOrUpdateMedeCine(Medecine medecine)
        {
            try
            {
                List<Medecine> med = new List<Medecine>();
                string json = File.ReadAllText(jsonFilePath);
                med = JsonConvert.DeserializeObject<List<Medecine>>(json).ToList();
                var medecines = med.Where(a => a.MedecineName == medecine.MedecineName).FirstOrDefault();
                if (medecines == null)
                {
                    med.Add(medecine);
                }
                else
                {
                    int index = med.FindIndex(x => x.MedecineName == medecine.MedecineName);
                    med[index] = medecine;
                }

                string jsonToStore = JsonConvert.SerializeObject(med);
                System.IO.File.WriteAllText(jsonToStore, jsonToStore);
                return true;
            }
            catch(Exception ex )
            {
                throw ex;
            }
        }
    }
}
