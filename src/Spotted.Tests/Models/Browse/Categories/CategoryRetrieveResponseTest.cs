using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models;
using Spotted.Models.Browse.Categories;

namespace Spotted.Tests.Models.Browse.Categories;

public class CategoryRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CategoryRetrieveResponse
        {
            ID = "equal",
            Href = "href",
            Icons =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                },
            ],
            Name = "EQUAL",
        };

        string expectedID = "equal";
        string expectedHref = "href";
        List<ImageObject> expectedIcons =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
            },
        ];
        string expectedName = "EQUAL";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedIcons.Count, model.Icons.Count);
        for (int i = 0; i < expectedIcons.Count; i++)
        {
            Assert.Equal(expectedIcons[i], model.Icons[i]);
        }
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CategoryRetrieveResponse
        {
            ID = "equal",
            Href = "href",
            Icons =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                },
            ],
            Name = "EQUAL",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CategoryRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CategoryRetrieveResponse
        {
            ID = "equal",
            Href = "href",
            Icons =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                },
            ],
            Name = "EQUAL",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CategoryRetrieveResponse>(json);
        Assert.NotNull(deserialized);

        string expectedID = "equal";
        string expectedHref = "href";
        List<ImageObject> expectedIcons =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
            },
        ];
        string expectedName = "EQUAL";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedIcons.Count, deserialized.Icons.Count);
        for (int i = 0; i < expectedIcons.Count; i++)
        {
            Assert.Equal(expectedIcons[i], deserialized.Icons[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CategoryRetrieveResponse
        {
            ID = "equal",
            Href = "href",
            Icons =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                },
            ],
            Name = "EQUAL",
        };

        model.Validate();
    }
}
