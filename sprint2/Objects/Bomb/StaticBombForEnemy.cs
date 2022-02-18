using CSE3902_Sprint2;
using CSE3902_Sprint2.Objects.Items;
using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Objects.NPC;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint2.Objects.Bomb
{
    class StaticBombForEnemy : ISprite
    {
        public Texture2D Texture { get; set; }
        private Enemy enemy;
        
        public int radius;
        public StaticBombForEnemy(Texture2D texture, Enemy enemy)
        {
            this.Texture = texture;
            this.enemy = enemy;
            radius = enemy.potionCount;
            
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            //destination.X = player.xPos;
            //destination.Y = player.yPos;
            Rectangle sourcerectangle = new Rectangle(0, 0, 1340, 1340);
            Rectangle destinationrectangle = new Rectangle((int)destination.X, (int)destination.Y, 50, 50);

            //float scale = .5f; //50% smaller

            Texture = ItemTextureStorage.Instance.getBombObjectSprite();
            float rotation = .0f;
            spriteBatch.Draw(Texture, destinationrectangle, sourcerectangle, Color.White, rotation, new Vector2(100, 50), SpriteEffects.None, 0f);
            //spriteBatch.Draw(Texture, destinationrectangle, sourcerectangle, Color.White);
        }

        public void Update()
        {
        }

        public void Explode(SpriteBatch spriteBatch, List<Rectangle> bombrange)
        {
            Texture2D explosionTexture = ItemTextureStorage.Instance.getExplosionSprite();
            Rectangle sourceRec = SpriteConstants.EXPLOSION;
    
            radius = enemy.potionCount;
            // explosion origin

            // temporary hard coded explosion radius of 3
            
                foreach (Rectangle rec in bombrange) {
                    spriteBatch.Draw(explosionTexture, rec, sourceRec, Color.White);
                }
            
            }
            
        }
            
    }

