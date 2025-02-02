﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.DTOs
{
    /// <summary>
    /// Does not update joke's id, likes, author, uploaddate, or dislikes. Just Premise and Punchline
    /// </summary>
    public class JokeUpdateDto
    {
        public int Id { get; set; }
        public string Premise { get; set; }
        public string Punchline { get; set; }
    }
}
