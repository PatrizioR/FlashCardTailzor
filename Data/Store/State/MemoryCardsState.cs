using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardTailzor.Data.Store.State
{
    public record MemoryCardsState : RootState
    {
        public MemoryCardsState(bool isLoading,
            string? currentErrorMessage,
            string? currentSuccessMessage) : base(isLoading, currentErrorMessage, currentSuccessMessage)
        {
        }
    }
}
