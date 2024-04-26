using Poker.Entities;
using Poker.Interfaces;
using System;

namespace Poker.Services
{
    public class Mesa_PokersService : AppDbContext, IMesa_PokersService
    {
        public readonly AppDbContext _context;
        public readonly ApiContext _apiContext;        

        public Mesa_PokersService(AppDbContext context, ApiContext apiContext)
        {
            _context = context;
            _apiContext = apiContext;
        }

        public int Criar_uma_Mesa_de_Poker(string name)
        {
            try
            {
                using (var apiContextInMemory = new ApiContext())
                {
                    var table_id = 0;
                    var mesas = apiContextInMemory.Mesas.LastOrDefault();

                    if (mesas != null)
                        table_id = mesas.Table_id + 1;
                    else
                        table_id = 1;

                    var l_user_id = new List<int>();
                    Mesa mesa = new Mesa(l_user_id, table_id);
                    
                    apiContextInMemory.Mesas.Add(mesa);
                    apiContextInMemory.SaveChanges();

                    return mesa.Table_id;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Adicionar_um_Usuario_a_Mesa(int user_id, int table_id)
        {
            using (var apiContextInMemory = new ApiContext())
            {
                var users = apiContextInMemory.Users.Where(x => x.UserId == user_id).ToList().FirstOrDefault();

                if (users == null)
                    return "Usuário não encontrado";

                var mesas = apiContextInMemory.Mesas.Where(x=>x.Table_id == table_id).ToList();

                if (mesas.Count > 0)
                {
                    foreach (var item in mesas)
                    {
                        if (item.User_id.Count < 8)
                        {
                            if (!item.User_id.Contains(user_id))
                            {
                                item.User_id.Add(user_id);
                                apiContextInMemory.SaveChanges();
                            }
                            else
                                return "Usuário já adiconado a mesa, tente outro!";
                        }
                        else
                        {
                            return "mesa: " + table_id + " cheia";
                        }
                    }
                }
                else
                    return "Mesa não encontrada";
            }

            return "Usuário adicionado a mesa: " + table_id + " com sucesso";
        }

        public User Simular_um_Ganhador(int table_id)
        {
            using (var apiContextInMemory = new ApiContext())
            {
                int resultado = 0;
                var mesa = apiContextInMemory.Mesas.Where(x => x.Table_id == table_id).FirstOrDefault();
                Random rand = new Random(DateTime.Now.Millisecond);

                if (mesa != null)
                {
                    if (mesa.User_id.Count >= 1)
                    {
                        resultado = mesa.User_id[rand.Next(mesa.User_id.Count)];
                    }
                }

                if (resultado == 0)
                {
                    var user = new User(1, "Nenhum ganhador, mesa inexistente ou vazia", "12997497103", "password");
                    return user;
                }
                else
                {
                    var user = apiContextInMemory.Users.Where(x => x.UserId == resultado).ToList().FirstOrDefault();
                    return user;
                }
            }
        }
    }
}
