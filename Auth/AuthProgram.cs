namespace Auth
{
    internal sealed class AuthProgram
    {
        public static void Main(string[] args)
        {
            new AuthHost(args).Run();
        }
    }
}