using AlmoxarifadoAPI.Controllers.Modelos;
using AlmoxarifadoDomain.Models;
using AlmoxarifadoServices.Interfaces;
using AlmoxarifadoServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotaFiscalController : ControllerCRUD<NotaFiscal>
    {
        public NotaFiscalController(NotaFiscalService service)
        {
            _Service = service;
        }
    }
}
