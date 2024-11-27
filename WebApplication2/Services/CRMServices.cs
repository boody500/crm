using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Diagnostics;


namespace WebApplication2.Services
{
    
    public class CRMServices
    {
        public CrmServiceClient ConnectToCrm()
        {
            try
            {
                string authType = "AuthType=OAuth"; // AuthType is OAuth and not Office365
                string userName = "11410120210222@stud.cu.edu.eg"; // Add your username here
                string password = "Boody_500"; // Add your password here
                string domainURL = "https://org641bc7f2.crm4.dynamics.com/"; // Add your Dynamics365 instance URL here 
                string universalCodes = "appid=51f81489-12ee-4a9e-aaae-a2591f45987d;redirecturi=https://callbackurl;LoginPrompt=Auto;"; // Universal Id and uri
                string connectionString = string.Format("{0}{1}", authType, ";") +
                    string.Format("Username={0}{1}", userName, ";") +
                    string.Format("Password={0}{1}", password, ";") +
                    string.Format("Url={0}{1}", domainURL, ";") +
                    universalCodes;

                Debug.WriteLine("*** Establishing connection to CRM... ***");
                CrmServiceClient client = new CrmServiceClient(connectionString);

                if (!client.IsReady)
                {
                    Debug.WriteLine(client.LastCrmException.Message);
                    Debug.WriteLine(client.LastCrmException.Source);
                    Debug.WriteLine(client.LastCrmException.StackTrace);
                }
                else
                {
                    Debug.WriteLine("\n*** Connection Successful! ***");
                    // Perform client operations here...
                }
              
                return client;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }



    }
}
