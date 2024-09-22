using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public class AttackingLinkSprite : ISprite
    {
        private Texture2D spritesheet;
        private int width;
        private int height;
        private int frame;
        private int totalFrames;
        private List<Rectangle> sourceList;
        private float scale;


        public AttackingLinkSprite(Texture2D sheet, List<Rectangle> sources, int numFrames, float s)
        {
            //width and height are size of sprite
            spritesheet = sheet;
            width = 16;
            height = 16;

            //size scales sprite to whatever is needed
            scale = s;
            totalFrames = numFrames;
            frame = 0;
            sourceList = sources;

            //hard coded values for sheet
            //sourceList[0] = down, 1 = right, 2 = up

        }

        public void Update()
        {
            //updates x and y position from LinkMovement.cs
            frame++;
            if (frame >= totalFrames)
            {
                //frame increments from 0 to count - 1
                frame = 0;
            }

        }
        public void Draw(SpriteBatch spritebatch)
        {
            //just for interface reasons
        }

        public void Draw(SpriteBatch sb, ILinkStateMachine state, int x, int y)
        {
            //needs access to state 
            //x and y are passed in by LinkAnimation from LinkMovement
            Rectangle destinationRectangle;
            Rectangle sourceRectangle;

            Boolean reverseFlag = false;

            //sourceList = down, right, up, order from left to right in spritesheet


            if (state.getMovementState() == (int)LinkStateMachine.MOVEMENT.MDOWN)
            {
                sourceRectangle = sourceList[frame];
            }
            else if (state.getMovementState() == (int)LinkStateMachine.MOVEMENT.MRIGHT)
            {
                sourceRectangle = sourceList[frame + totalFrames];
            }
            else if (state.getMovementState() == (int)LinkStateMachine.MOVEMENT.MUP)
            {
                sourceRectangle = sourceList[frame + 2 * totalFrames];
            }
            else if (state.getMovementState() == (int)LinkStateMachine.MOVEMENT.MLEFT)
            {
                //reverse flag since spritesheet doesn't have left sprites
                reverseFlag = true;
                sourceRectangle = sourceList[frame + 2 * totalFrames];
            }
            else
            {
                //defaults to down sprite animation
                sourceRectangle = sourceList[frame];
            }

            //destination rectangle dynamically scales with size of sourceRectangle size
            destinationRectangle = new Rectangle(x, y, (int)(sourceRectangle.Width * scale), (int)(sourceRectangle.Height * scale));

            sb.Begin(samplerState: SamplerState.PointClamp);
            if (reverseFlag)
            {
                //commented out until i fix the reverse flag stuff
                sb.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {//reverseFlag = false
                sb.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White);
            }
            sb.End();

        }
    }

}