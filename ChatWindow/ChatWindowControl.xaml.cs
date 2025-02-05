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

        private async Task ProcessAIResponseAsync()
        {
            return;
        }

    }
}