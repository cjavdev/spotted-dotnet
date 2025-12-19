using System;
using System.Text.Json;
using Spotted.Models;
using Spotted.Models.Me.Shows;

namespace Spotted.Tests.Models.Me.Shows;

public class ShowListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ShowListResponse
        {
            AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Published = true,
            Show = new()
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
                IsExternallyHosted = true,
                Languages = ["string"],
                MediaType = "media_type",
                Name = "name",
                Publisher = "publisher",
                TotalEpisodes = 0,
                Uri = "uri",
                Published = true,
            },
        };

        DateTimeOffset expectedAddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedPublished = true;
        ShowBase expectedShow = new()
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
            IsExternallyHosted = true,
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Publisher = "publisher",
            TotalEpisodes = 0,
            Uri = "uri",
            Published = true,
        };

        Assert.Equal(expectedAddedAt, model.AddedAt);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedShow, model.Show);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ShowListResponse
        {
            AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Published = true,
            Show = new()
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
                IsExternallyHosted = true,
                Languages = ["string"],
                MediaType = "media_type",
                Name = "name",
                Publisher = "publisher",
                TotalEpisodes = 0,
                Uri = "uri",
                Published = true,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ShowListResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ShowListResponse
        {
            AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Published = true,
            Show = new()
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
                IsExternallyHosted = true,
                Languages = ["string"],
                MediaType = "media_type",
                Name = "name",
                Publisher = "publisher",
                TotalEpisodes = 0,
                Uri = "uri",
                Published = true,
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ShowListResponse>(element);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedPublished = true;
        ShowBase expectedShow = new()
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
            IsExternallyHosted = true,
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Publisher = "publisher",
            TotalEpisodes = 0,
            Uri = "uri",
            Published = true,
        };

        Assert.Equal(expectedAddedAt, deserialized.AddedAt);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedShow, deserialized.Show);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ShowListResponse
        {
            AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Published = true,
            Show = new()
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
                IsExternallyHosted = true,
                Languages = ["string"],
                MediaType = "media_type",
                Name = "name",
                Publisher = "publisher",
                TotalEpisodes = 0,
                Uri = "uri",
                Published = true,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ShowListResponse { };

        Assert.Null(model.AddedAt);
        Assert.False(model.RawData.ContainsKey("added_at"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Show);
        Assert.False(model.RawData.ContainsKey("show"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ShowListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ShowListResponse
        {
            // Null should be interpreted as omitted for these properties
            AddedAt = null,
            Published = null,
            Show = null,
        };

        Assert.Null(model.AddedAt);
        Assert.False(model.RawData.ContainsKey("added_at"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Show);
        Assert.False(model.RawData.ContainsKey("show"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ShowListResponse
        {
            // Null should be interpreted as omitted for these properties
            AddedAt = null,
            Published = null,
            Show = null,
        };

        model.Validate();
    }
}
