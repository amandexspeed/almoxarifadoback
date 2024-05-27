using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    internal class NotaFiscalRepository : RepositoryModelCRUD<NotaFiscal>
    {
        private readonly ContextSQL _context;

        public NotaFiscalRepository(ContextSQL context)
        {

            _context = context;

        }

        public NotaFiscal CriarRegistro(NotaFiscal Registro)
        {
            _context.NotaFiscal.Add(Registro);
            _context.SaveChanges();
            return Registro;
        }

        public NotaFiscal DeletarRegistroPorId(int id)
        {
            NotaFiscal registro = ObterRegistroPorId(id);
            _context.NotaFiscal.Remove(registro);
            _context.SaveChanges();
            return registro;
        }

        public NotaFiscal ObterRegistroPorId(int id)
        {
            return _context.NotaFiscal
               .Select(n => new NotaFiscal
               {
                   ID_TIPO_NOTA = n.ID_TIPO_NOTA,
                   ID_FOR = n.ID_FOR,
                   ID_SEC = n.ID_SEC,
                   NUM_NOTA = n.NUM_NOTA,
                   VALOR_NOTA = n.VALOR_NOTA,
                   QTD_ITEM = n.QTD_ITEM,
                   ICMS = n.ICMS,
                   ISS = n.ISS,
                   ANO = n.ANO,
                   MES = n.MES,
                   DATA_NOTA = n.DATA_NOTA,
                   OBSERVACAO_NOTA = n.OBSERVACAO_NOTA,
                   EMPENHO_NUM = n.EMPENHO_NUM
               }
               ).ToList().First(x=> x?.ID_NOTA == id);
        }

        public List<NotaFiscal> ObterTodos()
        {
            return _context.NotaFiscal
                .Select(n => new NotaFiscal
                {
                    ID_NOTA = n.ID_NOTA,
                    ID_TIPO_NOTA = n.ID_TIPO_NOTA,
                    ID_FOR = n.ID_FOR,
                    ID_SEC = n.ID_SEC,
                    NUM_NOTA = n.NUM_NOTA,
                    VALOR_NOTA = n.VALOR_NOTA,
                    QTD_ITEM = n.QTD_ITEM,
                    ICMS = n.ICMS,
                    ISS = n.ISS,
                    ANO = n.ANO,
                    MES = n.MES,
                    DATA_NOTA = n.DATA_NOTA,
                    OBSERVACAO_NOTA = n.OBSERVACAO_NOTA,
                    EMPENHO_NUM = n.EMPENHO_NUM
                }
                ).ToList();
        }

        public NotaFiscal UpdateRegistro(NotaFiscal registro)
        {
            _context.NotaFiscal.Update( registro );
            _context.SaveChanges();
            return registro;
        }
    }
}
