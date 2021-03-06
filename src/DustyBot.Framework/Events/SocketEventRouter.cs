﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord.WebSocket;
using DustyBot.Framework.Utility;

namespace DustyBot.Framework.Events
{
    class SocketEventRouter : IEventRouter
    {
        HashSet<IEventHandler> _handlers;

        public IEnumerable<IEventHandler> Handlers => _handlers;
        public void Register(IEventHandler handler) => _handlers.Add(handler);

        public SocketEventRouter(IEnumerable<IEventHandler> handlers, DiscordSocketClient client)
        {
            _handlers = new HashSet<IEventHandler>(handlers);

            client.ChannelCreated += Client_ChannelCreated;
            client.ChannelDestroyed += Client_ChannelDestroyed;
            client.ChannelUpdated += Client_ChannelUpdated;
            client.CurrentUserUpdated += Client_CurrentUserUpdated;
            client.GuildAvailable += Client_GuildAvailable;
            client.GuildMembersDownloaded += Client_GuildMembersDownloaded;
            client.GuildMemberUpdated += Client_GuildMemberUpdated;
            client.GuildUnavailable += Client_GuildUnavailable;
            client.GuildUpdated += Client_GuildUpdated;
            client.JoinedGuild += Client_JoinedGuild;
            client.LeftGuild += Client_LeftGuild;
            client.MessageDeleted += Client_MessageDeleted;
            client.MessageReceived += Client_MessageReceived;
            client.MessageUpdated += Client_MessageUpdated;
            client.ReactionAdded += Client_ReactionAdded;
            client.ReactionRemoved += Client_ReactionRemoved;
            client.ReactionsCleared += Client_ReactionsCleared;
            client.RecipientAdded += Client_RecipientAdded;
            client.RecipientRemoved += Client_RecipientRemoved;
            client.RoleCreated += Client_RoleCreated;
            client.RoleDeleted += Client_RoleDeleted;
            client.RoleUpdated += Client_RoleUpdated;
            client.UserBanned += Client_UserBanned;
            client.UserIsTyping += Client_UserIsTyping;
            client.UserJoined += Client_UserJoined;
            client.UserLeft += Client_UserLeft;
            client.UserUnbanned += Client_UserUnbanned;
            client.UserUpdated += Client_UserUpdated;
            client.UserVoiceStateUpdated += Client_UserVoiceStateUpdated;
            client.MessagesBulkDeleted += Client_MessagesBulkDeleted;
        }

        private async Task Client_MessagesBulkDeleted(IReadOnlyCollection<Discord.Cacheable<Discord.IMessage, ulong>> arg1, ISocketMessageChannel arg2)
        {
            await _handlers.ForEachAsync(async x => await x.OnMessagesBulkDeleted(arg1, arg2));
        }

        private async Task Client_UserVoiceStateUpdated(SocketUser arg1, SocketVoiceState arg2, SocketVoiceState arg3)
        {
            await _handlers.ForEachAsync(async x => await x.OnUserVoiceStateUpdated(arg1, arg2, arg3));
        }

        private async Task Client_UserUpdated(SocketUser arg1, SocketUser arg2)
        {
            await _handlers.ForEachAsync(async x => await x.OnUserUpdated(arg1, arg2));
        }

        private async Task Client_UserUnbanned(SocketUser arg1, SocketGuild arg2)
        {
            await _handlers.ForEachAsync(async x => await x.OnUserUnbanned(arg1,  arg2));
        }

        private async Task Client_UserLeft(SocketGuildUser arg)
        {
            await _handlers.ForEachAsync(async x => await x.OnUserLeft(arg));
        }

        private async Task Client_UserJoined(SocketGuildUser arg)
        {
            await _handlers.ForEachAsync(async x => await x.OnUserJoined(arg));
        }

        private async Task Client_UserIsTyping(SocketUser arg1, ISocketMessageChannel arg2)
        {
            await _handlers.ForEachAsync(async x => await x.OnUserIsTyping(arg1, arg2));
        }

        private async Task Client_UserBanned(SocketUser arg1, SocketGuild arg2)
        {
            await _handlers.ForEachAsync(async x => await x.OnUserBanned(arg1,  arg2));
        }

        private async Task Client_RoleUpdated(SocketRole arg1, SocketRole arg2)
        {
            await _handlers.ForEachAsync(async x => await x.OnRoleUpdated(arg1, arg2));
        }

