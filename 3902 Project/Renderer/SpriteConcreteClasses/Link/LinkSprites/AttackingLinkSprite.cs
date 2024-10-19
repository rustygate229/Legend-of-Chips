using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using static _3902_Project.ILinkStateMachine;

namespace _3902_Project
{
    public class AttackingLinkSprite : ILinkSprite
    {
        private Texture2D spritesheet;
        private int frame;
        private int totalFrames;
        private List<Rectangle> sourceList;
        private float scale;
        private ILinkStateMachine linkStateMachine;
        public double x { get; set; }
        public double y { get; set; }


        public AttackingLinkSprite(Texture2D sheet, List<Rectangle> sources, int numFrames, float s, ILinkStateMachine state)
        {
            //width and height are size of sprite
            spritesheet = sheet;

            //size scales sprite to whatever is needed
            scale = s;
            totalFrames = numFrames;
            frame = 0;
            sourceList = sources;
            linkStateMachine = state;

            x = 0; y = 0;

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

        public void Draw(SpriteBatch sb)
        {
            //needs access to state 
            //x and y are passed in by LinkAnimation from LinkMovement
            Rectangle destinationRectangle;
            Rectangle sourceRectangle;
            Color tint = Color.White;

            Boolean reverseFlag = false;

            //sourceList = down, right, up, order from left to right in spritesheet

            ILinkStateMachine.MOVEMENT direction = linkStateMachine.getMovementState();

            if (direction == MOVEMENT.MDOWN || direction == MOVEMENT.SDOWN)
            {
                sourceRectangle = sourceList[frame];
            }
            else if (direction == MOVEMENT.MRIGHT ||direction == MOVEMENT.SRIGHT)
            {
                sourceRectangle = sourceList[frame + totalFrames];
            }
            else if (direction == MOVEMENT.MUP || direction == MOVEMENT.SUP)
            {
                sourceRectangle = sourceList[frame + 2 * totalFrames];
            }
            else if (direction == MOVEMENT.MLEFT || direction == MOVEMENT.SLEFT)
            {
                //reverse flag since spritesheet doesn't have left sprites
                reverseFlag = true;
                sourceRectangle = sourceList[frame + totalFrames];
            }
            else
            {
                //defaults to down sprite animation
                sourceRectangle = sourceList[frame];
            }

            //destination rectangle dynamically scales with size of sourceRectangle size
            if (direction == MOVEMENT.MUP || direction == MOVEMENT.SUP)
            {
                //offsets MUP sprites
                int height = (int)((y) - ((sourceRectangle.Height - 16) * scale));

                destinationRectangle = new Rectangle((int)(x), height, (int)(sourceRectangle.Width * scale), (int)(sourceRectangle.Height * scale));
            }
            else if (direction == MOVEMENT.MLEFT || direction == MOVEMENT.SLEFT)
            {
                int width = (int)(x - (sourceRectangle.Width - 16) * scale);

                destinationRectangle = new Rectangle(width, (int)(y), (int)(sourceRectangle.Width * scale), (int)(sourceRectangle.Height * scale));
            }
            else
            {
                destinationRectangle = new Rectangle((int)(x), (int)(y), (int)(sourceRectangle.Width * scale), (int)(sourceRectangle.Height * scale));
            }

            if (linkStateMachine.getDamage())
            {
                tint = Color.Red;
            }


            sb.Begin(samplerState: SamplerState.PointClamp);
            if (reverseFlag)
            {
                sb.Draw(spritesheet, destinationRectangle, sourceRectangle, tint, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {//reverseFlag = false
                sb.Draw(spritesheet, destinationRectangle, sourceRectangle, tint);
            }
            sb.End();

        }
    }

}