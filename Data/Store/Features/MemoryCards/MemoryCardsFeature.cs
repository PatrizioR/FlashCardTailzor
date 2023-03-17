using FlashCardTailzor.Data.Store.State;
using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardTailzor.Data.Store.Features.MemoryCards
{
    public class MemoryCardsFeature : Feature<MemoryCardsState>
    {
        public override string GetName() => nameof(MemoryCardsFeature);

        protected override MemoryCardsState GetInitialState() =>
           new(false, null, null);

    }
}
