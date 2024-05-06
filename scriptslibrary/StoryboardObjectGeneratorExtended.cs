using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public abstract class StoryboardObjectGeneratorExtended : StoryboardObjectGenerator
    {
        protected static int Width = 1980;
        protected static int Height = 1020; //1,574074
        protected static double ScreenScale = 480.0 / Height;
        protected static int Offset = 632;
        protected static double GetBeatDuration(Beatmap beatmap, int offset) => beatmap.GetTimingPointAt(offset).BeatDuration;
        protected static double GetHalfBeatDuration(Beatmap beatmap, int offset) => beatmap.GetTimingPointAt(offset).BeatDuration / 2;
        protected static double GetQuarterBeatDuration(Beatmap beatmap, int offset) => beatmap.GetTimingPointAt(offset).BeatDuration / 4;
        protected static Vector2 MinimumDimensions = new Vector2(-107, 0);
        protected static Vector2 MaximumDimensions = new Vector2(747, 480);
        protected static Vector2 ScreenMiddle = new Vector2(320, 240);
        protected static double DegToRad(double degrees) => degrees * 0.0174532925;
    }
}