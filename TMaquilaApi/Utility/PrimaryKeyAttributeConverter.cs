using System.Text.Json;
using System.Text.Json.Serialization;
using Supabase.Postgrest.Attributes;

public class PrimaryKeyAttributeConverter : JsonConverter<PrimaryKeyAttribute>
{
    public override PrimaryKeyAttribute Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var keyName = reader.GetString();
        return new PrimaryKeyAttribute(keyName, false);
    }

    public override void Write(Utf8JsonWriter writer, PrimaryKeyAttribute value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
