using System;

namespace Coding.Exercise
{
    public class Game 
    {
        public event EventHandler<EventArgs> IncreaseRatAttack;

        public event EventHandler<EventArgs> DecreaseAttack;

        public event EventHandler<EventArgs> IncreaseRatEnteredAttack;

        public void RatEntersHandler(object sender, EventArgs e)
        {
            IncreaseRatAttack?.Invoke(sender, EventArgs.Empty);
        }

        public void IncreaseEnteredRatAttackHandler(object sender, EventArgs e)
        {
            IncreaseRatEnteredAttack?.Invoke(sender, e);
        }

        public void RatDiesHandler(object sender, EventArgs e)
        {
            DecreaseAttack?.Invoke(sender, EventArgs.Empty);
        }
    }

    public class Rat : IDisposable 
    {
        public int Attack = 1;
        public event EventHandler<EventArgs> RatEnters;
        public event EventHandler<EventArgs> RatDies;
        public event EventHandler<EventArgs> IncreaseEnteredRatAttack;

        public Rat(Game game)
        {
            RatEnters += game.RatEntersHandler;
            IncreaseEnteredRatAttack += game.IncreaseEnteredRatAttackHandler;
            RatDies += game.RatDiesHandler;
            game.IncreaseRatAttack += Rat_IncreaseRatAttack;
            game.IncreaseRatEnteredAttack += Rat_IncreaseEnterdRatAttack;
            game.DecreaseAttack += Rat_DecreaseAttack;
            RatEnters?.Invoke(this, EventArgs.Empty);
        }

        private void Rat_IncreaseEnterdRatAttack(object sender, EventArgs e)
        {
            if (sender == this)
                Attack++;
        }

        private void Rat_DecreaseAttack(object sender, EventArgs e)
        {
            if (sender == this)
                return;

            Attack--; 
        }

        private void Rat_IncreaseRatAttack(object sender, EventArgs e)
        {
            if (sender == this)
                return;

            Attack++;
            IncreaseEnteredRatAttack?.Invoke(sender, e);

        }

        public void Dispose()
        {
            RatDies?.Invoke(this,EventArgs.Empty);
        }
    }
}

