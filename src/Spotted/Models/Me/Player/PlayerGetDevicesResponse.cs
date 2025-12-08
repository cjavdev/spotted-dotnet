using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Me.Player;

[JsonConverter(typeof(ModelConverter<PlayerGetDevicesResponse, PlayerGetDevicesResponseFromRaw>))]
public sealed record class PlayerGetDevicesResponse : ModelBase
{
    public required IReadOnlyList<DeviceObject> Devices
    {
        get { return ModelBase.GetNotNullClass<List<DeviceObject>>(this.RawData, "devices"); }
        init { ModelBase.Set(this._rawData, "devices", value); }
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

    public PlayerGetDevicesResponse(PlayerGetDevicesResponse playerGetDevicesResponse)
        : base(playerGetDevicesResponse) { }

    public PlayerGetDevicesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlayerGetDevicesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
    public PlayerGetDevicesResponse(List<DeviceObject> devices)
        : this()
    {
        this.Devices = devices;
    }
}

class PlayerGetDevicesResponseFromRaw : IFromRaw<PlayerGetDevicesResponse>
{
    /// <inheritdoc/>
    public PlayerGetDevicesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlayerGetDevicesResponse.FromRawUnchecked(rawData);
}
