using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models.Me.Player;

namespace Spotted.Tests.Models.Me.Player;

public class PlayerStartPlaybackParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlayerStartPlaybackParams
        {
            DeviceID = "0d1841b0976bae2a3a310dd74c0f3df354899bc8",
            ContextUri = "spotify:album:5ht7ItJgpBH7W6vJ5BqpPr",
            Offset = new Dictionary<string, JsonElement>()
            {
                { "position", JsonSerializer.SerializeToElement("bar") },
            },
            PositionMs = 0,
            Published = true,
            Uris = ["string"],
        };

        string expectedDeviceID = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";
        string expectedContextUri = "spotify:album:5ht7ItJgpBH7W6vJ5BqpPr";
        Dictionary<string, JsonElement> expectedOffset = new()
        {
            { "position", JsonSerializer.SerializeToElement("bar") },
        };
        long expectedPositionMs = 0;
        bool expectedPublished = true;
        List<string> expectedUris = ["string"];

        Assert.Equal(expectedDeviceID, parameters.DeviceID);
        Assert.Equal(expectedContextUri, parameters.ContextUri);
        Assert.NotNull(parameters.Offset);
        Assert.Equal(expectedOffset.Count, parameters.Offset.Count);
        foreach (var item in expectedOffset)
        {
            Assert.True(parameters.Offset.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Offset[item.Key]));
        }
        Assert.Equal(expectedPositionMs, parameters.PositionMs);
        Assert.Equal(expectedPublished, parameters.Published);
        Assert.NotNull(parameters.Uris);
        Assert.Equal(expectedUris.Count, parameters.Uris.Count);
        for (int i = 0; i < expectedUris.Count; i++)
        {
            Assert.Equal(expectedUris[i], parameters.Uris[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlayerStartPlaybackParams { };

        Assert.Null(parameters.DeviceID);
        Assert.False(parameters.RawQueryData.ContainsKey("device_id"));
        Assert.Null(parameters.ContextUri);
        Assert.False(parameters.RawBodyData.ContainsKey("context_uri"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawBodyData.ContainsKey("offset"));
        Assert.Null(parameters.PositionMs);
        Assert.False(parameters.RawBodyData.ContainsKey("position_ms"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
        Assert.Null(parameters.Uris);
        Assert.False(parameters.RawBodyData.ContainsKey("uris"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PlayerStartPlaybackParams
        {
            // Null should be interpreted as omitted for these properties
            DeviceID = null,
            ContextUri = null,
            Offset = null,
            PositionMs = null,
            Published = null,
            Uris = null,
        };

        Assert.Null(parameters.DeviceID);
        Assert.False(parameters.RawQueryData.ContainsKey("device_id"));
        Assert.Null(parameters.ContextUri);
        Assert.False(parameters.RawBodyData.ContainsKey("context_uri"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawBodyData.ContainsKey("offset"));
        Assert.Null(parameters.PositionMs);
        Assert.False(parameters.RawBodyData.ContainsKey("position_ms"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
        Assert.Null(parameters.Uris);
        Assert.False(parameters.RawBodyData.ContainsKey("uris"));
    }
}
