using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace csharpExpert.features
{
    public class AsyncAwait : IFeature
    {
        private Random random = new Random();

        public void ShowFeature()
        {
            "Async/Await".WriteLine();
            "downloading all pages in parallel".WriteLine();

            WaitForDownloadsParallel().Wait();
        }

        private async Task WaitForDownloadsParallel()
        {
            Stopwatch sw = Stopwatch.StartNew();

            string[] urls = {"google.com", "github.com", "stackoverflow.com", "microsoft.com"};

            // start downloading all urls in parallel
            List<Task<string>> tasks = new List<Task<string>>();
            foreach (var url in urls)
            {
                // tasks.Add(Task.Run(()=>DownloadDataAsync(url)));
                tasks.Add(DownloadDataAsync(url));
            }

            // wait for all tasks to complete
            var results = await Task.WhenAll(tasks);

            // show results
            foreach (var r in results)
                ShowResult(r);

            sw.Stop();
            $"total = {sw.ElapsedMilliseconds}ms".WriteLine();
        }

        private void ShowResult(string res)
        {
            res.WriteLine();
        }

        private async Task<string> DownloadDataAsync(string url)
        {
            int delayTime = random.Next(1000, 2000);
            await Task.Delay(delayTime);
            // i don't know why but Task.Delay(delayTime).Wait() doesn't work :|
            return $"downloaded data of {url} in {delayTime}ms.";
        }

        // if you want to use await keyword in a function, just add
        // async keyword in it's signature but if you want to make it
        // asynchronous, change its signature like this :
        // - if its return type is void, just change void keyword with Task
        //     Before = public void DoSomething();
        //     After = public Task DoSomething();
        // - otherwise wrap return type with Task<>
        //     Before = public string DoSomething();
        //     After = public Task<string> DoSomething();
        // finally add async before Task<T>/Task.

        // naming convention : if your function runs asynchronously, you have to add 'Async' to the end of it's name. 
    }
}