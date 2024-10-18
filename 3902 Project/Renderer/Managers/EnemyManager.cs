using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _3902_Project
{
    public class EnemyManager
    {
        // create enemy names for finding them
        public enum EnemyNames { GreenSlime, BrownSlime, Wizzrope, Proto, Darknut }

        // enemy dictionary/inventory
        private Dictionary<EnemyNames, ISprite> _enemies = new Dictionary<EnemyNames, ISprite>();
        private HashSet<ISprite> _runningEnemies = new HashSet<ISprite>();

        // create variables for passing
        private EnemySpriteFactory _factory = EnemySpriteFactory.Instance;
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;


        // constructor
        public EnemyManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;
        }


        // Load all enemy textures
        public void LoadAllTextures()
        {
            _factory.LoadAllTextures(_contentManager);

            _enemies.Add(EnemyNames.GreenSlime, _factory.CreateHolsteringEnemy_GreenSlime());
            _enemies.Add(EnemyNames.BrownSlime, _factory.CreateHolsteringEnemy_BrownSlime());
            _enemies.Add(EnemyNames.Wizzrope, _factory.CreateHolsteringEnemy_Wizzrope());
            _enemies.Add(EnemyNames.Proto, _factory.CreateHolsteringEnemy_Proto());
            _enemies.Add(EnemyNames.Darknut, _factory.CreateHolsteringMovingEnemy_Darknut());
        }


        public void PlaceEnemy(EnemyNames name, Vector2 placementPosition)
        {
            ISprite currentEnemy = _enemies[name];
            currentEnemy.SetPosition(placementPosition);
            _runningEnemies.Add(currentEnemy);
        }

        public void UnloadAllEnemies() { _runningEnemies = new HashSet<ISprite>(); }



        // Draw the current enemy
        public void Draw()
        {
            foreach (var enemy in _runningEnemies)
            {
                enemy.Draw(_spriteBatch);
            }
        }

        public void Update()
        {
            foreach (var enemy in _runningEnemies)
            {
                enemy.Update();
            }
        }
    }
}
