using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharp6CodeDemos
{
    public class StartingPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public StartingPoint(int x, int y) { X = x; Y = y; }

        public override string ToString()
        {
            return String.Format("{0},{1})", X, Y);
        }

        public double Dist
        {
            get { return Math.Sqrt(X * X + Y * Y); }
        }

        public JObject ToJson()
        {
            var result = new JObject();
            result["x"] = X;
            result["y"] = Y;
            return result;
        }

        public Point FromJson(JObject json)
        {
            if (json != null &&
                json["x"] != null &&
                json["x"].Type == JTokenType.Integer &&
                json["y"] != null &&
                json["y"].Type == JTokenType.Integer)
            {
                return new Point((int)json["x"], (int)json["y"]);
            }
            throw new ArgumentNullException("json");
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
            catch (HttpRequestException e) 
            {
                if (DateTime.Today.DayOfWeek == DayOfWeek.Thursday)
                {
                    Log(e);
                }
            }
            finally
            {
                LogGenericError();
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
