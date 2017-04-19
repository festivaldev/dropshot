using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.ServiceModel;

namespace DropshotServer {
	internal class Program {
		private static readonly string ServiceBaseUrl = "https://localhost/2.0";

		private static ApplicationWebService applicationWebService;
		private static AuthenticationWebService authenticationWebService;
		private static RelationshipWebService relationshipWebService;
		private static ShopWebService shopWebService;
		private static UserWebService userWebService;
		private static ClanWebService clanWebService;
		private static PrivateMessageWebService privateMessageWebService;

		private static void Main(string[] args) {
			Console.WriteLine("Project Dropshot [Version 1.0.015]");
			Console.WriteLine("(c) 2017 FESTIVAL Development. All rights reserved.\n");

			if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, @"Data"))) {
				Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, @"Data"));
			}

			var binding = new BasicHttpBinding();
			binding.Security.Mode = BasicHttpSecurityMode.Transport;
			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, errors) => true;

			#region ApplicationWebService

			applicationWebService = new ApplicationWebService();
			var applicationWebServiceEndpoint = new EndpointAddress(string.Format("{0}/ApplicationWebService", ServiceBaseUrl));
			var applicationWebServiceHost = new ServiceHost(applicationWebService);
			applicationWebServiceHost.AddServiceEndpoint(typeof(IApplicationWebServiceContract), binding, applicationWebServiceEndpoint.Uri);
			applicationWebServiceHost.Open();
			Console.WriteLine("OK");

			#endregion

			#region AuthenticationWebService

			authenticationWebService = new AuthenticationWebService();
			var authenticationWebServiceEndpoint = new EndpointAddress(string.Format("{0}/AuthenticationWebService", ServiceBaseUrl));
			var authenticationWebServiceHost = new ServiceHost(authenticationWebService);
			authenticationWebServiceHost.AddServiceEndpoint(typeof(IAuthenticationWebServiceContract), binding, authenticationWebServiceEndpoint.Uri);
			authenticationWebServiceHost.Open();
			Console.WriteLine("OK");

			#endregion

			#region RelationshipWebService

			relationshipWebService = new RelationshipWebService();
			var relationshipWebServiceEndpoint = new EndpointAddress(string.Format("{0}/RelationshipWebService", ServiceBaseUrl));
			var relationshipWebServiceHost = new ServiceHost(relationshipWebService);
			relationshipWebServiceHost.AddServiceEndpoint(typeof(IRelationshipWebServiceContract), binding, relationshipWebServiceEndpoint.Uri);
			relationshipWebServiceHost.Open();
			Console.WriteLine("OK");

			#endregion

			#region ShopWebService

			shopWebService = new ShopWebService();
			var shopWebServiceEndpoint = new EndpointAddress(string.Format("{0}/ShopWebService", ServiceBaseUrl));
			var shopWebServiceHost = new ServiceHost(shopWebService);
			shopWebServiceHost.AddServiceEndpoint(typeof(IShopWebServiceContract), binding, shopWebServiceEndpoint.Uri);
			shopWebServiceHost.Open();
			Console.WriteLine("OK");

			#endregion

			#region UserWebService

			userWebService = new UserWebService();
			var userWebServiceEndpoint = new EndpointAddress(string.Format("{0}/UserWebService", ServiceBaseUrl));
			var userWebServiceHost = new ServiceHost(userWebService);
			userWebServiceHost.AddServiceEndpoint(typeof(IUserWebServiceContract), binding, userWebServiceEndpoint.Uri);
			userWebServiceHost.Open();
			Console.WriteLine("OK");

			#endregion

			#region ClanWebService

			clanWebService = new ClanWebService();
			var clanWebServiceEndpoint = new EndpointAddress(string.Format("{0}/ClanWebService", ServiceBaseUrl));
			var clanWebServiceHost = new ServiceHost(clanWebService);
			clanWebServiceHost.AddServiceEndpoint(typeof(IClanWebServiceContract), binding, clanWebServiceEndpoint.Uri);
			clanWebServiceHost.Open();
			Console.WriteLine("OK");

			#endregion

			#region PrivateMessageWebService

			privateMessageWebService = new PrivateMessageWebService();
			var privateMessageWebServiceEndpoint = new EndpointAddress(string.Format("{0}/PrivateMessageWebService", ServiceBaseUrl));
			var privateMessageWebServiceHost = new ServiceHost(privateMessageWebService);
			privateMessageWebServiceHost.AddServiceEndpoint(typeof(IPrivateMessageWebServiceContract), binding, privateMessageWebServiceEndpoint.Uri);
			privateMessageWebServiceHost.Open();
			Console.WriteLine("OK");

			#endregion

			Console.WriteLine("All services running. Press Return to close.");
			Console.ReadLine();
		}

		public static string LoadEmbeddedJson(string dataPath) {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(dataPath);
            return new StreamReader(stream).ReadToEnd();
        }

		public static double GetProcessUptime() {
			var timeSpan = DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime();
			return timeSpan.TotalSeconds;
		}
	}
}