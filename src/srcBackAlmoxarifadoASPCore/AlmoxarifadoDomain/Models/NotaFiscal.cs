using AlmoxarifadoDomain.ClassesAbstratas;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoDomain.Models
{
    public class NotaFiscal:Modelo<NotaFiscal>
    {
        [KeyDB]
        public int ID_NOTA { get; set; }
        [KeyDB]
        public int ID_TIPO_NOTA { get; set; }

        public int ID_FOR { get; set; }
        public int ID_SEC { get; set; }
        public String NUM_NOTA { get; set; }
        public SqlMoney VALOR_NOTA { get; set;}
        public int QTD_ITEM { get; set; }
        public int ICMS {  get; set; }
        public int ISS {  get; set; }
        public int ANO {  get; set; }
        public int MES { get; set; }
        public DateTime DATA_NOTA { get; set; }
        public string OBSERVACAO_NOTA { get; set;}
        public string EMPENHO_NUM  { get; set;}

    }
}
