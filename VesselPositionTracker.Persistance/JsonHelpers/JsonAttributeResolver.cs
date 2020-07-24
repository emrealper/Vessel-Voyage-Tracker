﻿using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace VesselPositionTracker.Persistance.JsonHelpers
{
    public class JsonAttributeResolver : DefaultContractResolver
    {
        private Dictionary<string, string> PropertyMappings { get; set; }

        public JsonAttributeResolver(Dictionary<string, string> mappings)
        {
            this.PropertyMappings = mappings;
           
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            string resolvedName = null;
            var resolved = this.PropertyMappings.TryGetValue(propertyName, out resolvedName);
            return (resolved) ? resolvedName : base.ResolvePropertyName(propertyName);
        }
    }
}
