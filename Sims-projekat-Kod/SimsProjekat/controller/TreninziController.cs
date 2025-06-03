using Newtonsoft.Json;
using SismProjekat.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimsProjekat.controller
{
    public class TreninziController
    {
        //putanja do bin/debug/data/treninzi.json
        //private string putanjaDoJson = AppDomain.CurrentDomain.BaseDirectory + @"data\treninzi.json";
        //putanja do data/treninzi.json
        private readonly string putanjaDoJson = Path.Combine(Application.StartupPath, @"..\..\data\treninzi.json");

        private List<Trening> treninzi;

        private static readonly JsonSerializerSettings jsonSettongs= new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            Formatting = Formatting.Indented
        };

        public TreninziController()
        {
            treninzi = UcitajTreninge();
        }

        private List<Trening> UcitajTreninge()
        {
            if(!File.Exists(putanjaDoJson))
            {
                return new List<Trening>();
            }
            try
            {
                string json = File.ReadAllText(putanjaDoJson);
                var lista= JsonConvert.DeserializeObject<List<Trening>>(json, jsonSettongs);
                return lista ?? new List<Trening>();
                
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom ucitavanja treninga: " + ex.Message);
                return new List<Trening>();
            }
        }
        public List<Trening> DobaviSveTreninge()
        {
            return treninzi;
        }

        public void DodajTrening(Trening trening)
        {
            if (trening == null) return;

            treninzi.Add(trening);
            SacuvajTreninge();
        }

        public void ObrisiTrening(Trening trening)
        {
            if (trening == null) return;

            treninzi.Remove(trening);
            SacuvajTreninge();
        }

        public void IzmeniTrening(Trening startTrening, Trening izmenjenTrening)
        {
            if (startTrening == null|| izmenjenTrening==null) return;

            int index=treninzi.IndexOf(startTrening);
            if (index != -1)
            {
                treninzi[index] = izmenjenTrening;
                SacuvajTreninge();
            }
        }

        public void SacuvajTreninge()
        {
            try
            {
                string json = JsonConvert.SerializeObject(treninzi, jsonSettongs);
                File.WriteAllText(putanjaDoJson, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska prilikom cuvanja trening: "+ ex.Message);
            }
        }
    }
}
