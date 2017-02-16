using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class IP_Tickets
    {
        [Column(Name = "id")]
        [Display(Name = "ID")]
        public Nullable<int> id { get; set; }

        [Column(Name = "ref")]
        [Display(Name = "Referencia")]
        public string reference { get; set; }

        [Column(Name = "title")]
        [Display(Name = "Título")]
        public string title { get; set; }

        [Column(Name = "description")]
        [Display(Name = "Descripción")]
        public string description { get; set; }

        [Column(Name = "caller_id_friendlyname")]
        [Display(Name = "Reportado por")]
        public string caller_id_friendlyname { get; set; }

        [Column(Name = "agent_id_friendlyname")]
        [Display(Name = "Técnico")]
        public string agent_id_friendlyname { get; set; }

        [Column(Name = "functionalci_id_friendlyname")]
        [Display(Name = "Equipo")]
        public string functionalci_id_friendlyname { get; set; }

        [Column(Name = "start_date")]
        [Display(Name = "Fecha inicio")]
        public Nullable<DateTime> start_date { get; set; }

        [Column(Name = "assignment_date")]
        [Display(Name = "Fecha asignación")]
        public Nullable<DateTime> assignment_date { get; set; }

        [Column(Name = "resolution_date")]
        [Display(Name = "Fecha solución")]
        public Nullable<DateTime> resolution_date { get; set; }

        [Column(Name = "pending_reason")]
        [Display(Name = "Motivos de espera")]
        public string pending_reason { get; set; }

        [Column(Name = "solution")]
        [Display(Name = "Solución")]
        public string solution { get; set; }

        [Column(Name = "status")]
        [Display(Name = "Estado (iTop)")]
        public string status { get; set; }

        [Column(Name = "private_log")]
        [Display(Name = "Bitácora")]
        public string private_log { get; set; }

        [Column(Name = "time_spent")]
        [Display(Name = "Tiempo total")]
        public Nullable<Double> time_spent { get; set; }

        [Column(Name = "cumulatedpending_timespent")]
        [Display(Name = "Tiempo espera acumulado")]
        public Nullable<Double> cumulatedpending_timespent { get; set; }

        [Column(Name = "effective_timespent")]
        [Display(Name = "")]
        public Nullable<Double> effective_timespent { get; set; }

        public Double elapsedhours
        {
            get
            {
                Nullable<Double> eh = effective_timespent / 3600;
                return eh != null ? eh.Value : 0D;
            }
        }
    }
}
