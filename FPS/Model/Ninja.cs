using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.Model
{
    class Ninja
    {
        Vector2 position;
        float timer = 0;
       public float sizeOf;
        public float NinjaHP = 100;
        Vector2 ninjamove= new Vector2(200, -2);
        Random random;
        Player playercondition;
        public bool miniBossDeath = false;
        public Ninja(Player player)
        {
            random = new Random();
            playercondition = player;
        }
        public void NinjaTeleportation(float time)
        {
            if (!miniBossDeath)
            {
                timer += time;
                position += ninjamove * time;
                if (timer > 0.6f)
                {
                    position = new Vector2(random.Next(1, 600), random.Next(0, 300));
                    sizeOf = random.Next(60, 500);
                    playercondition.Health -= 1;
                    timer = 0;
                }
                if(NinjaHP <= 0)
                {
                    miniBossDeath = true;
                }
            }
            else
            {
                miniBossDeath = true;
            }
        }
        public Vector2 returnNewPosition
        {
            get
            {
                return new Vector2(position.X,position.Y);
            }
        }
        public Rectangle returnEverything
        {
            get
            {
                return new Rectangle((int)position.X,(int) position.Y, (int)sizeOf, (int)sizeOf);
            }
        }
        // vill ha Override över virtual men det fungerar ej, måste göra många saker innan det går att fungera// blir väl så att jag implementera vid senare implementation. Update// ska inte instansiera klassen, då kan jag overrida
        
        public void getHit(float coordX, float coordY, float damage)
        { 
            
            Vector2 MonsterlogicMouse = new Vector2(coordX, coordY);

            bool containCoord = returnEverything.Contains(MonsterlogicMouse.X, MonsterlogicMouse.Y);

            if(containCoord && !miniBossDeath)
            {
                NinjaHP -= damage;

                if(sizeOf>200)   
                {
                    NinjaHP -= damage * 3;
                }
            } 
            }

        }

     
    }

