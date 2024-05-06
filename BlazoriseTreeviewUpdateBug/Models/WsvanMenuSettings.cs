using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazoriseTreeviewUpdateBug
{
    public class WsvanMenuSettings
    {
        public int Id { get; set; }

        public string Label { get; set; } = string.Empty;

        public List<WsvanMenuRow>? Rows { get; set; }

        public List<WsvanProperty>? Properties { get; set; } = new List<WsvanProperty>();
    }

    public class WsvanMenuRow : IEquatable<WsvanMenuRow>
    {
        public int Id { get; set; }

        public string Label { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<WsvanMenuRow>? Subrows { get; set; }

        public List<WsvanProperty>? Properties { get; set; } = new List<WsvanProperty>();

        public bool Equals(WsvanMenuRow other)
        {
            return other.Id == Id;
        }
    }

    public class WsvanProperty
    {
        public int Id { get; set; }

        public string Label { get; set; } = string.Empty;

        public string Value { get; set; } = string.Empty;
    }
}

