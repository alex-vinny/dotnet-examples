namespace second.Models
{
    using System;
    using System.Net.Http;    
    using System.Threading.Tasks;

    public class MyAsyncMethods
    {
        public async static Task<long?> GetPageLengthNewWay()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("https://www.apple.com/");

            return httpMessage.Content.Headers.ContentLength;
        }

        public static Task<long?> GetPageLengthOldWay()
        {
            HttpClient client = new HttpClient();
            var httpTask = client.GetAsync("https://www.yahoo.com/");

            return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) =>
            {
                return antecedent.Result.Content.Headers.ContentLength;
            });
        }
    }
}
