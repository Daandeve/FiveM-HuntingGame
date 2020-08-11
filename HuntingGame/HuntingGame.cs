//using vSql;
using System;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace HuntingGame
{
    public class HuntingGame : BaseScript
    {
        public HuntingGame()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
            //vSql.Async.execute(query, parameters, callback)
        }

        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            RegisterCommand("car", new Action<int, List<object>, string>((source, args, raw) =>
            {
                // TODO: make a vehicle! fun!
                TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    args = new[] { "[CarSpawner]", $"I wish I could spawn this {(args.Count > 0 ? $"{args[0]} or" : "")} adder but my owner was too lazy. :(" }
                });
            }), false);
        }
    }
}
