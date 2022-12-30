using CardGame.Card;
using CardGame.Command;

namespace CardGame.Scripts
{
    public class tempCommand : Command.Command
    {
        private readonly CardFactory _cardFactory;
        private readonly CardsConfig _cardsConfig;

        public tempCommand(
            CardFactory cardFactory,
            CardsConfig cardsConfig)
        {
            _cardFactory = cardFactory;
            _cardsConfig = cardsConfig;
        }
        public override CommandResult Execute()
        {
            var model = _cardsConfig.Get(0);
        
            var protocol = new CardViewProtocol(model.Value.Name,model.Value.Discription,model.Value.BackSprite,model.Value.FrontSprite);

            for (int i = 0; i < 5; i++)
            {
                var card =  _cardFactory.Create(new CardViewProtocol(model.Value.Name,model.Value.Discription,model.Value.BackSprite,model.Value.FrontSprite));
             
            }

            return base.Execute();
        }
    }
}