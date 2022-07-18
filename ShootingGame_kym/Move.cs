using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingGame_kym
{
    internal class Move : Frame // 이동 관련 클래스
    {
        public static void MoveEnemy() // 적 이동
        {
            Random rand = new Random();
            int number = rand.Next(-1, 2); // -1, 0, 1 중 난수를 생성하고 적 위치에 합산한다.
            if (number == 0) // 0이 자주 나오는 경우를 대비해 0이나오면 한번 더 계산함
            {
                number = rand.Next(-1, 2);
            }
            if (enemyPos[1] >= 58) // 너무 오른쪽이나 왼쪽으로 붙지 않게 조정
            {
                enemyPos[1] -= 1;
            }
            else if (enemyPos[1] <= 1) // 벽에 붙으면 무조건 방향 변경
            {
                enemyPos[1] += 1;
            }
            else // 정상 범위라면 number만큼 좌 우 이동
            {
                enemyPos[1] += number;  // 프레임 호출될 때마다 적은 랜덤하게 좌우로 한칸씩 이동
            }
        }
        public static void MovePlayerLeft() // 플레이어 좌측 이동
        {
            playerPos[1] -= 1;
            playerBodyPos[1] -= 1;
            playerBody2Pos[1] -= 1;
            playerTailPos[1] -= 1;
            playerWingPos_L[1] -= 1;
            playerWingPos_R[1] -= 1;
        }
        public static void MovePlayerRight() // 플레이어 우측 이동
        {
            playerPos[1] += 1;
            playerBodyPos[1] += 1;
            playerBody2Pos[1] += 1;
            playerTailPos[1] += 1;
            playerWingPos_L[1] += 1;
            playerWingPos_R[1] += 1;
        }
        public static void CheckMap() // 맵 범위 체크
        {
            // 만약 적 또는 플레이어가 화면 사이즈 밖으로 벗어나게 된다면, 가장 자리에 위치를 Fix 시킴.
            if (enemyPos[1] <= 0) // 좌측 제한
            {
                enemyPos[1] = 0;
            }
            if (enemyPos[1] >= column - 1) // 우측 제한
            {
                enemyPos[1] = column - 1;
            }
            if (playerPos[1] <= 1) // 좌측 제한
            {
                playerPos[1] = 1;
                playerBodyPos[1] = 1;
                playerBody2Pos[1] = 1;
                playerTailPos[1] = 1;
                playerWingPos_L[1] = 0;
                playerWingPos_R[1] = 2;
            }
            if (playerPos[1] >= column - 2) // 우측 제한
            {
                playerPos[1] = column - 2;
                playerBodyPos[1] = column - 2;
                playerBody2Pos[1] = column - 2;
                playerTailPos[1] = column - 2;
                playerWingPos_L[1] = column - 3;
                playerWingPos_R[1] = column - 1;
            }
        }
    }
}
