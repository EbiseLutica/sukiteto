﻿using System.Drawing;
using Promete;
using Promete.Elements;
using Promete.Graphics;

namespace Sukiteto;

public class EffectedText(
    string text,
    float fontSize,
    FontStyle fontStyle,
    Color? color)
    : Text(text, Font.GetDefault(fontSize, fontStyle), color)
{
    public EffectType Effect { get; set; }
    public float EffectTime { get; set; }

    private float timer;

    protected override void OnUpdate()
    {
        // TODO deltaTimeをなんとかして取得する
        var deltaTime = (1 / 60f);
        timer += deltaTime;
        
        if (timer > EffectTime)
        {
            // TODO Destroy() で消えるようにPrometeを改良する
            (Parent as Container)?.Remove(this);
            Destroy();
            return;
        }

        var time = timer / EffectTime;
        
        switch (Effect)
        {
            case EffectType.SlideUp:
                Location += Vector.Up * (12 * deltaTime);
                break;
            case EffectType.ScaleUp:
                Scale *= 1.4f * deltaTime;
                break;
        }

        if (time > 0.5f)
        {
            var a = (int)(((1 - time) * 2) * 255);
            var c = Color ?? System.Drawing.Color.White;
            Color = System.Drawing.Color.FromArgb(a, c.R, c.G, c.B);
        }
    }

    public enum EffectType
    {
        SlideUp,
        ScaleUp,
    }
}