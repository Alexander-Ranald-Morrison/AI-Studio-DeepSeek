using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenAI.Chat;
using System.ClientModel;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using System.Windows.Threading;
using OpenAI;

namespace AI_Studio.ChatWindow
{
    /// <summary>
    /// Interaction logic for ChatWindowControl.
    /// </summary>
    public partial class ChatWindowControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatWindowControl"/> class.
        /// </summary>
        /// 
        private List<ChatMessage> messages = new List<ChatMessage>();
        private bool isProcessing = false;
        public ChatWindowControl()
        {
            this.InitializeComponent();
            messages.Add(new SystemChatMessage("You are an AI assistant."));
        }

        private async void SendButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (isProcessing)
                return;

            var userInput = UserInputTextBox.Text.Trim();
            if (string.IsNullOrEmpty(userInput))
                return;

            AppendMessage("User", userInput);
            messages.Add(new UserChatMessage(userInput));
            UserInputTextBox.Clear();

            await ProcessAIResponseAsync();
        }

        private void AppendMessage(string sender, string message)
        {
            ChatLog.Inlines.Add(new System.Windows.Documents.Run($"{sender}: {message}\n"));
        }

        private void AppendMessage(string message)
        {
            ChatLog.Inlines.Add(new System.Windows.Documents.Run($"{message}"));
        }

        private async Task ProcessAIResponseAsync()
        {
            isProcessing = true;
            try
            {
                var generalOptions = await General.GetLiveInstanceAsync();
                if (string.IsNullOrEmpty(generalOptions.ApiKey))
                {
                    AppendMessage("System", "API Key is missing. Please set it in the options.");
                    return;
                }

                string model = generalOptions.LanguageModel switch
                {
                    ChatLanguageModel.GPT4 => "gpt-4",
                    ChatLanguageModel.GPT4_Turbo => "gpt-4-turbo",
                    ChatLanguageModel.GPT4o => "gpt-4o",
                    ChatLanguageModel.Deepseek_V3 => "deepseek-chat",
                    ChatLanguageModel.Deepseek_R1 => "deepseek-reasoner",
                    _ => "gpt-4-turbo"
                };

                var apiKey = new ApiKeyCredential(generalOptions.ApiKey);
                var options = new OpenAIClientOptions
                {
                    Endpoint = new Uri(generalOptions.ApiEndpoint)
                };
                var client = new ChatClient(model, apiKey, options);

                var responseBuilder = new StringBuilder();

                // Stream the AI response
                AsyncCollectionResult<StreamingChatCompletionUpdate> completionUpdates = client.CompleteChatStreamingAsync(messages);
                AppendMessage("Assistant: ");
                await foreach (StreamingChatCompletionUpdate completionUpdate in completionUpdates)
                {
                    
                    if (completionUpdate.ContentUpdate.Count > 0)
                    {
                        responseBuilder.Append(completionUpdate.ContentUpdate[0].Text);
                        await Dispatcher.InvokeAsync(() =>
                        {
                            AppendMessage(completionUpdate.ContentUpdate[0].Text);
                        }, DispatcherPriority.Background);
                    }
                }
                AppendMessage("\n");
                var assistantMessage = responseBuilder.ToString();
                //AppendMessage("Assistant", assistantMessage);
                messages.Add(new AssistantChatMessage(assistantMessage));
            }
            catch (Exception ex)
            {
                AppendMessage("Error", ex.Message);
            }
            finally
            {
                isProcessing = false;
            }
        }

    }
}