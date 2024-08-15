namespace MedicalApp.Core.Services
{
    /// <summary>
    /// Defines the interface for managing screen navigation in the application.
    /// </summary>
    public interface IScreenManager
    {
        /// <summary>
        /// Navigates to a screen identified by the key.
        /// </summary>
        /// <param name="screenKey">The key representing the screen to navigate to.</param>
        void NavigateTo(string screenKey);
    }
}
