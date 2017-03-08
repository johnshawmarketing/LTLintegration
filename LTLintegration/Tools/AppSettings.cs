﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LTLintegration.Tools
{
    public static class AppSettings
    {
        public static string ShopifySecretKey { get; } = ConfigurationManager.AppSettings.Get("Shopify_Secret_Key");
        public static string ShopifyApiKey { get; } = ConfigurationManager.AppSettings.Get("Shopify_API_Key");
        public static string AppUrl { get; } = ConfigurationManager.AppSettings.Get("Shopify_App_Url");
    }
} 