using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models;
using Spotted.Models.Me;

namespace Spotted.Tests.Models.Me;

public class MeRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MeRetrieveResponse
        {
            ID = "id",
            Country = "country",
            DisplayName = "display_name",
            Email = "email",
            ExplicitContent = new() { FilterEnabled = true, FilterLocked = true },
            ExternalURLs = new() { Spotify = "spotify" },
            Followers = new() { Href = "href", Total = 0 },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                },
            ],
            Product = "product",
            Type = "type",
            Uri = "uri",
        };

        string expectedID = "id";
        string expectedCountry = "country";
        string expectedDisplayName = "display_name";
        string expectedEmail = "email";
        ExplicitContent expectedExplicitContent = new()
        {
            FilterEnabled = true,
            FilterLocked = true,
        };
        ExternalURLObject expectedExternalURLs = new() { Spotify = "spotify" };
        FollowersObject expectedFollowers = new() { Href = "href", Total = 0 };
        string expectedHref = "href";
        List<ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
            },
        ];
        string expectedProduct = "product";
        string expectedType = "type";
        string expectedUri = "uri";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedExplicitContent, model.ExplicitContent);
        Assert.Equal(expectedExternalURLs, model.ExternalURLs);
        Assert.Equal(expectedFollowers, model.Followers);
        Assert.Equal(expectedHref, model.Href);
        Assert.NotNull(model.Images);
        Assert.Equal(expectedImages.Count, model.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], model.Images[i]);
        }
        Assert.Equal(expectedProduct, model.Product);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUri, model.Uri);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MeRetrieveResponse
        {
            ID = "id",
            Country = "country",
            DisplayName = "display_name",
            Email = "email",
            ExplicitContent = new() { FilterEnabled = true, FilterLocked = true },
            ExternalURLs = new() { Spotify = "spotify" },
            Followers = new() { Href = "href", Total = 0 },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                },
            ],
            Product = "product",
            Type = "type",
            Uri = "uri",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MeRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MeRetrieveResponse
        {
            ID = "id",
            Country = "country",
            DisplayName = "display_name",
            Email = "email",
            ExplicitContent = new() { FilterEnabled = true, FilterLocked = true },
            ExternalURLs = new() { Spotify = "spotify" },
            Followers = new() { Href = "href", Total = 0 },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                },
            ],
            Product = "product",
            Type = "type",
            Uri = "uri",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MeRetrieveResponse>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCountry = "country";
        string expectedDisplayName = "display_name";
        string expectedEmail = "email";
        ExplicitContent expectedExplicitContent = new()
        {
            FilterEnabled = true,
            FilterLocked = true,
        };
        ExternalURLObject expectedExternalURLs = new() { Spotify = "spotify" };
        FollowersObject expectedFollowers = new() { Href = "href", Total = 0 };
        string expectedHref = "href";
        List<ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
            },
        ];
        string expectedProduct = "product";
        string expectedType = "type";
        string expectedUri = "uri";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedExplicitContent, deserialized.ExplicitContent);
        Assert.Equal(expectedExternalURLs, deserialized.ExternalURLs);
        Assert.Equal(expectedFollowers, deserialized.Followers);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.NotNull(deserialized.Images);
        Assert.Equal(expectedImages.Count, deserialized.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], deserialized.Images[i]);
        }
        Assert.Equal(expectedProduct, deserialized.Product);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUri, deserialized.Uri);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MeRetrieveResponse
        {
            ID = "id",
            Country = "country",
            DisplayName = "display_name",
            Email = "email",
            ExplicitContent = new() { FilterEnabled = true, FilterLocked = true },
            ExternalURLs = new() { Spotify = "spotify" },
            Followers = new() { Href = "href", Total = 0 },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                },
            ],
            Product = "product",
            Type = "type",
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MeRetrieveResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.ExplicitContent);
        Assert.False(model.RawData.ContainsKey("explicit_content"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Followers);
        Assert.False(model.RawData.ContainsKey("followers"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Images);
        Assert.False(model.RawData.ContainsKey("images"));
        Assert.Null(model.Product);
        Assert.False(model.RawData.ContainsKey("product"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MeRetrieveResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MeRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Country = null,
            DisplayName = null,
            Email = null,
            ExplicitContent = null,
            ExternalURLs = null,
            Followers = null,
            Href = null,
            Images = null,
            Product = null,
            Type = null,
            Uri = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.ExplicitContent);
        Assert.False(model.RawData.ContainsKey("explicit_content"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Followers);
        Assert.False(model.RawData.ContainsKey("followers"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Images);
        Assert.False(model.RawData.ContainsKey("images"));
        Assert.Null(model.Product);
        Assert.False(model.RawData.ContainsKey("product"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MeRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Country = null,
            DisplayName = null,
            Email = null,
            ExplicitContent = null,
            ExternalURLs = null,
            Followers = null,
            Href = null,
            Images = null,
            Product = null,
            Type = null,
            Uri = null,
        };

        model.Validate();
    }
}

public class ExplicitContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExplicitContent { FilterEnabled = true, FilterLocked = true };

        bool expectedFilterEnabled = true;
        bool expectedFilterLocked = true;

        Assert.Equal(expectedFilterEnabled, model.FilterEnabled);
        Assert.Equal(expectedFilterLocked, model.FilterLocked);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExplicitContent { FilterEnabled = true, FilterLocked = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ExplicitContent>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExplicitContent { FilterEnabled = true, FilterLocked = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ExplicitContent>(json);
        Assert.NotNull(deserialized);

        bool expectedFilterEnabled = true;
        bool expectedFilterLocked = true;

        Assert.Equal(expectedFilterEnabled, deserialized.FilterEnabled);
        Assert.Equal(expectedFilterLocked, deserialized.FilterLocked);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExplicitContent { FilterEnabled = true, FilterLocked = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExplicitContent { };

        Assert.Null(model.FilterEnabled);
        Assert.False(model.RawData.ContainsKey("filter_enabled"));
        Assert.Null(model.FilterLocked);
        Assert.False(model.RawData.ContainsKey("filter_locked"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExplicitContent { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExplicitContent
        {
            // Null should be interpreted as omitted for these properties
            FilterEnabled = null,
            FilterLocked = null,
        };

        Assert.Null(model.FilterEnabled);
        Assert.False(model.RawData.ContainsKey("filter_enabled"));
        Assert.Null(model.FilterLocked);
        Assert.False(model.RawData.ContainsKey("filter_locked"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExplicitContent
        {
            // Null should be interpreted as omitted for these properties
            FilterEnabled = null,
            FilterLocked = null,
        };

        model.Validate();
    }
}
