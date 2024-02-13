using API_Roteiriza.Models;

namespace API_Roteiriza.Repositories.IRepositories
{
    public interface IUserRepositorie
    {
        Task<UserModel> Cadastrar(UserModel usuario);

        Task<UserModel> ProcuarUsuarioPorId(int id);

        Task<List<UserModel>> VisualizarUsuarios();


        Task<UserModel> AtualizarUsuario(UserModel user, int id);

        Task<bool> DeletarUsuario(int id);

        Task<CardTravelModel> BuscarViagem(int idUser, int idTravel);

    }
}
