using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.AudioAnalysis;

[JsonConverter(typeof(ModelConverter<TimeIntervalObject, TimeIntervalObjectFromRaw>))]
public sealed record class TimeIntervalObject : ModelBase
{
    /// <summary>
    /// The confidence, from 0.0 to 1.0, of the reliability of the interval.
    /// </summary>
    public double? Confidence
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "confidence"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "confidence", value);
        }
    }

    /// <summary>
    /// The duration (in seconds) of the time interval.
    /// </summary>
    public double? Duration
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "duration"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "duration", value);
        }
    }

    /// <summary>
    /// The starting point (in seconds) of the time interval.
    /// </summary>
    public double? Start
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "start"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "start", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Confidence;
        _ = this.Duration;
        _ = this.Start;
    }

    public TimeIntervalObject() { }

    public TimeIntervalObject(TimeIntervalObject timeIntervalObject)
        : base(timeIntervalObject) { }

    public TimeIntervalObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TimeIntervalObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class TimeIntervalObjectFromRaw : IFromRaw<TimeIntervalObject>
{
    /// <inheritdoc/>
    public TimeIntervalObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TimeIntervalObject.FromRawUnchecked(rawData);
}
