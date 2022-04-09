﻿using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Objects.Decorations
{
    using CSE3902_CSE3902_Project;
    using CSE3902_CSE3902_Project.Objects.Player;
    using CSE3902_CSE3902_Project.Sprites;
    using CSE3902_Project.Collisions;
    using CSE3902_Project.Objects.Decorations;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Text;
        public class Coin : ICollideable, ISprite
        {
            private Game1 game;
            public Portal otherPortal;
            public Vector2 position;
            private Rectangle sources;
            private Rectangle sourceRec;
            private int row;
            private int colomn;
            private Rectangle destinationRec;
            private Texture2D texture;
            private int sourceIndex;
            private Vector2 timer;
            public Rectangle collider2D;
            public ICollisionHandler collisionHandler;
            public Vector2 switchTimer;
            public bool cooldown;
            private int speed;
            public Coin(Vector2 position, Game1 game)
            {
                this.game = game;
                this.position = position;
                sources = SpriteConstants.COIN;
                destinationRec = new Rectangle((int)position.X, (int)position.Y, 24, 24);
                texture = DecorationTextureStorage.Instance.getCoinSprite();
                sourceIndex = 0;
                collider2D = new Rectangle((int)position.X + 3, (int)position.Y + 3, 20, 20);
                speed = 3;
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(texture, destinationRec, sourceRec, Color.White);
            }

            public void Update()
            {
                sourceIndex = (sourceIndex + 1)% (12*speed);
                sourceRec = new Rectangle(16 * (int)(sourceIndex/speed), 0 , 16, 16);
                
            }

            public void UpdateCollider()
            {
            }
            public Rectangle GetCollider2D()
            {
                return collider2D;
            }
            public void Collected()
        {
            List<Coin> newCoinList = new List<Coin>();
            List<Vector2> newCoinPos = new List<Vector2>();
            foreach (Coin c in game.currentMap.coinList)
            {
                if (c.position != position)
                {
                    newCoinList.Add(c);
                    newCoinPos.Add(c.position);
                }
                
            }
            game.currentMap.coinPosList = newCoinPos;
            game.currentMap.coinList = newCoinList;
        }
        }
    

}
