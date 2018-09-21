using MattLamp.Config;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;

namespace MattLamp.Models
{
    internal class LedEffectMode
    {
        public static IEnumerable<LedEffectMode> Modes => _Modes.Value;

        private static Lazy<IEnumerable<LedEffectMode>> _Modes = new Lazy<IEnumerable<LedEffectMode>>(LoadModes);

        private static IEnumerable<LedEffectMode> LoadModes()
        {
            var config = ConfigurationManager.GetSection("effects") as EffectsCollection;
            if (config != null)
            {
                return config.Effects.Select(e => new LedEffectMode(e.Name, e.Description));
            }
            return new List<LedEffectMode>();
        }

        public string Name { get; }

        public string Description { get; }

        private LedEffectMode(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
