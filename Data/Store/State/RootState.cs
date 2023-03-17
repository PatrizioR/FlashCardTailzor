using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardTailzor.Data.Store.State
{
    public record RootState
    {
        public RootState(bool isLoading, string? currentErrorMessage, string? currentSuccessMessage) =>
            (IsLoading, CurrentErrorMessage, CurrentSuccessMessage) = (isLoading, currentErrorMessage, currentSuccessMessage);

        public bool IsLoading { get; init; }

        public string? CurrentErrorMessage { get; init; }
        public string? CurrentSuccessMessage { get; set; }

        public bool HasCurrentErrors => !string.IsNullOrWhiteSpace(CurrentErrorMessage);
        public bool HasCurrentSuccess => !string.IsNullOrEmpty(CurrentSuccessMessage);
    }
}
