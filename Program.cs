namespace HW_07_10_prop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(CallMethod);
            task.Start();
            task.Wait();
            Console.WriteLine("Main end");
            Console.ReadLine();
        }

        static async void CallMethod()
        {
            string filePath = @"C:\textFile.txt";
            Task<int> task = ReadFile(filePath);
            int length = await task;
            Console.WriteLine("Total length: " + length);
        }

        static async Task<int> ReadFile(string file)
        {
            int length  = 0;

            Console.WriteLine("File reading is stating");
            using (StreamReader reader = new StreamReader(file))
            {
                string s = await reader.ReadToEndAsync();
                length = s.Length;
            }
            Console.WriteLine("File reading is completed");
            return length;
        }
    }
}
