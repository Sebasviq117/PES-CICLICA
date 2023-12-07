using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class Notifi_Anticoncep
    {
        public int Notifi_ID { get; set; }
        public int Notifi_User_ID { get; set; }
        public int Notifi_Anti_Concep_ID { get; set; }
        public int? Notifi_Consj_ID { get; set; }
        public string Notifi_Descrip { get; set; }
        public Boolean Notifi_Estado { get;  set; }
        public DateTime Notifi_Start_Date { get; set; }
        public DateTime Notifi_Start_Time { get; set; }
        public DateTime? Notifi_Fecha_Final { get; set; }      
    }
    public class Anticoncep
    {
        public int Anti_Concep_ID { get; set; }
        public string Anti_Concep_Nombre { get; set; }
        public string Anti_Concep_Efectividad { get; set; }
    }
    public class Consejos
    {
        public int Consj_ID { get; set; }
        public int Consj_Consejo { get; set; }
    }
}
