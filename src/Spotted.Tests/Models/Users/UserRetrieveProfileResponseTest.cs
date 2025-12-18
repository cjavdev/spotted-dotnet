using System.Collections.Generic;
using System.Text.Json;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.Users;
using Models = Spotted.Models;

namespace Spotted.Tests.Models.Users;

public class UserRetrieveProfileResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserRetrieveProfileResponse
        {
            ID = "id",
            DisplayName = "display_name",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Followers = new()
            {
                Href = "href",
                Published = true,
                Total = 0,
            },
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
            Published = true,
            Type = Type.User,
            Uri = "uri",
        };

        string expectedID = "id";
        string expectedDisplayName = "display_name";
        Models::ExternalURLObject expectedExternalURLs = new()
        {
            Published = true,
            Spotify = "spotify",
        };
        Models::FollowersObject expectedFollowers = new()
        {
            Href = "href",
            Published = true,
            Total = 0,
        };
        string expectedHref = "href";
        List<Models::ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
                Published = true,
            },
        ];
        bool expectedPublished = true;
        ApiEnum<string, Type> expectedType = Type.User;
        string expectedUri = "uri";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedExternalURLs, model.ExternalURLs);
        Assert.Equal(expectedFollowers, model.Followers);
        Assert.Equal(expectedHref, model.Href);
        Assert.NotNull(model.Images);
        Assert.Equal(expectedImages.Count, model.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], model.Images[i]);
        }
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUri, model.Uri);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserRetrieveProfileResponse
        {
            ID = "id",
            DisplayName = "display_name",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Followers = new()
            {
                Href = "href",
                Published = true,
                Total = 0,
            },
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
            Published = true,
            Type = Type.User,
            Uri = "uri",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UserRetrieveProfileResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserRetrieveProfileResponse
        {
            ID = "id",
            DisplayName = "display_name",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Followers = new()
            {
                Href = "href",
                Published = true,
                Total = 0,
            },
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
            Published = true,
            Type = Type.User,
            Uri = "uri",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UserRetrieveProfileResponse>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDisplayName = "display_name";
        Models::ExternalURLObject expectedExternalURLs = new()
        {
            Published = true,
            Spotify = "spotify",
        };
        Models::FollowersObject expectedFollowers = new()
        {
            Href = "href",
            Published = true,
            Total = 0,
        };
        string expectedHref = "href";
        List<Models::ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
                Published = true,
            },
        ];
        bool expectedPublished = true;
        ApiEnum<string, Type> expectedType = Type.User;
        string expectedUri = "uri";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedExternalURLs, deserialized.ExternalURLs);
        Assert.Equal(expectedFollowers, deserialized.Followers);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.NotNull(deserialized.Images);
        Assert.Equal(expectedImages.Count, deserialized.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], deserialized.Images[i]);
        }
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUri, deserialized.Uri);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserRetrieveProfileResponse
        {
            ID = "id",
            DisplayName = "display_name",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Followers = new()
            {
                Href = "href",
                Published = true,
                Total = 0,
            },
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
            Published = true,
            Type = Type.User,
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserRetrieveProfileResponse { DisplayName = "display_name" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Followers);
        Assert.False(model.RawData.ContainsKey("followers"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Images);
        Assert.False(model.RawData.ContainsKey("images"));
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
        var model = new UserRetrieveProfileResponse { DisplayName = "display_name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UserRetrieveProfileResponse
        {
            DisplayName = "display_name",

            // Null should be interpreted as omitted for these properties
            ID = null,
            ExternalURLs = null,
            Followers = null,
            Href = null,
            Images = null,
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
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Images);
        Assert.False(model.RawData.ContainsKey("images"));
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
        var model = new UserRetrieveProfileResponse
        {
            DisplayName = "display_name",

            // Null should be interpreted as omitted for these properties
            ID = null,
            ExternalURLs = null,
            Followers = null,
            Href = null,
            Images = null,
            Published = null,
            Type = null,
            Uri = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserRetrieveProfileResponse
        {
            ID = "id",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Followers = new()
            {
                Href = "href",
                Published = true,
                Total = 0,
            },
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
            Published = true,
            Type = Type.User,
            Uri = "uri",
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserRetrieveProfileResponse
        {
            ID = "id",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Followers = new()
            {
                Href = "href",
                Published = true,
                Total = 0,
            },
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
            Published = true,
            Type = Type.User,
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UserRetrieveProfileResponse
        {
            ID = "id",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Followers = new()
            {
                Href = "href",
                Published = true,
                Total = 0,
            },
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
            Published = true,
            Type = Type.User,
            Uri = "uri",

            DisplayName = null,
        };

        Assert.Null(model.DisplayName);
        Assert.True(model.RawData.ContainsKey("display_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserRetrieveProfileResponse
        {
            ID = "id",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Followers = new()
            {
                Href = "href",
                Published = true,
                Total = 0,
            },
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
            Published = true,
            Type = Type.User,
            Uri = "uri",

            DisplayName = null,
        };

        model.Validate();
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.User)]
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
    [InlineData(Type.User)]
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
