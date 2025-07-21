using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace MandiPOS
{
    // Model for the GitHub release
    public class GitHubRelease
    {
        [JsonProperty("tag_name")]
        public string TagName { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("assets")]
        public GitHubAsset[] Assets { get; set; }
    }

    public class GitHubAsset
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("browser_download_url")]
        public string BrowserDownloadUrl { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }
    }

    public static class GitHubUpdater
    {
        static readonly HttpClient Client;

        static GitHubUpdater()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri("https://api.github.com/")
            };
            // GitHub API requires a User-Agent
            Client.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue(
                    Assembly.GetEntryAssembly().GetName().Name,
                    Application.ProductVersion
                )
            );
        }

        /// <summary>
        /// Returns the latest GitHub release metadata for the given repo.
        /// </summary>
        public static async Task<GitHubRelease> GetLatestReleaseAsync(string owner, string repo)
        {
            var url = $"repos/GhayyasAwan/MandiPOS/releases/latest";
            using (var resp = await Client.GetAsync(url)){
                resp.EnsureSuccessStatusCode();
                var json = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GitHubRelease>(json);
            }
        }

        /// <summary>
        /// Checks if the latest release tag is newer than the running app version.
        /// Returns the release object if newer, otherwise null.
        /// </summary>
        public static async Task<GitHubRelease> CheckForNewReleaseAsync(string owner, string repo)
        {
            var latest = await GetLatestReleaseAsync(owner, repo);

            // Strip leading 'v' if present, e.g. "v1.2.3" → "1.2.3"
            var tag = latest.TagName.TrimStart('v', 'V');

            if (Version.TryParse(tag, out var remoteVersion) &&
                Version.TryParse(Application.ProductVersion, out var currentVersion))
            {
                if (remoteVersion > currentVersion)
                    return latest;
            }

            return null;
        }
    }
}