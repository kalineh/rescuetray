using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace rescuetray
{
    public class RescueDataRaw
    {
        public string notes;
        public List<string> row_headers;
        public List<List<string>> rows;
    }

    public class RescueDataEntry
    {
        public int Rank;
        public int TimeSpentSeconds;
        public int NumberOfPeople;
        public string Activity;
        public string Category;
        public int Productivity;
    }

    public class RescueData
    {
        public string notes;
        public List<string> row_headers;
        public List<RescueDataEntry> rows;

        public static RescueData Deserialize(RescueDataRaw raw)
        {
            var result = new RescueData();

            result.notes = raw.notes;
            result.row_headers = raw.row_headers;
            result.rows = new List<RescueDataEntry>();

            foreach (var list in raw.rows)
            {
                var entry = new RescueDataEntry() {
                    Rank = Int32.Parse(list[0]),
                    TimeSpentSeconds = Int32.Parse(list[1]),
                    NumberOfPeople = Int32.Parse(list[2]),
                    Activity = list[3],
                    Category = list[4],
                    Productivity = Int32.Parse(list[5]),
                };

                result.rows.Add(entry);
            }

            return result;
        }
    };

    public class RescueDataManager
    {
        public string _key;
        public string _format;
        public string _url;

        public string _json;
        public RescueDataRaw _raw;
        public RescueData _data;

        public RescueDataManager(string key)
        {
            _key = key;
            _format = "json";
            _url = String.Format("https://www.rescuetime.com/anapi/data?key={0}&{1}", _key, _format);
        }

        public void Refresh()
        {
            // TODO: thread web request
            var web = new WebClient();
            var str = web.DownloadString(_url);

            var a = str.IndexOf('{');
            var b = str.LastIndexOf('}');

            var json = str.Substring(a, b - a + 1);

            //var obj = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            var raw = JsonConvert.DeserializeObject<RescueDataRaw>(json);
            var data = RescueData.Deserialize(raw);

            _json = json;
            _raw = raw;
            _data = data;
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var key = "B637R0noLkettPV3rLL8vkdY5jQoJEsiOTM4icZ3";
            var manager = new RescueDataManager(key);

            try
            {
                manager.Refresh();
            }
            catch (Exception)
            {
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
