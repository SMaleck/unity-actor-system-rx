namespace ActorSystem.Views
{
    public interface IActorView
    {
        IMonoActor MonoActor { get; }
        IPartialActorView[] PartialViews { get; }
    }
}
