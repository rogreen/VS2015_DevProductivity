using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using static System.Math;

namespace CSharp6CodeDemos
{
    public class EndingPoint
    {
        public int X { get; } = 5;
        public int Y { get; } = 7;

        public EndingPoint(int x, int y) { X = x; Y = y; }

        public override string ToString() => $"{X},{Y}";

        public double Dist => Sqrt(X * X + Y * Y);

        public JObject ToJson() => new JObject() {["x"] = X,["y"] = Y };

        public Point FromJson(JObject json)
        {
            if (json?["x"]?.Type == JTokenType.Integer &&
                json?["y"]?.Type == JTokenType.Integer)
            {
                return new Point((int)json["x"], (int)json["y"]);
            }
            throw new ArgumentNullException(nameof(json));
        }

        public async Task<string> CallWebSite(string webSite)
        {
            string success = "false";

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(webSite);
                HttpResponseMessage response = await client.GetAsync("api/products/1");
                success = "true";
            }
            catch (HttpRequestException e) when (DateTime.Today.DayOfWeek == DayOfWeek.Thursday)
            {
                await LogAsync(e);
            }
            finally
            {
                await LogGenericErrorAsync();
            }
            return success;
        }

        private void Log(HttpRequestException e)
        {
            throw new HttpRequestException();
        }

        private void LogGenericError()
        {
            throw new Exception();
        }

        private Task LogAsync(HttpRequestException e)
        {
            throw new HttpRequestException();
        }

        private Task LogGenericErrorAsync()
        {
            throw new Exception();
        }

    }
}
