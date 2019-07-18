using System;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Newtonsoft.Json.Linq;
namespace ArmDeployer
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientId = "";
            var clientSecret = "";
            var tenantId = "";
            var subscriptionId = "";
            var groupName = "";
            var location = Region.USSouthCentral;

            var credentials = SdkContext.AzureCredentialsFactory
                .FromServicePrincipal(clientId
                , clientSecret
                , tenantId
                , AzureEnvironment.AzureGlobalCloud
                );

            var templatePath = @"https://rdstorage10789078.blob.core.windows.net/testdata/template.json";
            //var paramPath = @"https://rdstorage10789078.blob.core.windows.net/testdata/param.json";
            //string p = System.IO.File.ReadAllText(@"C:\Users\vedarisi\source\repos\ArmDeployer\ArmDeployer\param.json");
            // var azure = Microsoft.Azure.Management.Fluent.Azure

            var azure = Azure
                .Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                .Authenticate(credentials)
                .WithSubscription(subscriptionId);

            // .WithDefaultSubscription(subscriptionId);

            Console.WriteLine("Creating AI Instance");
    
            
            Console.WriteLine("Deploying the template...");
            var pJObject = JObject.FromObject(new Parameters("test-app", "web", "East US"));


            
            try
            {
                var deployment = azure.Deployments.Define("mytestDeployment")
                    .WithExistingResourceGroup(groupName)
                    .WithTemplateLink(templatePath, "1.0.0.0")
                    .WithParameters(pJObject)
                    //.WithParametersLink(paramPath, "1.0.0.0")
                    .WithMode(Microsoft.Azure.Management.ResourceManager.Fluent.Models.DeploymentMode.Incremental)
                    .Create();
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            Console.WriteLine("Complete Deployment...");
            Console.WriteLine("Press enter to Come out of the program...");
            Console.ReadLine();
        }
    }
}