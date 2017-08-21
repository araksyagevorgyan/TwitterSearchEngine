﻿using System.Web.Optimization;

namespace MvcApplication.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/bundles/js/jquery-1.7.2.min.js",
                        "~/bundles/js/search_client.js",
                        "~/bundles/js/twitter-text.js"));
        }
    }
}