using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_3_and_final
{
    public interface IActor
    {
      string Name { get; }
        void DisplayHP();
        void SetHP(int value);

        void BaseAttack(IActor attacker,IActor target);
      
        void TakeTurn(IActor attacker, IActor target);
        void TakeDamage(int amount);

        //void StatDump();


    }
}
