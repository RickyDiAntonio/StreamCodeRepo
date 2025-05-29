﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_3_and_final.Abilities
{
    public static class AbilityFactory
    {
        // public Ability(string name, string text,int base damage,int reqLevel,int manaCost =0,params EffectTypes[] extraEffects)
        public static Ability CreateAbility(AbilityNames abilityName,string? customText =null)
        {
            return abilityName switch
            {
                //basic /weapon abilities
                AbilityNames.basicAttack => new Ability("Basic Attack",  
                customText??" performs a basic attack",
                1, 0,1.0f,0, new[] { EffectTypes.damage,EffectTypes.physical }),

                //Sorcery
                AbilityNames.healingSurge => new Ability("Healing Surge"," channels healing energies",1,1,1.0f,50, new[] { EffectTypes.heal }),
                AbilityNames.stormbolt => new Ability("Storm Bolt", " hurls a bolt of arcane energy",2, 2, 1.0f,25, new[] { EffectTypes.damage,EffectTypes.magic }),                
                AbilityNames.flameMark=> new Ability("Flame Mark"," sears a flaming rune on the enemy",2, 1,.5f,25, new[] { EffectTypes.damage, EffectTypes.magic, EffectTypes.DoT }),                
                AbilityNames.sphereOfProtection=> new Ability("Sphere of Protection", " is encased in a shimmering bubble",1,2,1.0f, 50, new[] {EffectTypes.magic, EffectTypes.shield }),
                //Might

                //finesse

                //monsterspecials
                AbilityNames.rend => new Ability("Rend", " rips flesh with its sharp teeth", 2, 0, 1.0f, 0, new[] {EffectTypes.physical,EffectTypes.DoT,EffectTypes.statChangeSpeed}),

                _ => throw new ArgumentOutOfRangeException(nameof(abilityName), $"Unknown ability: {abilityName}")

            };
        }
        public static Ability CreateAbilityEffect(Ability baseAbility,IActor caster)
        {
            if(baseAbility==null)throw new ArgumentNullException(nameof(baseAbility));
            // public Ability( name,  text , base damage, reqLevel, manaCost =0, EffectTypes[] extraEffects)
            
            int newDamage = 0;
            if (baseAbility.Effects.Contains(EffectTypes.magic))
            {
                newDamage = baseAbility.baseDamage;//will need to add the base attack modifier

            }
            if (baseAbility.Effects.Contains(EffectTypes.physical))
            {
                newDamage = baseAbility.baseDamage ;//will need to add the base attack modifier
            }
                         

            Ability effectAbility=  new Ability(baseAbility.name, baseAbility.text, newDamage, 0,baseAbility.scalingMultiplier, 0, baseAbility.Effects);
            return effectAbility;
               
        }
    }
}
