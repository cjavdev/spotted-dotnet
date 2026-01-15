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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// If this device is the currently active device.
    /// </summary>
    public bool? IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_active");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_active", value);
        }
    }

    /// <summary>
    /// If this device is currently in a private session.
    /// </summary>
    public bool? IsPrivateSession
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_private_session");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_private_session", value);
        }
    }

    /// <summary>
    /// Whether controlling this device is restricted. At present if this is "true"
    /// then no Web API commands will be accepted by this device.
    /// </summary>
    public bool? IsRestricted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_restricted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_restricted", value);
        }
    }

    /// <summary>
    /// A human-readable name for the device. Some devices have a name that the user
    /// can configure (e.g. \"Loudest speaker\") and some devices have a generic name
    /// associated with the manufacturer or device model.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("published");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("published", value);
        }
    }

    /// <summary>
    /// If this device can be used to set the volume.
    /// </summary>
    public bool? SupportsVolume
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("supports_volume");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("supports_volume", value);
        }
    }

    /// <summary>
    /// Device type, such as "computer", "smartphone" or "speaker".
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// The current volume in percent.
    /// </summary>
    public long? VolumePercent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("volume_percent");
        }
        init { this._rawData.Set("volume_percent", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeviceObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
