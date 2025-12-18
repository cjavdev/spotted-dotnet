using System.Collections.Generic;
using System.Text.Json;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.AudioAnalysis;

namespace Spotted.Tests.Models.AudioAnalysis;

public class AudioAnalysisRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AudioAnalysisRetrieveResponse
        {
            Bars =
            [
                new()
                {
                    Confidence = 0.925,
                    Duration = 2.18749,
                    Published = true,
                    Start = 0.49567,
                },
            ],
            Beats =
            [
                new()
                {
                    Confidence = 0.925,
                    Duration = 2.18749,
                    Published = true,
                    Start = 0.49567,
                },
            ],
            Meta = new()
            {
                AnalysisTime = 6.93906,
                AnalyzerVersion = "4.0.0",
                DetailedStatus = "OK",
                InputProcess = "libvorbisfile L+R 44100->22050",
                Platform = "Linux",
                StatusCode = 0,
                Timestamp = 1495193577,
            },
            Published = true,
            Sections =
            [
                new()
                {
                    Confidence = 1,
                    Duration = 6.97092,
                    Key = 9,
                    KeyConfidence = 0.297,
                    Loudness = -14.938,
                    Mode = Mode.ModeNoResult,
                    ModeConfidence = 0.471,
                    Published = true,
                    Start = 0,
                    Tempo = 113.178,
                    TempoConfidence = 0.647,
                    TimeSignature = 4,
                    TimeSignatureConfidence = 1,
                },
            ],
            Segments =
            [
                new()
                {
                    Confidence = 0.435,
                    Duration = 0.19891,
                    LoudnessEnd = 0,
                    LoudnessMax = -14.25,
                    LoudnessMaxTime = 0.07305,
                    LoudnessStart = -23.053,
                    Pitches = [0.212, 0.141, 0.294],
                    Published = true,
                    Start = 0.70154,
                    Timbre = [42.115, 64.373, -0.233],
                },
            ],
            Tatums =
            [
                new()
                {
                    Confidence = 0.925,
                    Duration = 2.18749,
                    Published = true,
                    Start = 0.49567,
                },
            ],
            Track = new()
            {
                AnalysisChannels = 1,
                AnalysisSampleRate = 22050,
                CodeVersion = 3.15,
                Codestring = "codestring",
                Duration = 207.95985,
                EchoprintVersion = 4.15,
                Echoprintstring = "echoprintstring",
                EndOfFadeIn = 0,
                Key = 9,
                KeyConfidence = 0.408,
                Loudness = -5.883f,
                Mode = 0,
                ModeConfidence = 0.485,
                NumSamples = 4585515,
                OffsetSeconds = 0,
                RhythmVersion = 1,
                Rhythmstring = "rhythmstring",
                SampleMd5 = "sample_md5",
                StartOfFadeOut = 201.13705,
                SynchVersion = 1,
                Synchstring = "synchstring",
                Tempo = 118.211f,
                TempoConfidence = 0.73,
                TimeSignature = 4,
                TimeSignatureConfidence = 0.994,
                WindowSeconds = 0,
            },
        };

        List<TimeIntervalObject> expectedBars =
        [
            new()
            {
                Confidence = 0.925,
                Duration = 2.18749,
                Published = true,
                Start = 0.49567,
            },
        ];
        List<TimeIntervalObject> expectedBeats =
        [
            new()
            {
                Confidence = 0.925,
                Duration = 2.18749,
                Published = true,
                Start = 0.49567,
            },
        ];
        Meta expectedMeta = new()
        {
            AnalysisTime = 6.93906,
            AnalyzerVersion = "4.0.0",
            DetailedStatus = "OK",
            InputProcess = "libvorbisfile L+R 44100->22050",
            Platform = "Linux",
            StatusCode = 0,
            Timestamp = 1495193577,
        };
        bool expectedPublished = true;
        List<Section> expectedSections =
        [
            new()
            {
                Confidence = 1,
                Duration = 6.97092,
                Key = 9,
                KeyConfidence = 0.297,
                Loudness = -14.938,
                Mode = Mode.ModeNoResult,
                ModeConfidence = 0.471,
                Published = true,
                Start = 0,
                Tempo = 113.178,
                TempoConfidence = 0.647,
                TimeSignature = 4,
                TimeSignatureConfidence = 1,
            },
        ];
        List<Segment> expectedSegments =
        [
            new()
            {
                Confidence = 0.435,
                Duration = 0.19891,
                LoudnessEnd = 0,
                LoudnessMax = -14.25,
                LoudnessMaxTime = 0.07305,
                LoudnessStart = -23.053,
                Pitches = [0.212, 0.141, 0.294],
                Published = true,
                Start = 0.70154,
                Timbre = [42.115, 64.373, -0.233],
            },
        ];
        List<TimeIntervalObject> expectedTatums =
        [
            new()
            {
                Confidence = 0.925,
                Duration = 2.18749,
                Published = true,
                Start = 0.49567,
            },
        ];
        Track expectedTrack = new()
        {
            AnalysisChannels = 1,
            AnalysisSampleRate = 22050,
            CodeVersion = 3.15,
            Codestring = "codestring",
            Duration = 207.95985,
            EchoprintVersion = 4.15,
            Echoprintstring = "echoprintstring",
            EndOfFadeIn = 0,
            Key = 9,
            KeyConfidence = 0.408,
            Loudness = -5.883f,
            Mode = 0,
            ModeConfidence = 0.485,
            NumSamples = 4585515,
            OffsetSeconds = 0,
            RhythmVersion = 1,
            Rhythmstring = "rhythmstring",
            SampleMd5 = "sample_md5",
            StartOfFadeOut = 201.13705,
            SynchVersion = 1,
            Synchstring = "synchstring",
            Tempo = 118.211f,
            TempoConfidence = 0.73,
            TimeSignature = 4,
            TimeSignatureConfidence = 0.994,
            WindowSeconds = 0,
        };

        Assert.NotNull(model.Bars);
        Assert.Equal(expectedBars.Count, model.Bars.Count);
        for (int i = 0; i < expectedBars.Count; i++)
        {
            Assert.Equal(expectedBars[i], model.Bars[i]);
        }
        Assert.NotNull(model.Beats);
        Assert.Equal(expectedBeats.Count, model.Beats.Count);
        for (int i = 0; i < expectedBeats.Count; i++)
        {
            Assert.Equal(expectedBeats[i], model.Beats[i]);
        }
        Assert.Equal(expectedMeta, model.Meta);
        Assert.Equal(expectedPublished, model.Published);
        Assert.NotNull(model.Sections);
        Assert.Equal(expectedSections.Count, model.Sections.Count);
        for (int i = 0; i < expectedSections.Count; i++)
        {
            Assert.Equal(expectedSections[i], model.Sections[i]);
        }
        Assert.NotNull(model.Segments);
        Assert.Equal(expectedSegments.Count, model.Segments.Count);
        for (int i = 0; i < expectedSegments.Count; i++)
        {
            Assert.Equal(expectedSegments[i], model.Segments[i]);
        }
        Assert.NotNull(model.Tatums);
        Assert.Equal(expectedTatums.Count, model.Tatums.Count);
        for (int i = 0; i < expectedTatums.Count; i++)
        {
            Assert.Equal(expectedTatums[i], model.Tatums[i]);
        }
        Assert.Equal(expectedTrack, model.Track);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AudioAnalysisRetrieveResponse
        {
            Bars =
            [
                new()
                {
                    Confidence = 0.925,
                    Duration = 2.18749,
                    Published = true,
                    Start = 0.49567,
                },
            ],
            Beats =
            [
                new()
                {
                    Confidence = 0.925,
                    Duration = 2.18749,
                    Published = true,
                    Start = 0.49567,
                },
            ],
            Meta = new()
            {
                AnalysisTime = 6.93906,
                AnalyzerVersion = "4.0.0",
                DetailedStatus = "OK",
                InputProcess = "libvorbisfile L+R 44100->22050",
                Platform = "Linux",
                StatusCode = 0,
                Timestamp = 1495193577,
            },
            Published = true,
            Sections =
            [
                new()
                {
                    Confidence = 1,
                    Duration = 6.97092,
                    Key = 9,
                    KeyConfidence = 0.297,
                    Loudness = -14.938,
                    Mode = Mode.ModeNoResult,
                    ModeConfidence = 0.471,
                    Published = true,
                    Start = 0,
                    Tempo = 113.178,
                    TempoConfidence = 0.647,
                    TimeSignature = 4,
                    TimeSignatureConfidence = 1,
                },
            ],
            Segments =
            [
                new()
                {
                    Confidence = 0.435,
                    Duration = 0.19891,
                    LoudnessEnd = 0,
                    LoudnessMax = -14.25,
                    LoudnessMaxTime = 0.07305,
                    LoudnessStart = -23.053,
                    Pitches = [0.212, 0.141, 0.294],
                    Published = true,
                    Start = 0.70154,
                    Timbre = [42.115, 64.373, -0.233],
                },
            ],
            Tatums =
            [
                new()
                {
                    Confidence = 0.925,
                    Duration = 2.18749,
                    Published = true,
                    Start = 0.49567,
                },
            ],
            Track = new()
            {
                AnalysisChannels = 1,
                AnalysisSampleRate = 22050,
                CodeVersion = 3.15,
                Codestring = "codestring",
                Duration = 207.95985,
                EchoprintVersion = 4.15,
                Echoprintstring = "echoprintstring",
                EndOfFadeIn = 0,
                Key = 9,
                KeyConfidence = 0.408,
                Loudness = -5.883f,
                Mode = 0,
                ModeConfidence = 0.485,
                NumSamples = 4585515,
                OffsetSeconds = 0,
                RhythmVersion = 1,
                Rhythmstring = "rhythmstring",
                SampleMd5 = "sample_md5",
                StartOfFadeOut = 201.13705,
                SynchVersion = 1,
                Synchstring = "synchstring",
                Tempo = 118.211f,
                TempoConfidence = 0.73,
                TimeSignature = 4,
                TimeSignatureConfidence = 0.994,
                WindowSeconds = 0,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudioAnalysisRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AudioAnalysisRetrieveResponse
        {
            Bars =
            [
                new()
                {
                    Confidence = 0.925,
                    Duration = 2.18749,
                    Published = true,
                    Start = 0.49567,
                },
            ],
            Beats =
            [
                new()
                {
                    Confidence = 0.925,
                    Duration = 2.18749,
                    Published = true,
                    Start = 0.49567,
                },
            ],
            Meta = new()
            {
                AnalysisTime = 6.93906,
                AnalyzerVersion = "4.0.0",
                DetailedStatus = "OK",
                InputProcess = "libvorbisfile L+R 44100->22050",
                Platform = "Linux",
                StatusCode = 0,
                Timestamp = 1495193577,
            },
            Published = true,
            Sections =
            [
                new()
                {
                    Confidence = 1,
                    Duration = 6.97092,
                    Key = 9,
                    KeyConfidence = 0.297,
                    Loudness = -14.938,
                    Mode = Mode.ModeNoResult,
                    ModeConfidence = 0.471,
                    Published = true,
                    Start = 0,
                    Tempo = 113.178,
                    TempoConfidence = 0.647,
                    TimeSignature = 4,
                    TimeSignatureConfidence = 1,
                },
            ],
            Segments =
            [
                new()
                {
                    Confidence = 0.435,
                    Duration = 0.19891,
                    LoudnessEnd = 0,
                    LoudnessMax = -14.25,
                    LoudnessMaxTime = 0.07305,
                    LoudnessStart = -23.053,
                    Pitches = [0.212, 0.141, 0.294],
                    Published = true,
                    Start = 0.70154,
                    Timbre = [42.115, 64.373, -0.233],
                },
            ],
            Tatums =
            [
                new()
                {
                    Confidence = 0.925,
                    Duration = 2.18749,
                    Published = true,
                    Start = 0.49567,
                },
            ],
            Track = new()
            {
                AnalysisChannels = 1,
                AnalysisSampleRate = 22050,
                CodeVersion = 3.15,
                Codestring = "codestring",
                Duration = 207.95985,
                EchoprintVersion = 4.15,
                Echoprintstring = "echoprintstring",
                EndOfFadeIn = 0,
                Key = 9,
                KeyConfidence = 0.408,
                Loudness = -5.883f,
                Mode = 0,
                ModeConfidence = 0.485,
                NumSamples = 4585515,
                OffsetSeconds = 0,
                RhythmVersion = 1,
                Rhythmstring = "rhythmstring",
                SampleMd5 = "sample_md5",
                StartOfFadeOut = 201.13705,
                SynchVersion = 1,
                Synchstring = "synchstring",
                Tempo = 118.211f,
                TempoConfidence = 0.73,
                TimeSignature = 4,
                TimeSignatureConfidence = 0.994,
                WindowSeconds = 0,
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudioAnalysisRetrieveResponse>(element);
        Assert.NotNull(deserialized);

        List<TimeIntervalObject> expectedBars =
        [
            new()
            {
                Confidence = 0.925,
                Duration = 2.18749,
                Published = true,
                Start = 0.49567,
            },
        ];
        List<TimeIntervalObject> expectedBeats =
        [
            new()
            {
                Confidence = 0.925,
                Duration = 2.18749,
                Published = true,
                Start = 0.49567,
            },
        ];
        Meta expectedMeta = new()
        {
            AnalysisTime = 6.93906,
            AnalyzerVersion = "4.0.0",
            DetailedStatus = "OK",
            InputProcess = "libvorbisfile L+R 44100->22050",
            Platform = "Linux",
            StatusCode = 0,
            Timestamp = 1495193577,
        };
        bool expectedPublished = true;
        List<Section> expectedSections =
        [
            new()
            {
                Confidence = 1,
                Duration = 6.97092,
                Key = 9,
                KeyConfidence = 0.297,
                Loudness = -14.938,
                Mode = Mode.ModeNoResult,
                ModeConfidence = 0.471,
                Published = true,
                Start = 0,
                Tempo = 113.178,
                TempoConfidence = 0.647,
                TimeSignature = 4,
                TimeSignatureConfidence = 1,
            },
        ];
        List<Segment> expectedSegments =
        [
            new()
            {
                Confidence = 0.435,
                Duration = 0.19891,
                LoudnessEnd = 0,
                LoudnessMax = -14.25,
                LoudnessMaxTime = 0.07305,
                LoudnessStart = -23.053,
                Pitches = [0.212, 0.141, 0.294],
                Published = true,
                Start = 0.70154,
                Timbre = [42.115, 64.373, -0.233],
            },
        ];
        List<TimeIntervalObject> expectedTatums =
        [
            new()
            {
                Confidence = 0.925,
                Duration = 2.18749,
                Published = true,
                Start = 0.49567,
            },
        ];
        Track expectedTrack = new()
        {
            AnalysisChannels = 1,
            AnalysisSampleRate = 22050,
            CodeVersion = 3.15,
            Codestring = "codestring",
            Duration = 207.95985,
            EchoprintVersion = 4.15,
            Echoprintstring = "echoprintstring",
            EndOfFadeIn = 0,
            Key = 9,
            KeyConfidence = 0.408,
            Loudness = -5.883f,
            Mode = 0,
            ModeConfidence = 0.485,
            NumSamples = 4585515,
            OffsetSeconds = 0,
            RhythmVersion = 1,
            Rhythmstring = "rhythmstring",
            SampleMd5 = "sample_md5",
            StartOfFadeOut = 201.13705,
            SynchVersion = 1,
            Synchstring = "synchstring",
            Tempo = 118.211f,
            TempoConfidence = 0.73,
            TimeSignature = 4,
            TimeSignatureConfidence = 0.994,
            WindowSeconds = 0,
        };

        Assert.NotNull(deserialized.Bars);
        Assert.Equal(expectedBars.Count, deserialized.Bars.Count);
        for (int i = 0; i < expectedBars.Count; i++)
        {
            Assert.Equal(expectedBars[i], deserialized.Bars[i]);
        }
        Assert.NotNull(deserialized.Beats);
        Assert.Equal(expectedBeats.Count, deserialized.Beats.Count);
        for (int i = 0; i < expectedBeats.Count; i++)
        {
            Assert.Equal(expectedBeats[i], deserialized.Beats[i]);
        }
        Assert.Equal(expectedMeta, deserialized.Meta);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.NotNull(deserialized.Sections);
        Assert.Equal(expectedSections.Count, deserialized.Sections.Count);
        for (int i = 0; i < expectedSections.Count; i++)
        {
            Assert.Equal(expectedSections[i], deserialized.Sections[i]);
        }
        Assert.NotNull(deserialized.Segments);
        Assert.Equal(expectedSegments.Count, deserialized.Segments.Count);
        for (int i = 0; i < expectedSegments.Count; i++)
        {
            Assert.Equal(expectedSegments[i], deserialized.Segments[i]);
        }
        Assert.NotNull(deserialized.Tatums);
        Assert.Equal(expectedTatums.Count, deserialized.Tatums.Count);
        for (int i = 0; i < expectedTatums.Count; i++)
        {
            Assert.Equal(expectedTatums[i], deserialized.Tatums[i]);
        }
        Assert.Equal(expectedTrack, deserialized.Track);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AudioAnalysisRetrieveResponse
        {
            Bars =
            [
                new()
                {
                    Confidence = 0.925,
                    Duration = 2.18749,
                    Published = true,
                    Start = 0.49567,
                },
            ],
            Beats =
            [
                new()
                {
                    Confidence = 0.925,
                    Duration = 2.18749,
                    Published = true,
                    Start = 0.49567,
                },
            ],
            Meta = new()
            {
                AnalysisTime = 6.93906,
                AnalyzerVersion = "4.0.0",
                DetailedStatus = "OK",
                InputProcess = "libvorbisfile L+R 44100->22050",
                Platform = "Linux",
                StatusCode = 0,
                Timestamp = 1495193577,
            },
            Published = true,
            Sections =
            [
                new()
                {
                    Confidence = 1,
                    Duration = 6.97092,
                    Key = 9,
                    KeyConfidence = 0.297,
                    Loudness = -14.938,
                    Mode = Mode.ModeNoResult,
                    ModeConfidence = 0.471,
                    Published = true,
                    Start = 0,
                    Tempo = 113.178,
                    TempoConfidence = 0.647,
                    TimeSignature = 4,
                    TimeSignatureConfidence = 1,
                },
            ],
            Segments =
            [
                new()
                {
                    Confidence = 0.435,
                    Duration = 0.19891,
                    LoudnessEnd = 0,
                    LoudnessMax = -14.25,
                    LoudnessMaxTime = 0.07305,
                    LoudnessStart = -23.053,
                    Pitches = [0.212, 0.141, 0.294],
                    Published = true,
                    Start = 0.70154,
                    Timbre = [42.115, 64.373, -0.233],
                },
            ],
            Tatums =
            [
                new()
                {
                    Confidence = 0.925,
                    Duration = 2.18749,
                    Published = true,
                    Start = 0.49567,
                },
            ],
            Track = new()
            {
                AnalysisChannels = 1,
                AnalysisSampleRate = 22050,
                CodeVersion = 3.15,
                Codestring = "codestring",
                Duration = 207.95985,
                EchoprintVersion = 4.15,
                Echoprintstring = "echoprintstring",
                EndOfFadeIn = 0,
                Key = 9,
                KeyConfidence = 0.408,
                Loudness = -5.883f,
                Mode = 0,
                ModeConfidence = 0.485,
                NumSamples = 4585515,
                OffsetSeconds = 0,
                RhythmVersion = 1,
                Rhythmstring = "rhythmstring",
                SampleMd5 = "sample_md5",
                StartOfFadeOut = 201.13705,
                SynchVersion = 1,
                Synchstring = "synchstring",
                Tempo = 118.211f,
                TempoConfidence = 0.73,
                TimeSignature = 4,
                TimeSignatureConfidence = 0.994,
                WindowSeconds = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AudioAnalysisRetrieveResponse { };

        Assert.Null(model.Bars);
        Assert.False(model.RawData.ContainsKey("bars"));
        Assert.Null(model.Beats);
        Assert.False(model.RawData.ContainsKey("beats"));
        Assert.Null(model.Meta);
        Assert.False(model.RawData.ContainsKey("meta"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Sections);
        Assert.False(model.RawData.ContainsKey("sections"));
        Assert.Null(model.Segments);
        Assert.False(model.RawData.ContainsKey("segments"));
        Assert.Null(model.Tatums);
        Assert.False(model.RawData.ContainsKey("tatums"));
        Assert.Null(model.Track);
        Assert.False(model.RawData.ContainsKey("track"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AudioAnalysisRetrieveResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AudioAnalysisRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            Bars = null,
            Beats = null,
            Meta = null,
            Published = null,
            Sections = null,
            Segments = null,
            Tatums = null,
            Track = null,
        };

        Assert.Null(model.Bars);
        Assert.False(model.RawData.ContainsKey("bars"));
        Assert.Null(model.Beats);
        Assert.False(model.RawData.ContainsKey("beats"));
        Assert.Null(model.Meta);
        Assert.False(model.RawData.ContainsKey("meta"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Sections);
        Assert.False(model.RawData.ContainsKey("sections"));
        Assert.Null(model.Segments);
        Assert.False(model.RawData.ContainsKey("segments"));
        Assert.Null(model.Tatums);
        Assert.False(model.RawData.ContainsKey("tatums"));
        Assert.Null(model.Track);
        Assert.False(model.RawData.ContainsKey("track"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AudioAnalysisRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            Bars = null,
            Beats = null,
            Meta = null,
            Published = null,
            Sections = null,
            Segments = null,
            Tatums = null,
            Track = null,
        };

        model.Validate();
    }
}

public class MetaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Meta
        {
            AnalysisTime = 6.93906,
            AnalyzerVersion = "4.0.0",
            DetailedStatus = "OK",
            InputProcess = "libvorbisfile L+R 44100->22050",
            Platform = "Linux",
            StatusCode = 0,
            Timestamp = 1495193577,
        };

        double expectedAnalysisTime = 6.93906;
        string expectedAnalyzerVersion = "4.0.0";
        string expectedDetailedStatus = "OK";
        string expectedInputProcess = "libvorbisfile L+R 44100->22050";
        string expectedPlatform = "Linux";
        long expectedStatusCode = 0;
        long expectedTimestamp = 1495193577;

        Assert.Equal(expectedAnalysisTime, model.AnalysisTime);
        Assert.Equal(expectedAnalyzerVersion, model.AnalyzerVersion);
        Assert.Equal(expectedDetailedStatus, model.DetailedStatus);
        Assert.Equal(expectedInputProcess, model.InputProcess);
        Assert.Equal(expectedPlatform, model.Platform);
        Assert.Equal(expectedStatusCode, model.StatusCode);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Meta
        {
            AnalysisTime = 6.93906,
            AnalyzerVersion = "4.0.0",
            DetailedStatus = "OK",
            InputProcess = "libvorbisfile L+R 44100->22050",
            Platform = "Linux",
            StatusCode = 0,
            Timestamp = 1495193577,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Meta>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Meta
        {
            AnalysisTime = 6.93906,
            AnalyzerVersion = "4.0.0",
            DetailedStatus = "OK",
            InputProcess = "libvorbisfile L+R 44100->22050",
            Platform = "Linux",
            StatusCode = 0,
            Timestamp = 1495193577,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Meta>(element);
        Assert.NotNull(deserialized);

        double expectedAnalysisTime = 6.93906;
        string expectedAnalyzerVersion = "4.0.0";
        string expectedDetailedStatus = "OK";
        string expectedInputProcess = "libvorbisfile L+R 44100->22050";
        string expectedPlatform = "Linux";
        long expectedStatusCode = 0;
        long expectedTimestamp = 1495193577;

        Assert.Equal(expectedAnalysisTime, deserialized.AnalysisTime);
        Assert.Equal(expectedAnalyzerVersion, deserialized.AnalyzerVersion);
        Assert.Equal(expectedDetailedStatus, deserialized.DetailedStatus);
        Assert.Equal(expectedInputProcess, deserialized.InputProcess);
        Assert.Equal(expectedPlatform, deserialized.Platform);
        Assert.Equal(expectedStatusCode, deserialized.StatusCode);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Meta
        {
            AnalysisTime = 6.93906,
            AnalyzerVersion = "4.0.0",
            DetailedStatus = "OK",
            InputProcess = "libvorbisfile L+R 44100->22050",
            Platform = "Linux",
            StatusCode = 0,
            Timestamp = 1495193577,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Meta { };

        Assert.Null(model.AnalysisTime);
        Assert.False(model.RawData.ContainsKey("analysis_time"));
        Assert.Null(model.AnalyzerVersion);
        Assert.False(model.RawData.ContainsKey("analyzer_version"));
        Assert.Null(model.DetailedStatus);
        Assert.False(model.RawData.ContainsKey("detailed_status"));
        Assert.Null(model.InputProcess);
        Assert.False(model.RawData.ContainsKey("input_process"));
        Assert.Null(model.Platform);
        Assert.False(model.RawData.ContainsKey("platform"));
        Assert.Null(model.StatusCode);
        Assert.False(model.RawData.ContainsKey("status_code"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Meta { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Meta
        {
            // Null should be interpreted as omitted for these properties
            AnalysisTime = null,
            AnalyzerVersion = null,
            DetailedStatus = null,
            InputProcess = null,
            Platform = null,
            StatusCode = null,
            Timestamp = null,
        };

        Assert.Null(model.AnalysisTime);
        Assert.False(model.RawData.ContainsKey("analysis_time"));
        Assert.Null(model.AnalyzerVersion);
        Assert.False(model.RawData.ContainsKey("analyzer_version"));
        Assert.Null(model.DetailedStatus);
        Assert.False(model.RawData.ContainsKey("detailed_status"));
        Assert.Null(model.InputProcess);
        Assert.False(model.RawData.ContainsKey("input_process"));
        Assert.Null(model.Platform);
        Assert.False(model.RawData.ContainsKey("platform"));
        Assert.Null(model.StatusCode);
        Assert.False(model.RawData.ContainsKey("status_code"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Meta
        {
            // Null should be interpreted as omitted for these properties
            AnalysisTime = null,
            AnalyzerVersion = null,
            DetailedStatus = null,
            InputProcess = null,
            Platform = null,
            StatusCode = null,
            Timestamp = null,
        };

        model.Validate();
    }
}

public class SectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Section
        {
            Confidence = 1,
            Duration = 6.97092,
            Key = 9,
            KeyConfidence = 0.297,
            Loudness = -14.938,
            Mode = Mode.ModeNoResult,
            ModeConfidence = 0.471,
            Published = true,
            Start = 0,
            Tempo = 113.178,
            TempoConfidence = 0.647,
            TimeSignature = 4,
            TimeSignatureConfidence = 1,
        };

        double expectedConfidence = 1;
        double expectedDuration = 6.97092;
        long expectedKey = 9;
        double expectedKeyConfidence = 0.297;
        double expectedLoudness = -14.938;
        ApiEnum<double, Mode> expectedMode = Mode.ModeNoResult;
        double expectedModeConfidence = 0.471;
        bool expectedPublished = true;
        double expectedStart = 0;
        double expectedTempo = 113.178;
        double expectedTempoConfidence = 0.647;
        long expectedTimeSignature = 4;
        double expectedTimeSignatureConfidence = 1;

        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedKeyConfidence, model.KeyConfidence);
        Assert.Equal(expectedLoudness, model.Loudness);
        Assert.Equal(expectedMode, model.Mode);
        Assert.Equal(expectedModeConfidence, model.ModeConfidence);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedStart, model.Start);
        Assert.Equal(expectedTempo, model.Tempo);
        Assert.Equal(expectedTempoConfidence, model.TempoConfidence);
        Assert.Equal(expectedTimeSignature, model.TimeSignature);
        Assert.Equal(expectedTimeSignatureConfidence, model.TimeSignatureConfidence);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Section
        {
            Confidence = 1,
            Duration = 6.97092,
            Key = 9,
            KeyConfidence = 0.297,
            Loudness = -14.938,
            Mode = Mode.ModeNoResult,
            ModeConfidence = 0.471,
            Published = true,
            Start = 0,
            Tempo = 113.178,
            TempoConfidence = 0.647,
            TimeSignature = 4,
            TimeSignatureConfidence = 1,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Section>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Section
        {
            Confidence = 1,
            Duration = 6.97092,
            Key = 9,
            KeyConfidence = 0.297,
            Loudness = -14.938,
            Mode = Mode.ModeNoResult,
            ModeConfidence = 0.471,
            Published = true,
            Start = 0,
            Tempo = 113.178,
            TempoConfidence = 0.647,
            TimeSignature = 4,
            TimeSignatureConfidence = 1,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Section>(element);
        Assert.NotNull(deserialized);

        double expectedConfidence = 1;
        double expectedDuration = 6.97092;
        long expectedKey = 9;
        double expectedKeyConfidence = 0.297;
        double expectedLoudness = -14.938;
        ApiEnum<double, Mode> expectedMode = Mode.ModeNoResult;
        double expectedModeConfidence = 0.471;
        bool expectedPublished = true;
        double expectedStart = 0;
        double expectedTempo = 113.178;
        double expectedTempoConfidence = 0.647;
        long expectedTimeSignature = 4;
        double expectedTimeSignatureConfidence = 1;

        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedKeyConfidence, deserialized.KeyConfidence);
        Assert.Equal(expectedLoudness, deserialized.Loudness);
        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.Equal(expectedModeConfidence, deserialized.ModeConfidence);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedStart, deserialized.Start);
        Assert.Equal(expectedTempo, deserialized.Tempo);
        Assert.Equal(expectedTempoConfidence, deserialized.TempoConfidence);
        Assert.Equal(expectedTimeSignature, deserialized.TimeSignature);
        Assert.Equal(expectedTimeSignatureConfidence, deserialized.TimeSignatureConfidence);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Section
        {
            Confidence = 1,
            Duration = 6.97092,
            Key = 9,
            KeyConfidence = 0.297,
            Loudness = -14.938,
            Mode = Mode.ModeNoResult,
            ModeConfidence = 0.471,
            Published = true,
            Start = 0,
            Tempo = 113.178,
            TempoConfidence = 0.647,
            TimeSignature = 4,
            TimeSignatureConfidence = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Section { };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.KeyConfidence);
        Assert.False(model.RawData.ContainsKey("key_confidence"));
        Assert.Null(model.Loudness);
        Assert.False(model.RawData.ContainsKey("loudness"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.ModeConfidence);
        Assert.False(model.RawData.ContainsKey("mode_confidence"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
        Assert.Null(model.Tempo);
        Assert.False(model.RawData.ContainsKey("tempo"));
        Assert.Null(model.TempoConfidence);
        Assert.False(model.RawData.ContainsKey("tempo_confidence"));
        Assert.Null(model.TimeSignature);
        Assert.False(model.RawData.ContainsKey("time_signature"));
        Assert.Null(model.TimeSignatureConfidence);
        Assert.False(model.RawData.ContainsKey("time_signature_confidence"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Section { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Section
        {
            // Null should be interpreted as omitted for these properties
            Confidence = null,
            Duration = null,
            Key = null,
            KeyConfidence = null,
            Loudness = null,
            Mode = null,
            ModeConfidence = null,
            Published = null,
            Start = null,
            Tempo = null,
            TempoConfidence = null,
            TimeSignature = null,
            TimeSignatureConfidence = null,
        };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.KeyConfidence);
        Assert.False(model.RawData.ContainsKey("key_confidence"));
        Assert.Null(model.Loudness);
        Assert.False(model.RawData.ContainsKey("loudness"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.ModeConfidence);
        Assert.False(model.RawData.ContainsKey("mode_confidence"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
        Assert.Null(model.Tempo);
        Assert.False(model.RawData.ContainsKey("tempo"));
        Assert.Null(model.TempoConfidence);
        Assert.False(model.RawData.ContainsKey("tempo_confidence"));
        Assert.Null(model.TimeSignature);
        Assert.False(model.RawData.ContainsKey("time_signature"));
        Assert.Null(model.TimeSignatureConfidence);
        Assert.False(model.RawData.ContainsKey("time_signature_confidence"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Section
        {
            // Null should be interpreted as omitted for these properties
            Confidence = null,
            Duration = null,
            Key = null,
            KeyConfidence = null,
            Loudness = null,
            Mode = null,
            ModeConfidence = null,
            Published = null,
            Start = null,
            Tempo = null,
            TempoConfidence = null,
            TimeSignature = null,
            TimeSignatureConfidence = null,
        };

        model.Validate();
    }
}

public class ModeTest : TestBase
{
    [Theory]
    [InlineData(Mode.ModeNoResult)]
    [InlineData(Mode.ModeMinor)]
    [InlineData(Mode.ModeMajor)]
    public void Validation_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<double, Mode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<double, Mode>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<SpottedInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Mode.ModeNoResult)]
    [InlineData(Mode.ModeMinor)]
    [InlineData(Mode.ModeMajor)]
    public void SerializationRoundtrip_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<double, Mode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<double, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<double, Mode>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<double, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SegmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Segment
        {
            Confidence = 0.435,
            Duration = 0.19891,
            LoudnessEnd = 0,
            LoudnessMax = -14.25,
            LoudnessMaxTime = 0.07305,
            LoudnessStart = -23.053,
            Pitches = [0.212, 0.141, 0.294],
            Published = true,
            Start = 0.70154,
            Timbre = [42.115, 64.373, -0.233],
        };

        double expectedConfidence = 0.435;
        double expectedDuration = 0.19891;
        double expectedLoudnessEnd = 0;
        double expectedLoudnessMax = -14.25;
        double expectedLoudnessMaxTime = 0.07305;
        double expectedLoudnessStart = -23.053;
        List<double> expectedPitches = [0.212, 0.141, 0.294];
        bool expectedPublished = true;
        double expectedStart = 0.70154;
        List<double> expectedTimbre = [42.115, 64.373, -0.233];

        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedLoudnessEnd, model.LoudnessEnd);
        Assert.Equal(expectedLoudnessMax, model.LoudnessMax);
        Assert.Equal(expectedLoudnessMaxTime, model.LoudnessMaxTime);
        Assert.Equal(expectedLoudnessStart, model.LoudnessStart);
        Assert.NotNull(model.Pitches);
        Assert.Equal(expectedPitches.Count, model.Pitches.Count);
        for (int i = 0; i < expectedPitches.Count; i++)
        {
            Assert.Equal(expectedPitches[i], model.Pitches[i]);
        }
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedStart, model.Start);
        Assert.NotNull(model.Timbre);
        Assert.Equal(expectedTimbre.Count, model.Timbre.Count);
        for (int i = 0; i < expectedTimbre.Count; i++)
        {
            Assert.Equal(expectedTimbre[i], model.Timbre[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Segment
        {
            Confidence = 0.435,
            Duration = 0.19891,
            LoudnessEnd = 0,
            LoudnessMax = -14.25,
            LoudnessMaxTime = 0.07305,
            LoudnessStart = -23.053,
            Pitches = [0.212, 0.141, 0.294],
            Published = true,
            Start = 0.70154,
            Timbre = [42.115, 64.373, -0.233],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Segment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Segment
        {
            Confidence = 0.435,
            Duration = 0.19891,
            LoudnessEnd = 0,
            LoudnessMax = -14.25,
            LoudnessMaxTime = 0.07305,
            LoudnessStart = -23.053,
            Pitches = [0.212, 0.141, 0.294],
            Published = true,
            Start = 0.70154,
            Timbre = [42.115, 64.373, -0.233],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Segment>(element);
        Assert.NotNull(deserialized);

        double expectedConfidence = 0.435;
        double expectedDuration = 0.19891;
        double expectedLoudnessEnd = 0;
        double expectedLoudnessMax = -14.25;
        double expectedLoudnessMaxTime = 0.07305;
        double expectedLoudnessStart = -23.053;
        List<double> expectedPitches = [0.212, 0.141, 0.294];
        bool expectedPublished = true;
        double expectedStart = 0.70154;
        List<double> expectedTimbre = [42.115, 64.373, -0.233];

        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedLoudnessEnd, deserialized.LoudnessEnd);
        Assert.Equal(expectedLoudnessMax, deserialized.LoudnessMax);
        Assert.Equal(expectedLoudnessMaxTime, deserialized.LoudnessMaxTime);
        Assert.Equal(expectedLoudnessStart, deserialized.LoudnessStart);
        Assert.NotNull(deserialized.Pitches);
        Assert.Equal(expectedPitches.Count, deserialized.Pitches.Count);
        for (int i = 0; i < expectedPitches.Count; i++)
        {
            Assert.Equal(expectedPitches[i], deserialized.Pitches[i]);
        }
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedStart, deserialized.Start);
        Assert.NotNull(deserialized.Timbre);
        Assert.Equal(expectedTimbre.Count, deserialized.Timbre.Count);
        for (int i = 0; i < expectedTimbre.Count; i++)
        {
            Assert.Equal(expectedTimbre[i], deserialized.Timbre[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Segment
        {
            Confidence = 0.435,
            Duration = 0.19891,
            LoudnessEnd = 0,
            LoudnessMax = -14.25,
            LoudnessMaxTime = 0.07305,
            LoudnessStart = -23.053,
            Pitches = [0.212, 0.141, 0.294],
            Published = true,
            Start = 0.70154,
            Timbre = [42.115, 64.373, -0.233],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Segment { };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.LoudnessEnd);
        Assert.False(model.RawData.ContainsKey("loudness_end"));
        Assert.Null(model.LoudnessMax);
        Assert.False(model.RawData.ContainsKey("loudness_max"));
        Assert.Null(model.LoudnessMaxTime);
        Assert.False(model.RawData.ContainsKey("loudness_max_time"));
        Assert.Null(model.LoudnessStart);
        Assert.False(model.RawData.ContainsKey("loudness_start"));
        Assert.Null(model.Pitches);
        Assert.False(model.RawData.ContainsKey("pitches"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
        Assert.Null(model.Timbre);
        Assert.False(model.RawData.ContainsKey("timbre"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Segment { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Segment
        {
            // Null should be interpreted as omitted for these properties
            Confidence = null,
            Duration = null,
            LoudnessEnd = null,
            LoudnessMax = null,
            LoudnessMaxTime = null,
            LoudnessStart = null,
            Pitches = null,
            Published = null,
            Start = null,
            Timbre = null,
        };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.LoudnessEnd);
        Assert.False(model.RawData.ContainsKey("loudness_end"));
        Assert.Null(model.LoudnessMax);
        Assert.False(model.RawData.ContainsKey("loudness_max"));
        Assert.Null(model.LoudnessMaxTime);
        Assert.False(model.RawData.ContainsKey("loudness_max_time"));
        Assert.Null(model.LoudnessStart);
        Assert.False(model.RawData.ContainsKey("loudness_start"));
        Assert.Null(model.Pitches);
        Assert.False(model.RawData.ContainsKey("pitches"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
        Assert.Null(model.Timbre);
        Assert.False(model.RawData.ContainsKey("timbre"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Segment
        {
            // Null should be interpreted as omitted for these properties
            Confidence = null,
            Duration = null,
            LoudnessEnd = null,
            LoudnessMax = null,
            LoudnessMaxTime = null,
            LoudnessStart = null,
            Pitches = null,
            Published = null,
            Start = null,
            Timbre = null,
        };

        model.Validate();
    }
}

public class TrackTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Track
        {
            AnalysisChannels = 1,
            AnalysisSampleRate = 22050,
            CodeVersion = 3.15,
            Codestring = "codestring",
            Duration = 207.95985,
            EchoprintVersion = 4.15,
            Echoprintstring = "echoprintstring",
            EndOfFadeIn = 0,
            Key = 9,
            KeyConfidence = 0.408,
            Loudness = -5.883f,
            Mode = 0,
            ModeConfidence = 0.485,
            NumSamples = 4585515,
            OffsetSeconds = 0,
            RhythmVersion = 1,
            Rhythmstring = "rhythmstring",
            SampleMd5 = "sample_md5",
            StartOfFadeOut = 201.13705,
            SynchVersion = 1,
            Synchstring = "synchstring",
            Tempo = 118.211f,
            TempoConfidence = 0.73,
            TimeSignature = 4,
            TimeSignatureConfidence = 0.994,
            WindowSeconds = 0,
        };

        long expectedAnalysisChannels = 1;
        long expectedAnalysisSampleRate = 22050;
        double expectedCodeVersion = 3.15;
        string expectedCodestring = "codestring";
        double expectedDuration = 207.95985;
        double expectedEchoprintVersion = 4.15;
        string expectedEchoprintstring = "echoprintstring";
        double expectedEndOfFadeIn = 0;
        long expectedKey = 9;
        double expectedKeyConfidence = 0.408;
        float expectedLoudness = -5.883f;
        long expectedMode = 0;
        double expectedModeConfidence = 0.485;
        long expectedNumSamples = 4585515;
        long expectedOffsetSeconds = 0;
        double expectedRhythmVersion = 1;
        string expectedRhythmstring = "rhythmstring";
        string expectedSampleMd5 = "sample_md5";
        double expectedStartOfFadeOut = 201.13705;
        double expectedSynchVersion = 1;
        string expectedSynchstring = "synchstring";
        float expectedTempo = 118.211f;
        double expectedTempoConfidence = 0.73;
        long expectedTimeSignature = 4;
        double expectedTimeSignatureConfidence = 0.994;
        long expectedWindowSeconds = 0;

        Assert.Equal(expectedAnalysisChannels, model.AnalysisChannels);
        Assert.Equal(expectedAnalysisSampleRate, model.AnalysisSampleRate);
        Assert.Equal(expectedCodeVersion, model.CodeVersion);
        Assert.Equal(expectedCodestring, model.Codestring);
        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedEchoprintVersion, model.EchoprintVersion);
        Assert.Equal(expectedEchoprintstring, model.Echoprintstring);
        Assert.Equal(expectedEndOfFadeIn, model.EndOfFadeIn);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedKeyConfidence, model.KeyConfidence);
        Assert.Equal(expectedLoudness, model.Loudness);
        Assert.Equal(expectedMode, model.Mode);
        Assert.Equal(expectedModeConfidence, model.ModeConfidence);
        Assert.Equal(expectedNumSamples, model.NumSamples);
        Assert.Equal(expectedOffsetSeconds, model.OffsetSeconds);
        Assert.Equal(expectedRhythmVersion, model.RhythmVersion);
        Assert.Equal(expectedRhythmstring, model.Rhythmstring);
        Assert.Equal(expectedSampleMd5, model.SampleMd5);
        Assert.Equal(expectedStartOfFadeOut, model.StartOfFadeOut);
        Assert.Equal(expectedSynchVersion, model.SynchVersion);
        Assert.Equal(expectedSynchstring, model.Synchstring);
        Assert.Equal(expectedTempo, model.Tempo);
        Assert.Equal(expectedTempoConfidence, model.TempoConfidence);
        Assert.Equal(expectedTimeSignature, model.TimeSignature);
        Assert.Equal(expectedTimeSignatureConfidence, model.TimeSignatureConfidence);
        Assert.Equal(expectedWindowSeconds, model.WindowSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Track
        {
            AnalysisChannels = 1,
            AnalysisSampleRate = 22050,
            CodeVersion = 3.15,
            Codestring = "codestring",
            Duration = 207.95985,
            EchoprintVersion = 4.15,
            Echoprintstring = "echoprintstring",
            EndOfFadeIn = 0,
            Key = 9,
            KeyConfidence = 0.408,
            Loudness = -5.883f,
            Mode = 0,
            ModeConfidence = 0.485,
            NumSamples = 4585515,
            OffsetSeconds = 0,
            RhythmVersion = 1,
            Rhythmstring = "rhythmstring",
            SampleMd5 = "sample_md5",
            StartOfFadeOut = 201.13705,
            SynchVersion = 1,
            Synchstring = "synchstring",
            Tempo = 118.211f,
            TempoConfidence = 0.73,
            TimeSignature = 4,
            TimeSignatureConfidence = 0.994,
            WindowSeconds = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Track>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Track
        {
            AnalysisChannels = 1,
            AnalysisSampleRate = 22050,
            CodeVersion = 3.15,
            Codestring = "codestring",
            Duration = 207.95985,
            EchoprintVersion = 4.15,
            Echoprintstring = "echoprintstring",
            EndOfFadeIn = 0,
            Key = 9,
            KeyConfidence = 0.408,
            Loudness = -5.883f,
            Mode = 0,
            ModeConfidence = 0.485,
            NumSamples = 4585515,
            OffsetSeconds = 0,
            RhythmVersion = 1,
            Rhythmstring = "rhythmstring",
            SampleMd5 = "sample_md5",
            StartOfFadeOut = 201.13705,
            SynchVersion = 1,
            Synchstring = "synchstring",
            Tempo = 118.211f,
            TempoConfidence = 0.73,
            TimeSignature = 4,
            TimeSignatureConfidence = 0.994,
            WindowSeconds = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Track>(element);
        Assert.NotNull(deserialized);

        long expectedAnalysisChannels = 1;
        long expectedAnalysisSampleRate = 22050;
        double expectedCodeVersion = 3.15;
        string expectedCodestring = "codestring";
        double expectedDuration = 207.95985;
        double expectedEchoprintVersion = 4.15;
        string expectedEchoprintstring = "echoprintstring";
        double expectedEndOfFadeIn = 0;
        long expectedKey = 9;
        double expectedKeyConfidence = 0.408;
        float expectedLoudness = -5.883f;
        long expectedMode = 0;
        double expectedModeConfidence = 0.485;
        long expectedNumSamples = 4585515;
        long expectedOffsetSeconds = 0;
        double expectedRhythmVersion = 1;
        string expectedRhythmstring = "rhythmstring";
        string expectedSampleMd5 = "sample_md5";
        double expectedStartOfFadeOut = 201.13705;
        double expectedSynchVersion = 1;
        string expectedSynchstring = "synchstring";
        float expectedTempo = 118.211f;
        double expectedTempoConfidence = 0.73;
        long expectedTimeSignature = 4;
        double expectedTimeSignatureConfidence = 0.994;
        long expectedWindowSeconds = 0;

        Assert.Equal(expectedAnalysisChannels, deserialized.AnalysisChannels);
        Assert.Equal(expectedAnalysisSampleRate, deserialized.AnalysisSampleRate);
        Assert.Equal(expectedCodeVersion, deserialized.CodeVersion);
        Assert.Equal(expectedCodestring, deserialized.Codestring);
        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedEchoprintVersion, deserialized.EchoprintVersion);
        Assert.Equal(expectedEchoprintstring, deserialized.Echoprintstring);
        Assert.Equal(expectedEndOfFadeIn, deserialized.EndOfFadeIn);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedKeyConfidence, deserialized.KeyConfidence);
        Assert.Equal(expectedLoudness, deserialized.Loudness);
        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.Equal(expectedModeConfidence, deserialized.ModeConfidence);
        Assert.Equal(expectedNumSamples, deserialized.NumSamples);
        Assert.Equal(expectedOffsetSeconds, deserialized.OffsetSeconds);
        Assert.Equal(expectedRhythmVersion, deserialized.RhythmVersion);
        Assert.Equal(expectedRhythmstring, deserialized.Rhythmstring);
        Assert.Equal(expectedSampleMd5, deserialized.SampleMd5);
        Assert.Equal(expectedStartOfFadeOut, deserialized.StartOfFadeOut);
        Assert.Equal(expectedSynchVersion, deserialized.SynchVersion);
        Assert.Equal(expectedSynchstring, deserialized.Synchstring);
        Assert.Equal(expectedTempo, deserialized.Tempo);
        Assert.Equal(expectedTempoConfidence, deserialized.TempoConfidence);
        Assert.Equal(expectedTimeSignature, deserialized.TimeSignature);
        Assert.Equal(expectedTimeSignatureConfidence, deserialized.TimeSignatureConfidence);
        Assert.Equal(expectedWindowSeconds, deserialized.WindowSeconds);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Track
        {
            AnalysisChannels = 1,
            AnalysisSampleRate = 22050,
            CodeVersion = 3.15,
            Codestring = "codestring",
            Duration = 207.95985,
            EchoprintVersion = 4.15,
            Echoprintstring = "echoprintstring",
            EndOfFadeIn = 0,
            Key = 9,
            KeyConfidence = 0.408,
            Loudness = -5.883f,
            Mode = 0,
            ModeConfidence = 0.485,
            NumSamples = 4585515,
            OffsetSeconds = 0,
            RhythmVersion = 1,
            Rhythmstring = "rhythmstring",
            SampleMd5 = "sample_md5",
            StartOfFadeOut = 201.13705,
            SynchVersion = 1,
            Synchstring = "synchstring",
            Tempo = 118.211f,
            TempoConfidence = 0.73,
            TimeSignature = 4,
            TimeSignatureConfidence = 0.994,
            WindowSeconds = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Track { };

        Assert.Null(model.AnalysisChannels);
        Assert.False(model.RawData.ContainsKey("analysis_channels"));
        Assert.Null(model.AnalysisSampleRate);
        Assert.False(model.RawData.ContainsKey("analysis_sample_rate"));
        Assert.Null(model.CodeVersion);
        Assert.False(model.RawData.ContainsKey("code_version"));
        Assert.Null(model.Codestring);
        Assert.False(model.RawData.ContainsKey("codestring"));
        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.EchoprintVersion);
        Assert.False(model.RawData.ContainsKey("echoprint_version"));
        Assert.Null(model.Echoprintstring);
        Assert.False(model.RawData.ContainsKey("echoprintstring"));
        Assert.Null(model.EndOfFadeIn);
        Assert.False(model.RawData.ContainsKey("end_of_fade_in"));
        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.KeyConfidence);
        Assert.False(model.RawData.ContainsKey("key_confidence"));
        Assert.Null(model.Loudness);
        Assert.False(model.RawData.ContainsKey("loudness"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.ModeConfidence);
        Assert.False(model.RawData.ContainsKey("mode_confidence"));
        Assert.Null(model.NumSamples);
        Assert.False(model.RawData.ContainsKey("num_samples"));
        Assert.Null(model.OffsetSeconds);
        Assert.False(model.RawData.ContainsKey("offset_seconds"));
        Assert.Null(model.RhythmVersion);
        Assert.False(model.RawData.ContainsKey("rhythm_version"));
        Assert.Null(model.Rhythmstring);
        Assert.False(model.RawData.ContainsKey("rhythmstring"));
        Assert.Null(model.SampleMd5);
        Assert.False(model.RawData.ContainsKey("sample_md5"));
        Assert.Null(model.StartOfFadeOut);
        Assert.False(model.RawData.ContainsKey("start_of_fade_out"));
        Assert.Null(model.SynchVersion);
        Assert.False(model.RawData.ContainsKey("synch_version"));
        Assert.Null(model.Synchstring);
        Assert.False(model.RawData.ContainsKey("synchstring"));
        Assert.Null(model.Tempo);
        Assert.False(model.RawData.ContainsKey("tempo"));
        Assert.Null(model.TempoConfidence);
        Assert.False(model.RawData.ContainsKey("tempo_confidence"));
        Assert.Null(model.TimeSignature);
        Assert.False(model.RawData.ContainsKey("time_signature"));
        Assert.Null(model.TimeSignatureConfidence);
        Assert.False(model.RawData.ContainsKey("time_signature_confidence"));
        Assert.Null(model.WindowSeconds);
        Assert.False(model.RawData.ContainsKey("window_seconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Track { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Track
        {
            // Null should be interpreted as omitted for these properties
            AnalysisChannels = null,
            AnalysisSampleRate = null,
            CodeVersion = null,
            Codestring = null,
            Duration = null,
            EchoprintVersion = null,
            Echoprintstring = null,
            EndOfFadeIn = null,
            Key = null,
            KeyConfidence = null,
            Loudness = null,
            Mode = null,
            ModeConfidence = null,
            NumSamples = null,
            OffsetSeconds = null,
            RhythmVersion = null,
            Rhythmstring = null,
            SampleMd5 = null,
            StartOfFadeOut = null,
            SynchVersion = null,
            Synchstring = null,
            Tempo = null,
            TempoConfidence = null,
            TimeSignature = null,
            TimeSignatureConfidence = null,
            WindowSeconds = null,
        };

        Assert.Null(model.AnalysisChannels);
        Assert.False(model.RawData.ContainsKey("analysis_channels"));
        Assert.Null(model.AnalysisSampleRate);
        Assert.False(model.RawData.ContainsKey("analysis_sample_rate"));
        Assert.Null(model.CodeVersion);
        Assert.False(model.RawData.ContainsKey("code_version"));
        Assert.Null(model.Codestring);
        Assert.False(model.RawData.ContainsKey("codestring"));
        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.EchoprintVersion);
        Assert.False(model.RawData.ContainsKey("echoprint_version"));
        Assert.Null(model.Echoprintstring);
        Assert.False(model.RawData.ContainsKey("echoprintstring"));
        Assert.Null(model.EndOfFadeIn);
        Assert.False(model.RawData.ContainsKey("end_of_fade_in"));
        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.KeyConfidence);
        Assert.False(model.RawData.ContainsKey("key_confidence"));
        Assert.Null(model.Loudness);
        Assert.False(model.RawData.ContainsKey("loudness"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.ModeConfidence);
        Assert.False(model.RawData.ContainsKey("mode_confidence"));
        Assert.Null(model.NumSamples);
        Assert.False(model.RawData.ContainsKey("num_samples"));
        Assert.Null(model.OffsetSeconds);
        Assert.False(model.RawData.ContainsKey("offset_seconds"));
        Assert.Null(model.RhythmVersion);
        Assert.False(model.RawData.ContainsKey("rhythm_version"));
        Assert.Null(model.Rhythmstring);
        Assert.False(model.RawData.ContainsKey("rhythmstring"));
        Assert.Null(model.SampleMd5);
        Assert.False(model.RawData.ContainsKey("sample_md5"));
        Assert.Null(model.StartOfFadeOut);
        Assert.False(model.RawData.ContainsKey("start_of_fade_out"));
        Assert.Null(model.SynchVersion);
        Assert.False(model.RawData.ContainsKey("synch_version"));
        Assert.Null(model.Synchstring);
        Assert.False(model.RawData.ContainsKey("synchstring"));
        Assert.Null(model.Tempo);
        Assert.False(model.RawData.ContainsKey("tempo"));
        Assert.Null(model.TempoConfidence);
        Assert.False(model.RawData.ContainsKey("tempo_confidence"));
        Assert.Null(model.TimeSignature);
        Assert.False(model.RawData.ContainsKey("time_signature"));
        Assert.Null(model.TimeSignatureConfidence);
        Assert.False(model.RawData.ContainsKey("time_signature_confidence"));
        Assert.Null(model.WindowSeconds);
        Assert.False(model.RawData.ContainsKey("window_seconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Track
        {
            // Null should be interpreted as omitted for these properties
            AnalysisChannels = null,
            AnalysisSampleRate = null,
            CodeVersion = null,
            Codestring = null,
            Duration = null,
            EchoprintVersion = null,
            Echoprintstring = null,
            EndOfFadeIn = null,
            Key = null,
            KeyConfidence = null,
            Loudness = null,
            Mode = null,
            ModeConfidence = null,
            NumSamples = null,
            OffsetSeconds = null,
            RhythmVersion = null,
            Rhythmstring = null,
            SampleMd5 = null,
            StartOfFadeOut = null,
            SynchVersion = null,
            Synchstring = null,
            Tempo = null,
            TempoConfidence = null,
            TimeSignature = null,
            TimeSignatureConfidence = null,
            WindowSeconds = null,
        };

        model.Validate();
    }
}
