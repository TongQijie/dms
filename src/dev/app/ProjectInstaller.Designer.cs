namespace Dade.Dms.Dev.App
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AppServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.AppServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // AppServiceProcessInstaller
            // 
            this.AppServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.AppServiceProcessInstaller.Password = null;
            this.AppServiceProcessInstaller.Username = null;
            // 
            // AppServiceInstaller
            // 
            this.AppServiceInstaller.Description = "This App Service is always running for DMS.";
            this.AppServiceInstaller.DisplayName = "Dev App Service for DMS";
            this.AppServiceInstaller.ServiceName = "AppService";
            this.AppServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.AppServiceProcessInstaller,
            this.AppServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller AppServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller AppServiceInstaller;
    }
}