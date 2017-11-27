﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFootball.Data.Yahoo
{
    [DataContract]
    public class YahooToken
    {
        [DataMember(Name = "id_token")]
        public string IdToken { get; set; }
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }
        [DataMember(Name = "refresh_token")]
        public string RefreshToken { get; set; }
        [DataMember(Name = "expires_in")]
        public int ExpiresInMinutes { get; set; }
        [DataMember(Name = "token_type")]
        public string TokenType { get; set; }
        [DataMember(Name = "xoauth_yahoo_guid")]
        public string XoauthYahooGuid { get; set; }
    }
}
