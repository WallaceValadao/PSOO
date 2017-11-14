using PSOO.Dominio.Enumeradores;

namespace PSOO.IDAO
{
    public interface IConexao
    {
        string ConnectionString { get; }
        string DefaultSchemaDB { get; }
        TipoBanco TipoBanco { get; }
        string NameSpaceMap { get; }
    }
}
