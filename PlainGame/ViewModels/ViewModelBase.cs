using ReactiveUI;

namespace PlainGame.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public ViewModelBase()
        {
            var game = new Game();
            game.Run();
        }
    }
}