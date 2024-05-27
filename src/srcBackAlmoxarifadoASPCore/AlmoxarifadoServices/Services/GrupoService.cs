using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AlmoxarifadoServices.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.Services
{
    public class GrupoService : ServiceModelCR<Grupo>
    {
        public GrupoService(RepositoryModelCR<Grupo> repository) : base(repository)
        {
        }



    }

    //public class GrupoService:IServiceCR<Grupo>
    //{
    //    private readonly IRepositoryCR<Grupo> _grupoRepository;
    //    //private readonly MapperConfiguration configurationMapper;
    //    private DTO<Grupo> dto;

    //    public GrupoService(IRepositoryCR<Grupo> pGrupoRepository)
    //    {
    //        dto = new DTO<Grupo>();
    //        _grupoRepository = pGrupoRepository;
    //        //configurationMapper = new MapperConfiguration(cfg =>
    //        //{
    //        //    cfg.CreateMap<Grupo, DTO<Grupo>>();
    //        //    cfg.CreateMap<DTO<Grupo>, Grupo>();
    //        //});
    //    }

    //    public List<GrupoGetDTO> ObterTodos()
    //    {
    //        var mapper = configurationMapper.CreateMapper();


    //        return mapper.Map<List<GrupoGetDTO>>(_grupoRepository.ObterTodos());
    //    }

    //    public Grupo ObterRegistroPorID(int id)
    //    {
    //        return _grupoRepository.ObterRegistroPorId(id);
    //    }

    //    public GrupoGetDTO CriarRegistro(GrupoPostDTO grupo)
    //    {
    //        var grupoSalvo = _grupoRepository.CriarRegistro(
    //             new Grupo { NOME_GRU = grupo.NOME_GRU, SUGESTAO_GRU = grupo.SUGESTAO_GRU }
    //          );

    //        return new GrupoGetDTO
    //        {
    //            ID_GRU = grupoSalvo.ID_GRU,
    //            NOME_GRU = grupoSalvo.NOME_GRU,
    //            SUGESTAO_GRU = grupoSalvo.SUGESTAO_GRU
    //        };
    //    }

    //    List<DynamicMetaObject> IServiceCR<Grupo>.ObterTodos()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public DynamicMetaObject CriarRegistro(DynamicMetaObject n)
    //    {
    //        var grupoSalvo = _grupoRepository.CriarRegistro(
    //             new Grupo { NOME_GRU = grupo.NOME_GRU, SUGESTAO_GRU = grupo.SUGESTAO_GRU }
    //          );

    //        DTO<Grupo> newDTO = new DTO<Grupo>( grupoSalvo );
    //        return newDTO.DTOGet();
    //    }
    //}
}
