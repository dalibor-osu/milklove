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
    public class Flash : StoryboardObjectGeneratorExtended
    {
        private int[] flashTimes = { 51256, 53756, 56256, 58756, 61256, 63756, 66257 };
        
        public override void Generate()
        {
            double flashDuration = GetBeatDuration(Beatmap, Offset);
		    var layer = GetLayer("flash");
            var sprite = layer.CreateSprite("sb/white.png", OsbOrigin.Centre);
            
            sprite.ScaleVec(0, Width * ScreenScale, Height * ScreenScale);
            sprite.Fade(0, 0);
            
            sprite.Fade(48756, flashTimes[0], 0, 1);
            
            foreach (var flashTime in flashTimes)
            {
                sprite.Fade(flashTime, flashTime + flashDuration, 1, 0);
            }
            
            sprite.Fade(68444, 69694, 0, 1);
            sprite.Fade(69694, 71257, 1, 1);
            sprite.Fade(71257, 71257 + flashDuration, 1, 0);
        }
    }
}
