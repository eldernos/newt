
namespace Newt
{
    class NewtApp
    {
        static void Main(string[] args)
        {
            // Profiler.EnableAll();
            using (var game = new NewtGame())
            {
                game.Run();
            }
        }
    }
}
