using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part_3_and_final.Monsters;

namespace Part_3_and_final
{
    public interface IActor
    {
        void DisplayHP();
        void SetHP(int value);
        void TakeEffectType(EffectTypes effectType,int amount);
        void TakeDamage(int amount);
        void TurnStart();
        void TakeTurn(Player player,List<Monster> monsters);
        Vitals GetVitals();
        bool isAlive();
        string GetName();


    }
}
