namespace PSOO.Dominio
{
    public class Contato : IEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Usuario Usuario { get; }
        public byte[] Foto { get; set; }
        public int Numero { get; set; }
    }
}
