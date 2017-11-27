using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FantasyFootball.Data.Yahoo
{
    [DataContract]
    public class ApiResult<T>
    {
        [DataMember(Name = "fantasy_content")]
        public List<T> FantasyResult { get; set; }

        public ApiResult()
        {
            FantasyResult = new List<T>();
        }
    }
}
