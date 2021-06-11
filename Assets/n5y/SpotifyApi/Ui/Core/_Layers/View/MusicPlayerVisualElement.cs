using System;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;

namespace n5y.SpotifyApi.Ui.Core.View {
    public class MusicPlayerVisualElement : IPlayingMusicPresentation, IMusicControlPresentation, IMusicViewTrigger {
        readonly VisualElement root;
        readonly Subject<Unit> onListOpen;
        readonly Subject<Unit> onAuthorization;
        readonly Subject<Unit> onPlay;
        readonly Subject<Unit> onPrevious;
        readonly Subject<Unit> onNext;
        readonly ReactiveProperty<float> seekValue;
        readonly CompositeDisposable disposable;
        Button openButton;
        Button authButton;
        Button playButton;
        Button nextButton;
        Button prevButton;
        Slider slider;
        Label timeLabel;
        Label trackLabel;
        Label albumLabel;
        Label artistLabel;
        VisualElement  artworkElm;

        public MusicPlayerVisualElement(VisualElement visualElement, CompositeDisposable lifeTime) {
            root = visualElement;
            onListOpen = new Subject<Unit>();
            onAuthorization = new Subject<Unit>();
            onPlay = new Subject<Unit>();
            onPrevious = new Subject<Unit>();
            onNext = new Subject<Unit>();
            seekValue = new ReactiveProperty<float>();
            disposable = lifeTime;
        }

        public void Bind() {
            openButton = root.Q<Button>("openButton");
            authButton = root.Q<Button>("authButton");

            var musicView = root.Q("MusicView");
            trackLabel = musicView.Q<Label>("Title");
            albumLabel = musicView.Q<Label>("Album");
            artistLabel = musicView.Q<Label>("Artist");
            artworkElm = musicView.Q("Artwork");

            var controlView = root.Q("MusicControl");
            playButton = controlView.Q<Button>("play");
            nextButton = controlView.Q<Button>("right");
            prevButton = controlView.Q<Button>("left");
            slider = controlView.Q<Slider>("progress slider");
            timeLabel = controlView.Q<Label>("progress time");

            openButton.clickable.clicked += () => onListOpen.OnNext(Unit.Default);
            authButton.clickable.clicked += () => onAuthorization.OnNext(Unit.Default);
            playButton.clickable.clicked += () => onPlay.OnNext(Unit.Default);
            nextButton.clickable.clicked += () => onNext.OnNext(Unit.Default);
            prevButton.clickable.clicked += () => onPrevious.OnNext(Unit.Default);

            // 毎フレームスライダーを監視
            seekValue.Value = slider.value;
            Observable.IntervalFrame(1)
                .Subscribe(_ => {
                    seekValue.Value = slider.value;
                })
                .AddTo(disposable);
        }

        void IPlayingMusicPresentation.SetTitle(string title) {
            trackLabel.text = title;
        }

        void IPlayingMusicPresentation.SetAlbumName(string albumName) {
            albumLabel.text = albumName;
        }

        void IPlayingMusicPresentation.SetArtistName(string artistName) {
            artistLabel.text = artistName;
        }

        void IPlayingMusicPresentation.SetArtwork(Sprite artwork) {
            artworkElm.style.backgroundImage = new StyleBackground(artwork.texture);
        }

        void IMusicControlPresentation.SetPlayState(MusicPlayState state) {
            playButton.text = state == MusicPlayState.Playing ? "pause" : "play";
        }

        void IMusicControlPresentation.SetTime(MusicTimeTuple musicTime) {
            var elapsed = TimeSpan.FromSeconds(musicTime.elapsedSeconds);
            var total = TimeSpan.FromSeconds(musicTime.totalSeconds);
            timeLabel.text = $"{elapsed:mm\\:ss}/{total:mm\\:ss}";
            if (musicTime.totalSeconds > 0.0F) {
                slider.value = musicTime.elapsedSeconds / musicTime.totalSeconds;
            }
        }

        IObservable<Unit> IMusicViewTrigger.OnListOpen => onListOpen;
        IObservable<Unit> IMusicViewTrigger.OnAuthorization => onAuthorization;
        IObservable<Unit> IMusicViewTrigger.OnPlay => onPlay;
        IObservable<Unit> IMusicViewTrigger.OnPrevious => onPrevious;
        IObservable<Unit> IMusicViewTrigger.OnNext => onNext;
        IReadOnlyReactiveProperty<float> IMusicViewTrigger.SeekValue => seekValue;
    }
}
