using System;
using System.Text.Json;
using Spotted.Core;
using Spotted.Exceptions;
using Following = Spotted.Models.Me.Following;

namespace Spotted.Tests.Models.Me.Following;

public class FollowingCheckParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Following::FollowingCheckParams
        {
            Ids = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6",
            Type = Following::Type.Artist,
        };

        string expectedIds = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6";
        ApiEnum<string, Following::Type> expectedType = Following::Type.Artist;

        Assert.Equal(expectedIds, parameters.Ids);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void Url_Works()
    {
        Following::FollowingCheckParams parameters = new()
        {
            Ids = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6",
            Type = Following::Type.Artist,
        };

        var url = parameters.Url(
            new() { ClientID = "My Client ID", ClientSecret = "My Client Secret" }
        );

        Assert.Equal(
            new Uri(
                "https://api.spotify.com/v1/me/following/contains?ids=2CIMQHirSU0MQqyYHq0eOx%2c57dN52uHvrHOxijzpIgu3E%2c1vCWHaC5f2uS3yhpwWbIA6&type=artist"
            ),
            url
        );
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Following::Type.Artist)]
    [InlineData(Following::Type.User)]
    public void Validation_Works(Following::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Following::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Following::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SpottedInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Following::Type.Artist)]
    [InlineData(Following::Type.User)]
    public void SerializationRoundtrip_Works(Following::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Following::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Following::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Following::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Following::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
