using Carrot.Core.ViewModels;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Carrot.Core.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
{
    private static ISettings AppSettings {
        get {
            return CrossSettings.Current;
        }
    }

    #region Setting Constants

    private const string SettingsKey = "previous_location";
    private static readonly Location SettingsDefault = new Location(0.0, 0.0);

    #endregion


    public static string LocationSettings {
        get {
            return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault.ToString());
        }
        set {
            AppSettings.AddOrUpdateValue(SettingsKey, value);
        }
    }

}
}