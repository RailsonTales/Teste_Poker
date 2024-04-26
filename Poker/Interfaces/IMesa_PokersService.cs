using Poker.Entities;

namespace Poker.Interfaces
{
    public interface IMesa_PokersService
    {
        public int Criar_uma_Mesa_de_Poker(string name);
        public string Adicionar_um_Usuario_a_Mesa(int user_id, int table_id);
        public User Simular_um_Ganhador(int table_id);
    }
}
