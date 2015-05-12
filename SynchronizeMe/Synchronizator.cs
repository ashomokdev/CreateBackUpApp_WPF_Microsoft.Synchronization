using System;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Files;
using System.Windows;

namespace SynchronizeMe
{
    class Synchronizator
    {
        internal static void Run(string sourseFolderPath, string backupFolderPath)
        {
            try
            {
                FileSyncProvider sourceReplica = new FileSyncProvider(sourseFolderPath);

                FileSyncProvider backupReplica = new FileSyncProvider(backupFolderPath);

                //Initialize the agent which actually performs the
                //synchronization.
                SyncOrchestrator agent = new SyncOrchestrator();

                //assign the source replica as the Local Provider and the
                //backup replica as the Remote provider so that the agent
                //knows which is the source and which one is the backup.
                agent.LocalProvider = sourceReplica;
                agent.RemoteProvider = backupReplica;

                agent.Direction = SyncDirectionOrder.Upload;

                //make a call to the Synchronize method for starting the
                //synchronization process.
                agent.Synchronize();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace + e.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
