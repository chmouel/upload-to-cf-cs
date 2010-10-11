/*
Copyright: BSD
Author: Chmouel Boudjnah <chmouel@chmouel.com>
*/

using System;
using System.Collections.Generic;
using com.mosso.cloudfiles;
using com.mosso.cloudfiles.domain;
using System.IO;

namespace UploadToCFCLI
{
	class MainClass
	{
		static String username;
		static String api_key;
		static String chosenContainer;
		static String filePath;
		
		public static void Main (string[] args)
		{
			Boolean b = false;
			
			if (args.Length != 4) {
				Console.WriteLine("Usage: username api_key container object");
				Environment.Exit(1);
			}
			
			username = args[0];
			api_key = args[1];
			chosenContainer = args[2];
			filePath = args[3];
	
			UserCredentials userCreds = new UserCredentials(username, api_key);
			Connection connection = new com.mosso.cloudfiles.Connection(userCreds);

			List<string> containers = connection.GetContainers();
			
			foreach (string container in containers) {
				if (container == chosenContainer)
					b = true;
			}
			
			if (!b) {
				Console.WriteLine("Container {0} does not seem to exist.", chosenContainer);
				Environment.Exit(1);
			}
			
			if (!File.Exists(filePath)) {
				Console.WriteLine("fileName {0} does not seem to exist.", filePath);
				Environment.Exit(1);
			}
			
			FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			connection.PutStorageItem(chosenContainer, fileStream, Path.GetFileName(filePath));
			Console.WriteLine("*success* uploaded");
		}
	}
}

