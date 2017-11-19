using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnitTestOrientDb
{
    [JsonObject(MemberSerialization.OptOut)]
    public abstract class OrientDbEntity
    {
        [JsonProperty(PropertyName = "@class")]
        public string _class { get { return this.GetType().Name; } }

        [JsonProperty(PropertyName = "@rid")]
        public string _rid { get; set; }
    }
}
