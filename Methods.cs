
        static void WriteToTextFile(string fileName, string stringToWrite)
        {
            using (StreamWriter writer = new StreamWriter(fileName + ".txt", true))
            {
                writer.WriteLine(stringToWrite);
            }
        }

        static string GetWebElement(string stringURI)
        {
            using (var client = new WebClient())
            {
                return client.DownloadString(stringURI);
            }
        }
