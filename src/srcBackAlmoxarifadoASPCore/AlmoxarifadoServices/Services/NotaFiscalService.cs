using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices.DTO;
using AlmoxarifadoServices.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.Services
{
    public class NotaFiscalService : ServiceModelCRUD<NotaFiscal>
    {
        public NotaFiscalService(RepositoryModelCR<NotaFiscal> repository) : base(repository)
        {
        }
    }

    //public class NotaFiscalService: IServiceCRUD<NotaFiscal>
    //{
    //    private readonly IRepositoryCRUD<NotaFiscal> _NotaFiscalRepository;
    //    private readonly MapperConfiguration configurationMapper;

    //    public NotaFiscalService(IRepositoryCRUD<NotaFiscal> pNotaFiscalRepository)
    //    {
    //        _NotaFiscalRepository = pNotaFiscalRepository;
    //        configurationMapper = new MapperConfiguration(cfg =>
    //        {
    //            cfg.CreateMap<NotaFiscal, NotaFiscalGetDTO>();
    //            cfg.CreateMap<NotaFiscalGetDTO, NotaFiscal>();
    //        });
    //    }

    //    public List<NotaFiscalGetDTO> ObterTodos()
    //    {

    //        var mapper = configurationMapper.CreateMapper();
    //        return mapper.Map<List<NotaFiscalGetDTO>>(_NotaFiscalRepository.ObterTodos());

    //    }


    //    public NotaFiscal ObterRegistroPorID(int id)
    //    {


    //        return _NotaFiscalRepository.ObterRegistroPorId(id);
    //    }

    //    public NotaFiscalGetDTO CriarRegistro(NotaFiscalPostDTO n)
    //    {
    //        var RegistroSalvo = _NotaFiscalRepository.CriarRegistro(
    //             new NotaFiscal {
    //                 ID_TIPO_NOTA = n.ID_TIPO_NOTA,
    //                 ID_FOR = n.ID_FOR,
    //                 ID_SEC = n.ID_SEC,
    //                 NUM_NOTA = n.NUM_NOTA,
    //                 VALOR_NOTA = n.VALOR_NOTA,
    //                 QTD_ITEM = n.QTD_ITEM,
    //                 ICMS = n.ICMS,
    //                 ISS = n.ISS,
    //                 ANO = n.ANO,
    //                 MES = n.MES,
    //                 DATA_NOTA = n.DATA_NOTA,
    //                 OBSERVACAO_NOTA = n.OBSERVACAO_NOTA,
    //                 EMPENHO_NUM = n.EMPENHO_NUM
    //             }
    //          );

    //        return new NotaFiscalGetDTO
    //        {
    //            ID_NOTA = RegistroSalvo.ID_NOTA,
    //            ID_TIPO_NOTA = RegistroSalvo.ID_TIPO_NOTA,
    //            ID_FOR = RegistroSalvo.ID_FOR,
    //            ID_SEC = RegistroSalvo.ID_SEC,
    //            NUM_NOTA = RegistroSalvo.NUM_NOTA,
    //            VALOR_NOTA = RegistroSalvo.VALOR_NOTA,
    //            QTD_ITEM = RegistroSalvo.QTD_ITEM,
    //            ICMS = RegistroSalvo.ICMS,
    //            ISS = RegistroSalvo.ISS,
    //            ANO = RegistroSalvo.ANO,
    //            MES = RegistroSalvo.MES,
    //            DATA_NOTA = RegistroSalvo.DATA_NOTA,
    //            OBSERVACAO_NOTA = RegistroSalvo.OBSERVACAO_NOTA,
    //            EMPENHO_NUM = RegistroSalvo.EMPENHO_NUM
    //        };
    //    }

    //}
}
