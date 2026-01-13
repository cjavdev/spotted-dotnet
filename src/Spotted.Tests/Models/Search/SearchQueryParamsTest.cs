using System;
using System.Collections.Generic;
using System.Text.Json;
using Spotted.Core;
using Spotted.Exceptions;
using Search = Spotted.Models.Search;

namespace Spotted.Tests.Models.Search;

public class SearchQueryParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Search::SearchQueryParams
        {
            Q = "remaster%20track:Doxy%20artist:Miles%20Davis",
            Type = [Search::Type.Album],
            IncludeExternal = Search::IncludeExternal.Audio,
            Limit = 10,
            Market = "ES",
            Offset = 5,
        };

        string expectedQ = "remaster%20track:Doxy%20artist:Miles%20Davis";
        List<ApiEnum<string, Search::Type>> expectedType = [Search::Type.Album];
        ApiEnum<string, Search::IncludeExternal> expectedIncludeExternal =
            Search::IncludeExternal.Audio;
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
        var parameters = new Search::SearchQueryParams
        {
            Q = "remaster%20track:Doxy%20artist:Miles%20Davis",
            Type = [Search::Type.Album],
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
        var parameters = new Search::SearchQueryParams
        {
            Q = "remaster%20track:Doxy%20artist:Miles%20Davis",
            Type = [Search::Type.Album],

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

    [Fact]
    public void Url_Works()
    {
        Search::SearchQueryParams parameters = new()
        {
            Q = "remaster%20track:Doxy%20artist:Miles%20Davis",
            Type = [Search::Type.Album],
            IncludeExternal = Search::IncludeExternal.Audio,
            Limit = 10,
            Market = "ES",
            Offset = 5,
        };

        var url = parameters.Url(
            new() { ClientID = "My Client ID", ClientSecret = "My Client Secret" }
        );

        Assert.Equal(
            new Uri(
                "https://api.spotify.com/v1/search?q=remaster%2520track%3aDoxy%2520artist%3aMiles%2520Davis&type=album&include_external=audio&limit=10&market=ES&offset=5"
            ),
            url
        );
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Search::Type.Album)]
    [InlineData(Search::Type.Artist)]
    [InlineData(Search::Type.Playlist)]
    [InlineData(Search::Type.Track)]
    [InlineData(Search::Type.Show)]
    [InlineData(Search::Type.Episode)]
    [InlineData(Search::Type.Audiobook)]
    public void Validation_Works(Search::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Search::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Search::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SpottedInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Search::Type.Album)]
    [InlineData(Search::Type.Artist)]
    [InlineData(Search::Type.Playlist)]
    [InlineData(Search::Type.Track)]
    [InlineData(Search::Type.Show)]
    [InlineData(Search::Type.Episode)]
    [InlineData(Search::Type.Audiobook)]
    public void SerializationRoundtrip_Works(Search::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Search::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Search::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Search::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Search::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class IncludeExternalTest : TestBase
{
    [Theory]
    [InlineData(Search::IncludeExternal.Audio)]
    public void Validation_Works(Search::IncludeExternal rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Search::IncludeExternal> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Search::IncludeExternal>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SpottedInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Search::IncludeExternal.Audio)]
    public void SerializationRoundtrip_Works(Search::IncludeExternal rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Search::IncludeExternal> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Search::IncludeExternal>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Search::IncludeExternal>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Search::IncludeExternal>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
