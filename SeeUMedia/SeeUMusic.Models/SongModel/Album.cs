namespace SeeUMedia.Models.SongModel
{
    public class Album
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
        /// artists
        /// </summary>
        public Artist artists { get; set; }

        /// <summary>
        /// publishTime
        /// </summary>
        public double publishTime { get; set; }

        /// <summary>
        /// size
        /// </summary>
        public int size { get; set; }

        /// <summary>
        /// copyrightId
        /// </summary>
        public int copyrightId { get; set; }

        /// <summary>
        /// status
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// picId
        /// </summary>
        public double picId { get; set; }

        /// <summary>
        /// mark
        /// </summary>
        public int mark { get; set; }
    }
}
