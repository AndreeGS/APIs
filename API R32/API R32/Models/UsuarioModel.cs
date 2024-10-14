namespace API_R32.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public double Salario { get; set; }

        public double aumentarSalario (double valorAumento)
        {
            return Salario += valorAumento;
        }

        public double reduzirSalario(double valorReducao)
        {
            return Salario -= valorReducao;
        }

    }
}
