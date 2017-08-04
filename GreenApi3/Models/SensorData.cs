using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenApi3.Models
{
    public class SensorData
    {
        public string LocationName { get; set; }
        public double Temperature { get; set; }
        public double SmokeLevel { get; set; }

        public double Proximity { get; set; }

        public string BatteryStatus { get; set; }

        public int isAlarming { get; set; }
    }
}