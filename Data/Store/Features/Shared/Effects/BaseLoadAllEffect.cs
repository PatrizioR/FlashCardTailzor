using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FlashCardTailzor.Data.Models.Repositories;
using FlashCardTailzor.Data.Store.Features.Shared.Effects;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace FlashCardTailzor.Data.Store.Features.Shared.Effects
{
    public abstract class BaseLoadAllEffect<A, S, F, T> : BaseEffect<A, S, F>
    {
        protected BaseLoadAllEffect(ILogger<BaseLoadAllEffect<A, S, F, T>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
        {
        }

        protected override async Task HandleEffectAsync(A action, IDispatcher dispatcher)
        {
            string message = $"Executing load {action?.GetType().Name} action...";
            logger.LogInformation(message);
            var items = await clientRepository.GetAllAsync<T>(httpClient);
            string messageSuccess = $"Executed {action?.GetType().Name} action successfully!";
            logger.LogInformation(messageSuccess);
            await SideHandleEffectAsync(action, dispatcher, items);
            var successAction = (S)Activator.CreateInstance(typeof(S), items)!;
            dispatcher.Dispatch(successAction);
        }

        protected virtual async Task SideHandleEffectAsync(A action, IDispatcher dispatcher, IEnumerable<T> items)
        {
            await Task.CompletedTask;
            logger.LogDebug("Skip sideHandleEffect");
        }
    }
}