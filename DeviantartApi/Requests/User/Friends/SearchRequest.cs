﻿using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User.Friends
{
    using System.Threading;

    public class SearchRequest : Request<Objects.ArrayOfResults<Objects.User>>
    {
        [Parameter("username")]
        public string Username { get; set; }

        [Parameter("query")]
        public string Query { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.User>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Username);
            values.AddParameter(() => Query);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync("user/friends/search?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
