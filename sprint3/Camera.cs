﻿using Microsoft.Xna.Framework;
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
            if (Position != direction)
            {
                //Position.X += ((direction.X - Position.X) / 10);
                //Position.Y += ((direction.Y - Position.Y) / 10);
                //Origin.X += ((direction.X - Origin.X) / 10);
                //Origin.Y += ((direction.Y - Origin.Y) / 10);
                
            }
            
        }
        public void Zoomin (float zoomin)
        {
            if (Zoom < 2.5f)
            {
                Zoom += zoomin;
            }
           
            
        }
        public void Update()
        {
            zoom = Zoom;
            rotate = Rotation;
            ori = Origin;
            pos = Position;
        }


        public Matrix GetTransform()
        {
            var translationMatrix = Matrix.CreateTranslation(new Vector3(pos.X, pos.Y, 0));
            var rotationMatrix = Matrix.CreateRotationZ(rotate);
            var scaleMatrix = Matrix.CreateScale(new Vector3(zoom, zoom, 1));
            var originMatrix = Matrix.CreateTranslation(new Vector3(ori.X, ori.Y, 0));

            return translationMatrix * rotationMatrix * scaleMatrix * originMatrix;
        }

    }
    
}
