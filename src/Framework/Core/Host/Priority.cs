namespace Aurora.Core.Host
{
    public enum Priority
    {
        /// <summary>
        /// Initialized Before Framework Modules
        /// </summary>
        PreFramework,
        /// <summary>
        /// Framework Modules
        /// </summary>
        Framework,
        /// <summary>
        /// Initialized Immediately after Framework Modules 
        /// </summary>
        Core, 
        /// <summary>
        /// Initialized After Core, before application Modules
        /// </summary>
        PreApplication,
        /// <summary>
        /// Application Modules
        /// </summary>
        Application,
        /// <summary>
        /// Initialized After Application Modules
        /// </summary>
        PostApplication
    }
}