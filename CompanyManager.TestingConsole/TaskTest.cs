using System.Collections.Concurrent;

namespace CompanyManager.TestingConsole;

public class TaskTest
{
    public static async Task Do(int taskNumber)
    {
        var tasks = new Task[taskNumber];
        var results = new ConcurrentBag<int>();

        for (var i = 0; i < tasks.Length; i++)
        {
            tasks[i] = Task.Run(async () =>
            {
                var x = await DoTask();
                results.Add(x);
            });
        }

        await Task.WhenAll(tasks);
        
        Console.WriteLine("Results:");
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }

    private static async Task<int> DoTask()
    {
        await Task.Delay(100);
        return Random.Shared.Next(10) * Random.Shared.Next(1000);
    }
}