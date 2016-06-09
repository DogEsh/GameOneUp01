

namespace SimpleTeam.GameOne.GameInfo
{
    public class SimplusHP : ISimplusHP
    {
        private int _cur;
        private int _max;
        private int _bonusCapture;
        public int Cur { get { return _cur; } }
        public int Max { get { return _max; } }

        public SimplusHP(int cur, int max = 100, int bonusCapture = 10)
        {
            _cur = cur;
            _max = max;
            _bonusCapture = bonusCapture;
        }
        public bool Attack(int HP)
        {
            _cur -= HP;
            bool isСaptured = _cur < 0;
            if (isСaptured)
            {
                _cur *= -1;
                _cur += _bonusCapture;
            }
            Limit();
            return isСaptured;
        }
        public void Defense(int HP)
        {
            Inc(HP);
        }
        public void Inc(int HP)
        {
            _cur += HP;
            Limit();
        }
        private void Limit()
        {
            if (_cur > _max)
            {
                _cur = _max;
            }
        }
    }
}
