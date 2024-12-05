using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class ProjectileManager
    {
        public enum ProjectileNames
        {
            Bomb, BlueArrow, FireBall, Boomerang,
            WoodSwordAttack, IronSwordAttack, MasterSwordAttack, MagicStaffSAttack, DebugSwordAttack
        }

        public enum ProjectileType { LinkProj, EnemyProj }

        private List<IJoiner> _runningProjectileJoiners = new List<IJoiner>();
        private List<ICollisionBox> _collisionBoxes = new List<ICollisionBox>();
        private ProjectileFactory _factory = ProjectileFactory.Instance;
        private SpriteBatch _spriteBatch;

        // constructor
        public ProjectileManager() { }

        public void LoadAll(SpriteBatch spriteBatch, ContentManager content) { _spriteBatch = spriteBatch; _factory.LoadAllTextures(content); }

        /// <summary>
        /// call the projectile for sprites with only frames, meaning that it is a projectile that is only one animation, and NO direction or NO frame/renderer switching
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        /// <param name="direction"></param>
        /// <returns>the sprite added to the list</returns>
        public void CallProjectile(ProjectileNames name, ProjectileType type, Vector2 placementPosition, Renderer.DIRECTION direction, float printScale)
        {
            IJoiner currentJoiner = _factory.CreateProjectile(name, direction, printScale);
            currentJoiner.PositionOnWindow = placementPosition;
            _runningProjectileJoiners.Add(currentJoiner);

            if (type.Equals(ProjectileType.LinkProj))
                currentJoiner.CollisionBox = new LinkProjCollisionBox(currentJoiner.CurrentSprite);
            else
                currentJoiner.CollisionBox = new EnemyProjCollisionBox(currentJoiner.CurrentSprite);
            SetCollidable(currentJoiner.CollisionBox);
            SetDamageHealth(currentJoiner.CollisionBox);
            _collisionBoxes.Add(currentJoiner.CollisionBox);
        }

        public void UnloadAllTextures(ContentManager content)
        {
            _factory.UnloadAllTextures(content);
        }

        public void UnloadProjectileJoiner(IJoiner joiner)
        {
            _collisionBoxes.Remove(joiner.CollisionBox);
            _runningProjectileJoiners.Remove(joiner);
        }

        public void UnloadAllProjectiles()
        {
            _runningProjectileJoiners.Clear();
            _collisionBoxes.Clear();
        }


        /// <summary>
        /// Draw all blocks in the List
        /// </summary>
        public void Draw()
        {
            foreach (var projectile in _runningProjectileJoiners)
            {
                projectile.CurrentSprite.Draw(_spriteBatch);
            }
        }

        public void Update()
        {
            List<IJoiner> unloadList = new List<IJoiner>();
            foreach (var projectile in _runningProjectileJoiners)
            {
                projectile.Update();
                projectile.CollisionBox.Bounds = projectile.CurrentSprite.DestinationRectangle;
                SetCollidable(projectile.CollisionBox);
                SetDamageSwitches(projectile.CollisionBox);
                if (projectile.RemovableFlip is true)
                    unloadList.Add(projectile);
            }
            foreach (var projectile in unloadList)
            {
                if (_runningProjectileJoiners.Contains(projectile))
                    UnloadProjectileJoiner(projectile);
            }
        }

        public void SetNewSwordPosition(Vector2 updatePosition)
        {
            foreach (var projectile in _runningProjectileJoiners)
            {
                if (projectile is PJoiner_SwordAttack)
                {
                    projectile.PositionOnWindow += updatePosition;
                }
            }

        }
    }
}