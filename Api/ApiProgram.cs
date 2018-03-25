namespace Api
{
    internal sealed class ApiProgram
    {
        public static void Main(string[] args)
        {
            new ApiHost(args).Run();
        }
    }
}