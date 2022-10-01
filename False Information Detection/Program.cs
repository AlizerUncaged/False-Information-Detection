namespace AI
{
    /// <summary>
    /// An AI for detecting false news using machine learning
    /// algorithms.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main entry point of the program.
        /// </summary>
        public async Task StartAsync()
        {

        }

        static void Main(string[] args) => new Program()
            .StartAsync()
            .GetAwaiter()
            .GetResult();
    }
}