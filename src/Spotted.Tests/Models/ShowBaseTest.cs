using System.Collections.Generic;
using System.Text.Json;
using Spotted.Core;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class ShowBaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ShowBase
        {
            ID = "id",
            AvailableMarkets = ["string"],
            Copyrights =
            [
                new()
                {
                    Published = true,
                    Text = "text",
                    Type = "type",
                },
            ],
            Description = "description",
            Explicit = true,
            ExternalUrls = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            HtmlDescription = "html_description",
            Images =
            [
                new()
                {
                    Height = 300,
                    Url = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            IsExternallyHosted = true,
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Publisher = "publisher",
            TotalEpisodes = 0,
            Uri = "uri",
            Published = true,
        };

        string expectedID = "id";
        List<string> expectedAvailableMarkets = ["string"];
        List<CopyrightObject> expectedCopyrights =
        [
            new()
            {
                Published = true,
                Text = "text",
                Type = "type",
            },
        ];
        string expectedDescription = "description";
        bool expectedExplicit = true;
        ExternalUrlObject expectedExternalUrls = new() { Published = true, Spotify = "spotify" };
        string expectedHref = "href";
        string expectedHtmlDescription = "html_description";
        List<ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                Url = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
                Published = true,
            },
        ];
        bool expectedIsExternallyHosted = true;
        List<string> expectedLanguages = ["string"];
        string expectedMediaType = "media_type";
        string expectedName = "name";
        string expectedPublisher = "publisher";
        long expectedTotalEpisodes = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("show");
        string expectedUri = "uri";
        bool expectedPublished = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAvailableMarkets.Count, model.AvailableMarkets.Count);
        for (int i = 0; i < expectedAvailableMarkets.Count; i++)
        {
            Assert.Equal(expectedAvailableMarkets[i], model.AvailableMarkets[i]);
        }
        Assert.Equal(expectedCopyrights.Count, model.Copyrights.Count);
        for (int i = 0; i < expectedCopyrights.Count; i++)
        {
            Assert.Equal(expectedCopyrights[i], model.Copyrights[i]);
        }
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedExplicit, model.Explicit);
        Assert.Equal(expectedExternalUrls, model.ExternalUrls);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedHtmlDescription, model.HtmlDescription);
        Assert.Equal(expectedImages.Count, model.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], model.Images[i]);
        }
        Assert.Equal(expectedIsExternallyHosted, model.IsExternallyHosted);
        Assert.Equal(expectedLanguages.Count, model.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], model.Languages[i]);
        }
        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPublisher, model.Publisher);
        Assert.Equal(expectedTotalEpisodes, model.TotalEpisodes);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUri, model.Uri);
        Assert.Equal(expectedPublished, model.Published);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ShowBase
        {
            ID = "id",
            AvailableMarkets = ["string"],
            Copyrights =
            [
                new()
                {
                    Published = true,
                    Text = "text",
                    Type = "type",
                },
            ],
            Description = "description",
            Explicit = true,
            ExternalUrls = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            HtmlDescription = "html_description",
            Images =
            [
                new()
                {
                    Height = 300,
                    Url = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            IsExternallyHosted = true,
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Publisher = "publisher",
            TotalEpisodes = 0,
            Uri = "uri",
            Published = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ShowBase>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ShowBase
        {
            ID = "id",
            AvailableMarkets = ["string"],
            Copyrights =
            [
                new()
                {
                    Published = true,
                    Text = "text",
                    Type = "type",
                },
            ],
            Description = "description",
            Explicit = true,
            ExternalUrls = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            HtmlDescription = "html_description",
            Images =
            [
                new()
                {
                    Height = 300,
                    Url = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            IsExternallyHosted = true,
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Publisher = "publisher",
            TotalEpisodes = 0,
            Uri = "uri",
            Published = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ShowBase>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<string> expectedAvailableMarkets = ["string"];
        List<CopyrightObject> expectedCopyrights =
        [
            new()
            {
                Published = true,
                Text = "text",
                Type = "type",
            },
        ];
        string expectedDescription = "description";
        bool expectedExplicit = true;
        ExternalUrlObject expectedExternalUrls = new() { Published = true, Spotify = "spotify" };
        string expectedHref = "href";
        string expectedHtmlDescription = "html_description";
        List<ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                Url = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
                Published = true,
            },
        ];
        bool expectedIsExternallyHosted = true;
        List<string> expectedLanguages = ["string"];
        string expectedMediaType = "media_type";
        string expectedName = "name";
        string expectedPublisher = "publisher";
        long expectedTotalEpisodes = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("show");
        string expectedUri = "uri";
        bool expectedPublished = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAvailableMarkets.Count, deserialized.AvailableMarkets.Count);
        for (int i = 0; i < expectedAvailableMarkets.Count; i++)
        {
            Assert.Equal(expectedAvailableMarkets[i], deserialized.AvailableMarkets[i]);
        }
        Assert.Equal(expectedCopyrights.Count, deserialized.Copyrights.Count);
        for (int i = 0; i < expectedCopyrights.Count; i++)
        {
            Assert.Equal(expectedCopyrights[i], deserialized.Copyrights[i]);
        }
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedExplicit, deserialized.Explicit);
        Assert.Equal(expectedExternalUrls, deserialized.ExternalUrls);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedHtmlDescription, deserialized.HtmlDescription);
        Assert.Equal(expectedImages.Count, deserialized.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], deserialized.Images[i]);
        }
        Assert.Equal(expectedIsExternallyHosted, deserialized.IsExternallyHosted);
        Assert.Equal(expectedLanguages.Count, deserialized.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], deserialized.Languages[i]);
        }
        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPublisher, deserialized.Publisher);
        Assert.Equal(expectedTotalEpisodes, deserialized.TotalEpisodes);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUri, deserialized.Uri);
        Assert.Equal(expectedPublished, deserialized.Published);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ShowBase
        {
            ID = "id",
            AvailableMarkets = ["string"],
            Copyrights =
            [
                new()
                {
                    Published = true,
                    Text = "text",
                    Type = "type",
                },
            ],
            Description = "description",
            Explicit = true,
            ExternalUrls = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            HtmlDescription = "html_description",
            Images =
            [
                new()
                {
                    Height = 300,
                    Url = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            IsExternallyHosted = true,
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Publisher = "publisher",
            TotalEpisodes = 0,
            Uri = "uri",
            Published = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ShowBase
        {
            ID = "id",
            AvailableMarkets = ["string"],
            Copyrights =
            [
                new()
                {
                    Published = true,
                    Text = "text",
                    Type = "type",
                },
            ],
            Description = "description",
            Explicit = true,
            ExternalUrls = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            HtmlDescription = "html_description",
            Images =
            [
                new()
                {
                    Height = 300,
                    Url = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            IsExternallyHosted = true,
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Publisher = "publisher",
            TotalEpisodes = 0,
            Uri = "uri",
        };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ShowBase
        {
            ID = "id",
            AvailableMarkets = ["string"],
            Copyrights =
            [
                new()
                {
                    Published = true,
                    Text = "text",
                    Type = "type",
                },
            ],
            Description = "description",
            Explicit = true,
            ExternalUrls = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            HtmlDescription = "html_description",
            Images =
            [
                new()
                {
                    Height = 300,
                    Url = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            IsExternallyHosted = true,
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Publisher = "publisher",
            TotalEpisodes = 0,
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ShowBase
        {
            ID = "id",
            AvailableMarkets = ["string"],
            Copyrights =
            [
                new()
                {
                    Published = true,
                    Text = "text",
                    Type = "type",
                },
            ],
            Description = "description",
            Explicit = true,
            ExternalUrls = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            HtmlDescription = "html_description",
            Images =
            [
                new()
                {
                    Height = 300,
                    Url = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            IsExternallyHosted = true,
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Publisher = "publisher",
            TotalEpisodes = 0,
            Uri = "uri",

            // Null should be interpreted as omitted for these properties
            Published = null,
        };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ShowBase
        {
            ID = "id",
            AvailableMarkets = ["string"],
            Copyrights =
            [
                new()
                {
                    Published = true,
                    Text = "text",
                    Type = "type",
                },
            ],
            Description = "description",
            Explicit = true,
            ExternalUrls = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            HtmlDescription = "html_description",
            Images =
            [
                new()
                {
                    Height = 300,
                    Url = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            IsExternallyHosted = true,
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Publisher = "publisher",
            TotalEpisodes = 0,
            Uri = "uri",

            // Null should be interpreted as omitted for these properties
            Published = null,
        };

        model.Validate();
    }
}
