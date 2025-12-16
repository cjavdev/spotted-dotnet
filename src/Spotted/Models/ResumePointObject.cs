using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models;

[JsonConverter(typeof(ModelConverter<ResumePointObject, ResumePointObjectFromRaw>))]
public sealed record class ResumePointObject : ModelBase
{
    /// <summary>
    /// Whether or not the episode has been fully played by the user.
    /// </summary>
    public bool? FullyPlayed
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "fully_played"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "fully_played", value);
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
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "published", value);
        }
    }

    /// <summary>
    /// The user's most recent position in the episode in milliseconds.
    /// </summary>
    public long? ResumePositionMs
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "resume_position_ms"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "resume_position_ms", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FullyPlayed;
        _ = this.Published;
        _ = this.ResumePositionMs;
    }

    public ResumePointObject() { }

    public ResumePointObject(ResumePointObject resumePointObject)
        : base(resumePointObject) { }

    public ResumePointObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResumePointObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResumePointObjectFromRaw.FromRawUnchecked"/>
    public static ResumePointObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResumePointObjectFromRaw : IFromRaw<ResumePointObject>
{
    /// <inheritdoc/>
    public ResumePointObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ResumePointObject.FromRawUnchecked(rawData);
}
