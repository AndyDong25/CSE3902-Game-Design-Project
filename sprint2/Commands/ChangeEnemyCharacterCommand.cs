using sprint2.Objects.NPC;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2.Commands
{
    class ChangeEnemyCharacterCommand : ICommand
    {
        private Enemy myEnemy;
        public ChangeEnemyCharacterCommand(Enemy enemy)
        {
            myEnemy = enemy;
        }
        public void Execute()
        {
            myEnemy.ChangeCharacter();
        }
    }
}