        private async Task Client_RoleDeleted(SocketRole arg)
        {
            await _handlers.ForEachAsync(async x => await x.OnRoleDeleted(arg));
        }

        private async Task Client_RoleCreated(SocketRole arg)
        {
            await _handlers.ForEachAsync(async x => await x.OnRoleCreated(arg));
        }

        private async Task Client_RecipientRemoved(SocketGroupUser arg)
        {
            await _handlers.ForEachAsync(async x => await x.OnRecipientRemoved(arg));
        }

        private async Task Client_RecipientAdded(SocketGroupUser arg)
        {
            await _handlers.ForEachAsync(async x => await x.OnRecipientAdded(arg));
        }

        private async Task Client_ReactionsCleared(Discord.Cacheable<Discord.IUserMessage, ulong> arg1, ISocketMessageChannel arg2)
        {
            await _handlers.ForEachAsync(async x => await x.OnReactionsCleared(arg1, arg2));
        }

        private async Task Client_ReactionRemoved(Discord.Cacheable<Discord.IUserMessage, ulong> arg1, ISocketMessageChannel arg2, SocketReaction arg3)
        {
            await _handlers.ForEachAsync(async x => await x.OnReactionRemoved(arg1, arg2, arg3));
        }

        private async Task Client_ReactionAdded(Discord.Cacheable<Discord.IUserMessage, ulong> arg1, ISocketMessageChannel arg2, SocketReaction arg3)
        {
            await _handlers.ForEachAsync(async x => await x.OnReactionAdded(arg1, arg2, arg3));
        }

        private async Task Client_MessageUpdated(Discord.Cacheable<Discord.IMessage, ulong> arg1, SocketMessage arg2, ISocketMessageChannel arg3)
        {
            await _handlers.ForEachAsync(async x => await x.OnMessageUpdated(arg1, arg2, arg3));
        }

        private async Task Client_MessageReceived(SocketMessage arg)
        {
            await _handlers.ForEachAsync(async x => await x.OnMessageReceived(arg));
        }

        private async Task Client_MessageDeleted(Discord.Cacheable<Discord.IMessage, ulong> arg1, ISocketMessageChannel arg2)
        {
            await _handlers.ForEachAsync(async x => await x.OnMessageDeleted(arg1, arg2));
        }

        private async Task Client_LeftGuild(SocketGuild arg)
        {
            await _handlers.ForEachAsync(async x => await x.OnLeftGuild(arg));
        }

        private async Task Client_JoinedGuild(SocketGuild arg)
        {
            await _handlers.ForEachAsync(async x => await x.OnJoinedGuild(arg));
        }

        private async Task Client_GuildUpdated(SocketGuild arg1, SocketGuild arg2)
        {
            await _handlers.ForEachAsync(async x => await x.OnGuildUpdated(arg1, arg2));
        }

        private async Task Client_GuildUnavailable(SocketGuild arg)
        {
            await _handlers.ForEachAsync(async x => await x.OnGuildUnavailable(arg));
        }

        private async Task Client_GuildMemberUpdated(SocketGuildUser arg1, SocketGuildUser arg2)
        {
            await _handlers.ForEachAsync(async x => await x.OnGuildMemberUpdated(arg1, arg2));
        }

        private async Task Client_GuildMembersDownloaded(SocketGuild arg)
        {
            await _handlers.ForEachAsync(async x => await x.OnGuildMembersDownloaded( arg));
        }

        private async Task Client_GuildAvailable(SocketGuild arg)
        {
            await _handlers.ForEachAsync(async x => await x.OnGuildAvailable( arg));
        }

        private async Task Client_CurrentUserUpdated(SocketSelfUser arg1, SocketSelfUser arg2)
        {
            await _handlers.ForEachAsync(async x => await x.OnCurrentUserUpdated(arg1, arg2));
        }

        private async Task Client_ChannelUpdated(SocketChannel arg1, SocketChannel arg2)
        {
            await _handlers.ForEachAsync(async x => await x.OnChannelUpdated(arg1, arg2));
        }

        private async Task Client_ChannelDestroyed(SocketChannel arg)
        {
            await _handlers.ForEachAsync(async x => await x.OnChannelDestroyed(arg));
        }

        private async Task Client_ChannelCreated(SocketChannel arg)
        {
            await _handlers.ForEachAsync(async x => await x.OnChannelCreated(arg));
        }
    }
}
