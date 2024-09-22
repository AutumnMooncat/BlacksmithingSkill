using Leclair.Stardew.BetterCrafting;
using Leclair.Stardew.BetterCrafting.Menus;
using Leclair.Stardew.Common.Crafting;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Enchantments;
using StardewValley.Tools;
using StardewValley.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewValley.Audio;

namespace BlacksmithingSkillCode
{
    internal class Events
    {
        public static void OnGameLaunched(object? sender, GameLaunchedEventArgs e)
        {
            ModEntry.BetterCrafting = ModEntry.Instance.Helper.ModRegistry.GetApi<IBetterCrafting>("leclair.bettercrafting");
            ModEntry.BetterCrafting.PostCraft += OnPostCraft;
            //ModEntry.BetterCrafting.PerformCraft += OnCraft;
        }

        private static void OnCraft(IGlobalPerformCraftEvent e)
        {

        }

        private static void OnPostCraft(IPostCraftEvent e)
        {
            BetterCraftingPage page = e.Menu as BetterCraftingPage;
            if (page != null)
            {
                if (page.Station != null && page.Station.Id.Equals("MistressAutumn.BlacksmithingSkill_SmithingAnvil"))
                {
                    ModEntry.Instance.Monitor.Log("Crafted " + e.Item.Name + " at anvil.", LogLevel.Debug);

                    if (e.Item.HasContextTag("blacksmithingskill_dust"))
                    {
                        int exp = e.Item.sellToStorePrice() / 2;
                        Utilities.AddSmithingXP(e.Player, exp);

                        e.Player.playNearbySoundAll("stoneCrack", null, SoundContext.Default);
                        e.Player.Stamina -= Math.Max(10 - Utilities.GetSmithingLevel(e.Player) * 1, 0);
                    }

                    MeleeWeapon meleeWeapon = e.Item as MeleeWeapon;
                    if (meleeWeapon != null)
                    {
                        int exp = e.Item.sellToStorePrice() / 10;
                        Utilities.AddSmithingXP(e.Player, exp);

                        e.Player.playNearbySoundAll("clank", null, SoundContext.Default);
                        DelayedAction.playSoundAfterDelay("clank", 250);
                        DelayedAction.playSoundAfterDelay("clank", 500);
                        e.Player.Stamina -= Math.Max(20 - Utilities.GetSmithingLevel(e.Player) * 1, 0);

                        e.Item.modData.Add(Utilities.CraftedKey, "true");
                        if (Utilities.HasStylishFinish(e.Player))
                        {
                            e.Item.modData.Add(Utilities.StylishKey, "true");
                        }
                        if (Utilities.HasPracticalFinish(e.Player))
                        {
                            e.Item.modData.Add(Utilities.PracticalKey, "true");
                            meleeWeapon.AddEnchantment(new AttackEnchantment()
                            {
                                Level = 2
                            });
                        }
                        if (Utilities.HasExpertSmith(e.Player))
                        {
                            e.Item.modData.Add(Utilities.ExpertKey, "true");
                        }
                        if (Utilities.HasResourcefulSmith(e.Player))
                        {
                            e.Item.modData.Add(Utilities.ResourcefulKey, "true");
                            foreach (Item item in e.ConsumedItems.ToArray())
                            {
                                if (item.Stack > 1 && Game1.random.NextBool())
                                {
                                    if (e.Player.couldInventoryAcceptThisItem(item.getOne()))
                                    {
                                        e.Player.addItemToInventory(item.getOne());
                                    }
                                    else
                                    {
                                        e.Player.currentLocation.debris.Add(new Debris(item, e.Player.Position));
                                    }
                                }
                            }
                        }
                        if (Utilities.HasLuxuryGrips(e.Player))
                        {
                            e.Item.modData.Add(Utilities.GripsKey, "true");
                            meleeWeapon.AddEnchantment(new WeaponSpeedEnchantment
                            {
                                Level = 2
                            });
                        }
                        if (Utilities.HasLuxuryPadding(e.Player))
                        {
                            e.Item.modData.Add(Utilities.PaddingKey, "true");
                            meleeWeapon.AddEnchantment(new DefenseEnchantment
                            {
                                Level = 2
                            });
                        }

                    }
                }
            }
        }
    }
}
