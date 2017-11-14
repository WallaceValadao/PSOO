namespace PSOO.Dominio
{
    public class Perfil : IEntidade
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public void tracarPerfil() { }
    }
}
