using AlmoxarifadoDomain.ClassesAbstratas;
using AlmoxarifadoServices.DTO;
using AlmoxarifadoServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers.Modelos
{
    [ApiController]
    public abstract class ControllerCRUD<T> : ControllerBase where T : Modelo<T>
    {
        protected ServiceModelCRUD<T> _Service;
        protected DTO<T> _dto;

       

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var grupos = _Service.ObterTodos();
                return Ok(grupos);
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.{e.Message}");
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetPorID(int id)
        {
            try
            {
                var grupo = _Service.ObterRegistroPorID(id);
                if (grupo == null)
                {
                    return StatusCode(404, "Nenhum Usuario Encontrado com Esse Codigo");
                }
                return Ok(grupo);
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.{e.Message}");
            }

        }

        [HttpPost]
        public IActionResult CriarGrupo(DTO<T> dto)
        {
            try
            {
                var grupoSalvo = _Service.CriarRegistro(dto);
                return Ok(grupoSalvo);
            }
            catch (Exception e )
            {

                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.{e.Message}");
            }
        }
    }
}

