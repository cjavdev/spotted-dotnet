using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Me.Player;

[JsonConverter(
    typeof(JsonModelConverter<PlayerGetDevicesResponse, PlayerGetDevicesResponseFromRaw>)
)]
public sealed record class PlayerGetDevicesResponse : JsonModel
{
    public required IReadOnlyList<DeviceObject> Devices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DeviceObject>>("devices");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DeviceObject>>(
                "devices",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Devices)
        {
            item.Validate();
        }
    }

    public PlayerGetDevicesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlayerGetDevicesResponse(PlayerGetDevicesResponse playerGetDevicesResponse)
        : base(playerGetDevicesResponse) { }
#pragma warning restore CS8618

    public PlayerGetDevicesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlayerGetDevicesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlayerGetDevicesResponseFromRaw.FromRawUnchecked"/>
    public static PlayerGetDevicesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PlayerGetDevicesResponse(IReadOnlyList<DeviceObject> devices)
        : this()
    {
        this.Devices = devices;
    }
}

class PlayerGetDevicesResponseFromRaw : IFromRawJson<PlayerGetDevicesResponse>
{
    /// <inheritdoc/>
    public PlayerGetDevicesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlayerGetDevicesResponse.FromRawUnchecked(rawData);
}
