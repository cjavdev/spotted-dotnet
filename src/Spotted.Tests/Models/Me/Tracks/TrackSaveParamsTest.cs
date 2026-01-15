using System;
using System.Collections.Generic;
using System.Text.Json;
using Spotted.Core;
using Spotted.Models.Me.Tracks;

namespace Spotted.Tests.Models.Me.Tracks;

public class TrackSaveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TrackSaveParams
        {
            Ids = ["string"],
            Published = true,
            TimestampedIds =
            [
                new() { ID = "id", AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            ],
        };

        List<string> expectedIds = ["string"];
        bool expectedPublished = true;
        List<TimestampedID> expectedTimestampedIds =
        [
            new() { ID = "id", AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
        ];

        Assert.Equal(expectedIds.Count, parameters.Ids.Count);
        for (int i = 0; i < expectedIds.Count; i++)
        {
            Assert.Equal(expectedIds[i], parameters.Ids[i]);
        }
        Assert.Equal(expectedPublished, parameters.Published);
        Assert.NotNull(parameters.TimestampedIds);
        Assert.Equal(expectedTimestampedIds.Count, parameters.TimestampedIds.Count);
        for (int i = 0; i < expectedTimestampedIds.Count; i++)
        {
            Assert.Equal(expectedTimestampedIds[i], parameters.TimestampedIds[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TrackSaveParams { Ids = ["string"] };

        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
        Assert.Null(parameters.TimestampedIds);
        Assert.False(parameters.RawBodyData.ContainsKey("timestamped_ids"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TrackSaveParams
        {
            Ids = ["string"],

            // Null should be interpreted as omitted for these properties
            Published = null,
            TimestampedIds = null,
        };

        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
        Assert.Null(parameters.TimestampedIds);
        Assert.False(parameters.RawBodyData.ContainsKey("timestamped_ids"));
    }

    [Fact]
    public void Url_Works()
    {
        TrackSaveParams parameters = new() { Ids = ["string"] };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.Equal(new Uri("https://api.spotify.com/v1/me/tracks"), url);
    }
}

public class TimestampedIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TimestampedID
        {
            ID = "id",
            AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedAddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAddedAt, model.AddedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TimestampedID
        {
            ID = "id",
            AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TimestampedID>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TimestampedID
        {
            ID = "id",
            AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TimestampedID>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedAddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAddedAt, deserialized.AddedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TimestampedID
        {
            ID = "id",
            AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }
}
