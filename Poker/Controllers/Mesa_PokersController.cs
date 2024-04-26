using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Poker.Entities;
using Poker.Interfaces;

namespace Poker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Mesa_PokersController : ControllerBase
    {
        private readonly IMesa_PokersService _mesa_PokersService;

        public Mesa_PokersController(IMesa_PokersService mesa_PokersService)
        {
            _mesa_PokersService = mesa_PokersService;
        }

        [HttpPost("Criar_uma_Mesa_de_Poker")]
        [Authorize]
        public int Criar_uma_Mesa_de_Poker(string name)
        {
            return _mesa_PokersService.Criar_uma_Mesa_de_Poker(name);
        }

        [HttpPost("Adicionar_um_Usuario_a_Mesa")]
        [Authorize]
        public string Adicionar_um_Usuario_a_Mesa(int user_id, int table_id)
        {
            return _mesa_PokersService.Adicionar_um_Usuario_a_Mesa(user_id, table_id);
        }

        [HttpPost("Simular_um_Ganhador")]
        [Authorize]
        public User Simular_um_Ganhador(int table_id)
        {
            return _mesa_PokersService.Simular_um_Ganhador(table_id);
        }
    }
}
