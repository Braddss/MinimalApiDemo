using BenchmarkMinApi.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace BenchmarkMinApi.Benchmark
{
    internal class ApiBenchmarker
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string apiBaseUrl = "https://localhost:7248/api/v1/string";
        private static readonly int benchmarkCount = 10000;

        public static async Task BenchmarkApi()
        {
            Console.WriteLine("Start Benchmark");
            Console.WriteLine();
            Console.WriteLine($"Each enpoint is tested {benchmarkCount} times");
            Console.WriteLine();

            var inputText = """
                The quick brown fox jumps over the lazy dog. This sentence is often used to test typing skills 
                because it contains every letter of the alphabet at least once. However, the quick brown fox 
                isn’t the only animal jumping around. In a quiet forest, far from the hustle and bustle of the 
                city, animals live in harmony. The fox, the deer, and the rabbit share the land, each contributing 
                to the ecosystem. Every morning, the sun rises over the trees, casting light on the creatures below. 
                Birds sing their songs, while the wind gently sways the branches. The forest thrives, providing 
                shelter and food for all its inhabitants. Life in the forest may seem simple, but every creature 
                plays an important role. The cycles of nature continue uninterrupted, from sunrise to sunset. 
                As night falls, the forest grows quiet, but the balance of life remains intact.
                """;

            await BenchmarkWordCount(inputText);
            await BenchmarkWordContains(inputText);
            await BenchmarkCharCount(inputText);
            await BenchmarkCharContains(inputText);
            await BenchmarkBase64Check(inputText);
            await BenchmarkMailCheck();
            await BenchmarkDecimalConversion();

            Console.WriteLine("Benchmark finished!");
        }

        private static async Task BenchmarkWordCount(string inputText)
        {
            var model = new WordCountModel
            {
                Text = inputText,
                WordsToCount = ["", "the", "life", "fox"],
            };

            await BenchmarkEndpoint($"/words/count", model);
        }

        private static async Task BenchmarkWordContains(string inputText)
        {
            var model = new WordContainsModel
            { 
                Text = inputText,
                WordsToCheck = ["", "the", "life", "fox"],
            };

            await BenchmarkEndpoint($"/words/contains", model);
        }

        private static async Task BenchmarkCharCount(string inputText)
        {
            var model = new CharCountModel
            {
                Text = inputText,
                CharsToCount = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '.', '3'],
            };

            await BenchmarkEndpoint($"/characters/count", model);
        }

        private static async Task BenchmarkCharContains(string inputText)
        {
            var model = new CharContainsModel
            {
                Text = inputText,
                CharsToCheck = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '.', '3'],
            };

            await BenchmarkEndpoint($"/characters/contains", model);
        }

        private static async Task BenchmarkBase64Check(string inputText)
        {
            var bytes = Encoding.UTF8.GetBytes(inputText);
            var base64String = Convert.ToBase64String(bytes);

            var model = new TextModel { Text = base64String };

            await BenchmarkEndpoint($"/base64/check", model);
        }

        private static async Task BenchmarkMailCheck()
        {
            await BenchmarkEndpoint($"/mail/check", new TextModel { Text = "test@example.com" });
        }

        private static async Task BenchmarkDecimalConversion()
        {
            await BenchmarkEndpoint($"/conversion/decimal", new TextModel { Text = "1,6.00.500.3025m" });
        }


        private static async Task BenchmarkEndpoint(string endpoint, object requestData)
        {
            var url = $"{apiBaseUrl}{endpoint}";
            var jsonData = JsonSerializer.Serialize(requestData);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            HttpResponseMessage response = new HttpResponseMessage();

            for (int i = 0; i < benchmarkCount; i++)
            {
                response = await client.PostAsync(url, content);
            }

            stopwatch.Stop();

            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Endpoint: {endpoint}");
            var lengthToTake = Math.Min(100, jsonData.Length);
            Console.WriteLine($"Input: {jsonData.AsSpan(..lengthToTake)}");
            Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Time taken per request: {(double)stopwatch.ElapsedMilliseconds / benchmarkCount} ms");
            Console.WriteLine($"Response: {result}");
            Console.WriteLine(new string('-', 100));
            Console.WriteLine();
        }
    }
}
