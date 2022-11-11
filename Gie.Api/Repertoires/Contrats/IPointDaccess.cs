namespace Gie.Api.Repertoires.Contrats
{
    public interface IPointDaccess : IDisposable
    {
        IRepertoireDadresse RepertoireDadresse { get; }
        IRepertoireDetudiant RepertoireDetudiant { get; }
        IRepertoireDeNiveau RepertoireDeNiveau { get; }
        Task Enregistrer();
    }
}
