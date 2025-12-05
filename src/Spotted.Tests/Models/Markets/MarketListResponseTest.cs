using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models.Markets;

namespace Spotted.Tests.Models.Markets;

public class MarketListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MarketListResponse { Markets = ["CA", "BR", "IT"] };

        List<string> expectedMarkets = ["CA", "BR", "IT"];

        Assert.Equal(expectedMarkets.Count, model.Markets.Count);
        for (int i = 0; i < expectedMarkets.Count; i++)
        {
            Assert.Equal(expectedMarkets[i], model.Markets[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MarketListResponse { Markets = ["CA", "BR", "IT"] };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MarketListResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MarketListResponse { Markets = ["CA", "BR", "IT"] };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MarketListResponse>(json);
        Assert.NotNull(deserialized);

        List<string> expectedMarkets = ["CA", "BR", "IT"];

        Assert.Equal(expectedMarkets.Count, deserialized.Markets.Count);
        for (int i = 0; i < expectedMarkets.Count; i++)
        {
            Assert.Equal(expectedMarkets[i], deserialized.Markets[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MarketListResponse { Markets = ["CA", "BR", "IT"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MarketListResponse { };

        Assert.Null(model.Markets);
        Assert.False(model.RawData.ContainsKey("markets"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MarketListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MarketListResponse
        {
            // Null should be interpreted as omitted for these properties
            Markets = null,
        };

        Assert.Null(model.Markets);
        Assert.False(model.RawData.ContainsKey("markets"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MarketListResponse
        {
            // Null should be interpreted as omitted for these properties
            Markets = null,
        };

        model.Validate();
    }
}
