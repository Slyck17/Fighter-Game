// Code Edit
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FightingGame
{
    class Fighter
    {
        public string name;
        public Texture2D[] movementAnimations;
        public int health;
        //public Move[] moveset;
        Vector2 speed;
        Vector2 velocity;
        bool canJump;
        public Rectangle rect;
        //hitboxes+hurtboxes
        //armor? maybe later

        public Fighter(string n, /*Texture2D[] a,*/ int h, /*Move[] m,*/ Rectangle r)
        {
            name = n;
            //movementAnimations = a;
            health = h;
            //moveset = m;
            speed = new Vector2(10, -15);
            velocity = new Vector2(0, 0);
            rect = r;
            canJump = true;
         }
        public void Update(GamePadState GPState, int screenHeight)
        {
            Input(GPState);
            rect.X += (int)velocity.X;
            rect.Y += (int)velocity.Y;
            if (!canJump)
                velocity.Y += .50f;
            if (rect.Bottom >= screenHeight)
            {
                canJump = true;
                velocity.Y = 0;
            }

        }
        public void Input(GamePadState GPState)
        {
            if (GPState.ThumbSticks.Left.X != 0)
                velocity.X = GPState.ThumbSticks.Left.X * speed.X;
            else
                velocity.X = 0;
            if(GPState.ThumbSticks.Left.Y >= 0.5 && canJump)
            {
                canJump = false;
                velocity.Y = speed.Y;
            }
           // if (GPState.ThumbSticks.Left.Y <= -0.5 && canJump)
            //{
              //  canJump = false;
                //velocity.Y = 0;
            //}
        }
    }
         
         
}

