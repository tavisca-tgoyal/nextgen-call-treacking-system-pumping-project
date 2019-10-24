using NCTS.Contracts.Interfaces.ApiProxyModel;
using NCTS.Contracts.Models.ApiProxyModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NCTS.Services.ApiProxyModelServices
{
    public class CallDataServices : ICallDataServices
    {
        public List<CallDataProxy> CallDataList;
        public List<CallDataProxy> GetProxyObjects()
        {
            const string Format = "http://logs.stage.oski.io/_plugin/kibana/elasticsearch/_msearch";

            var myHttpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(Format));

            // Set the 'Method' property of the 'Webrequest' to 'POST'.
            myHttpWebRequest.Method = "POST";

            // Create a new string object to POST data to the Url.
            var json = GetJson();

            //var encoding = new ASCIIEncoding();
            var dataInBytes = Encoding.ASCII.GetBytes(json);

            // Set the content type of the data being posted.
            myHttpWebRequest.ContentType = "application/json";
            myHttpWebRequest.ContentLength = dataInBytes.Length;
            myHttpWebRequest.Headers["kbn-version"] = "5.1.1";

            // Set the content length of the string being posted.
            var stream = myHttpWebRequest.GetRequestStream();
            stream.Write(dataInBytes, 0, dataInBytes.Length);


            // Close the Stream object.
            stream.Close();
            var response = (HttpWebResponse)myHttpWebRequest.GetResponse();
            var responseStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
            string valueFromResponse = readStream.ReadToEnd();

            valueFromResponse = "[" + valueFromResponse + "]";

            CallDataList = JsonConvert.DeserializeObject<List<CallDataProxy>>(valueFromResponse);

            return CallDataList;
        }

        private static string GetJson()
        {
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            string gte = string.Empty;
            string lte = string.Empty;

            int currentHour = Convert.ToInt32(DateTime.Now.Hour);
            int startHour = ((currentHour / 6) * 6) - 6;
            int endHour = (currentHour / 6) * 6;

            gte = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, startHour, 0, 0, 1).Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds.ToString();
            lte = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, endHour, 0, 0, 1).Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds.ToString();

            var ApiRequestBody = @"{""index"":[""logs-" + date + @"""],""ignore_unavailable"":true}";
            ApiRequestBody = ApiRequestBody + Environment.NewLine + @"{""size"":500,""sort"":[{""log_time"":{""order"":""desc"",""unmapped_type"":""boolean""}}],""query"":{""bool"":{""must"":[{""query_string"":{""query"":""app_name: chatops AND category: call_action AND call_action: *"",""analyze_wildcard"":true}},{""range"":{""log_time"":{""gte"":" + gte + @",""lte"":" + lte + @",""format"":""epoch_millis""}}}],""must_not"":[]}},""highlight"":{""pre_tags"":[""@kibana-highlighted-field@""],""post_tags"":[""@/kibana-highlighted-field@""],""fields"":{""*"":{}},""require_field_match"":false,""fragment_size"":2147483647},""_source"":{""excludes"":[]},""aggs"":{""2"":{""date_histogram"":{""field"":""log_time"",""interval"":""3h"",""time_zone"":""Asia/Kolkata"",""min_doc_count"":1}}},""stored_fields"":[""*""],""script_fields"":{},""docvalue_fields"":[""check_in"",""search_date"",""check_out"",""time_stamp"",""pickup_date"",""dropoff_date"",""log_time"",""@timestamp"",""Timestamp"",""start_time"",""lastrun"",""lastsync""]}" + Environment.NewLine;

            return ApiRequestBody;
        }
    }
}
