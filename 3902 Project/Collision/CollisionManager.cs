using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using static _3902_Project.PlaySoundEffect;

namespace _3902_Project
{
    public partial class CollisionManager
    {
        public List<List<ICollisionBox>> _collisionBoxes;
        private BlockManager _blockManager;
        private ItemManager _itemManager;
        private EnemyManager _enemyManager;
        private CollisionHandlerManager _collisionHandlerManager = new();
        private ProjectileManager _projectileManager;
        private LinkManager _linkManager;
        private PlaySoundEffect _sound;

        // constructor
        public CollisionManager() { }

        // load all textures relating to blocks
        public void LoadAll(LinkManager link, EnemyManager enemy, BlockManager block, ItemManager item, ProjectileManager projectile, PlaySoundEffect sound, EnvironmentFactory enviro)
        {
            _linkManager = link;
            _enemyManager = enemy;
            _blockManager = block;
            _itemManager = item;
            _projectileManager = projectile;
            _sound = sound;

            // Initialize Collision
            _collisionBoxes = new List<List<ICollisionBox>>();
            _collisionHandlerManager.LoadAll(link, enemy, block, item, projectile, sound, enviro);
            loadCollisions();
        }

        private void loadCollisions()
        {
            _collisionBoxes.Clear();

            // add the collision boxes IN ORDER (VERY IMPORTANT)
            _collisionBoxes.Add(_linkManager.GetCollisionBoxes());
            _collisionBoxes.Add(_enemyManager.GetCollisionBoxes());
            _collisionBoxes.Add(_blockManager.GetCollisionBoxes());
            _collisionBoxes.Add(_projectileManager.GetCollisionBoxes());
            _collisionBoxes.Add(_itemManager.GetCollisionBoxes());
        }


        /// <summary>
        /// Update all items in the List
        /// </summary>
        public void Update()
        {
            loadCollisions();

            // Detect Collisions
            List<CollisionData> detectedCollisions = CollisionDetector.DetectCollisions(_collisionBoxes);

            // Handle Collisions
            _collisionHandlerManager.HandleCollisions(detectedCollisions);
        }
    }
}