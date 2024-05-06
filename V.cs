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
    public class V : StoryboardObjectGeneratorExtended
    {
        public override void Generate()
        {
            var layer = GetLayer("vig");
            var sprite = layer.CreateSprite("sb/v.png", OsbOrigin.Centre);
            
            sprite.Scale(-2000, ScreenScale);
            sprite.Fade(-2000, 0.6);
            sprite.Fade(78684, 1);
        }
    }
}
