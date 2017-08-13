using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Space_Invaders.Models.Enimies
{
    public class TestEnemy : Enemy
    {
        public TestEnemy(int x, int y)
            : base(x, y)
        {

        }
        public override void MoveInTroops(int leftmostUnitX, int rightmostUnitX, int colomns)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            throw new NotImplementedException();
        }

        public override bool GetWeaponState()
        {
            throw new NotImplementedException();
        }

        public override void SendWeaponState(bool isActivated)
        {
            throw new NotImplementedException();
        }
    }
}
