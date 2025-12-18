using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class AudiobookBaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AudiobookBase
        {
            ID = "id",
            Authors = [new() { Name = "name", Published = true }],
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
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            HTMLDescription = "html_description",
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
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Narrators = [new() { Name = "name", Published = true }],
            Publisher = "publisher",
            TotalChapters = 0,
            Uri = "uri",
            Edition = "Unabridged",
            Published = true,
        };

        string expectedID = "id";
        List<AuthorObject> expectedAuthors = [new() { Name = "name", Published = true }];
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
        ExternalURLObject expectedExternalURLs = new() { Published = true, Spotify = "spotify" };
        string expectedHref = "href";
        string expectedHTMLDescription = "html_description";
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
        List<string> expectedLanguages = ["string"];
        string expectedMediaType = "media_type";
        string expectedName = "name";
        List<NarratorObject> expectedNarrators = [new() { Name = "name", Published = true }];
        string expectedPublisher = "publisher";
        long expectedTotalChapters = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"audiobook\"");
        string expectedUri = "uri";
        string expectedEdition = "Unabridged";
        bool expectedPublished = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAuthors.Count, model.Authors.Count);
        for (int i = 0; i < expectedAuthors.Count; i++)
        {
            Assert.Equal(expectedAuthors[i], model.Authors[i]);
        }
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
        Assert.Equal(expectedLanguages.Count, model.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], model.Languages[i]);
        }
        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedNarrators.Count, model.Narrators.Count);
        for (int i = 0; i < expectedNarrators.Count; i++)
        {
            Assert.Equal(expectedNarrators[i], model.Narrators[i]);
        }
        Assert.Equal(expectedPublisher, model.Publisher);
        Assert.Equal(expectedTotalChapters, model.TotalChapters);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUri, model.Uri);
        Assert.Equal(expectedEdition, model.Edition);
        Assert.Equal(expectedPublished, model.Published);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AudiobookBase
        {
            ID = "id",
            Authors = [new() { Name = "name", Published = true }],
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
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            HTMLDescription = "html_description",
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
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Narrators = [new() { Name = "name", Published = true }],
            Publisher = "publisher",
            TotalChapters = 0,
            Uri = "uri",
            Edition = "Unabridged",
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudiobookBase>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AudiobookBase
        {
            ID = "id",
            Authors = [new() { Name = "name", Published = true }],
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
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            HTMLDescription = "html_description",
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
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Narrators = [new() { Name = "name", Published = true }],
            Publisher = "publisher",
            TotalChapters = 0,
            Uri = "uri",
            Edition = "Unabridged",
            Published = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudiobookBase>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<AuthorObject> expectedAuthors = [new() { Name = "name", Published = true }];
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
        ExternalURLObject expectedExternalURLs = new() { Published = true, Spotify = "spotify" };
        string expectedHref = "href";
        string expectedHTMLDescription = "html_description";
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
        List<string> expectedLanguages = ["string"];
        string expectedMediaType = "media_type";
        string expectedName = "name";
        List<NarratorObject> expectedNarrators = [new() { Name = "name", Published = true }];
        string expectedPublisher = "publisher";
        long expectedTotalChapters = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"audiobook\"");
        string expectedUri = "uri";
        string expectedEdition = "Unabridged";
        bool expectedPublished = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAuthors.Count, deserialized.Authors.Count);
        for (int i = 0; i < expectedAuthors.Count; i++)
        {
            Assert.Equal(expectedAuthors[i], deserialized.Authors[i]);
        }
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
        Assert.Equal(expectedLanguages.Count, deserialized.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], deserialized.Languages[i]);
        }
        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedNarrators.Count, deserialized.Narrators.Count);
        for (int i = 0; i < expectedNarrators.Count; i++)
        {
            Assert.Equal(expectedNarrators[i], deserialized.Narrators[i]);
        }
        Assert.Equal(expectedPublisher, deserialized.Publisher);
        Assert.Equal(expectedTotalChapters, deserialized.TotalChapters);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUri, deserialized.Uri);
        Assert.Equal(expectedEdition, deserialized.Edition);
        Assert.Equal(expectedPublished, deserialized.Published);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AudiobookBase
        {
            ID = "id",
            Authors = [new() { Name = "name", Published = true }],
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
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            HTMLDescription = "html_description",
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
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Narrators = [new() { Name = "name", Published = true }],
            Publisher = "publisher",
            TotalChapters = 0,
            Uri = "uri",
            Edition = "Unabridged",
            Published = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AudiobookBase
        {
            ID = "id",
            Authors = [new() { Name = "name", Published = true }],
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
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            HTMLDescription = "html_description",
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
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Narrators = [new() { Name = "name", Published = true }],
            Publisher = "publisher",
            TotalChapters = 0,
            Uri = "uri",
        };

        Assert.Null(model.Edition);
        Assert.False(model.RawData.ContainsKey("edition"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AudiobookBase
        {
            ID = "id",
            Authors = [new() { Name = "name", Published = true }],
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
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            HTMLDescription = "html_description",
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
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Narrators = [new() { Name = "name", Published = true }],
            Publisher = "publisher",
            TotalChapters = 0,
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AudiobookBase
        {
            ID = "id",
            Authors = [new() { Name = "name", Published = true }],
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
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            HTMLDescription = "html_description",
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
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Narrators = [new() { Name = "name", Published = true }],
            Publisher = "publisher",
            TotalChapters = 0,
            Uri = "uri",

            // Null should be interpreted as omitted for these properties
            Edition = null,
            Published = null,
        };

        Assert.Null(model.Edition);
        Assert.False(model.RawData.ContainsKey("edition"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AudiobookBase
        {
            ID = "id",
            Authors = [new() { Name = "name", Published = true }],
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
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            HTMLDescription = "html_description",
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
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Narrators = [new() { Name = "name", Published = true }],
            Publisher = "publisher",
            TotalChapters = 0,
            Uri = "uri",

            // Null should be interpreted as omitted for these properties
            Edition = null,
            Published = null,
        };

        model.Validate();
    }
}
