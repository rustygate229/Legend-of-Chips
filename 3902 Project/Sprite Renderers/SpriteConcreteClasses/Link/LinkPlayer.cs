﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using static _3902_Project.ILinkStateMachine;

namespace _3902_Project
{
    public partial class LinkPlayer
    {
        IAnimation _animation;
        LinkMovement _linkMovement;
        ILinkStateMachine _linkStateMachine;
        ProjectileManager _projectileManager;
        LinkInventory _linkInventory;
        CharacterStateManager _characterState;

        // Link boundary area (x, y, width, height)
        private Rectangle playAreaBoundary = new Rectangle(125, 320, 780, 450);
        private Rectangle doorBoundaries2 = new Rectangle(510, 320, 2, 2);  //up
        private Rectangle doorBoundaries3 = new Rectangle(510, 760, 2, 2);   //down
        private Rectangle doorBoundaries1 = new Rectangle(120, 550, 2, 2);  //left
        private Rectangle doorBoundaries4 = new Rectangle(883, 550, 2, 2);    //right



        //double x, y;
        public LinkPlayer(SpriteBatch sb, ContentManager content, ProjectileManager projectileManager, CharacterStateManager characterState)
        {
            _linkMovement = new LinkMovement();
            _linkStateMachine = new LinkStateMachine();
            _animation = new LinkAnimation(sb, content, _linkStateMachine);
            _linkInventory = new LinkInventory();
            _characterState = characterState;

            _projectileManager = projectileManager;

        }
        

        public ICollisionBox getCollisionBox()
        {
            return _linkMovement.getCollisionBox();
        }

        private bool CannotMove()
        {
            return (_linkStateMachine.getAttackState() == ATTACK.THROW);
        }

        private bool IsMovementKeysPressed()
        {
            KeyboardState keyboard = Keyboard.GetState();

            return keyboard.IsKeyDown(Keys.W) ||
                keyboard.IsKeyDown(Keys.A) ||
                keyboard.IsKeyDown(Keys.S) ||
                keyboard.IsKeyDown(Keys.D) ||
                keyboard.IsKeyDown(Keys.Up) ||
                keyboard.IsKeyDown(Keys.Left) ||
                keyboard.IsKeyDown(Keys.Down) ||
                keyboard.IsKeyDown(Keys.Right);
        }

        private bool IsAttackKeysPressed()
        {
            KeyboardState keyboard = Keyboard.GetState();
            return keyboard.IsKeyDown(Keys.Z) || keyboard.IsKeyDown(Keys.N) || keyboard.IsKeyDown(Keys.C);
        }

        private bool IsDamagedKeysPressed()
        {
            KeyboardState keyboard = Keyboard.GetState();
            return keyboard.IsKeyDown(Keys.E);
        }

      

        public void Attack() { _linkStateMachine.setMelee(); }
        public void Throw() {
            _linkStateMachine.setThrow();
            FireProjectile();
        }

        //Character State Logic
        public void TakeDamage(int damageAmount)
        {
            _characterState.DecreaseHealth(damageAmount);
        }

        public void PickUpItem(string itemName)
        {
            _characterState.AddItem(itemName);
        }

        public void UseItem(string itemName)
        {
            _characterState.UseItem(itemName);
        }


        public void StopAttack() { _linkStateMachine.stopAttack(); }
        public void StopDamage() { _linkStateMachine.stopDamage(); }
        public void flipDamaged() { _linkStateMachine.setDamage(); }

        public void changeToItem1() { _linkStateMachine.setInventory(1); }
        public void changeToItem2() { _linkStateMachine.setInventory(2); }
        public void changeToItem3() { _linkStateMachine.setInventory(3); }
        public void changeToItem4() { _linkStateMachine.setInventory(4); }

        public void changeToItem5() { _linkStateMachine.setInventory(5); }

        public void Update()
        {
            _animation.Update();

            int x = (int)_linkMovement.getXPosition();
            int y = (int)_linkMovement.getYPosition();

            //updates linkMovement according to any collisions
            ICollisionBox playerCollisionBox = ((LinkMovement)_linkMovement).getCollisionBox();
            playerCollisionBox.Bounds = new Rectangle(x, y, playerCollisionBox.Bounds.Width, playerCollisionBox.Bounds.Height);

            // Ensure Link stays within the play area or door regions
            if (!playAreaBoundary.Contains(playerCollisionBox.Bounds))
            {
                bool isWithinDoorArea = false;

                // Check if Link is within any of the door boundaries
                if (doorBoundaries1.Intersects(playerCollisionBox.Bounds) ||
                    doorBoundaries2.Intersects(playerCollisionBox.Bounds) ||
                    doorBoundaries3.Intersects(playerCollisionBox.Bounds) ||
                    doorBoundaries4.Intersects(playerCollisionBox.Bounds))
                {
                    isWithinDoorArea = true;
                }

                // Keep in bounds only if not in a door area
                if (!isWithinDoorArea)
                {
                    CollisionBoxHelper.KeepInBounds(playerCollisionBox, playAreaBoundary);
                }
            }

            // Print Link's position for debugging purposes
            //Console.WriteLine($"Link Position: X = {x}, Y = {y}");


            if (!IsDamagedKeysPressed()) { StopDamage(); }
            if (!IsMovementKeysPressed()) { StayStill(); }
            if (!IsAttackKeysPressed()) { StopAttack(); }
        }

        public ILinkStateMachine.MOVEMENT getState()
        {
            return _linkStateMachine.getMovementState();
        }

        public ILinkStateMachine.ATTACK getAttack()
        {
            return _linkStateMachine.getAttackState();
        }

        //debug test
        public void DrawPlayAreaBoundary(SpriteBatch spriteBatch, Texture2D whiteRectangle)
        {
            // 确保在绘制之前调用 Begin
            spriteBatch.Begin();

            // 绘制 playAreaBoundary 的四个边框
            spriteBatch.Draw(whiteRectangle, new Rectangle(playAreaBoundary.Left, playAreaBoundary.Top, playAreaBoundary.Width, 2), Color.Red); // 上边框
            spriteBatch.Draw(whiteRectangle, new Rectangle(playAreaBoundary.Left, playAreaBoundary.Bottom - 2, playAreaBoundary.Width, 2), Color.Red); // 下边框
            spriteBatch.Draw(whiteRectangle, new Rectangle(playAreaBoundary.Left, playAreaBoundary.Top, 2, playAreaBoundary.Height), Color.Red); // 左边框
            spriteBatch.Draw(whiteRectangle, new Rectangle(playAreaBoundary.Right - 2, playAreaBoundary.Top, 2, playAreaBoundary.Height), Color.Red); // 右边框

            // 绘制门的边界区域
            spriteBatch.Draw(whiteRectangle, doorBoundaries1, Color.Blue); // 左门边界
            spriteBatch.Draw(whiteRectangle, doorBoundaries2, Color.Blue); // 上门边界
            spriteBatch.Draw(whiteRectangle, doorBoundaries3, Color.Blue); // 下门边界
            spriteBatch.Draw(whiteRectangle, doorBoundaries4, Color.Blue); // 右门边界

            // 确保在绘制完成后调用 End
            spriteBatch.End();
        }



    }
}
