﻿using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User
{
    using System.Threading;

    public class FriendsRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.Friend>>
    {
        public enum UserExpand
        {
            Details,
            Geo,
            Profile,
            Stats
        }

        private string _username;

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        public FriendsRequest(string username)
        {
            _username = username;
        }

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Friend>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddHashSetParameter(() => UserExpands);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"user/friends/{_username}" + values.ToGetParameters(), cancellationToken);
        }
    }
}