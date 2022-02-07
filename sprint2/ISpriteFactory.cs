using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2
{
    public interface ISpriteFactory
    {
        void LoadAllResources(ContentManager content);
    }
}
