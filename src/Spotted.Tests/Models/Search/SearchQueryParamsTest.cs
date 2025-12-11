using System.Text.Json;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.Search;

namespace Spotted.Tests.Models.Search;

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Album)]
    [InlineData(Type.Artist)]
    [InlineData(Type.Playlist)]
    [InlineData(Type.Track)]
    [InlineData(Type.Show)]
    [InlineData(Type.Episode)]
    [InlineData(Type.Audiobook)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<SpottedInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.Album)]
    [InlineData(Type.Artist)]
    [InlineData(Type.Playlist)]
    [InlineData(Type.Track)]
    [InlineData(Type.Show)]
    [InlineData(Type.Episode)]
    [InlineData(Type.Audiobook)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class IncludeExternalTest : TestBase
{
    [Theory]
    [InlineData(IncludeExternal.Audio)]
    public void Validation_Works(IncludeExternal rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IncludeExternal> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IncludeExternal>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<SpottedInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IncludeExternal.Audio)]
    public void SerializationRoundtrip_Works(IncludeExternal rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IncludeExternal> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IncludeExternal>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IncludeExternal>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IncludeExternal>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
