using System.Collections.Generic;
using System.Text.Json;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.Search;

namespace Spotted.Tests.Models.Search;

public class SearchQueryParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SearchQueryParams
        {
            Q = "remaster%20track:Doxy%20artist:Miles%20Davis",
            Type = [Type.Album],
            IncludeExternal = IncludeExternal.Audio,
            Limit = 10,
            Market = "ES",
            Offset = 5,
        };

        string expectedQ = "remaster%20track:Doxy%20artist:Miles%20Davis";
        List<ApiEnum<string, Type>> expectedType = [Type.Album];
        ApiEnum<string, IncludeExternal> expectedIncludeExternal = IncludeExternal.Audio;
        long expectedLimit = 10;
        string expectedMarket = "ES";
        long expectedOffset = 5;

        Assert.Equal(expectedQ, parameters.Q);
        Assert.Equal(expectedType.Count, parameters.Type.Count);
        for (int i = 0; i < expectedType.Count; i++)
        {
            Assert.Equal(expectedType[i], parameters.Type[i]);
        }
        Assert.Equal(expectedIncludeExternal, parameters.IncludeExternal);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMarket, parameters.Market);
        Assert.Equal(expectedOffset, parameters.Offset);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SearchQueryParams
        {
            Q = "remaster%20track:Doxy%20artist:Miles%20Davis",
            Type = [Type.Album],
        };

        Assert.Null(parameters.IncludeExternal);
        Assert.False(parameters.RawQueryData.ContainsKey("include_external"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SearchQueryParams
        {
            Q = "remaster%20track:Doxy%20artist:Miles%20Davis",
            Type = [Type.Album],

            // Null should be interpreted as omitted for these properties
            IncludeExternal = null,
            Limit = null,
            Market = null,
            Offset = null,
        };

        Assert.Null(parameters.IncludeExternal);
        Assert.False(parameters.RawQueryData.ContainsKey("include_external"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
    }
}

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

        Assert.NotNull(value);
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

        Assert.NotNull(value);
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
