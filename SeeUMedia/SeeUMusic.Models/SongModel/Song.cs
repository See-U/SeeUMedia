using System;
using System.Collections.Generic;
using System.Text;

namespace SeeUMedia.Models.SongModel
{
    public class Song
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
        public Artist[] artists { get; set; }

        /// <summary>
        /// album
        /// </summary>
        public Album album { get; set; }

        /// <summary>
        /// duration
        /// </summary>
        public double duration { get; set; }

        /// <summary>
        /// copyrightId
        /// </summary>
        public int copyrightId { get; set; }

        /// <summary>
        /// status
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// alias
        /// </summary>
        public string[] alias { get; set; }

        /// <summary>
        /// rtype
        /// </summary>
        public int rtype { get; set; }

        /// <summary>
        /// ftype
        /// </summary>
        public int ftype { get; set; }

        /// <summary>
        /// mvid
        /// </summary>
        public int mvid { get; set; }

        /// <summary>
        /// fee
        /// </summary>
        public int fee { get; set; }

        /// <summary>
        /// rUrl
        /// </summary>
        public string rUrl { get; set; }

        /// <summary>
        /// mark
        /// </summary>
        public string mark { get; set; }
    }
}

#if Demo
{{
  "id": 469699266,
  "name": "最美情侣",
  "artists": [
    {
      "id": 12356407,
      "name": "白小白",
      "picUrl": null,
      "alias": [],
      "albumSize": 0,
      "picId": 0,
      "img1v1Url": "https://p1.music.126.net/6y-UleORITEDbvrOLV0Q8A==/5639395138885805.jpg",
      "img1v1": 0,
      "trans": null
    }
  ],
  "album": {
    "id": 35326717,
    "name": "最美情侣",
    "artist": {
      "id": 0,
      "name": "",
      "picUrl": null,
      "alias": [],
      "albumSize": 0,
      "picId": 0,
      "img1v1Url": "https://p1.music.126.net/6y-UleORITEDbvrOLV0Q8A==/5639395138885805.jpg",
      "img1v1": 0,
      "trans": null
    },
    "publishTime": 1491235200007,
    "size": 18,
    "copyrightId": 445010,
    "status": 0,
    "picId": 18940187300130282,
    "mark": 0
  },
  "duration": 241600,
  "copyrightId": 445010,
  "status": 0,
  "alias": [],
  "rtype": 0,
  "ftype": 0,
  "mvid": 0,
  "fee": 8,
  "rUrl": null,
  "mark": 65600
}}
#endif