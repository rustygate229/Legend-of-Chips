using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Collision.I;

namespace _3902_Project;

public partial class LinkPlayer : IGameObject
{
    public Rectangle Bounds { get; private set; }
    public bool IsCollidable => true;

    private ILinkMovement _linkMovement;
    private ILinkStateMachine _linkStateMachine;
    private IAnimation _animation;
    private CollisionDetector _collisionDetector;
    private CollisionHandler _collisionHandler;

    public LinkPlayer(SpriteBatch sb, ContentManager content, CollisionHandler collisionHandler)
    {
        _linkMovement = new LinkMovement();
        _linkStateMachine = new LinkStateMachine();
        _animation = new LinkAnimation(sb, content, _linkStateMachine);
        _collisionDetector = new CollisionDetector();
        _collisionHandler = collisionHandler;
        Bounds = new Rectangle(200, 200, 32, 32); // Initial position and size
    }

    public void SetPosition(int x, int y)
    {
        Bounds = new Rectangle(x, y, Bounds.Width, Bounds.Height);
    }

    public void MoveLeft(List<IGameObject> gameObjects)
    {
        if (!_linkStateMachine.getDamage())
        {
            _linkMovement.moveLeft();
            Bounds = new Rectangle(Bounds.X - 5, Bounds.Y, Bounds.Width, Bounds.Height);
            HandleCollisions(gameObjects);
            _linkStateMachine.changeStateMovingLeft();
            _animation.AnimMoving(_linkMovement.getXPosition(), _linkMovement.getYPosition());
        }
    }

    public void MoveRight(List<IGameObject> gameObjects)
    {
        if (!_linkStateMachine.getDamage())
        {
            _linkMovement.moveRight();
            Bounds = new Rectangle(Bounds.X + 5, Bounds.Y, Bounds.Width, Bounds.Height);
            HandleCollisions(gameObjects);
            _linkStateMachine.changeStateMovingRight();
            _animation.AnimMoving(_linkMovement.getXPosition(), _linkMovement.getYPosition());
        }
    }

    public void MoveUp(List<IGameObject> gameObjects)
    {
        if (!_linkStateMachine.getDamage())
        {
            _linkMovement.moveUp();
            Bounds = new Rectangle(Bounds.X, Bounds.Y - 5, Bounds.Width, Bounds.Height);
            HandleCollisions(gameObjects);
            _linkStateMachine.changeStateMovingUp();
            _animation.AnimMoving(_linkMovement.getXPosition(), _linkMovement.getYPosition());
        }
    }

    public void MoveDown(List<IGameObject> gameObjects)
    {
        if (!_linkStateMachine.getDamage())
        {
            _linkMovement.moveDown();
            Bounds = new Rectangle(Bounds.X, Bounds.Y + 5, Bounds.Width, Bounds.Height);
            HandleCollisions(gameObjects);
            _linkStateMachine.changeStateMovingDown();
            _animation.AnimMoving(_linkMovement.getXPosition(), _linkMovement.getYPosition());
        }
    }

    public void HandleCollisions(List<IGameObject> gameObjects)
    {
        foreach (var obj in gameObjects)
        {
            if (obj != this && obj.IsCollidable)
            {
                if (_collisionDetector.DetectCollision(this, obj))
                {
                    CollisionType side = DetermineCollisionSide(obj);
                    _collisionHandler.HandleCollision(this, obj, side);
                }
            }
        }
    }

    private CollisionType DetermineCollisionSide(IGameObject otherObject)
    {
        Rectangle intersection = Rectangle.Intersect(this.Bounds, otherObject.Bounds);
        if (intersection.Width >= intersection.Height)
        {
            return this.Bounds.Top < otherObject.Bounds.Top ? CollisionType.Bottom : CollisionType.Top;
        }
        else
        {
            return this.Bounds.Left < otherObject.Bounds.Left ? CollisionType.Right : CollisionType.Left;
        }
    }

    public void OnCollision(CollisionType collisionType, IGameObject otherObject)
    {
        // Custom collision handling logic if needed
        if (collisionType != CollisionType.None && otherObject is Block)
        {
            Console.WriteLine("Player collided with a block.");
        }
    }
}

