﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using System.Linq;

namespace DustyBot.Framework.Utility
{
    public static class DiscordHelpers
    {
        public static async Task EnsureBotPermissions(IGuild guild, params GuildPermission[] perms)
        {
            var user = await guild.GetCurrentUserAsync();
            var missing = new HashSet<GuildPermission>();
            foreach (var perm in perms)
            {
                if (!user.GuildPermissions.Has(perm))
                    missing.Add(perm);
            }

            if (missing.Count > 0)
                throw new Exceptions.MissingBotPermissionsException(missing.ToArray());
        }

        public static async Task EnsureBotPermissions(IGuildChannel channel, params ChannelPermission[] perms)
        {
            var user = await channel.Guild.GetCurrentUserAsync();
            var missing = new HashSet<ChannelPermission>();
            foreach (var perm in perms)
            {
                if (!user.GetPermissions(channel).Has(perm))
                    missing.Add(perm);
            }

            if (missing.Count > 0)
                throw new Exceptions.MissingBotChannelPermissionsException(missing.ToArray());
        }

        public static async Task EnsureBotPermissions(IChannel channel, params ChannelPermission[] perms)
        {
            var guildChannel = channel as IGuildChannel;
            await EnsureBotPermissions(guildChannel, perms);
        }
    }
}
