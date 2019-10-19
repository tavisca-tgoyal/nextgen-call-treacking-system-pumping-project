using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.Contracts.Models.ApiProxyModels
{
    public class CallDataProxy
    {
        public Respons[] responses { get; set; }
    }

    public class Respons
    {
        public int took { get; set; }
        public bool timed_out { get; set; }
        public _Shards _shards { get; set; }
        public Hits hits { get; set; }
        public Aggregations aggregations { get; set; }
        public int status { get; set; }
    }

    public class _Shards
    {
        public int total { get; set; }
        public int successful { get; set; }
        public int failed { get; set; }
    }

    public class Hits
    {
        public int total { get; set; }
        public object max_score { get; set; }
        public Hit[] hits { get; set; }
    }

    public class Hit
    {
        public string _index { get; set; }
        public string _type { get; set; }
        public string _id { get; set; }
        public object _score { get; set; }
        public _Source _source { get; set; }
        public Fields fields { get; set; }
        public Highlight highlight { get; set; }
        public long[] sort { get; set; }
    }

    public class _Source
    {
        public string id { get; set; }
        public DateTime log_time { get; set; }
        public int pid { get; set; }
        public string machine { get; set; }
        public string app_domain { get; set; }
        public string type { get; set; }
        public object msg { get; set; }
        public string app_name { get; set; }
        public object tid { get; set; }
        public object cid { get; set; }
        public object sid { get; set; }
        public object app_txid { get; set; }
        public string log_sink { get; set; }
        public string category { get; set; }
        public string alarm_name { get; set; }
        public string handler_type { get; set; }
        public string call_action { get; set; }
        public string recipient { get; set; }
        public string employee_id { get; set; }
        public string application { get; set; }
        public string environment { get; set; }
        public string incident_id { get; set; }
        public int call_tree_level { get; set; }
        public DateTime time_stamp { get; set; }
    }

    public class Fields
    {
        public long[] time_stamp { get; set; }
        public long[] log_time { get; set; }
    }

    public class Highlight
    {
        public string[] alarm_name { get; set; }
        public string[] handler_type { get; set; }
        public string[] log_sink { get; set; }
        public string[] app_domain { get; set; }
        public string[] type { get; set; }
        public string[] app_name { get; set; }
        public string[] environment { get; set; }
        public string[] incident_id { get; set; }
        public string[] application { get; set; }
        public string[] call_action { get; set; }
        public string[] machine { get; set; }
        public string[] employee_id { get; set; }
        public string[] recipient { get; set; }
        public string[] id { get; set; }
        public string[] category { get; set; }
    }

    public class Aggregations
    {
        public _2 _2 { get; set; }
    }

    public class _2
    {
        public Bucket[] buckets { get; set; }
    }

    public class Bucket
    {
        public DateTime key_as_string { get; set; }
        public long key { get; set; }
        public int doc_count { get; set; }
    }

}
