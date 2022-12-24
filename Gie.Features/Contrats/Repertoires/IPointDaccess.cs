namespace Gie.Features.Contrats.Repertoires
{
    public interface IPointDaccess : IDisposable
    {
        IRepertoireDadresse RepertoireDadresse { get; }
        IRepertoireDetudiant RepertoireDetudiant { get; }
        IRepertoireDeNiveau RepertoireDeNiveau { get; }
        Task Enregistrer();
    }
}
