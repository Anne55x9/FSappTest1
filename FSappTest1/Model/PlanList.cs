using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace FSappTest1.Model
{
    public class PlanList : ObservableCollection<Plan>
    {
        public PlanList()
            :base() 
        {
            this.Add(new Plan() {ChefKok = "Martin", Help1 = "Frank", Help2 = "Ted", Help3 = "Hui", Clean1 = "Flemming", Clean2 = "Anne", Clean3 = "Karl", Clean4 = "Poul"});
        }

        public string GetJsonPlan()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }

        /// <summary>
        /// Metode som konverterer json syntax til chsharp - en form for genindlæsning af det gemte. 
        /// </summary>
        /// <param name="jsonPlan"></param>

        public void InsertJson(string jsonPlan)
        {
            List<Plan> nyListePlan = JsonConvert.DeserializeObject<List<Plan>>(jsonPlan);
            foreach (var Plan in nyListePlan)
            {
                this.Add(Plan);
            }
        }

    }
}
