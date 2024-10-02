using UnityEngine;
using Quantum;

public class TeamAsset : AssetObject {

    public byte id;
    public string nameTranslationKey;
    public string textSpriteNormal, textSpriteColorblind, textSpriteColorblindBig;

    [ColorUsage(false)] public Color color;
    public Sprite spriteNormal, spriteColorblind;

}