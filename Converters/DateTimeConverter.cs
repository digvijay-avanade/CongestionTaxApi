﻿using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace congestiontaxapi.converters;

public class DateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Debug.Assert(typeToConvert == typeof(DateTime));

        var input = reader.GetString();
        Debug.Assert(input != null);
        return DateTime.Parse(input);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToUniversalTime().ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"));
    }
}
