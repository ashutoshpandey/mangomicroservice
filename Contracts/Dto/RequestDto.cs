﻿namespace Contracts
{
    public class RequestDto
    {
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
