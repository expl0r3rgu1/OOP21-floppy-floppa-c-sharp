using System.Windows.Forms;
using System.Timers;
using System;
using System.Collections.Generic;

namespace OOP21_floppy_floppa_c_sharp.CristinaZoccola
{
    class Character : Movable
    {
        public static bool immortal = false;
        private readonly Skin _skin;
        private bool _dead;
        private bool _jumping;
        private readonly Timer _timer;

        public Character(Position position, Skin skin) : base(position)
        {
            _skin = skin;
            _dead = false;
            _jumping = false;
            _timer = new Timer(500);
            _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        public bool IsDead() => _dead;

        public void Die() => _dead = immortal ? false : true;

        public static void SetImmortal() => immortal = true;

        public static void UnSetImmortal() => immortal = false;

        public Skin GetSkin() => _skin;

        public void Jump()
        {
            if (!_jumping)
            {
                _timer.Start();
                _jumping = true;
            }
            _timer.Start();
        }

        public void CollideFixedObstacle(List<FixedObstacle> fixedObstacleList)
        {
            int space_between_pipes = 300;
            foreach(FixedObstacle fixedObstacle in fixedObstacleList)
            {
                int characterX = GetPosition().GetX();
                int characterWiderX = characterX + _skin.GetWidth();
                int characterY = GetPosition().GetY();
                int characterLowerY = characterY + _skin.GetHeight();
                int obstacleX = fixedObstacle.GetPosition().GetX();
                int obstacleWiderX = obstacleX + fixedObstacle.GetSkin().GetWidth();
                int obstacleUpperY = fixedObstacle.GetPosition().GetY() + (int)space_between_pipes / 2;
                int obstacleLowerY = fixedObstacle.GetPosition().GetY() + (int)space_between_pipes / 2;

                if((characterY >= obstacleX && characterX <= obstacleWiderX) 
                    || (characterWiderX >= obstacleUpperY && characterLowerY <= obstacleWiderX))
                {
                    if((characterY >= obstacleUpperY || characterY <= obstacleLowerY) 
                        || (characterLowerY >= obstacleUpperY || characterLowerY <= obstacleLowerY))
                    {
                        Die();
                        break;
                    }
                }
            }
        }

        public void CollideMovingObstacle(List<MovingObstacle> movingObstacleList)
        {
            foreach(MovingObstacle movingObstacle in movingObstacleList)
            {
                int x = movingObstacle.GetPosition().GetX();
                int y = movingObstacle.GetPosition().GetY();
                int height = movingObstacle.GetSkin().GetHeight();
                int width = movingObstacle.GetSkin().GetWidth();

                if(CheckCollision(x, y, height, width))
                {
                    Die();
                    break;
                }
            }
        }

        public void CollideMalus(List<Malus> malusList)
        {
            foreach(Malus malus in malusList)
            {
                int x = malus.GetPosition().GetX();
                int y = malus.GetPosition().GetY();
                int height = malus.GetSkin().GetHeight();
                int width = malus.GetSkin().GetWidth();

                if (CheckCollision(x, y, height, width))
                {
                    malus.ChangeState();
                    break;
                }
            }
        }

        public void CollideBooster(List<Booster> boosterList)
        {
            foreach(Booster booster in boosterList)
            {
                int x = booster.GetPosition().GetX();
                int y = booster.GetPosition().GetY();
                int height = booster.GetSkin().GetHeight();
                int width = booster.GetSkin().GetWidth();

                if (CheckCollision(x, y, height, width))
                {
                    booster.ChangeState();
                    break;
                }
            }
        }

        public void CollideBorders()
        {
            int characterY = GetPosition().GetY();
            int characterLowerY = characterY + _skin.GetHeight();
            int upperBorder = 0;
            int lowerBorder = 1080;

            if (characterY <= upperBorder || characterLowerY >= lowerBorder)
            {
                Die();
            }
        }

        private bool CheckCollision(int x, int y, int height, int width)
        {
            int characterX = GetPosition().GetX();
            int characterWiderX = characterX + _skin.GetWidth();
            int characterY = GetPosition().GetY();
            int characterLowerY = characterY + _skin.GetHeight();
            int entityWiderX = x + width;
            int entityLowerY = y + height;

            if((characterX >= x && characterX <= entityWiderX) 
                || (characterWiderX >= x && characterWiderX <= entityWiderX))
            {
                if((characterY >= y && characterY <= entityLowerY) || (characterLowerY >= y && characterLowerY <= entityLowerY))
                {
                    return true;
                }
            }
            return false;
        }

        public override void Animate(RibbonElementPaintEventArgs ribbonPaintEventArgs)
        {
            throw new System.NotImplementedException();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            _jumping = false;
            _timer.Stop();
        }

    }
}
