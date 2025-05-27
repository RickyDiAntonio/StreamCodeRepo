using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_3_and_final.Abilities
{
    public static class AbilityFactory
    {
        // public Ability(string name, string text,int reqLevel,int manaCost =0,params EffectTypes[] extraEffects)
        public static Ability CreateAbility(AbilityNames abilityName)
        {
            return abilityName switch
            {
                //basic /weapon abilities
                AbilityNames.basicAttack => new Ability("Basic Attack",  " performs a basic attack", 0,0, new[] { EffectTypes.damage }),

                //Sorcery
                AbilityNames.healingSurge => new Ability("Healing Surge"," channels healing energies",1,50, new[] { EffectTypes.heal }),
                AbilityNames.stormbolt => new Ability("Storm Bolt", " hurls a bolt of arcane energy", 1,25, new[] { EffectTypes.damage,EffectTypes.DoT }),                
                AbilityNames.flameMark=> new Ability("Flame Mark"," sears a flaming rune on the enemy",1,25, new[] { EffectTypes.damage }),
                
                AbilityNames.sphereOfProtection=> new Ability("Sphere of Protection", " is encased in a shimmering bubble",2,50, new[] { EffectTypes.shield }),
                //Might

                //finesse

                //effects dot

                _ => throw new ArgumentOutOfRangeException(nameof(abilityName), $"Unknown ability: {abilityName}")

            };
        }
        public static Ability CreateAbilityEffect(AbilityNames abilityName)
        {
            return abilityName switch
            {
                //basic /weapon abilities
              
                //Might

                //finesse

                //effects dot

                _ => throw new ArgumentOutOfRangeException(nameof(abilityName), $"Unknown ability: {abilityName}")

            };
        }
    }
}
