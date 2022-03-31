using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace PlanHPP.Models
{
    public class Motor
    {
        
        public string Name { get; set; }
        public string Switch { get; set; }
        public int ID { get; set; }
        public int Indicator { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public List<Comment> Comments { get; set; }
        public int DoSwitch { get; set; }
        public int DoGround { get; set; }
        public int DodisconnectedCable { get; set; }



    }
}

