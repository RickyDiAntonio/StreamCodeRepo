using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_3_and_final.Monsters
{
    public class MonsterFactory
    {
        
        public  Monster CreateMonster(MonsterTypes type)
        {
            return type switch
            {
                MonsterTypes.goblin => new Goblin(),
                MonsterTypes.wolf => new Wolf(),
                _=> throw new ArgumentOutOfRangeException(nameof(type),$"Unknown monster type: {type}")
            };
        }
    }
}
