using System;
using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models.Me.Tracks;

namespace Spotted.Tests.Models.Me.Tracks;

public class TrackSaveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TrackSaveParams
        {
            IDs = ["string"],
            Published = true,
            TimestampedIDs =
            [
                new() { ID = "id", AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            ],
        };

        List<string> expectedIDs = ["string"];
        bool expectedPublished = true;
        List<TimestampedID> expectedTimestampedIDs =
        [
            new() { ID = "id", AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
        ];

        Assert.Equal(expectedIDs.Count, parameters.IDs.Count);
        for (int i = 0; i < expectedIDs.Count; i++)
        {
            Assert.Equal(expectedIDs[i], parameters.IDs[i]);
        }
        Assert.Equal(expectedPublished, parameters.Published);
        Assert.NotNull(parameters.TimestampedIDs);
        Assert.Equal(expectedTimestampedIDs.Count, parameters.TimestampedIDs.Count);
        for (int i = 0; i < expectedTimestampedIDs.Count; i++)
        {
            Assert.Equal(expectedTimestampedIDs[i], parameters.TimestampedIDs[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TrackSaveParams { IDs = ["string"] };

        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
        Assert.Null(parameters.TimestampedIDs);
        Assert.False(parameters.RawBodyData.ContainsKey("timestamped_ids"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TrackSaveParams
        {
            IDs = ["string"],

            // Null should be interpreted as omitted for these properties
            Published = null,
            TimestampedIDs = null,
        };

        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
        Assert.Null(parameters.TimestampedIDs);
        Assert.False(parameters.RawBodyData.ContainsKey("timestamped_ids"));
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TimestampedID>(json);

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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TimestampedID>(element);
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
