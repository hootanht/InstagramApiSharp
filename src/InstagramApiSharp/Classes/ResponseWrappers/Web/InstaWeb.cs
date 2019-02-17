﻿/*
 * Developer: Ramtin Jokar [ Ramtinak@live.com ] [ My Telegram Account: https://t.me/ramtinak ]
 * 
 * Github source: https://github.com/ramtinak/InstagramApiSharp
 * Nuget package: https://www.nuget.org/packages/InstagramApiSharp
 * 
 * IRANIAN DEVELOPERS
 */

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using InstagramApiSharp.Classes.ResponseWrappers;
using InstagramApiSharp.Classes.Models;
using InstagramApiSharp.Enums;
namespace InstagramApiSharp.Classes.ResponseWrappers.Web
{
    public class InstaWebContainer
    {
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        [JsonProperty("language_code")]
        public string LanguageCode { get; set; }
        [JsonProperty("locale")]
        public string Locale { get; set; }
        [JsonProperty("config")]
        public InstaWebConfig Config { get; set; }
        [JsonProperty("entry_data")]
        public InstaWebEntryData Entry { get; set; }
    }

    public class InstaWebConfig
    {
        [JsonProperty("viewer")]
        public InstaUserShortResponse Viewer { get; set; }
    }

    public class InstaWebEntryData
    {
        [JsonProperty("SettingsPages")]
        public List<InstaWebSettingsPageResponse> SettingsPages { get; set; } = new List<InstaWebSettingsPageResponse>();
    }

    public class InstaWebSettingsPageResponse
    {
        [JsonProperty("is_blocked")]
        public bool? IsBlocked { get; set; }
        [JsonProperty("page_name")]
        public string PageName { get; set; }
        internal InstaWebType PageType
        {
            get
            {
                if (string.IsNullOrEmpty(PageName))
                    return InstaWebType.Unknown;
                try
                {
                    var name = PageName.Replace("_", "");

                    return (InstaWebType)Enum.Parse(typeof(InstaWebType), name, true);
                }
                catch { }
                return InstaWebType.Unknown;
            }
        }
        [JsonProperty("date_joined")]
        public InstaWebData DateJoined { get; set; }
        [JsonProperty("switched_to_business")]
        public InstaWebData SwitchedToBusiness { get; set; }
        [JsonProperty("data")]
        public InstaWebDataList Data { get; set; }
    }
    
    public class InstaWebData
    {
        [JsonProperty("link")]
        public object Link { get; set; }
        [JsonProperty("data")]
        public InstaWebDataItem Data { get; set; }
        [JsonProperty("cursor")]
        public string Cursor { get; set; }
    }

    public class InstaWebDataList
    {
        [JsonProperty("link")]
        public object Link { get; set; }
        [JsonProperty("data")]
        public List<InstaWebDataItem> Data { get; set; } = new List<InstaWebDataItem>();
        [JsonProperty("cursor")]
        public string Cursor { get; set; }
    }
    public class InstaWebDataItem
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("timestamp")]
        public long? Timestamp { get; set; }
    }




}