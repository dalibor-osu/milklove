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
    public class Images : StoryboardObjectGeneratorExtended
    {
        private int[] changeTimes = { 51256, 53756, 56256, 58756, 61256, 63756, 66257, 68757, 69694 };
        
        public override void Generate()
        {
            var layer = GetLayer("images");
            var images = new OsbSprite[10];
            var beatDuration = Beatmap.GetTimingPointAt(Offset).BeatDuration;

            var bg = layer.CreateSprite("bg.png");
            bg.Scale(-2000, ScreenScale);
            bg.Fade(0, 0);
            bg.Fade(1256, 9694, 0, 1);
            bg.Fade(9694, changeTimes[0], 1, 1);
            
            double scale = ScreenScale * 1.1;
            int xOffset = 20;

            int i = 0;
            images[i] = layer.CreateSprite($"sb/ml{i}.jpg");
            images[i].Fade(changeTimes[i], changeTimes[i + 2], 1, 1);
            images[i].Scale(changeTimes[0], scale);
            images[i].MoveX(changeTimes[i], changeTimes[i + 2], ScreenMiddle.X - xOffset, ScreenMiddle.X + xOffset);
            i++;
            
            images[i] = layer.CreateSprite($"sb/ml{i}.jpg");
            images[i].Fade(changeTimes[i], changeTimes[i + 2], 1, 1);
            images[i].Scale(OsbEasing.Out, changeTimes[1], changeTimes[1] + beatDuration * 2, 0, scale);
            images[i].Rotate(OsbEasing.OutCubic, changeTimes[1], changeTimes[1] + beatDuration * 2, -DegToRad(180), 0);
            images[i].Scale(changeTimes[1], scale);
            images[i].MoveX(changeTimes[i], changeTimes[i + 2], ScreenMiddle.X + xOffset, ScreenMiddle.X - xOffset);
            i++;
            
            images[i] = layer.CreateSprite($"sb/ml{i}.jpg");
            images[i].Fade(changeTimes[i], changeTimes[i + 2], 1, 1);
            images[i].MoveY(OsbEasing.OutBounce, changeTimes[2], changeTimes[2] + beatDuration * 2, -240, 240);
            images[i].Scale(changeTimes[2], scale);
            images[i].MoveX(changeTimes[i], changeTimes[i + 2], ScreenMiddle.X - xOffset, ScreenMiddle.X + xOffset);
            i++;
            
            images[i] = layer.CreateSprite($"sb/ml{i}.jpg");
            images[i].Fade(changeTimes[i], changeTimes[i + 2], 1, 1);
            images[i].Scale(changeTimes[3], scale);
            images[i].MoveX(changeTimes[i], changeTimes[i + 2], ScreenMiddle.X + xOffset, ScreenMiddle.X - xOffset);
            i = 6;
            
            images[i] = layer.CreateSprite($"sb/ml{i}.jpg");
            images[i].Fade(changeTimes[5], changeTimes[7], 1, 1);
            images[i].MoveY(OsbEasing.Out, changeTimes[i], changeTimes[i] + beatDuration * 2, 240, 480 + 240);
            images[i].Scale(changeTimes[6], scale);
            images[i].MoveX(changeTimes[5], changeTimes[7], ScreenMiddle.X + xOffset, ScreenMiddle.X - xOffset);
            i = 4;
            
            images[i] = layer.CreateSprite($"sb/ml{i}.png", OsbOrigin.CentreRight);
            images[i].Fade(changeTimes[i], changeTimes[4] + beatDuration * 2, 1, 1);
            images[i].MoveY(OsbEasing.OutCubic, changeTimes[4], changeTimes[4] + beatDuration * 2, -240, 240);
            images[i].MoveX(OsbEasing.Out, changeTimes[5], changeTimes[5] + beatDuration * 2, 320, -107);
            images[i].Scale(changeTimes[4], scale);
            images[i].MoveX(changeTimes[4], changeTimes[5], ScreenMiddle.X - xOffset / 2, ScreenMiddle.X + xOffset / 2);
            i = 5;
            
            images[i] = layer.CreateSprite($"sb/ml{i}.png", OsbOrigin.CentreLeft);
            images[i].Fade(changeTimes[4], changeTimes[4] + beatDuration * 2, 1, 1);
            images[i].MoveY(OsbEasing.OutCubic, changeTimes[4], changeTimes[4] + beatDuration * 2, 480 + 240, 240);
            images[i].MoveX(OsbEasing.Out, changeTimes[5], changeTimes[5] + beatDuration * 2, 320,  640 + 107);
            images[i].Scale(changeTimes[5], scale);
            images[i].MoveX(changeTimes[4], changeTimes[5], ScreenMiddle.X - xOffset / 2, ScreenMiddle.X + xOffset / 2);

            i = 7;
            images[i] = layer.CreateSprite($"sb/ml{i}.jpg");
            images[i].Fade(changeTimes[i - 1], changeTimes[i + 1], 1, 1);
            images[i].MoveY(OsbEasing.Out, changeTimes[i - 1], changeTimes[i - 1] + beatDuration * 2,  -240, 240);
            images[i].Scale(changeTimes[i - 1], scale);
            images[i].Scale(68444, 69694, scale, scale * 1.2);
            images[i].Rotate(68444, 69694, 0, DegToRad(5));
            images[i].MoveX(changeTimes[i - 1], changeTimes[i + 1], ScreenMiddle.X - xOffset, ScreenMiddle.X + xOffset);
            
            i = 8;
            images[i] = layer.CreateSprite($"sb/ml{i}.jpg");
            images[i].Scale(71257, ScreenScale);
            images[i].Fade(71257, 73757, 1, 1);
            images[i].Fade(73757, 76257, 1, 0);
            images[i].Scale(71257, 76257, ScreenScale, ScreenScale * 1.2);
            images[i].Rotate(71257, 76257, 0, DegToRad(10));
        }
    }
}
