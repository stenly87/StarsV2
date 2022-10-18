using System;

namespace StarsV2.View
{
    internal class LevelSelector
    {
        private int level;

        public int Level
        {
            get => level;
            internal set
            {
                level = value;
                OnLevelSelected?.Invoke(this, level);
            }
        }

        public event EventHandler<int> OnLevelSelected;

    }
}