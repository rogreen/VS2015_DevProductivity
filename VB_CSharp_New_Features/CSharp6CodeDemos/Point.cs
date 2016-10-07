using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Math;

namespace CSharp6CodeDemos
{
    public class Point
    {
        #region Getter only auto properties and initializers

        //public int X { get; set; }
        //public int Y { get; set; }

        public int X { get; } = 5;
        public int Y { get; } = 7;

        #endregion

        public Point(int x, int y) { X = x; Y = y; }


        #region String interpolation

        //public override string ToString()
        //{
        //    return String.Format("{0},{1})", X, Y);
        //}

        //public override string ToString()
        //{
        //    return $"X is {X}, Y is {Y}";
        //}

        #endregion

        #region Expression bodies on method-like members

        //public override string ToString()
        //{
        //    return $"{X},{Y}";
        //}

        public override string ToString() => $"{X},{Y}";

        #endregion

        #region Expression bodies on property-like function members

        //public double Dist
        //{
        //    get { return Math.Sqrt(X * X + Y * Y); }
        //}

        #endregion

        #region Reference static classes

        public double Dist => Sqrt(X * X + Y * Y);

        #endregion

        #region Index initializers

        //public JObject ToJson()
        //{
        //    var result = new JObject();
        //    result["x"] = X;
        //    result["y"] = Y;
        //    return result;
        //}

        public JObject ToJson() => new JObject() {["x"] = X,["y"] = Y };

        #endregion

        #region Null-conditional operators'

        //public Point FromJson(JObject json)
        //{
        //    if (json != null &&
        //        json["x"] != null &&
        //        json["x"].Type == JTokenType.Integer &&
        //        json["y"] != null &&
        //        json["y"].Type == JTokenType.Integer)
        //    {
        //        return new Point((int)json["x"], (int)json["y"]);
        //    }
        //    throw new ArgumentNullException("json");
        //}

        public Point FromJson1(JObject freddie)
        {
            if (freddie?["x"]?.Type == JTokenType.Integer &&
                freddie?["y"]?.Type == JTokenType.Integer)
            {
                return new Point((int)freddie["x"], (int)freddie["y"]);
            }
            throw new ArgumentNullException("json");
        }

        #endregion

        #region nameof operator

        public Point FromJson2(JObject json)
        {
            if (json?["x"]?.Type == JTokenType.Integer &&
                json?["y"]?.Type == JTokenType.Integer)
            {
                return new Point((int)json["x"], (int)json["y"]);
            }
            throw new ArgumentNullException(nameof(json));
        }

        #endregion

        #region Await in catch and finally blocks

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
            catch (HttpRequestException e)  when (DateTime.Today.DayOfWeek == DayOfWeek.Thursday)
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

        #endregion

    }
}
