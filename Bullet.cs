using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingGame_kym
{
    internal class Bullet : Frame // 총알 충돌 판정 클래스
    {
        public static void MoveBullet()
        {
            if (isAttack == true)
            {
                bulletPos_L[0] -= 5; // 플레이어 총알 이동
                bulletPos_L[1] -= 1;
                bulletPos_R[0] -= 5;
                bulletPos_R[1] += 1;
                bulletPos[0] -= 5;
            }
            else
            {
                InitBullet();
            }
        }
        public static void MoveEnemyBullet()
        {
            enemyBulletPos[0] += 2; // 적 총알 이동
        }
        public static void CheckBullet()
        {
            if ((bulletPos_L[0] == enemyPos[0] && bulletPos_L[1] == enemyPos[1]) || // 만약 총이 적에게 맞는다면
            (bulletPos_R[0] == enemyPos[0] && bulletPos_R[1] == enemyPos[1]) ||
            (bulletPos[0] == enemyPos[0] && bulletPos[1] == enemyPos[1]))
            {
                ScoreLife.score += 100;  // 점수는 100점 증가
                Console.Beep(); // 사운드
                InitBullet(); // 총알 초기화
            }
            else if (bulletPos_L[0] <= 3 && bulletPos_R[0] <= 3) // 만약 시야를 벗어난다면
            {
                InitBullet();
            }
            else if ((enemyBulletPos[0] == bulletPos_L[0] && enemyBulletPos[1] == bulletPos_L[1]) ||
                    (enemyBulletPos[0] == bulletPos_R[0] && enemyBulletPos[1] == bulletPos_R[1]) ||
                    (enemyBulletPos[0] == bulletPos[0] && enemyBulletPos[1] == bulletPos[1]))// 적 총알 == 플레이어 총알 일 때
            {
                InitEnemyBullet();

                InitBullet();
            }
            if ((enemyBulletPos[0] == playerPos[0] + 1 && enemyBulletPos[1] == playerPos[1]) ||
                (enemyBulletPos[0] == playerWingPos_L[0] && enemyBulletPos[1] == playerWingPos_L[1]) ||
                (enemyBulletPos[0] == playerWingPos_L[0] && enemyBulletPos[1] == playerWingPos_R[1]))// 적 총알 == 플레이어 일때
            {
                InitEnemyBullet();
                if (ScoreLife.lifeCount > 0) ScoreLife.lifeCount -= 1;
            }
            else if (enemyBulletPos[0] >= 41) // 적 총알 시야 이탈
            {
                InitEnemyBullet();
            }
        }
        static void InitBullet() // 내 총알 초기화
        {
            pixel[bulletPos_L[0], bulletPos_L[1]] = '　';
            pixel[bulletPos_R[0], bulletPos_R[1]] = '　';
            pixel[bulletPos[0], bulletPos[1]] = '　';
            bulletPos_L[0] = playerPos[0] - 1; // 초기화
            bulletPos_L[1] = playerPos[1] - 1;
            bulletPos_R[0] = playerPos[0] - 1; // 초기화
            bulletPos_R[1] = playerPos[1] + 1;
            bulletPos[0] = playerPos[0] - 1;
            bulletPos[1] = playerPos[1];
        }
        static void InitEnemyBullet() // 적 총알 초기화
        {
            pixel[enemyBulletPos[0], enemyBulletPos[1]] = '　';
            enemyBulletPos[0] = enemyPos[0] + 1;
            enemyBulletPos[1] = enemyPos[1];
        }
    }
}
