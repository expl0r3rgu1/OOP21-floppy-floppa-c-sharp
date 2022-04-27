﻿using System.Windows.Forms;
using System.Timers;
using System.Collections.Generic;
using System.Drawing;
using Utilities;
//using namespace of FixedObstacle
//using namespace of MovingObstacle
//using namespace of Malus
//using namespace of Booster

namespace Character
{
    /// <summary>
    /// A class that implements the character, it keeps track of its current status
    /// (if it is dead or alive), it updates its position making it go lower due to
    /// gravity or upper when performing a jump and it checks its collision with the
    /// various entities on the map and with the borders of the map, this class extends the class Movable
    /// </summary>
    class Character : Movable
    {
        /// <summary>
        /// if it is true the character is immune from death, its default value is false
        /// </summary>
        public static bool Immortal = false;
        private readonly Skin skin;
        private bool dead;
        private bool jumping;
        private readonly Timer timer;

        /// <param name="position">the initial spawning position of the character</param>
        /// <param name="skin">the skin of the character</param>
        public Character(Position position, Skin skin) : base(position)
        {
            this.skin = skin;
            dead = false;
            jumping = false;
            timer = new Timer(500);
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        /// <returns>true if the character is dead</returns>
        public bool IsDead() => dead;

        /// <summary>
        /// Makes the status of the character as dead
        /// </summary>
        public void Die() => dead = Immortal ? false : true;

        /// <summary>
        /// Method to make the character immortal
        /// </summary>
        public static void SetImmortal() => Immortal = true;

        /// <summary>
        /// Method to make the character to its normal state
        /// </summary>
        public static void UnSetImmortal() => Immortal = false;

        /// <summary>
        /// Getter of the character skin
        /// </summary>
        /// <returns>the character skin</returns>
        public Skin GetSkin() => skin;

        /// <summary>
        /// Makes the character jump
        /// </summary>
        public void Jump()
        {
            if (!jumping)
            {
                timer.Start();
                jumping = true;
            }
            timer.Start();
        }

        /// <summary>
        /// Checks if the character collides with a fixed obstacle, if it happens it will
        /// change the character status to dead
        /// </summary>
        /// <param name="fixedObstacleList">a list of the fixed obstacles that the character could collide</param>
        public void CollideFixedObstacle(List<FixedObstacle> fixedObstacleList)
        {
            int space_between_pipes = 300;
            foreach(FixedObstacle fixedObstacle in fixedObstacleList)
            {
                int characterX = GetPosition().GetX();
                int characterWiderX = characterX + skin.GetWidth();
                int characterY = GetPosition().GetY();
                int characterLowerY = characterY + skin.GetHeight();
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

        /// <summary>
        /// Checks if the character collides with a fixed obstacle, if it happens it will
        /// change the character status to dead
        /// </summary>
        /// <param name="movingObstacleList">a list of the moving obstacles that the character could collide</param>
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

        /// <summary>
        /// Checks if the character collides with a malus, if it happens it will apply
        /// the effects of that malus
        /// </summary>
        /// <param name="malusList">a list of the maluses that the character could collide</param>
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

        /// <summary>
        /// Checks if the character collides with a booster, if it happens it will apply 
        /// the effects of that booster
        /// </summary>
        /// <param name="boosterList">a list of the boosters that the character could collide</param>
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

        /// <summary>
        /// Checks if the character collides with the borders of the map
        /// </summary>
        public void CollideBorders()
        {
            int characterY = GetPosition().GetY();
            int characterLowerY = characterY + skin.GetHeight();
            int upperBorder = 0;
            int lowerBorder = 1080;

            if (characterY <= upperBorder || characterLowerY >= lowerBorder)
            {
                Die();
            }
        }

        /// <summary>
        /// Private method to check if the character collides with a moving item
        /// </summary>
        /// <param name="x">the x coordinate of the entity</param>
        /// <param name="y">the y coordinate of the entity</param>
        /// <param name="height">the height of the entity</param>
        /// <param name="width">the width of the entity</param>
        /// <returns>true if the character collides with an entity</returns>
        private bool CheckCollision(int x, int y, int height, int width)
        {
            int characterX = GetPosition().GetX();
            int characterWiderX = characterX + skin.GetWidth();
            int characterY = GetPosition().GetY();
            int characterLowerY = characterY + skin.GetHeight();
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

        /// <inheritdoc />
        public override void Animate(RibbonElementPaintEventArgs ribbonElementPaintEventArgs)
        {
            int x = GetPosition().GetX();
            int y = GetPosition().GetY();
            int width = skin.GetWidth();
            int height = skin.GetHeight();
            Image image = skin.GetImage();

            ribbonElementPaintEventArgs.Graphics.DrawImage(image, x, y, width, height);

            UpdatePosition();
        }

        /// <summary>
        /// Private method to update the position of the character
        /// </summary>
        private void UpdatePosition()
        {
            int movingFactor = 2;
            int value = jumping ? -2 : 1;
            GetPosition().SetY(GetPosition().GetY() + value * movingFactor);
        }

        /// <summary>
        /// What happens when the character finish his jump
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            jumping = false;
            timer.Stop();
        }

    }
}
