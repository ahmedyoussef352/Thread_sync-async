namespace Thread_sync_async_session4
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /*Thread Creation
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Thread t1 = new Thread(() =>
            {
                PrintStars();
            });
            Thread t2 = new Thread(() =>
            {
                PrintCarets();
            });
            t1.Start();
            t2.Start();
            Console.WriteLine("Finsh");*/

            /*Thread Pool Created
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem((state) =>
                {
                    PrintStars();
                });
                sw.Stop();

            }
            Console.WriteLine(sw.ElapsedMilliseconds);*/

            /* Task

            //var task = Task.Run(() => GetLenth("Woking on Task"));
            //var result = task.Result;*/

            /*Async
            ASyncDataService service = new ASyncDataService();
            string result = await service.FetchDataFromApiASync();

            await service.DoSomething();

            Task first = Task.Run(async () =>
            {
                await Task.Delay(100);
                //return 100;
                throw new Exception("something wrong");
            });

            Console.WriteLine(first.Status);

            try
            {
                await first;
            }
            catch (Exception e)
            {
                Console.WriteLine(first.Status);
                Console.WriteLine(first.IsCompleted);
                Console.WriteLine(first.IsCompletedSuccessfully);
            }
            */

            //DownloadService downloadService = new DownloadService();
            //await downloadService.DownloadWithTimeOut("Ahmed.text", 2000);

            // task.whenall, taskwhenany , task.wheneach
            //task.wheneach
            DownloadService service3 = new DownloadService();
            var tasks = new[]
            {
                service3.DownloadFileAsync("file1.text"),
                service3.DownloadFileAsync("file2.text"),

                service3.DownloadWithTimeOut("file3.text",1000)
            };
            await foreach (var task in Task.WhenEach(tasks))
            {
                var result = await task;
                Console.WriteLine($"Completed with Result {result}");
            }


            /*taskwhenany
            ASyncDataService service2 = new ASyncDataService();
            var dataTask = service2.FetchDataFromDatabaseASync();
            var timeOut = Task.Delay(3000);

            var first = await Task.WhenAny(dataTask, timeOut);
            if (first == timeOut)
            {
                Console.WriteLine("Requested time out");
            }
            else
            {
                Console.WriteLine($"data retrieved " + await dataTask);
            }*/

            /* task.whenall
            // ASyncDataService service = new ASyncDataService();
            // var stopwatch = Stopwatch.StartNew();
            // var tasks = new[]
            // {
            //    service.FetchDataFromApiASync(),
            //    service.FetchDataFromApiASync(),
            //    service.FetchDataFromApiASync(),
            //    service.FetchDataFromApiASync(),
            //};
            // await Task.WhenAll(tasks);
            // stopwatch.Stop();
            // Console.WriteLine(stopwatch.ElapsedMilliseconds);*/
        }
        static void ThrowException()
        {
            throw new InvalidOperationException("This is an exception");
        }
        public static int GetLenth(string s)
        {
            return s.Length;
        }
        public static void PrintCarets()
        {
            for (int i = 0; i < 50; i++)
            {
                //Console.Write(" ^ ");
                //Console.WriteLine();
            }

        }
        public static void PrintStars()
        {
            for (int i = 0; i < 50; i++)
            {
                //Console.Write(" * ");
                //Console.WriteLine();
            }

        }
    }

}
