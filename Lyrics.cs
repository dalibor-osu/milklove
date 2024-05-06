using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class Lyrics : StoryboardObjectGeneratorExtended
    {
        private int[] lyricsTimes =
        { 
            9694,
            14694,
            19694,
            24694,
            29694,
            34694,
            39694,
            45944,
            49694,
            54694,
            60006,
            65944,
            69694,
            71257
        };

        private int[] backgroundLengths =
        { 
            355,
            460,
            370,
            375,
            420,
            495,
            495,
            295,
            560,
            515,
            360,
            360,
            170,
        };

        private double lyricsScale = ScreenScale * 0.4;
        private int fadeTime = 500;
        private int lineYOffset = 50;
        private int lineXMove = 50;

        private int initXPosition = -20;

        public override void Generate()
        {
		    var lyrics = new List<OsbSprite>();
            var lyricsBackground = new List<OsbSprite>();
            var layer = GetLayer("lyrics");
            double beatDuration = GetBeatDuration(Beatmap, Offset);

            for (int i = 0; i < 13; i++)
            {
                var sprite = layer.CreateSprite("sb/white.png", OsbOrigin.TopLeft);
                lyricsBackground.Add(sprite);
            }

            for (int i = 0; i < 13; i++)
            {
                var sprite = layer.CreateSprite("sb/lyrics/" + i + ".png", OsbOrigin.TopLeft);
                lyrics.Add(sprite);
            }

            int endTime = 0;
            int yPosition = 100;

            for (int i = 0; i < lyrics.Count; i++)
            {
                bool isEven = i % 2 == 0;
                
                if (isEven && i + 2 < lyrics.Count) {
                    endTime = lyricsTimes[i + 2] - fadeTime * 2;
                }

                if (isEven) {
                    yPosition = yPosition == 30 ? 400 - yPosition : 30;
                }

                var line = new Line {
                    Sprite = lyrics[i],
                    Background = lyricsBackground[i],
                    BackgroundLength = backgroundLengths[i],
                    StartTime = lyricsTimes[i],
                    EndTime = endTime,
                    Handle = GetLineHandle(i),
                    StartPosition = new Vector2(initXPosition + (isEven ? 0 : lineXMove), yPosition + i % 2 * lineYOffset),
                    EndPosition = new Vector2(initXPosition + (isEven ? lineXMove : lineXMove / 2) + (isEven ? 0 : lineXMove), yPosition + (isEven ? 0 : lineYOffset)),
                    Color = i < 8 ? Color4.White : Color4.DeepPink
                };

                line.HandleLine();
            }
        }

        private Action<Line> GetLineHandle(int index) {
            switch(index) {
                case 12:
                    return HandleLastLine;
                default:
                    return HandleLine;
            }
        }

        private void HandleLine(Line line)
        {
            // Scale
            line.Sprite.Scale(line.StartTime, lyricsScale);

            // Fade
            line.Sprite.Fade(line.StartTime - fadeTime, line.StartTime, 0, 1);
            line.Sprite.Fade(line.StartTime, line.EndTime, 1, 1);
            line.Sprite.Fade(line.EndTime, line.EndTime + fadeTime, 1, 0);

            // Position
            line.Sprite.Move(line.StartTime - fadeTime, line.EndTime + fadeTime, line.StartPosition, line.EndPosition);

            // Color
            line.Sprite.Color(line.StartTime, line.Color);

            GenerateLineBackground(line);
        }

        private void HandleLastLine(Line line) {
            line.StartPosition = new Vector2(ScreenMiddle.X - 120, ScreenMiddle.Y - 20);
            line.EndPosition = line.StartPosition;
            line.StartTime = 69694;
            line.EndTime = 73757;
            line.StartPosition = new Vector2(line.StartPosition.X + lineXMove * 0.75f, line.StartPosition.Y);

            // Scale
            line.Sprite.Scale(line.StartTime, lyricsScale);

            // Fade
            line.Sprite.Fade(line.StartTime - fadeTime, line.StartTime, 0, 1);
            line.Sprite.Fade(line.StartTime, line.EndTime, 1, 1);
            line.Sprite.Fade(line.EndTime, line.EndTime + fadeTime, 1, 0);

            // Position
            line.Sprite.Move(line.StartTime, line.StartPosition);

            // Color
            line.Sprite.Color(line.StartTime, line.Color);

            int height = 20;
            double duration = GetBeatDuration(Beatmap, Offset) * 4;
            double startTime = line.StartTime + fadeTime;

            Vector2 offset = new Vector2(-10, 15);

            line.Background.ScaleVec(OsbEasing.OutCubic , startTime - fadeTime, startTime + duration, 0, height, line.BackgroundLength, height);

            line.Background.Fade(startTime - fadeTime, startTime, 0, 1);
            line.Background.Fade(startTime, line.EndTime, 1, 1);
            line.Background.Fade(line.EndTime, line.EndTime + fadeTime, 1, 0);

            line.Background.Move(startTime - fadeTime, line.StartPosition + offset);

            line.Background.Color(startTime - fadeTime, line.Color == Color4.DeepPink ? Color4.White : Color4.DeepPink);
        }

        private void GenerateLineBackground(Line line, OsbOrigin? origin = null) {
            int height = 20;
            double duration = GetBeatDuration(Beatmap, Offset) * 4;
            double startTime = line.StartTime + fadeTime;

            if (origin != null) {
                line.Background.Origin = origin.Value;
            }

            Vector2 offset = new Vector2(-10, 15);

            line.Background.ScaleVec(OsbEasing.OutCubic , startTime - fadeTime, startTime + duration, 0, height, line.BackgroundLength, height);

            line.Background.Fade(startTime - fadeTime, startTime, 0, 1);
            line.Background.Fade(startTime, line.EndTime, 1, 1);
            line.Background.Fade(line.EndTime, line.EndTime + fadeTime, 1, 0);

            line.Background.Move(startTime - fadeTime, line.EndTime + fadeTime, line.StartPosition + offset, line.EndPosition + offset);

            line.Background.Color(startTime - fadeTime, line.Color == Color4.DeepPink ? Color4.White : Color4.DeepPink);
        }

        private class Line {
            public OsbSprite Sprite;
            public OsbSprite Background;
            public int BackgroundLength;
            public int StartTime;
            public int EndTime;
            public Action<Line> Handle;
            public Vector2 StartPosition;
            public Vector2 EndPosition;
            public Color4 Color;

            public void HandleLine()
            {
                Handle(this);
            }
        }
    }
}
