using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMockExam.Model
{
    public class Temp
    {
        public int Id { get; set; }
        public decimal Humidity { get; set; }
        public decimal Temperatur { get; set; }
        public decimal Pressure { get; set; }
        public DateTime TimeStamp { get; set; }

        public Temp(int id, decimal humidity, decimal temperatur, decimal pressure, DateTime timeStamp)
        {
            Id = id;
            Humidity = humidity;
            Temperatur = temperatur;
            Pressure = pressure;
            TimeStamp = timeStamp;
        }

        public Temp()
        {
        }

        public override string ToString()
        {
            return Id + " " + Humidity + " " + Temperatur + " " + Pressure + " " + TimeStamp + " ";
        }
    }
}
