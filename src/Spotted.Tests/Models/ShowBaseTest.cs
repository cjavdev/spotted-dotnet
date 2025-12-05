using System.Collections.Generic;
using System.Text.Json;
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
            Copyrights = [new() { Text = "text", Type = "type" }],
            Description = "description",
            Explicit = true,
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            HTMLDescription = "html_description",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
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

        string expectedID = "id";
        List<string> expectedAvailableMarkets = ["string"];
        List<CopyrightObject> expectedCopyrights = [new() { Text = "text", Type = "type" }];
        string expectedDescription = "description";
        bool expectedExplicit = true;
        ExternalURLObject expectedExternalURLs = new() { Spotify = "spotify" };
        string expectedHref = "href";
        string expectedHTMLDescription = "html_description";
        List<ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
            },
        ];
        bool expectedIsExternallyHosted = true;
        List<string> expectedLanguages = ["string"];
        string expectedMediaType = "media_type";
        string expectedName = "name";
        string expectedPublisher = "publisher";
        long expectedTotalEpisodes = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"show\"");
        string expectedUri = "uri";

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
        Assert.Equal(expectedExternalURLs, model.ExternalURLs);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedHTMLDescription, model.HTMLDescription);
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ShowBase
        {
            ID = "id",
            AvailableMarkets = ["string"],
            Copyrights = [new() { Text = "text", Type = "type" }],
            Description = "description",
            Explicit = true,
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            HTMLDescription = "html_description",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ShowBase>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ShowBase
        {
            ID = "id",
            AvailableMarkets = ["string"],
            Copyrights = [new() { Text = "text", Type = "type" }],
            Description = "description",
            Explicit = true,
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            HTMLDescription = "html_description",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ShowBase>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<string> expectedAvailableMarkets = ["string"];
        List<CopyrightObject> expectedCopyrights = [new() { Text = "text", Type = "type" }];
        string expectedDescription = "description";
        bool expectedExplicit = true;
        ExternalURLObject expectedExternalURLs = new() { Spotify = "spotify" };
        string expectedHref = "href";
        string expectedHTMLDescription = "html_description";
        List<ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
            },
        ];
        bool expectedIsExternallyHosted = true;
        List<string> expectedLanguages = ["string"];
        string expectedMediaType = "media_type";
        string expectedName = "name";
        string expectedPublisher = "publisher";
        long expectedTotalEpisodes = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"show\"");
        string expectedUri = "uri";

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
        Assert.Equal(expectedExternalURLs, deserialized.ExternalURLs);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedHTMLDescription, deserialized.HTMLDescription);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ShowBase
        {
            ID = "id",
            AvailableMarkets = ["string"],
            Copyrights = [new() { Text = "text", Type = "type" }],
            Description = "description",
            Explicit = true,
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            HTMLDescription = "html_description",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
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
}
