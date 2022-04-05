using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace TrayDir
{
	class UpdateUtils
	{
		private static string SOURCE = "https://api.github.com/repos/SamuelSVD/TrayDir/releases/latest";
		private static Thread updatesThread;
		private class GitHubRelease {
			public string html_url;
			public string tag_name;
			public GitHubRelease()
			{
				html_url = null;
				tag_name = null;
			}
		}
		private class Version
		{
			public int major, minor, patch;
			public Version(string versionString)
			{
				int i = 0;
				int j = 0;
				j = versionString.IndexOf(".");
				major = int.Parse(versionString.Substring(i, j));
				i = versionString.IndexOf(".",j+1);
				minor = int.Parse(versionString.Substring(j+1,i-j-1));
				patch = int.Parse(versionString.Substring(i + 1, versionString.Length - i - 1));
			}
		}
		public static void CheckForUpdates()
		{
			if (updatesThread == null || !updatesThread.IsAlive)
			{
				updatesThread = new Thread(UpdatesThread);
				updatesThread.Start();
			}
		}
		private static async void UpdatesThread()
		{
			try
			{
				string JSON = await GetVersion();
				JavaScriptSerializer json_serializer = new JavaScriptSerializer();
				GitHubRelease latestRelease = json_serializer.Deserialize<GitHubRelease>(JSON);
				if (latestRelease.tag_name != ProgramData.pd.LatestVersion) {
					if (SemverCompare(Assembly.GetEntryAssembly().GetName().Version.ToString(), latestRelease.tag_name)) {
						if (MessageBox.Show(Properties.Strings_en.Form_NewUpdateUpdateNow, Properties.Strings_en.Form_NewUpdateAvailable, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
							System.Diagnostics.Process.Start(latestRelease.html_url);
						} else {
							ProgramData.pd.LatestVersion = latestRelease.tag_name;
						}
					}
				}
			}
			catch
			{

			}
		}
		public async static Task<string> GetVersion()
		{
			string JSON;
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(SOURCE);
			request.UserAgent = "TrayDir";
			request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			using (Stream stream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(stream))
			{
				JSON = await reader.ReadToEndAsync();
			}
			return JSON;
		}
		public static bool SemverCompare(string oldVersion, string newVersion)
		{
			try
			{
				string pattern = "[0-9]+.[0-9]+.[0-9]+";
				Regex rgx = new Regex(pattern);
				MatchCollection matches = rgx.Matches(oldVersion);
				Version oldV = new Version(matches[0].ToString());
				matches = rgx.Matches(newVersion);
				Version newV = new Version(matches[0].ToString());
				return (newV.major > oldV.major || (newV.major == oldV.major && 
						(newV.minor > oldV.minor || (newV.minor == oldV.minor && 
						(newV.patch > oldV.patch)))));
			}
			catch
			{
				return false;
			}
		}

	}
}
