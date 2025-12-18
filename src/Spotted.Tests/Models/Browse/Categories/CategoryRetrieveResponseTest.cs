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
                    Published = true,
                },
            ],
            Name = "EQUAL",
            Published = true,
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
                Published = true,
            },
        ];
        string expectedName = "EQUAL";
        bool expectedPublished = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedIcons.Count, model.Icons.Count);
        for (int i = 0; i < expectedIcons.Count; i++)
        {
            Assert.Equal(expectedIcons[i], model.Icons[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPublished, model.Published);
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
                    Published = true,
                },
            ],
            Name = "EQUAL",
            Published = true,
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
                    Published = true,
                },
            ],
            Name = "EQUAL",
            Published = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CategoryRetrieveResponse>(element);
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
                Published = true,
            },
        ];
        string expectedName = "EQUAL";
        bool expectedPublished = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedIcons.Count, deserialized.Icons.Count);
        for (int i = 0; i < expectedIcons.Count; i++)
        {
            Assert.Equal(expectedIcons[i], deserialized.Icons[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPublished, deserialized.Published);
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
                    Published = true,
                },
            ],
            Name = "EQUAL",
            Published = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
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
                    Published = true,
                },
            ],
            Name = "EQUAL",
        };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
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
                    Published = true,
                },
            ],
            Name = "EQUAL",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
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
                    Published = true,
                },
            ],
            Name = "EQUAL",

            // Null should be interpreted as omitted for these properties
            Published = null,
        };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
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
                    Published = true,
                },
            ],
            Name = "EQUAL",

            // Null should be interpreted as omitted for these properties
            Published = null,
        };

        model.Validate();
    }
}
