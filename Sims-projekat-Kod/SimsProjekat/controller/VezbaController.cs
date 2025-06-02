using SismProjekat.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace SimsProjekat.controller
{
    public class VezbaController
    {
        string putanjaDoJson = AppDomain.CurrentDomain.BaseDirectory + @"data\vezbe.json";


        public List<Vezba> DobaviSveVezbe()
        {
            if (!File.Exists(putanjaDoJson))
            {
                MessageBox.Show($"Fajl nije pronadjen");
                return new List<Vezba>();
            }

            string json = File.ReadAllText(putanjaDoJson);
            return JsonConvert.DeserializeObject<List<Vezba>>(json);
        }
    }
}
