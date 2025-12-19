using System.Collections.Generic;
using System.Text.Json;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class ArtistObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ArtistObject
        {
            ID = "id",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Followers = new()
            {
                Href = "href",
                Published = true,
                Total = 0,
            },
            Genres = ["Prog rock", "Grunge"],
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Name = "name",
            Popularity = 0,
            Published = true,
            Type = Type.Artist,
            Uri = "uri",
        };

        string expectedID = "id";
        ExternalURLObject expectedExternalURLs = new() { Published = true, Spotify = "spotify" };
        FollowersObject expectedFollowers = new()
        {
            Href = "href",
            Published = true,
            Total = 0,
        };
        List<string> expectedGenres = ["Prog rock", "Grunge"];
        string expectedHref = "href";
        List<ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
                Published = true,
            },
        ];
        string expectedName = "name";
        long expectedPopularity = 0;
        bool expectedPublished = true;
        ApiEnum<string, Type> expectedType = Type.Artist;
        string expectedUri = "uri";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExternalURLs, model.ExternalURLs);
        Assert.Equal(expectedFollowers, model.Followers);
        Assert.NotNull(model.Genres);
        Assert.Equal(expectedGenres.Count, model.Genres.Count);
        for (int i = 0; i < expectedGenres.Count; i++)
        {
            Assert.Equal(expectedGenres[i], model.Genres[i]);
        }
        Assert.Equal(expectedHref, model.Href);
        Assert.NotNull(model.Images);
        Assert.Equal(expectedImages.Count, model.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], model.Images[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPopularity, model.Popularity);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUri, model.Uri);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ArtistObject
        {
            ID = "id",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Followers = new()
            {
                Href = "href",
                Published = true,
                Total = 0,
            },
            Genres = ["Prog rock", "Grunge"],
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Name = "name",
            Popularity = 0,
            Published = true,
            Type = Type.Artist,
            Uri = "uri",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ArtistObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ArtistObject
        {
            ID = "id",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Followers = new()
            {
                Href = "href",
                Published = true,
                Total = 0,
            },
            Genres = ["Prog rock", "Grunge"],
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Name = "name",
            Popularity = 0,
            Published = true,
            Type = Type.Artist,
            Uri = "uri",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ArtistObject>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ExternalURLObject expectedExternalURLs = new() { Published = true, Spotify = "spotify" };
        FollowersObject expectedFollowers = new()
        {
            Href = "href",
            Published = true,
            Total = 0,
        };
        List<string> expectedGenres = ["Prog rock", "Grunge"];
        string expectedHref = "href";
        List<ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
                Published = true,
            },
        ];
        string expectedName = "name";
        long expectedPopularity = 0;
        bool expectedPublished = true;
        ApiEnum<string, Type> expectedType = Type.Artist;
        string expectedUri = "uri";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedExternalURLs, deserialized.ExternalURLs);
        Assert.Equal(expectedFollowers, deserialized.Followers);
        Assert.NotNull(deserialized.Genres);
        Assert.Equal(expectedGenres.Count, deserialized.Genres.Count);
        for (int i = 0; i < expectedGenres.Count; i++)
        {
            Assert.Equal(expectedGenres[i], deserialized.Genres[i]);
        }
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.NotNull(deserialized.Images);
        Assert.Equal(expectedImages.Count, deserialized.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], deserialized.Images[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPopularity, deserialized.Popularity);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUri, deserialized.Uri);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ArtistObject
        {
            ID = "id",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Followers = new()
            {
                Href = "href",
                Published = true,
                Total = 0,
            },
            Genres = ["Prog rock", "Grunge"],
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Name = "name",
            Popularity = 0,
            Published = true,
            Type = Type.Artist,
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ArtistObject { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Followers);
        Assert.False(model.RawData.ContainsKey("followers"));
        Assert.Null(model.Genres);
        Assert.False(model.RawData.ContainsKey("genres"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Images);
        Assert.False(model.RawData.ContainsKey("images"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Popularity);
        Assert.False(model.RawData.ContainsKey("popularity"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ArtistObject { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ArtistObject
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            ExternalURLs = null,
            Followers = null,
            Genres = null,
            Href = null,
            Images = null,
            Name = null,
            Popularity = null,
            Published = null,
            Type = null,
            Uri = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Followers);
        Assert.False(model.RawData.ContainsKey("followers"));
        Assert.Null(model.Genres);
        Assert.False(model.RawData.ContainsKey("genres"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Images);
        Assert.False(model.RawData.ContainsKey("images"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Popularity);
        Assert.False(model.RawData.ContainsKey("popularity"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ArtistObject
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            ExternalURLs = null,
            Followers = null,
            Genres = null,
            Href = null,
            Images = null,
            Name = null,
            Popularity = null,
            Published = null,
            Type = null,
            Uri = null,
        };

        model.Validate();
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Artist)]
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
    [InlineData(Type.Artist)]
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
