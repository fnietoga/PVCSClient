using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace PVCSClient.Libraries
{
    public class PVCSFileLabel
    {
        public string Descripcion { get; set; }
        public string Environment { get; set; }
        public DateTime? Date { get; set; }
        public string Version { get; set; }

        public PVCSFileLabel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <example>->Promocionado a SIT2: 05/11/2016 14:30:19.......... rev: 1.2</example>
        /// <example>->Version PROD...................................... rev: 1.8</example>
        /// <example>->Promocionado a TST1 05/01/2017 a las 125032 en 232 rev: 1.7</example>
        /// <param name="input"></param>
        public PVCSFileLabel(string input) : this()
        {
            //Toma el texto completo como descripción
            this.Descripcion = input;

            //Busca el entorno
            this.Environment = input.ExtractString(@"\b(?:Promocionado a|Version)\s*(\w+)\b");
 
            //Extrae la fecha y hora
            this.Date = input.ExtractDateTime();

            //Busca la version
            this.Version = input.ExtractString(@"\brev:\s*(\d+.\d+)\b");
            //.*?= Cualquier texto, \s?= espacio opcional, \d+ = numerico con uno o varios digitos
        }
    }

}