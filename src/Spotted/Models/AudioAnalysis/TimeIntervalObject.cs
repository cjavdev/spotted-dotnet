using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.AudioAnalysis;

[JsonConverter(typeof(JsonModelConverter<TimeIntervalObject, TimeIntervalObjectFromRaw>))]
public sealed record class TimeIntervalObject : JsonModel
{
    /// <summary>
    /// The confidence, from 0.0 to 1.0, of the reliability of the interval.
    /// </summary>
    public double? Confidence
    {
        get { return this._rawData.GetNullableStruct<double>("confidence"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confidence", value);
        }
    }

    /// <summary>
    /// The duration (in seconds) of the time interval.
    /// </summary>
    public double? Duration
    {
        get { return this._rawData.GetNullableStruct<double>("duration"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("duration", value);
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
        get { return this._rawData.GetNullableStruct<bool>("published"); }
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
    /// The starting point (in seconds) of the time interval.
    /// </summary>
    public double? Start
    {
        get { return this._rawData.GetNullableStruct<double>("start"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("start", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Confidence;
        _ = this.Duration;
        _ = this.Published;
        _ = this.Start;
    }

    public TimeIntervalObject() { }

    public TimeIntervalObject(TimeIntervalObject timeIntervalObject)
        : base(timeIntervalObject) { }

    public TimeIntervalObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TimeIntervalObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimeIntervalObjectFromRaw.FromRawUnchecked"/>
    public static TimeIntervalObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimeIntervalObjectFromRaw : IFromRawJson<TimeIntervalObject>
{
    /// <inheritdoc/>
    public TimeIntervalObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TimeIntervalObject.FromRawUnchecked(rawData);
}
