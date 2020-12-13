using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using SpotifyApi.Models;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace SpotifyApi.Tests.EditMode {
    public class JsonToModelsTest {
        TestModelJsons testJson;

        float e(int d) { return 1.0F / (float)Math.Pow(10, d); }

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            testJson = AssetDatabase.LoadAssetAtPath<TestModelJsons>(
                "Assets/SpotifyApi/Tests/EditMode/TestModelJsons.asset");
        }

        // いちいち全てJsonの値が正しいかはチェックしない

        [Test]
        public void TestUserModel() {
            var model = JsonConvert.DeserializeObject<UserModel>(testJson.UserProfileResponse);
            Assert.That(model.Country, Is.Not.Empty);
            Assert.That(model.DisplayName, Is.Not.Empty);
            Assert.That(model.Email, Is.Not.Empty);
            Assert.That(model.ExternalUrls.Spotify, Is.Not.Empty);
            Assert.That(model.Href, Is.Not.Empty);
            Assert.That(model.Id, Is.InstanceOf<UserId>());
            Assert.That(model.Id.value, Is.Not.Empty);
            Assert.That(model.Images, Is.Not.Empty);
            Assert.That(model.Images[0].Height, Is.Null);
            Assert.That(model.Images[0].Width, Is.Null);
            Assert.That(model.Images[0].Url, Is.Not.Empty);
            Assert.That(model.Product, Is.Not.Empty);
            Assert.That(model.Type, Is.Not.Empty);
            Assert.That(model.Uri, Is.Not.Empty);
        }

        [Test]
        public void TestAudioAnalysisModel() {
            var model = JsonConvert.DeserializeObject<AudioAnalysisModel>(testJson.AudioAnalysisResponse);
            Assert.That(model.Bars, Is.Not.Empty);
            Assert.That(model.Bars[0].Start, Is.Not.Zero);
            Assert.That(model.Bars[0].Duration, Is.Not.Zero);
            Assert.That(model.Bars[0].Confidence, Is.Not.Zero);
            Assert.That(model.Beats, Is.Not.Empty);
            Assert.That(model.Beats[0].Start, Is.Not.Zero);
            Assert.That(model.Beats[0].Duration, Is.Not.Zero);
            Assert.That(model.Beats[0].Confidence, Is.Not.Zero);

            Assert.That(model.Sections, Is.Not.Empty);
            Assert.That(model.Sections[0].Start, Is.Not.Zero);
            Assert.That(model.Sections[0].Duration, Is.Not.Zero);
            Assert.That(model.Sections[0].Confidence, Is.Not.Zero);
            Assert.That(model.Sections[0].Loudness, Is.Not.Zero);
            Assert.That(model.Sections[0].Tempo, Is.Not.Zero);
            Assert.That(model.Sections[0].TempoConfidence, Is.Not.Zero);
            Assert.That(model.Sections[0].Key, Is.Not.Zero);
            Assert.That(model.Sections[0].KeyConfidence, Is.Not.Zero);
            Assert.That(model.Sections[0].Mode, Is.Not.Zero);
            Assert.That(model.Sections[0].ModeConfidence, Is.Not.Zero);
            Assert.That(model.Sections[0].TimeSignature, Is.Not.Zero);
            Assert.That(model.Sections[0].TimeSignatureConfidence, Is.Not.Zero);

            Assert.That(model.Segments, Is.Not.Empty);
            Assert.That(model.Segments[0].Start, Is.Not.Zero);
            Assert.That(model.Segments[0].Duration, Is.Not.Zero);
            Assert.That(model.Segments[0].Confidence, Is.Not.Zero);
            Assert.That(model.Segments[0].LoudnessStart, Is.Not.Zero);
            Assert.That(model.Segments[0].LoudnessMaxTime, Is.Not.Zero);
            Assert.That(model.Segments[0].LoudnessMax, Is.Not.Zero);
            Assert.That(model.Segments[0].LoudnessEnd, Is.Not.Zero);
            Assert.That(model.Segments[0].Pitches, Is.Not.Empty);
            Assert.That(model.Segments[0].Timbre, Is.Not.Empty);

            Assert.That(model.Tatums, Is.Not.Empty);
            Assert.That(model.Tatums[0].Start, Is.Not.Zero);
            Assert.That(model.Tatums[0].Duration, Is.Not.Zero);
            Assert.That(model.Tatums[0].Confidence, Is.Not.Zero);

            Assert.That(model.Track.Duration, Is.Not.Zero);
            Assert.That(model.Track.SampleMd5, Is.Empty);
            Assert.That(model.Track.OffsetSeconds, Is.Zero);
            Assert.That(model.Track.WindowSeconds, Is.Zero);
            Assert.That(model.Track.AnalysisSampleRate, Is.Not.Zero);
            Assert.That(model.Track.AnalysisChannels, Is.Not.Zero);
            Assert.That(model.Track.StartOfFadeOut, Is.Not.Zero);
            Assert.That(model.Track.Loudness, Is.Not.Zero);
            Assert.That(model.Track.Tempo, Is.Not.Zero);
            Assert.That(model.Track.TempoConfidence, Is.Not.Zero);
            Assert.That(model.Track.TimeSignature, Is.Not.Zero);
            Assert.That(model.Track.TimeSignatureConfidence, Is.Not.Zero);
            Assert.That(model.Track.Key, Is.Not.Zero);
            Assert.That(model.Track.KeyConfidence, Is.Not.Zero);
            Assert.That(model.Track.Mode, Is.Zero);
            Assert.That(model.Track.ModeConfidence, Is.Not.Zero);
            Assert.That(model.Track.Codestring, Is.Not.Empty);
            Assert.That(model.Track.CodeVersion, Is.Not.Zero);
            Assert.That(model.Track.Echoprintstring, Is.Not.Empty);
            Assert.That(model.Track.EchoprintVersion, Is.Not.Zero);
            Assert.That(model.Track.Synchstring, Is.Not.Empty);
            Assert.That(model.Track.SynchVersion, Is.Not.Zero);
            Assert.That(model.Track.Rhythmstring, Is.Not.Empty);
            Assert.That(model.Track.RhythmVersion, Is.Not.Zero);
        }

        [Test]
        public void TestAudioFeaturesModel() {
            var model = JsonConvert.DeserializeObject<AudioFeaturesModel>(testJson.AudioFeaturesResponse);
            Assert.That(model.Danceability, Is.Not.Zero);
            Assert.That(model.Energy, Is.Not.Zero);
            Assert.That(model.Key, Is.Not.Zero);
            Assert.That(model.Loudness, Is.Not.Zero);
            Assert.That(model.Mode, Is.Zero);
            Assert.That(model.Speechiness, Is.Not.Zero);
            Assert.That(model.Acousticness, Is.Not.Zero);
            Assert.That(model.Instrumentalness, Is.Not.Zero);
            Assert.That(model.Liveness, Is.Not.Zero);
            Assert.That(model.Valence, Is.Not.Zero);
            Assert.That(model.Tempo, Is.Not.Zero);
            Assert.That(model.Type, Is.Not.Empty);
            Assert.That(model.Id, Is.InstanceOf<TrackId>());
            Assert.That(model.Id.value, Is.Not.Empty);
            Assert.That(model.Uri, Is.Not.Empty);
            Assert.That(model.TrackHref, Is.Not.Empty);
            Assert.That(model.AnalysisUrl, Is.Not.Empty);
            Assert.That(model.DurationMs, Is.Not.Zero);
            Assert.That(model.TimeSignature, Is.Not.Zero);
        }

        [Test]
        public void TestTrackModel() {
            var model = JsonConvert.DeserializeObject<TrackModel>(testJson.TrackResponse);
            {
                var album = model.Album;
                Assert.That(album.AlbumType, Is.Not.Empty);
                Assert.That(album.Artists, Is.Not.Empty);
                {
                    var artist = album.Artists[0];
                    Assert.That(artist.ExternalUrls.Spotify, Is.Not.Empty);
                    Assert.That(artist.Href, Is.Not.Empty);
                    Assert.That(artist.Id, Is.InstanceOf<ArtistId>());
                    Assert.That(artist.Id.value, Is.Not.Empty);
                    Assert.That(artist.Name, Is.Not.Empty);
                    Assert.That(artist.Type, Is.Not.Empty);
                    Assert.That(artist.Uri, Is.Not.Empty);
                }
                Assert.That(album.AvailableMarkets, Is.Not.Empty);
                Assert.That(album.ExternalUrls.Spotify, Is.Not.Empty);
                Assert.That(album.Href, Is.Not.Empty);
                Assert.That(album.Id, Is.InstanceOf<AlbumId>());
                Assert.That(album.Id.value, Is.Not.Empty);
                Assert.That(album.Images, Is.Not.Empty);
                {
                    var image = album.Images[0];
                    Assert.That(image.Height, Is.Not.Zero);
                    Assert.That(image.Url, Is.Not.Empty);
                    Assert.That(image.Width, Is.Not.Zero);
                }
                Assert.That(album.Name, Is.Not.Empty);
                Assert.That(album.ReleaseDate, Is.Not.Empty);
                Assert.That(album.ReleaseDatePrecision, Is.Not.Empty);
                Assert.That(album.Type, Is.Not.Empty);
                Assert.That(album.Uri, Is.Not.Empty);
            }
            Assert.That(model.Artists, Is.Not.Empty);
            {
                var artist = model.Artists[0];
                Assert.That(artist.ExternalUrls.Spotify, Is.Not.Empty);
                Assert.That(artist.Href, Is.Not.Empty);
                Assert.That(artist.Id, Is.InstanceOf<ArtistId>());
                Assert.That(artist.Id.value, Is.Not.Empty);
                Assert.That(artist.Name, Is.Not.Empty);
                Assert.That(artist.Type, Is.Not.Empty);
                Assert.That(artist.Uri, Is.Not.Empty);
            }
            Assert.That(model.AvailableMarkets, Is.Not.Empty);
            Assert.That(model.DiscNumber, Is.Not.Zero);
            Assert.That(model.DurationMs, Is.Not.Zero);
            Assert.That(model.Explicit, Is.False);
            Assert.That(model.ExternalIds.Isrc, Is.Not.Empty);
            Assert.That(model.ExternalUrls.Spotify, Is.Not.Empty);
            Assert.That(model.Href, Is.Not.Empty);
            Assert.That(model.Id, Is.InstanceOf<TrackId>());
            Assert.That(model.Id.value, Is.Not.Empty);
            Assert.That(model.IsLocal, Is.False);
            Assert.That(model.Name, Is.Not.Empty);
            Assert.That(model.Popularity, Is.Not.Zero);
            Assert.That(model.PreviewUrl, Is.Not.Empty);
            Assert.That(model.TrackNumber, Is.Not.Zero);
            Assert.That(model.Type, Is.Not.Empty);
            Assert.That(model.Uri, Is.Not.Empty);
        }

        [Test]
        public void TestTracksModel() {
            var model = JsonConvert.DeserializeObject<PlaylistTrackPagingModel>(testJson.PlaylistTracksResponse);
            Assert.That(model.Href, Is.Not.Empty);
            Assert.That(model.Items, Is.Not.Empty);
            {
                var item = model.Items[0];
                Assert.That(item.AddedAt, Is.Not.Empty);
                {
                    var addedBy = item.AddedBy;
                    Assert.That(addedBy.ExternalUrls.Spotify, Is.Not.Empty);
                    Assert.That(addedBy.Href, Is.Not.Empty);
                    Assert.That(addedBy.Id, Is.InstanceOf<UserId>());
                    Assert.That(addedBy.Id.value, Is.Not.Empty);
                    Assert.That(addedBy.Type, Is.Not.Empty);
                    Assert.That(addedBy.Uri, Is.Not.Empty);
                }
                Assert.That(item.IsLocal, Is.False);
                {
                    var track = item.Track;
                    {
                        var album = track.Album;
                        Assert.That(album.AlbumType, Is.Not.Empty);
                        Assert.That(album.Artists, Is.Not.Empty);
                        {
                            var artist = album.Artists[0];
                            Assert.That(artist.ExternalUrls.Spotify, Is.Not.Empty);
                            Assert.That(artist.Href, Is.Not.Empty);
                            Assert.That(artist.Id, Is.InstanceOf<ArtistId>());
                            Assert.That(artist.Id.value, Is.Not.Empty);
                            Assert.That(artist.Name, Is.Not.Empty);
                            Assert.That(artist.Type, Is.Not.Empty);
                            Assert.That(artist.Uri, Is.Not.Empty);
                        }
                        Assert.That(album.AvailableMarkets, Is.Not.Empty);
                        Assert.That(album.ExternalUrls.Spotify, Is.Not.Empty);
                        Assert.That(album.Href, Is.Not.Empty);
                        Assert.That(album.Id, Is.InstanceOf<AlbumId>());
                        Assert.That(album.Id.value, Is.Not.Empty);
                        Assert.That(album.Images, Is.Not.Empty);
                        {
                            var image = album.Images[0];
                            Assert.That(image.Height, Is.Not.Zero);
                            Assert.That(image.Url, Is.Not.Empty);
                            Assert.That(image.Width, Is.Not.Zero);
                        }
                        Assert.That(album.Name, Is.Not.Empty);
                        Assert.That(album.ReleaseDate, Is.Null);
                        Assert.That(album.ReleaseDatePrecision, Is.Null);
                        Assert.That(album.Type, Is.Not.Empty);
                        Assert.That(album.Uri, Is.Not.Empty);
                    }
                    Assert.That(track.Artists, Is.Not.Empty);
                    {
                        var artist = track.Artists[0];
                        Assert.That(artist.ExternalUrls.Spotify, Is.Not.Empty);
                        Assert.That(artist.Href, Is.Not.Empty);
                        Assert.That(artist.Id, Is.InstanceOf<ArtistId>());
                        Assert.That(artist.Id.value, Is.Not.Empty);
                        Assert.That(artist.Name, Is.Not.Empty);
                        Assert.That(artist.Type, Is.Not.Empty);
                        Assert.That(artist.Uri, Is.Not.Empty);
                    }
                    Assert.That(track.AvailableMarkets, Is.Not.Empty);
                    Assert.That(track.DiscNumber, Is.Not.Zero);
                    Assert.That(track.DurationMs, Is.Not.Zero);
                    Assert.That(track.Explicit, Is.False);
                    Assert.That(track.ExternalIds.Isrc, Is.Not.Empty);
                    Assert.That(track.ExternalUrls.Spotify, Is.Not.Empty);
                    Assert.That(track.Href, Is.Not.Empty);
                    Assert.That(track.Id, Is.InstanceOf<TrackId>());
                    Assert.That(track.Id.value, Is.Not.Empty);
                    Assert.That(track.IsLocal, Is.False);
                    Assert.That(track.Name, Is.Not.Empty);
                    Assert.That(track.Popularity, Is.Not.Zero);
                    Assert.That(track.PreviewUrl, Is.Not.Empty);
                    Assert.That(track.TrackNumber, Is.Not.Zero);
                    Assert.That(track.Type, Is.Not.Empty);
                    Assert.That(track.Uri, Is.Not.Empty);
                }
            }
            Assert.That(model.Limit, Is.Not.Zero);
            Assert.That(model.Next, Is.Null);
            Assert.That(model.Offset, Is.Zero);
            Assert.That(model.Previous, Is.Null);
            Assert.That(model.Total, Is.Not.Zero);
        }

        [Test]
        public void TestPlaylistModel() {
            var model = JsonConvert.DeserializeObject<PlaylistModel>(testJson.PlaylistResponse);
            Assert.That(model.Collaborative, Is.False);
            Assert.That(model.Description, Is.Not.Empty);
            Assert.That(model.ExternalUrls.Spotify, Is.Not.Empty);
            Assert.That(model.Href, Is.Not.Empty);
            Assert.That(model.Id, Is.InstanceOf<PlaylistId>());
            Assert.That(model.Id.value, Is.Not.Empty);
            Assert.That(model.Images, Is.Not.Empty);
            Assert.That(model.Images[0].Url, Is.Not.Empty);
            Assert.That(model.Name, Is.Not.Empty);
            {
                var owner = model.Owner;
                Assert.That(owner.ExternalUrls.Spotify, Is.Not.Empty);
                Assert.That(owner.Href, Is.Not.Empty);
                Assert.That(owner.Id, Is.InstanceOf<UserId>());
                Assert.That(owner.Id.value, Is.Not.Empty);
                Assert.That(owner.Type, Is.Not.Empty);
                Assert.That(owner.Uri, Is.Not.Empty);
            }
            Assert.That(model.Public, Is.Null);
            Assert.That(model.SnapshotId, Is.Not.Empty);
            {
                var tracks = model.Tracks;
                Assert.That(tracks.Href, Is.Not.Empty);
                {
                    Assert.That(tracks.Items, Is.Not.Empty);
                    {
                        var item = tracks.Items[0];
                        Assert.That(item.AddedAt, Is.Not.Empty);
                        {
                            var addedBy = item.AddedBy;
                            Assert.That(addedBy.ExternalUrls.Spotify, Is.Not.Empty);
                            Assert.That(addedBy.Href, Is.Not.Empty);
                            Assert.That(addedBy.Id, Is.InstanceOf<UserId>());
                            Assert.That(addedBy.Id.value, Is.Not.Empty);
                            Assert.That(addedBy.Type, Is.Not.Empty);
                            Assert.That(addedBy.Uri, Is.Not.Empty);
                        }
                        Assert.That(item.IsLocal, Is.False);
                        {
                            var track = item.Track;
                            {
                                var album = track.Album;
                                Assert.That(album.AlbumType, Is.Not.Empty);
                                Assert.That(album.AvailableMarkets, Is.Not.Empty);
                                Assert.That(album.ExternalUrls.Spotify, Is.Not.Empty);
                                Assert.That(album.Href, Is.Not.Empty);
                                Assert.That(album.Id, Is.InstanceOf<AlbumId>());
                                Assert.That(album.Id.value, Is.Not.Empty);
                                Assert.That(album.Images, Is.Not.Empty);
                                {
                                    var image = album.Images[0];
                                    Assert.That(image.Height, Is.Not.Zero);
                                    Assert.That(image.Url, Is.Not.Empty);
                                    Assert.That(image.Width, Is.Not.Zero);
                                }
                                Assert.That(album.Name, Is.Not.Empty);
                                Assert.That(album.Type, Is.Not.Empty);
                                Assert.That(album.Uri, Is.Not.Empty);
                            }
                            Assert.That(track.Artists, Is.Not.Empty);
                            {
                                var artist = track.Artists[0];
                                Assert.That(artist.ExternalUrls.Spotify, Is.Not.Empty);
                                Assert.That(artist.Href, Is.Not.Empty);
                                Assert.That(artist.Id, Is.InstanceOf<ArtistId>());
                                Assert.That(artist.Id.value, Is.Not.Empty);
                                Assert.That(artist.Name, Is.Not.Empty);
                                Assert.That(artist.Type, Is.Not.Empty);
                                Assert.That(artist.Uri, Is.Not.Empty);
                            }
                            Assert.That(track.AvailableMarkets, Is.Not.Empty);
                            Assert.That(track.DiscNumber, Is.Not.Zero);
                            Assert.That(track.DurationMs, Is.Not.Zero);
                            Assert.That(track.Explicit, Is.False);
                            Assert.That(track.ExternalIds.Isrc, Is.Not.Empty);
                            Assert.That(track.ExternalUrls.Spotify, Is.Not.Empty);
                            Assert.That(track.Href, Is.Not.Empty);
                            Assert.That(track.Id, Is.InstanceOf<TrackId>());
                            Assert.That(track.Id.value, Is.Not.Empty);
                            Assert.That(track.Name, Is.Not.Empty);
                            Assert.That(track.Popularity, Is.Not.Zero);
                            Assert.That(track.PreviewUrl, Is.Not.Empty);
                            Assert.That(track.TrackNumber, Is.Not.Zero);
                            Assert.That(track.Type, Is.Not.Empty);
                            Assert.That(track.Uri, Is.Not.Empty);
                        }
                    }
                }
                Assert.That(tracks.Limit, Is.Not.Zero);
                Assert.That(tracks.Next, Is.Not.Empty);
                Assert.That(tracks.Offset, Is.Zero);
                Assert.That(tracks.Previous, Is.Null);
                Assert.That(tracks.Total, Is.Not.Zero);
            }
            Assert.That(model.Type, Is.Not.Empty);
            Assert.That(model.Uri, Is.Not.Empty);
        }

        [Test]
        public void TestPlaylistsPagingModel() {
            var model = JsonConvert.DeserializeObject<PlaylistsPagingModel>(testJson.PlaylistsResponse);
            Assert.That(model.Href, Is.Not.Empty);
            Assert.That(model.Items, Is.Not.Empty);
            {
                var item = model.Items[0];

                Assert.That(item.Collaborative, Is.False);
                Assert.That(item.Description, Is.Null);
                Assert.That(item.ExternalUrls.Spotify, Is.Not.Empty);
                Assert.That(item.Href, Is.Not.Empty);
                Assert.That(item.Id, Is.InstanceOf<PlaylistId>());
                Assert.That(item.Id.value, Is.Not.Empty);
                Assert.That(item.Images, Is.Empty);
                Assert.That(item.Name, Is.Not.Empty);
                {
                    var owner = item.Owner;
                    Assert.That(owner.ExternalUrls.Spotify, Is.Not.Empty);
                    Assert.That(owner.Href, Is.Not.Empty);
                    Assert.That(owner.Id, Is.InstanceOf<UserId>());
                    Assert.That(owner.Id.value, Is.Not.Empty);
                    Assert.That(owner.Type, Is.Not.Empty);
                    Assert.That(owner.Uri, Is.Not.Empty);
                }
                Assert.That(item.Public, Is.True);
                Assert.That(item.SnapshotId, Is.Not.Empty);
                Assert.That(item.Tracks.Href, Is.Not.Empty);
                Assert.That(item.Tracks.Total, Is.Not.Zero);
                Assert.That(item.Type, Is.Not.Empty);
                Assert.That(item.Uri, Is.Not.Empty);
            }
            Assert.That(model.Limit, Is.Not.Zero);
            Assert.That(model.Next, Is.Null);
            Assert.That(model.Offset, Is.Zero);
            Assert.That(model.Previous, Is.Null);
            Assert.That(model.Total, Is.Not.Zero);
        }

        [Test]
        public void TestCurrentlyPlayingTrackModel() {
            var model = JsonConvert.DeserializeObject<CurrentlyPlayingTrackModel>(testJson.UserCurrentlyPlayingTrackResponse);
            {
                var context = model.Context;
                Assert.That(context.ExternalUrls.Spotify, Is.Not.Empty);
                Assert.That(context.Href, Is.Not.Empty);
                Assert.That(context.Type, Is.Not.Empty);
                Assert.That(context.Uri, Is.Not.Empty);
            }
            Assert.That(model.Timestamp, Is.Not.Zero);
            Assert.That(model.ProgressMs, Is.Not.Zero);
            Assert.That(model.IsPlaying, Is.True);
            Assert.That(model.CurrentlyPlayingType, Is.Not.Empty);
            {
                var item = model.Item;
                {
                    var album = item.Album;
                    Assert.That(album.AlbumType, Is.Not.Empty);
                    Assert.That(album.ExternalUrls.Spotify, Is.Not.Empty);
                    Assert.That(album.Href, Is.Not.Empty);
                    Assert.That(album.Id, Is.InstanceOf<AlbumId>());
                    Assert.That(album.Id.value, Is.Not.Empty);
                    Assert.That(album.Images, Is.Not.Empty);
                    {
                        var image = album.Images[0];
                        Assert.That(image.Height, Is.Not.Zero);
                        Assert.That(image.Url, Is.Not.Empty);
                        Assert.That(image.Width, Is.Not.Zero);
                    }
                    Assert.That(album.Name, Is.Not.Empty);
                    Assert.That(album.Type, Is.Not.Empty);
                    Assert.That(album.Uri, Is.Not.Empty);
                }
                Assert.That(item.Artists, Is.Not.Empty);
                {
                    var artist = item.Artists[0];
                    Assert.That(artist.ExternalUrls.Spotify, Is.Not.Empty);
                    Assert.That(artist.Href, Is.Not.Empty);
                    Assert.That(artist.Id, Is.InstanceOf<ArtistId>());
                    Assert.That(artist.Id.value, Is.Not.Empty);
                    Assert.That(artist.Name, Is.Not.Empty);
                    Assert.That(artist.Type, Is.Not.Empty);
                    Assert.That(artist.Uri, Is.Not.Empty);
                }
                Assert.That(item.AvailableMarkets, Is.Not.Empty);
                Assert.That(item.DiscNumber, Is.Not.Zero);
                Assert.That(item.DurationMs, Is.Not.Zero);
                Assert.That(item.Explicit, Is.False);
                Assert.That(item.ExternalIds.Isrc, Is.Not.Empty);
                Assert.That(item.ExternalUrls.Spotify, Is.Not.Empty);
                Assert.That(item.Href, Is.Not.Empty);
                Assert.That(item.Id, Is.InstanceOf<TrackId>());
                Assert.That(item.Id.value, Is.Not.Empty);
                Assert.That(item.Name, Is.Not.Empty);
                Assert.That(item.Popularity, Is.Zero);
                Assert.That(item.PreviewUrl, Is.Not.Empty);
                Assert.That(item.TrackNumber, Is.Not.Zero);
                Assert.That(item.Type, Is.Not.Empty);
                Assert.That(item.Uri, Is.Not.Empty);
            }
        }

        [Test]
        public void TestDeviceListModel() {
            var model = JsonConvert.DeserializeObject<DeviceListModel>(testJson.UserAvailableDevicesResponse);
            Assert.That(model.Devices, Is.Not.Empty);
            {
                var device = model.Devices[0];
                Assert.That(device.Id, Is.InstanceOf<DeviceId>());
                Assert.That(device.Id.value, Is.Not.Empty);
                Assert.That(device.IsActive, Is.False);
                Assert.That(device.IsPrivateSession, Is.True);
                Assert.That(device.IsRestricted, Is.False);
                Assert.That(device.Name, Is.Not.Empty);
                Assert.That(device.Type, Is.Not.Empty);
                Assert.That(device.VolumePercent, Is.Not.Zero);
            }
        }

        [Test]
        public void TestPlayerModel() {
            var model = JsonConvert.DeserializeObject<PlayerModel>(testJson.UserCurrentPlayingResponse);
            Assert.That(model.Timestamp, Is.Not.Zero);
            {
                var device = model.Device;
                Assert.That(device.Id, Is.InstanceOf<DeviceId>());
                Assert.That(device.Id.value, Is.Not.Empty);
                Assert.That(device.IsActive, Is.False);
                Assert.That(device.IsRestricted, Is.False);
                Assert.That(device.Name, Is.Not.Empty);
                Assert.That(device.Type, Is.Not.Empty);
                Assert.That(device.VolumePercent, Is.Not.Zero);
            }
            Assert.That(model.ProgressMs, Is.Not.Zero);
            Assert.That(model.IsPlaying, Is.True);
            Assert.That(model.CurrentlyPlayingType, Is.Not.Zero);
            Assert.That(model.ShuffleState, Is.False);
            Assert.That(model.RepeatState, Is.Not.Empty);
            {
                var context = model.Context;
                Assert.That(context.ExternalUrls.Spotify, Is.Not.Empty);
                Assert.That(context.Href, Is.Not.Empty);
                Assert.That(context.Type, Is.Not.Empty);
                Assert.That(context.Uri, Is.Not.Empty);
            }
        }

        [Test]
        public void TestSavedTracksPagingModel() {
            var model = JsonConvert.DeserializeObject<SavedTracksPagingModel>(testJson.UserSavedTracksResponse);
            Assert.That(model.Href, Is.Not.Empty);
            Assert.That(model.Items, Is.Not.Empty);
            {
                var item = model.Items[0];
                Assert.That(item.AddedAt, Is.Not.Empty);
                {
                    var track = item.Track;
                    {
                        var album = track.Album;
                        Assert.That(album.AlbumType, Is.Not.Empty);
                        Assert.That(album.Artists, Is.Not.Empty);
                        {
                            var artist = album.Artists[0];
                            Assert.That(artist.ExternalUrls.Spotify, Is.Not.Empty);
                            Assert.That(artist.Href, Is.Not.Empty);
                            Assert.That(artist.Id, Is.InstanceOf<ArtistId>());
                            Assert.That(artist.Id.value, Is.Not.Empty);
                            Assert.That(artist.Name, Is.Not.Empty);
                            Assert.That(artist.Type, Is.Not.Empty);
                            Assert.That(artist.Uri, Is.Not.Empty);
                        }
                        Assert.That(album.AvailableMarkets, Is.Not.Empty);
                        Assert.That(album.ExternalUrls.Spotify, Is.Not.Empty);
                        Assert.That(album.Href, Is.Not.Empty);
                        Assert.That(album.Id, Is.InstanceOf<AlbumId>());
                        Assert.That(album.Id.value, Is.Not.Empty);
                        Assert.That(album.Images, Is.Not.Empty);
                        {
                            var image = album.Images[0];
                            Assert.That(image.Height, Is.Not.Zero);
                            Assert.That(image.Url, Is.Not.Empty);
                            Assert.That(image.Width, Is.Not.Zero);
                        }
                        Assert.That(album.Name, Is.Not.Empty);
                        Assert.That(album.Type, Is.Not.Empty);
                        Assert.That(album.Uri, Is.Not.Empty);
                    }
                    Assert.That(track.Artists, Is.Not.Empty);
                    {
                        var artist = track.Artists[0];
                        Assert.That(artist.ExternalUrls.Spotify, Is.Not.Empty);
                        Assert.That(artist.Href, Is.Not.Empty);
                        Assert.That(artist.Id, Is.InstanceOf<ArtistId>());
                        Assert.That(artist.Id.value, Is.Not.Empty);
                        Assert.That(artist.Name, Is.Not.Empty);
                        Assert.That(artist.Type, Is.Not.Empty);
                        Assert.That(artist.Uri, Is.Not.Empty);
                    }
                    Assert.That(track.AvailableMarkets, Is.Not.Empty);
                    Assert.That(track.DiscNumber, Is.Not.Zero);
                    Assert.That(track.DurationMs, Is.Not.Zero);
                    Assert.That(track.Explicit, Is.False);
                    Assert.That(track.ExternalIds.Isrc, Is.Not.Empty);
                    Assert.That(track.ExternalUrls.Spotify, Is.Not.Empty);
                    Assert.That(track.Href, Is.Not.Empty);
                    Assert.That(track.Id, Is.InstanceOf<TrackId>());
                    Assert.That(track.Id.value, Is.Not.Empty);
                    Assert.That(track.Name, Is.Not.Empty);
                    Assert.That(track.Popularity, Is.Not.Zero);
                    Assert.That(track.PreviewUrl, Is.Not.Empty);
                    Assert.That(track.TrackNumber, Is.Not.Zero);
                    Assert.That(track.Type, Is.Not.Empty);
                    Assert.That(track.Uri, Is.Not.Empty);
                }
                Assert.That(model.Limit, Is.Not.Zero);
                Assert.That(model.Next, Is.Not.Empty);
                Assert.That(model.Offset, Is.Zero);
                Assert.That(model.Previous, Is.Null);
                Assert.That(model.Total, Is.Not.Zero);
            }
        }

        [Test]
        public void TestSavedAlbumsPagingModel() {
            var model = JsonConvert.DeserializeObject<SavedAlbumsPagingModel>(testJson.UserSavedAlbumsResponse);
            Assert.That(model.Href, Is.Not.Empty);
            Assert.That(model.Items, Is.Not.Empty);
            {
                var item = model.Items[0];
                Assert.That(item.AddedAt, Is.Not.Empty);
                {
                    var album = item.Album;
                    Assert.That(album.AlbumType, Is.Not.Empty);
                    Assert.That(album.Artists, Is.Not.Empty);
                    {
                        var artist = album.Artists[0];
                        Assert.That(artist.ExternalUrls.Spotify, Is.Not.Empty);
                        Assert.That(artist.Href, Is.Not.Empty);
                        Assert.That(artist.Id, Is.InstanceOf<ArtistId>());
                        Assert.That(artist.Id.value, Is.Not.Empty);
                        Assert.That(artist.Name, Is.Not.Empty);
                        Assert.That(artist.Type, Is.Not.Empty);
                        Assert.That(artist.Uri, Is.Not.Empty);
                    }
                    Assert.That(album.AvailableMarkets, Is.Not.Empty);
                    Assert.That(album.Copyrights, Is.Not.Empty);
                    {
                        var copyrights = album.Copyrights[0];
                        Assert.That(copyrights.Text, Is.Not.Empty);
                        Assert.That(copyrights.Type, Is.Not.Empty);
                    }
                    Assert.That(album.ExternalIds.Upc, Is.Not.Empty);
                    Assert.That(album.ExternalUrls.Spotify, Is.Not.Empty);
                    Assert.That(album.Genres, Is.Empty);
                    Assert.That(album.Href, Is.Not.Empty);
                    Assert.That(album.Id, Is.InstanceOf<AlbumId>());
                    Assert.That(album.Id.value, Is.Not.Empty);
                    Assert.That(album.Images, Is.Not.Empty);
                    {
                        var image = album.Images[0];
                        Assert.That(image.Height, Is.Not.Zero);
                        Assert.That(image.Url, Is.Not.Empty);
                        Assert.That(image.Width, Is.Not.Zero);
                    }
                    Assert.That(album.Name, Is.Not.Empty);
                    Assert.That(album.Popularity, Is.Not.Zero);
                    Assert.That(album.ReleaseDate, Is.Not.Empty);
                    Assert.That(album.ReleaseDatePrecision, Is.Not.Empty);
                    {
                        var tracks = album.Tracks;
                        Assert.That(tracks.Href, Is.Not.Empty);
                        Assert.That(tracks.Items, Is.Not.Empty);
                        {
                            var track = tracks.Items[0];
                            Assert.That(track.Artists, Is.Not.Empty);
                            {
                                var artist = track.Artists[0];
                                Assert.That(artist.ExternalUrls.Spotify, Is.Not.Empty);
                                Assert.That(artist.Href, Is.Not.Empty);
                                Assert.That(artist.Id, Is.InstanceOf<ArtistId>());
                                Assert.That(artist.Id.value, Is.Not.Empty);
                                Assert.That(artist.Name, Is.Not.Empty);
                                Assert.That(artist.Type, Is.Not.Empty);
                                Assert.That(artist.Uri, Is.Not.Empty);
                            }
                            Assert.That(track.AvailableMarkets, Is.Not.Empty);
                            Assert.That(track.DiscNumber, Is.Not.Zero);
                            Assert.That(track.DurationMs, Is.Not.Zero);
                            Assert.That(track.Explicit, Is.False);
                            Assert.That(track.ExternalUrls.Spotify, Is.Not.Empty);
                            Assert.That(track.Href, Is.Not.Empty);
                            Assert.That(track.Id, Is.InstanceOf<TrackId>());
                            Assert.That(track.Id.value, Is.Not.Empty);
                            Assert.That(track.Name, Is.Not.Empty);
                            Assert.That(track.PreviewUrl, Is.Not.Empty);
                            Assert.That(track.TrackNumber, Is.Not.Zero);
                            Assert.That(track.Type, Is.Not.Empty);
                            Assert.That(track.Uri, Is.Not.Empty);
                        }
                        Assert.That(tracks.Limit, Is.Not.Zero);
                        Assert.That(tracks.Next, Is.Null);
                        Assert.That(tracks.Offset, Is.Zero);
                        Assert.That(tracks.Previous, Is.Null);
                        Assert.That(tracks.Total, Is.Not.Zero);
                    }
                }
                Assert.That(model.Limit, Is.Not.Zero);
                Assert.That(model.Next, Is.Not.Empty);
                Assert.That(model.Offset, Is.Zero);
                Assert.That(model.Previous, Is.Null);
                Assert.That(model.Total, Is.Not.Zero);
            }
        }

        [Test]
        public void TestArtistsPagingModel() {
            var model = JsonConvert.DeserializeObject<AlbumsPagingModel>(testJson.ArtistAlbumsResponse);
            Assert.That(model.Href, Is.Not.Empty);
            Assert.That(model.Items, Is.Not.Empty);
            {
                var album = model.Items[0];
                Assert.That(album.AlbumType, Is.Not.Empty);
                Assert.That(album.Artists, Is.Not.Empty);
                {
                    var artist = album.Artists[0];
                    Assert.That(artist.ExternalUrls.Spotify, Is.Not.Empty);
                    Assert.That(artist.Href, Is.Not.Empty);
                    Assert.That(artist.Id, Is.InstanceOf<ArtistId>());
                    Assert.That(artist.Id.value, Is.Not.Empty);
                    Assert.That(artist.Name, Is.Not.Empty);
                    Assert.That(artist.Type, Is.Not.Empty);
                    Assert.That(artist.Uri, Is.Not.Empty);
                }
                Assert.That(album.AvailableMarkets, Is.Not.Empty);
                Assert.That(album.ExternalUrls.Spotify, Is.Not.Empty);
                Assert.That(album.Href, Is.Not.Empty);
                Assert.That(album.Id, Is.InstanceOf<AlbumId>());
                Assert.That(album.Id.value, Is.Not.Empty);
                Assert.That(album.Images, Is.Not.Empty);
                {
                    var image = album.Images[0];
                    Assert.That(image.Height, Is.Not.Zero);
                    Assert.That(image.Url, Is.Not.Empty);
                    Assert.That(image.Width, Is.Not.Zero);
                }
                Assert.That(album.Name, Is.Not.Empty);
                Assert.That(album.ReleaseDate, Is.Not.Empty);
                Assert.That(album.ReleaseDatePrecision, Is.Not.Empty);
                Assert.That(album.Type, Is.Not.Empty);
                Assert.That(album.Uri, Is.Not.Empty);
            }
            Assert.That(model.Limit, Is.Not.Zero);
            Assert.That(model.Next, Is.Not.Empty);
            Assert.That(model.Offset, Is.Zero);
            Assert.That(model.Previous, Is.Null);
            Assert.That(model.Total, Is.Not.Zero);
        }

        [Test]
        public void TestArtistModel() {
            var model = JsonConvert.DeserializeObject<ArtistModel>(testJson.ArtistResponse);
            Assert.That(model.ExternalUrls.Spotify, Is.Not.Empty);
            Assert.That(model.Genres, Is.Not.Empty);
            Assert.That(model.Href, Is.Not.Empty);
            Assert.That(model.Id, Is.InstanceOf<ArtistId>());
            Assert.That(model.Id.value, Is.Not.Empty);
            Assert.That(model.Images, Is.Not.Empty);
            {
                var image = model.Images[0];
                Assert.That(image.Height, Is.Not.Zero);
                Assert.That(image.Url, Is.Not.Empty);
                Assert.That(image.Width, Is.Not.Zero);
            }
            Assert.That(model.Name, Is.Not.Empty);
            Assert.That(model.Popularity, Is.Not.Zero);
            Assert.That(model.Type, Is.Not.Empty);
            Assert.That(model.Uri, Is.Not.Empty);
        }

        [Test]
        public void TestTracksPagingModel() {
            var model = JsonConvert.DeserializeObject<TracksPagingModel>(testJson.AlbumTracksResponse);
            Assert.That(model.Href, Is.Not.Empty);
            Assert.That(model.Items, Is.Not.Empty);
            {
                var track = model.Items[0];
                Assert.That(track.Artists, Is.Not.Empty);
                {
                    var artist = track.Artists[0];
                    Assert.That(artist.ExternalUrls.Spotify, Is.Not.Empty);
                    Assert.That(artist.Href, Is.Not.Empty);
                    Assert.That(artist.Id, Is.InstanceOf<ArtistId>());
                    Assert.That(artist.Id.value, Is.Not.Empty);
                    Assert.That(artist.Name, Is.Not.Empty);
                    Assert.That(artist.Type, Is.Not.Empty);
                    Assert.That(artist.Uri, Is.Not.Empty);
                }
                Assert.That(track.AvailableMarkets, Is.Not.Empty);
                Assert.That(track.DiscNumber, Is.Not.Zero);
                Assert.That(track.DurationMs, Is.Not.Zero);
                Assert.That(track.Explicit, Is.False);
                Assert.That(track.ExternalUrls.Spotify, Is.Not.Empty);
                Assert.That(track.Href, Is.Not.Empty);
                Assert.That(track.Id, Is.InstanceOf<TrackId>());
                Assert.That(track.Id.value, Is.Not.Empty);
                Assert.That(track.Name, Is.Not.Empty);
                Assert.That(track.PreviewUrl, Is.Not.Empty);
                Assert.That(track.TrackNumber, Is.Not.Zero);
                Assert.That(track.Type, Is.Not.Empty);
                Assert.That(track.Uri, Is.Not.Empty);
            }
            Assert.That(model.Limit, Is.Not.Zero);
            Assert.That(model.Next, Is.Not.Empty);
            Assert.That(model.Offset, Is.Zero);
            Assert.That(model.Previous, Is.Null);
            Assert.That(model.Total, Is.Not.Zero);
        }


        [Test]
        public void TestAlbumModel() {
            var model = JsonConvert.DeserializeObject<AlbumModel>(testJson.AlbumResponse);
            Assert.That(model.Href, Is.Not.Empty);
            Assert.That(model.Artists, Is.Not.Empty);
            {
                var artist = model.Artists[0];
                Assert.That(artist.ExternalUrls.Spotify, Is.Not.Empty);
                Assert.That(artist.Href, Is.Not.Empty);
                Assert.That(artist.Id, Is.InstanceOf<ArtistId>());
                Assert.That(artist.Id.value, Is.Not.Empty);
                Assert.That(artist.Name, Is.Not.Empty);
                Assert.That(artist.Type, Is.Not.Empty);
                Assert.That(artist.Uri, Is.Not.Empty);
            }
            Assert.That(model.Copyrights, Is.Not.Empty);
            {
                var copyrights = model.Copyrights[0];
                Assert.That(copyrights.Text, Is.Not.Empty);
                Assert.That(copyrights.Type, Is.Not.Empty);
            }
            Assert.That(model.ExternalIds.Upc, Is.Not.Empty);
            Assert.That(model.ExternalUrls.Spotify, Is.Not.Empty);
            Assert.That(model.Genres, Is.Empty);
            Assert.That(model.Href, Is.Not.Empty);
            Assert.That(model.Id, Is.InstanceOf<AlbumId>());
            Assert.That(model.Id.value, Is.Not.Empty);
            Assert.That(model.Images, Is.Not.Empty);
            {
                var image = model.Images[0];
                Assert.That(image.Height, Is.Not.Zero);
                Assert.That(image.Url, Is.Not.Empty);
                Assert.That(image.Width, Is.Not.Zero);
            }
            Assert.That(model.Name, Is.Not.Empty);
            Assert.That(model.Popularity, Is.Not.Zero);
            Assert.That(model.ReleaseDate, Is.Not.Empty);
            Assert.That(model.ReleaseDatePrecision, Is.Not.Empty);
            {
                var tracks = model.Tracks;
                Assert.That(tracks.Href, Is.Not.Empty);
                Assert.That(tracks.Items, Is.Not.Empty);
                {
                    var track = tracks.Items[0];
                    Assert.That(track.Artists, Is.Not.Empty);
                    {
                        var artist = track.Artists[0];
                        Assert.That(artist.ExternalUrls.Spotify, Is.Not.Empty);
                        Assert.That(artist.Href, Is.Not.Empty);
                        Assert.That(artist.Id, Is.InstanceOf<ArtistId>());
                        Assert.That(artist.Id.value, Is.Not.Empty);
                        Assert.That(artist.Name, Is.Not.Empty);
                        Assert.That(artist.Type, Is.Not.Empty);
                        Assert.That(artist.Uri, Is.Not.Empty);
                    }
                    Assert.That(track.AvailableMarkets, Is.Not.Empty);
                    Assert.That(track.DiscNumber, Is.Not.Zero);
                    Assert.That(track.DurationMs, Is.Not.Zero);
                    Assert.That(track.Explicit, Is.False);
                    Assert.That(track.ExternalUrls.Spotify, Is.Not.Empty);
                    Assert.That(track.Href, Is.Not.Empty);
                    Assert.That(track.Id, Is.InstanceOf<TrackId>());
                    Assert.That(track.Id.value, Is.Not.Empty);
                    Assert.That(track.Name, Is.Not.Empty);
                    Assert.That(track.PreviewUrl, Is.Not.Empty);
                    Assert.That(track.TrackNumber, Is.Not.Zero);
                    Assert.That(track.Type, Is.Not.Empty);
                    Assert.That(track.Uri, Is.Not.Empty);
                }
            }
            Assert.That(model.Type, Is.Not.Empty);
            Assert.That(model.Uri, Is.Not.Empty);
        }
    }
}
