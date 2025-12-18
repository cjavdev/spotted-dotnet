using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models.Recommendations;

namespace Spotted.Tests.Models.Recommendations;

public class RecommendationListAvailableGenreSeedsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RecommendationListAvailableGenreSeedsResponse
        {
            Genres = ["alternative", "samba"],
        };

        List<string> expectedGenres = ["alternative", "samba"];

        Assert.Equal(expectedGenres.Count, model.Genres.Count);
        for (int i = 0; i < expectedGenres.Count; i++)
        {
            Assert.Equal(expectedGenres[i], model.Genres[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RecommendationListAvailableGenreSeedsResponse
        {
            Genres = ["alternative", "samba"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<RecommendationListAvailableGenreSeedsResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RecommendationListAvailableGenreSeedsResponse
        {
            Genres = ["alternative", "samba"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<RecommendationListAvailableGenreSeedsResponse>(element);
        Assert.NotNull(deserialized);

        List<string> expectedGenres = ["alternative", "samba"];

        Assert.Equal(expectedGenres.Count, deserialized.Genres.Count);
        for (int i = 0; i < expectedGenres.Count; i++)
        {
            Assert.Equal(expectedGenres[i], deserialized.Genres[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RecommendationListAvailableGenreSeedsResponse
        {
            Genres = ["alternative", "samba"],
        };

        model.Validate();
    }
}
