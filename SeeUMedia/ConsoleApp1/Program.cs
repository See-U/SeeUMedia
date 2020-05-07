using NeteaseCloudMusicApi;
using Newtonsoft.Json.Linq;
using SeeUMedia.Models.SongModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        private static CloudMusicApi api = new CloudMusicApi();
        private static Dictionary<string, string> queries;
        private static bool isOk;
        private static string msg;
        private static JObject json;


        private static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            await SearchMusic();
        }

        /// <summary>
        /// 查找音乐
        /// </summary>
        /// <returns></returns>
        private static async Task SearchMusic()
        {
            queries = new Dictionary<string, string>();
            queries["keywords"] = "最美情侣";
            (isOk, json) = await api.RequestAsync(CloudMusicApiProviders.Search, queries);
            if (!isOk)
                throw new ApplicationException($"获取歌曲详情失败： {json}");
            var Lst = json["result"];
            foreach (JObject song in Lst["songs"])
            {
                var item = song.ToObject<Song>();
            }

        }
    }
}
