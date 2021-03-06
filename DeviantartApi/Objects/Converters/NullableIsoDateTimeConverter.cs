﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace DeviantartApi.Objects.Converters
{
    public class NullableIsoDateTimeConverter : IsoDateTimeConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var val = reader.Value as string;
            if (val == null)
            {
                var a = reader.Value as DateTime?;
                return a;
            }
            if (string.IsNullOrWhiteSpace(val)) return null;
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                writer.WriteNull();
            else base.WriteJson(writer, value, serializer);
        }
    }
}
