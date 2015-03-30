using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SniffleTracker9000.Helpers
{
    using System.Web.Mvc;

    using Newtonsoft.Json;

    public static class HtmlHelperExtensions
    {
        private static readonly JsonSerializerSettings settings;

        static HtmlHelperExtensions()
        {
            settings = new JsonSerializerSettings();
            //settings.ContractResolver = new Newtonsoft.Json.Serialization.();
        }

        public static MvcHtmlString ToJson(this HtmlHelper html, object value)
        {
            return MvcHtmlString.Create(JsonConvert.SerializeObject(value, Formatting.None, settings));
        }
    }
}