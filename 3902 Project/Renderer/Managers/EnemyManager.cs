using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _3902_Project
{
    public class EnemyManager
    {
        // out of bound vector that will never affect environment loading
        private Vector2 _brokenPosition = new Vector2(-1000, -1000);

        // item dictionary/inventory
        private Dictionary<ISprite, Vector2> _enemies = new Dictionary<ISprite, Vector2>();

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

            _enemies.Add(_factory.CreateHolsteringEnemy_GreenSlime(), _brokenPosition);
            _enemies.Add(_factory.CreateHolsteringEnemy_BrownSlime(), _brokenPosition);
            _enemies.Add(_factory.CreateHolsteringEnemy_Wizzrope(), _brokenPosition);
            _enemies.Add(_factory.CreateHolsteringEnemy_Proto(), _brokenPosition);
        }


        private void ReplaceDictValue(ISprite Key, Vector2 newValue)
        {
            _enemies.Remove(Key);
            _enemies.Add(Key, newValue);
        }

        public void PlaceHolsteringEnemy_GreenSlime(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateHolsteringEnemy_GreenSlime(), placementPosition); }
        public void PlaceHolsteringEnemy_BrownSlime(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateHolsteringEnemy_BrownSlime(), placementPosition); }
        public void PlaceHolsteringEnemy_Wizzrope(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateHolsteringEnemy_Wizzrope(), placementPosition); }
        public void PlaceHolsteringEnemy_Proto(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateHolsteringEnemy_Proto(), placementPosition); }



        // Draw the current enemy
        public void Draw()
        {
            foreach (var enemy in _enemies)
            {
                if (!enemy.Value.Equals(_brokenPosition))
                {
                    enemy.Key.Draw(_spriteBatch, enemy.Value);
                }
            }
        }

        public void Update()
        {
            foreach (var enemy in _enemies)
            {
                if (!enemy.Value.Equals(_brokenPosition))
                {
                    enemy.Key.Update();
                }
            }
        }
    }
}
