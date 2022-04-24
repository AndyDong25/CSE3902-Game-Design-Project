using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3
{
    public class Camera
    {
        public float Zoom = 1;
        public Vector2 Position = new Vector2(0, 0);
        public Vector2 direction;
        public float Rotation = 0;
        public Vector2 Origin = new Vector2(0,0);
        private float zoom;
        private float rotate;
        private Vector2 pos;
        private Vector2 ori;
        
        public Camera()
        {
            zoom = Zoom;
            rotate = Rotation;
            ori = Origin;
            pos = Position;
        }

        public void Move(Vector2 direction)
        {
            this.direction = direction;
            float xSide = 400 / Zoom;
            float ySize = 300 / Zoom;
            if (direction.X < xSide)
            {
                direction.X = xSide;
            }
            if (direction.X > (800-xSide))
            {
                direction.X = 800-xSide;
            }
            if (direction.Y < ySize)
            {
                direction.Y = ySize;
            }
            if (direction.Y > 600-ySize)
            {
                direction.Y = 600-ySize;
            }
            Position = new Vector2(-(direction.X - xSide), -(direction.Y - ySize));
        }
        public void Zoomin (float zoomin)
        {
            Zoom = zoomin;
           
            
        }
        public void Update()
        {
            zoom = Zoom;
            rotate = Rotation;
            ori = Origin;
            pos = Position;
        }



        public void DisplayLocation(Vector2 position)
        {
            Zoomin(3.0f);
            Move(position);

        }

        public Matrix GetTransform()
        {
            var translationMatrix = Matrix.CreateTranslation(new Vector3(pos.X, pos.Y, 0));
            var rotationMatrix = Matrix.CreateRotationZ(rotate);
            var scaleMatrix = Matrix.CreateScale(new Vector3(zoom, zoom, 1));
            var originMatrix = Matrix.CreateTranslation(new Vector3(ori.X, ori.Y, 0));

            return translationMatrix * rotationMatrix * scaleMatrix * originMatrix;
            //return translationMatrix * rotationMatrix * scaleMatrix ;
        }

    }
    
}
