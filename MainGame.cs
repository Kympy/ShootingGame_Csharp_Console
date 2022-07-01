using System;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Threading.Tasks;

namespace ShootingGame_kym // MainGame 을 상속 받는 Frame을 중심으로 나머지 클래스들이 Frame을 상속받아 진행됨
{
    public class MainGame // 메인 클래스
    {
        const int waitTick = 1000 / 60; // 60 프레임(10FPS)

        static void Main(string[] args)
        {
            int lastTick = 0; // 마지막 틱
            int currentTick; // 현재 틱
            Init.InitLobby();
            while(true)
            {
                if(Init.Start() == true)
                {
                    break;
                }
            }
            Init.InitWindow(); // 윈도우 창 초기화
            while (true)// 반복
            {
                currentTick = System.Environment.TickCount; // 현재 시간
                if (currentTick - lastTick < waitTick) continue; // 경과 시간이 1 / 60 초 보다 작다면 실행 건너뜀
                else // 조건 만족 시
                {
                    lastTick = currentTick;
                    if (ScoreLife.lifeCount == 0) // 목숨이 0 이면
                    {
                        Init.EndGame(); // 종료 화면
                        continue;
                    }
                    KeyInput.CheckKey();// 키 입력 확인
                    Frame.DrawFrame(Frame.isAttack); // 프레임 렌더링
                    Bullet.CheckBullet(); // 총알 충돌 체크
                }
            }
        }
    }
}
