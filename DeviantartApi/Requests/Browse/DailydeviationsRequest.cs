﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse
{
    public class DailyDeviationsRequest : Request<Objects.DailyDeviations>
    {
        public enum UserExpand
        {
            Watch
        }

        public HashSet<UserExpand> UserExpands = new HashSet<UserExpand>();
        /// <summary>
        /// Day to browse. Left null for today.
        /// </summary>
        public DateTime? day = null;
        public bool LoadMature { get; set; }

        public override async Task<Response<Objects.DailyDeviations>> ExecuteAsync()
        {
            return await ExecuteDefaultAsync("browse/dailydeviations?" + 
                                             $"date={day?.ToString("yyyy-MM-dd")}" + 
                                             "&expand=" + string.Join(",", UserExpands.Select(x => "user." + x.ToString().ToLower()).ToList()) +
                                             $"&mature_content={LoadMature.ToString().ToLower()}");
        }
    }
}
