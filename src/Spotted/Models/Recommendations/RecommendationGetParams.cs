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
/// enough data to generate a list of tracks.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
[Obsolete("deprecated")]
public record class RecommendationGetParams : ParamsBase
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("market");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("market", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("max_acousticness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_acousticness", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("max_danceability");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_danceability", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("max_duration_ms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_duration_ms", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("max_energy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_energy", value);
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
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("max_instrumentalness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_instrumentalness", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("max_key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_key", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("max_liveness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_liveness", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("max_loudness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_loudness", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("max_mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_mode", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("max_popularity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_popularity", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("max_speechiness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_speechiness", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("max_tempo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_tempo", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("max_time_signature");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_time_signature", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("max_valence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_valence", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("min_acousticness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_acousticness", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("min_danceability");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_danceability", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("min_duration_ms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_duration_ms", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("min_energy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_energy", value);
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
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("min_instrumentalness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_instrumentalness", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("min_key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_key", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("min_liveness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_liveness", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("min_loudness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_loudness", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("min_mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_mode", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("min_popularity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_popularity", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("min_speechiness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_speechiness", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("min_tempo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_tempo", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("min_time_signature");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_time_signature", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("min_valence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_valence", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("seed_artists");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("seed_artists", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("seed_genres");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("seed_genres", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("seed_tracks");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("seed_tracks", value);
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
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("target_acousticness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("target_acousticness", value);
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
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("target_danceability");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("target_danceability", value);
        }
    }

    /// <summary>
    /// Target duration of the track (ms)
    /// </summary>
    public long? TargetDurationMs
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("target_duration_ms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("target_duration_ms", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("target_energy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("target_energy", value);
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
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("target_instrumentalness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("target_instrumentalness", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("target_key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("target_key", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("target_liveness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("target_liveness", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("target_loudness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("target_loudness", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("target_mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("target_mode", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("target_popularity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("target_popularity", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("target_speechiness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("target_speechiness", value);
        }
    }

    /// <summary>
    /// Target tempo (BPM)
    /// </summary>
    public double? TargetTempo
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("target_tempo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("target_tempo", value);
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
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("target_time_signature");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("target_time_signature", value);
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("target_valence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("target_valence", value);
        }
    }

    public RecommendationGetParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecommendationGetParams(RecommendationGetParams recommendationGetParams)
        : base(recommendationGetParams) { }
#pragma warning restore CS8618

    public RecommendationGetParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecommendationGetParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(RecommendationGetParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
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

    public override int GetHashCode()
    {
        return 0;
    }
}
