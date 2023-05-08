using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

namespace Integrations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegrationsController : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<string> Sender(string request)
        {
            OpenAIAPI api = new OpenAIAPI("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");
            var result = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
            {
                Model = Model.ChatGPTTurbo,
                Temperature = 0.1,
                MaxTokens = 1024,
                Messages = new ChatMessage[] {
                    new ChatMessage(ChatMessageRole.User, request)
                }
            });

            var reply = result.Choices[0].Message;

            return reply.Content;
        }
    }
}
