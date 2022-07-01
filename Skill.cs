using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingGame_kym
{
    internal class Skill : Frame
    {
        public static void MoveSkill()
        {
            if(isSkill == true)
            {
                skillPos_Lpoint[0] -= 1;
                skillPos_Rpoint[0] -= 1;
                skillPos_Top[0] -= 1;
            }
            else
            {
                InitSkill();
            }
        }
        public static void CheckSkill()
        {
            // 스킬이 화면 벗어나면
            // 스킬이 충돌하면
            // 초기화
        }
        public static void InitSkill()
        {
            skillPos_Lpoint[0] = playerPos[0] - 1;
            skillPos_Lpoint[1] = playerPos[0] - 4;
            skillPos_Rpoint[0] = playerPos[0] - 1;
            skillPos_Top[0] = playerPos[0] - 5;
            skillPos_Top[1] = playerPos[0];
        }
    }
}
