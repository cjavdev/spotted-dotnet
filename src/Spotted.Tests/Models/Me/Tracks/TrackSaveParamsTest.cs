using System;
using System.Text.Json;
using Spotted.Models.Me.Tracks;

namespace Spotted.Tests.Models.Me.Tracks;

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
