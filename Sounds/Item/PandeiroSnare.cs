using Microsoft.Xna.Framework.Audio;
using Terraria.ModLoader;
using Terraria;
using System;

namespace BahiaMod.Sounds.Item
{
    class PandeiroSnare : ModSound
    {
        public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
        {
            soundInstance = sound.CreateInstance();
            soundInstance.Volume = volume * .7f;
            soundInstance.Pan = pan;
            soundInstance.Pitch = 0f;
            return soundInstance;
        }
    }
}