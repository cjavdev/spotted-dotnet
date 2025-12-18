using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Me.Player;

[JsonConverter(typeof(JsonModelConverter<DeviceObject, DeviceObjectFromRaw>))]
public sealed record class DeviceObject : JsonModel
{
    /// <summary>
    /// The device ID. This ID is unique and persistent to some extent. However, this
    /// is not guaranteed and any cached `device_id` should periodically be cleared
    /// out and refetched as necessary.
    /// </summary>
    public string? ID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// If this device is the currently active device.
    /// </summary>
    public bool? IsActive
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "is_active"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "is_active", value);
        }
    }

    /// <summary>
    /// If this device is currently in a private session.
    /// </summary>
    public bool? IsPrivateSession
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "is_private_session"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "is_private_session", value);
        }
    }

    /// <summary>
    /// Whether controlling this device is restricted. At present if this is "true"
    /// then no Web API commands will be accepted by this device.
    /// </summary>
    public bool? IsRestricted
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "is_restricted"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "is_restricted", value);
        }
    }

    /// <summary>
    /// A human-readable name for the device. Some devices have a name that the user
    /// can configure (e.g. \"Loudest speaker\") and some devices have a generic name
    /// associated with the manufacturer or device model.
    /// </summary>
    public string? Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "name", value);
        }
    }

    /// <summary>
    /// The playlist's public/private status (if it should be added to the user's
    /// profile or not): `true` the playlist will be public, `false` the playlist
    /// will be private, `null` the playlist status is not relevant. For more about
    /// public/private status, see [Working with Playlists](/documentation/web-api/concepts/playlists)
    /// </summary>
    public bool? Published
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "published", value);
        }
    }

    /// <summary>
    /// If this device can be used to set the volume.
    /// </summary>
    public bool? SupportsVolume
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "supports_volume"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "supports_volume", value);
        }
    }

    /// <summary>
    /// Device type, such as "computer", "smartphone" or "speaker".
    /// </summary>
    public string? Type
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "type", value);
        }
    }

    /// <summary>
    /// The current volume in percent.
    /// </summary>
    public long? VolumePercent
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "volume_percent"); }
        init { JsonModel.Set(this._rawData, "volume_percent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.IsActive;
        _ = this.IsPrivateSession;
        _ = this.IsRestricted;
        _ = this.Name;
        _ = this.Published;
        _ = this.SupportsVolume;
        _ = this.Type;
        _ = this.VolumePercent;
    }

    public DeviceObject() { }

    public DeviceObject(DeviceObject deviceObject)
        : base(deviceObject) { }

    public DeviceObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeviceObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeviceObjectFromRaw.FromRawUnchecked"/>
    public static DeviceObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeviceObjectFromRaw : IFromRawJson<DeviceObject>
{
    /// <inheritdoc/>
    public DeviceObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DeviceObject.FromRawUnchecked(rawData);
}
