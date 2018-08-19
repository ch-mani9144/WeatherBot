using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherBot.Utilites
{
    public class WeatherReportDS
    {
        public Query query;
    }

    public class Query
    {
        public int count { get; set; }
        public string created { get; set; }
        public string lang { get; set; }
        public Result results { get; set; }
    }

    public class Result
    {
        public Channel channel { get; set; }
        public Place place { get; set; }
    }

    public class Place
    {
        public string woeid { get; set; }
    }

    public class Channel
    {
        public Units units { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public string lastBuildDate { get; set; }
        public string ttl { get; set; }
        public Location location { get; set; }
        public Wind wind { get; set; }
        public Atmosphere atmosphere { get; set; }
        public Astronomy astronomy { get; set; }
        public Image image { get; set; }
        public Item item { get; set; }
    }

    public class Item
    {
        public string title { get; set; }
        public string lat { get; set; }
        public string Long { get; set; }
        public string pubDate { get; set; }
        public Condition condition { get; set; }
        public List<FCDayCondition> forecast { get; set; }
        public string description { get; set; }
        public GuId guId { get; set; }

    }

    public class GuId
    {
        public string isPermaLink { get; set; }
    }

    public class FCDayCondition
    {
        public string code { get; set; }
        public string date { get; set; }
        public string day { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string text { get; set; }

    }

    public class Condition
    {
        public string code { get; set; }
        public string date { get; set; }
        public string temp { get; set; }
        public string text { get; set; }
    }

    public class Image
    {
        public string title { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string link { get; set; }
        public string url { get; set; }
    }

    public class Astronomy
    {
        public string sunrise { get; set; }
        public string sunset { get; set; }
    }

    public class Atmosphere
    {
        public string humidity { get; set; }
        public string pressure { get; set; }
        public string rising { get; set; }
        public string visibility { get; set; }
    }

    public class Wind
    {
        public string chill { get; set; }
        public string direction { get; set; }
        public string speed { get; set; }
    }

    public class Location
    {
        public string city { get; set; }
        public string country { get; set; }
        public string region { get; set; }
    }

    public class Units
    {
        public string distance { get; set; }
        public string pressure { get; set; }
        public string speed { get; set; }
        public string temperature { get; set; }
    }
}