using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Recommendations;

/// <summary>
/// Recommendations are generated based on the available information for a given seed
/// entity and matched against similar artists and tracks. If there is sufficient
/// information about the provided seeds, a list of tracks will be returned together
/// with pool size details.
///
/// <para>For artists and tracks that are very new or obscure there might not be
/// enough data to generate a list of tracks. </para>
/// </summary>
[Obsolete("deprecated")]
public sealed record class RecommendationGetParams : ParamsBase
{
    /// <summary>
    /// The target size of the list of recommended tracks. For seeds with unusually
    /// small pools or when highly restrictive filtering is applied, it may be impossible
    /// to generate the requested number of recommended tracks. Debugging information
    /// for such cases is available in the response. Default: 20\. Minimum: 1\. Maximum:
    /// 100.
    /// </summary>
    public long? Limit
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "limit", value);
        }
    }

    /// <summary>
    /// An [ISO 3166-1 alpha-2 country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2).
    ///   If a country code is specified, only content that is available in that market
    /// will be returned.<br/>   If a valid user access token is specified in the
    /// request header, the country associated with   the user account will take
    /// priority over this parameter.<br/>   _**Note**: If neither market or user
    /// country are provided, the content is considered unavailable for the client._<br/>
    ///   Users can view the country that is associated with their account in the
    /// [account settings](https://www.spotify.com/account/overview/).
    /// </summary>
    public string? Market
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "market"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "market", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard ceiling on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `max_instrumentalness=0.35` would filter out
    /// most tracks that are likely to be instrumental.
    /// </summary>
    public double? MaxAcousticness
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "max_acousticness"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "max_acousticness", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard ceiling on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `max_instrumentalness=0.35` would filter out
    /// most tracks that are likely to be instrumental.
    /// </summary>
    public double? MaxDanceability
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "max_danceability"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "max_danceability", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard ceiling on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `max_instrumentalness=0.35` would filter out
    /// most tracks that are likely to be instrumental.
    /// </summary>
    public long? MaxDurationMs
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "max_duration_ms"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "max_duration_ms", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard ceiling on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `max_instrumentalness=0.35` would filter out
    /// most tracks that are likely to be instrumental.
    /// </summary>
    public double? MaxEnergy
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "max_energy"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "max_energy", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard ceiling on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `max_instrumentalness=0.35` would filter out
    /// most tracks that are likely to be instrumental.
    /// </summary>
    public double? MaxInstrumentalness
    {
        get
        {
            return ModelBase.GetNullableStruct<double>(this.RawQueryData, "max_instrumentalness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "max_instrumentalness", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard ceiling on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `max_instrumentalness=0.35` would filter out
    /// most tracks that are likely to be instrumental.
    /// </summary>
    public long? MaxKey
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "max_key"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "max_key", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard ceiling on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `max_instrumentalness=0.35` would filter out
    /// most tracks that are likely to be instrumental.
    /// </summary>
    public double? MaxLiveness
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "max_liveness"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "max_liveness", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard ceiling on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `max_instrumentalness=0.35` would filter out
    /// most tracks that are likely to be instrumental.
    /// </summary>
    public double? MaxLoudness
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "max_loudness"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "max_loudness", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard ceiling on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `max_instrumentalness=0.35` would filter out
    /// most tracks that are likely to be instrumental.
    /// </summary>
    public long? MaxMode
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "max_mode"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "max_mode", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard ceiling on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `max_instrumentalness=0.35` would filter out
    /// most tracks that are likely to be instrumental.
    /// </summary>
    public long? MaxPopularity
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "max_popularity"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "max_popularity", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard ceiling on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `max_instrumentalness=0.35` would filter out
    /// most tracks that are likely to be instrumental.
    /// </summary>
    public double? MaxSpeechiness
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "max_speechiness"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "max_speechiness", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard ceiling on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `max_instrumentalness=0.35` would filter out
    /// most tracks that are likely to be instrumental.
    /// </summary>
    public double? MaxTempo
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "max_tempo"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "max_tempo", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard ceiling on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `max_instrumentalness=0.35` would filter out
    /// most tracks that are likely to be instrumental.
    /// </summary>
    public long? MaxTimeSignature
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "max_time_signature"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "max_time_signature", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard ceiling on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `max_instrumentalness=0.35` would filter out
    /// most tracks that are likely to be instrumental.
    /// </summary>
    public double? MaxValence
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "max_valence"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "max_valence", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard floor on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `min_tempo=140` would restrict results to
    /// only those tracks with a tempo of greater than 140 beats per minute.
    /// </summary>
    public double? MinAcousticness
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "min_acousticness"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "min_acousticness", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard floor on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `min_tempo=140` would restrict results to
    /// only those tracks with a tempo of greater than 140 beats per minute.
    /// </summary>
    public double? MinDanceability
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "min_danceability"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "min_danceability", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard floor on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `min_tempo=140` would restrict results to
    /// only those tracks with a tempo of greater than 140 beats per minute.
    /// </summary>
    public long? MinDurationMs
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "min_duration_ms"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "min_duration_ms", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard floor on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `min_tempo=140` would restrict results to
    /// only those tracks with a tempo of greater than 140 beats per minute.
    /// </summary>
    public double? MinEnergy
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "min_energy"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "min_energy", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard floor on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `min_tempo=140` would restrict results to
    /// only those tracks with a tempo of greater than 140 beats per minute.
    /// </summary>
    public double? MinInstrumentalness
    {
        get
        {
            return ModelBase.GetNullableStruct<double>(this.RawQueryData, "min_instrumentalness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "min_instrumentalness", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard floor on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `min_tempo=140` would restrict results to
    /// only those tracks with a tempo of greater than 140 beats per minute.
    /// </summary>
    public long? MinKey
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "min_key"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "min_key", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard floor on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `min_tempo=140` would restrict results to
    /// only those tracks with a tempo of greater than 140 beats per minute.
    /// </summary>
    public double? MinLiveness
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "min_liveness"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "min_liveness", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard floor on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `min_tempo=140` would restrict results to
    /// only those tracks with a tempo of greater than 140 beats per minute.
    /// </summary>
    public double? MinLoudness
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "min_loudness"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "min_loudness", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard floor on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `min_tempo=140` would restrict results to
    /// only those tracks with a tempo of greater than 140 beats per minute.
    /// </summary>
    public long? MinMode
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "min_mode"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "min_mode", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard floor on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `min_tempo=140` would restrict results to
    /// only those tracks with a tempo of greater than 140 beats per minute.
    /// </summary>
    public long? MinPopularity
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "min_popularity"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "min_popularity", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard floor on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `min_tempo=140` would restrict results to
    /// only those tracks with a tempo of greater than 140 beats per minute.
    /// </summary>
    public double? MinSpeechiness
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "min_speechiness"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "min_speechiness", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard floor on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `min_tempo=140` would restrict results to
    /// only those tracks with a tempo of greater than 140 beats per minute.
    /// </summary>
    public double? MinTempo
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "min_tempo"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "min_tempo", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard floor on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `min_tempo=140` would restrict results to
    /// only those tracks with a tempo of greater than 140 beats per minute.
    /// </summary>
    public long? MinTimeSignature
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "min_time_signature"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "min_time_signature", value);
        }
    }

    /// <summary>
    /// For each tunable track attribute, a hard floor on the selected track attribute’s
    /// value can be provided. See tunable track attributes below for the list of
    /// available options. For example, `min_tempo=140` would restrict results to
    /// only those tracks with a tempo of greater than 140 beats per minute.
    /// </summary>
    public double? MinValence
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "min_valence"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "min_valence", value);
        }
    }

    /// <summary>
    /// A comma separated list of [Spotify IDs](/documentation/web-api/concepts/spotify-uris-ids)
    /// for seed artists.  Up to 5 seed values may be provided in any combination
    /// of `seed_artists`, `seed_tracks` and `seed_genres`.<br/> _**Note**: only
    /// required if `seed_genres` and `seed_tracks` are not set_.
    /// </summary>
    public string? SeedArtists
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "seed_artists"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "seed_artists", value);
        }
    }

    /// <summary>
    /// A comma separated list of any genres in the set of [available genre seeds](/documentation/web-api/reference/get-recommendation-genres).
    /// Up to 5 seed values may be provided in any combination of `seed_artists`,
    /// `seed_tracks` and `seed_genres`.<br/> _**Note**: only required if `seed_artists`
    /// and `seed_tracks` are not set_.
    /// </summary>
    public string? SeedGenres
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "seed_genres"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "seed_genres", value);
        }
    }

    /// <summary>
    /// A comma separated list of [Spotify IDs](/documentation/web-api/concepts/spotify-uris-ids)
    /// for a seed track.  Up to 5 seed values may be provided in any combination
    /// of `seed_artists`, `seed_tracks` and `seed_genres`.<br/> _**Note**: only required
    /// if `seed_artists` and `seed_genres` are not set_.
    /// </summary>
    public string? SeedTracks
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "seed_tracks"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "seed_tracks", value);
        }
    }

    /// <summary>
    /// For each of the tunable track attributes (below) a target value may be provided.
    /// Tracks with the attribute values nearest to the target values will be preferred.
    /// For example, you might request `target_energy=0.6` and `target_danceability=0.8`.
    /// All target values will be weighed equally in ranking results.
    /// </summary>
    public double? TargetAcousticness
    {
        get
        {
            return ModelBase.GetNullableStruct<double>(this.RawQueryData, "target_acousticness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "target_acousticness", value);
        }
    }

    /// <summary>
    /// For each of the tunable track attributes (below) a target value may be provided.
    /// Tracks with the attribute values nearest to the target values will be preferred.
    /// For example, you might request `target_energy=0.6` and `target_danceability=0.8`.
    /// All target values will be weighed equally in ranking results.
    /// </summary>
    public double? TargetDanceability
    {
        get
        {
            return ModelBase.GetNullableStruct<double>(this.RawQueryData, "target_danceability");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "target_danceability", value);
        }
    }

    /// <summary>
    /// Target duration of the track (ms)
    /// </summary>
    public long? TargetDurationMs
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "target_duration_ms"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "target_duration_ms", value);
        }
    }

    /// <summary>
    /// For each of the tunable track attributes (below) a target value may be provided.
    /// Tracks with the attribute values nearest to the target values will be preferred.
    /// For example, you might request `target_energy=0.6` and `target_danceability=0.8`.
    /// All target values will be weighed equally in ranking results.
    /// </summary>
    public double? TargetEnergy
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "target_energy"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "target_energy", value);
        }
    }

    /// <summary>
    /// For each of the tunable track attributes (below) a target value may be provided.
    /// Tracks with the attribute values nearest to the target values will be preferred.
    /// For example, you might request `target_energy=0.6` and `target_danceability=0.8`.
    /// All target values will be weighed equally in ranking results.
    /// </summary>
    public double? TargetInstrumentalness
    {
        get
        {
            return ModelBase.GetNullableStruct<double>(
                this.RawQueryData,
                "target_instrumentalness"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "target_instrumentalness", value);
        }
    }

    /// <summary>
    /// For each of the tunable track attributes (below) a target value may be provided.
    /// Tracks with the attribute values nearest to the target values will be preferred.
    /// For example, you might request `target_energy=0.6` and `target_danceability=0.8`.
    /// All target values will be weighed equally in ranking results.
    /// </summary>
    public long? TargetKey
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "target_key"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "target_key", value);
        }
    }

    /// <summary>
    /// For each of the tunable track attributes (below) a target value may be provided.
    /// Tracks with the attribute values nearest to the target values will be preferred.
    /// For example, you might request `target_energy=0.6` and `target_danceability=0.8`.
    /// All target values will be weighed equally in ranking results.
    /// </summary>
    public double? TargetLiveness
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "target_liveness"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "target_liveness", value);
        }
    }

    /// <summary>
    /// For each of the tunable track attributes (below) a target value may be provided.
    /// Tracks with the attribute values nearest to the target values will be preferred.
    /// For example, you might request `target_energy=0.6` and `target_danceability=0.8`.
    /// All target values will be weighed equally in ranking results.
    /// </summary>
    public double? TargetLoudness
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "target_loudness"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "target_loudness", value);
        }
    }

    /// <summary>
    /// For each of the tunable track attributes (below) a target value may be provided.
    /// Tracks with the attribute values nearest to the target values will be preferred.
    /// For example, you might request `target_energy=0.6` and `target_danceability=0.8`.
    /// All target values will be weighed equally in ranking results.
    /// </summary>
    public long? TargetMode
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "target_mode"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "target_mode", value);
        }
    }

    /// <summary>
    /// For each of the tunable track attributes (below) a target value may be provided.
    /// Tracks with the attribute values nearest to the target values will be preferred.
    /// For example, you might request `target_energy=0.6` and `target_danceability=0.8`.
    /// All target values will be weighed equally in ranking results.
    /// </summary>
    public long? TargetPopularity
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "target_popularity"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "target_popularity", value);
        }
    }

    /// <summary>
    /// For each of the tunable track attributes (below) a target value may be provided.
    /// Tracks with the attribute values nearest to the target values will be preferred.
    /// For example, you might request `target_energy=0.6` and `target_danceability=0.8`.
    /// All target values will be weighed equally in ranking results.
    /// </summary>
    public double? TargetSpeechiness
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "target_speechiness"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "target_speechiness", value);
        }
    }

    /// <summary>
    /// Target tempo (BPM)
    /// </summary>
    public double? TargetTempo
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "target_tempo"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "target_tempo", value);
        }
    }

    /// <summary>
    /// For each of the tunable track attributes (below) a target value may be provided.
    /// Tracks with the attribute values nearest to the target values will be preferred.
    /// For example, you might request `target_energy=0.6` and `target_danceability=0.8`.
    /// All target values will be weighed equally in ranking results.
    /// </summary>
    public long? TargetTimeSignature
    {
        get
        {
            return ModelBase.GetNullableStruct<long>(this.RawQueryData, "target_time_signature");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "target_time_signature", value);
        }
    }

    /// <summary>
    /// For each of the tunable track attributes (below) a target value may be provided.
    /// Tracks with the attribute values nearest to the target values will be preferred.
    /// For example, you might request `target_energy=0.6` and `target_danceability=0.8`.
    /// All target values will be weighed equally in ranking results.
    /// </summary>
    public double? TargetValence
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawQueryData, "target_valence"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "target_valence", value);
        }
    }

    public RecommendationGetParams() { }

    public RecommendationGetParams(RecommendationGetParams recommendationGetParams)
        : base(recommendationGetParams) { }

    public RecommendationGetParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecommendationGetParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static RecommendationGetParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/recommendations")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
