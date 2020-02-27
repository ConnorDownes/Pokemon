using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Models
{
    public class Move
    {
        public Move2 move { get; set; }
        public List<VersionGroupDetail> version_group_details
        {
            get; set;
        }
    }
}