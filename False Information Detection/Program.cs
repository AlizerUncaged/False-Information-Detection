using False_Information_Detection;

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
            Console.Write("News Article Title: ");
            var title = Console.ReadLine();
            Console.Write("News Article Text: ");
            var text = Console.ReadLine();
            // Load sample data
            var sampleData = new FakeNewsConfiguration.ModelInput()
            {
                Title = title,
                Text = text,
            };

            // Load model and predict output
            var result = FakeNewsConfiguration.Predict(sampleData);
            Console.WriteLine($"Prediction: {(result.Prediction == 0 ? "Reliable" : "Most Likely Fake")}");
        }

        static void Main(string[] args) => new Program()
            .StartAsync()
            .GetAwaiter()
            .GetResult();
    }
}