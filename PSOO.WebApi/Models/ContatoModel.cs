namespace PSOO.WebApi.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ContatoModel(int Id, string Nome)
        {
            this.Id = Id;
            this.Nome = Nome;
        }
    }
}