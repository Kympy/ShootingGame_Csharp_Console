using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingGame_kym
{
    internal class Position : MainGame
    {
        // Player
        public static int[] playerPos = { 38, 28 }; // 플레이어 현 위치
        public static int[] playerBodyPos = { playerPos[0] + 1, playerPos[1] };
        public static int[] playerBody2Pos = { playerPos[0] + 2, playerPos[1] };
        public static int[] playerTailPos = { playerPos[0] + 3, playerPos[1] };
        public static int[] playerWingPos_L = { playerBodyPos[0], playerPos[1] - 1 };
        public static int[] playerWingPos_R = { playerBodyPos[0], playerPos[1] + 1 };

        // Bullet
        public static int[] bulletPos_L = { playerPos[0] - 1, playerPos[1] - 1 }; // 왼쪽 총알의 현 위치
        public static int[] bulletPos_R = { playerPos[0] - 1, playerPos[1] + 1 }; // 오른쪽 총알의 현 위치
        public static int[] bulletPos = { playerPos[0] - 1, playerPos[1] }; // 중앙 총알의 현 위치

        //Enemy
        public static int[] enemyPos = { 2, 28 }; // 적의 현 위치
        public static int[] enemyBulletPos = { enemyPos[0] + 1, enemyPos[1] }; // 적 총알 위치

        // Skill
        
        //public static int[] skillPos = { playerPos[0] - 1, playerPos[0] };
        public static int[] skillPos_Lpoint = { playerPos[0] - 1, playerPos[0] - 4 };
        public static int[] skillPos_Rpoint = { playerPos[0] - 1, playerPos[0] + 4 };
        public static int[] skillPos_Top = { playerPos[0] - 5, playerPos[0] };
    }
}
