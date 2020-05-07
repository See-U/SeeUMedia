namespace SeeUMedia.Models.SongModel
{
    public class Artist
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// picUrl
        /// </summary>
        public string picUrl { get; set; }

        /// <summary>
        /// alias
        /// </summary>
        public string[] alias { get; set; }

        /// <summary>
        /// albumSize
        /// </summary>
        public int albumSize { get; set; }

        /// <summary>
        /// picId
        /// </summary>
        public int picId { get; set; }

        /// <summary>
        /// img1v1Url
        /// </summary>
        public string img1v1Url { get; set; }

        /// <summary>
        /// img1v1
        /// </summary>
        public int img1v1 { get; set; }

        /// <summary>
        /// trans
        /// </summary>
        public string trans { get; set; }
    }
}