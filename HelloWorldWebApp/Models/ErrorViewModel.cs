// <copyright file="ErrorViewModel.cs" company="Principal 33">
// Copyright (c) Principal 33. All rights reserved.
// </copyright>

namespace HelloWorldWebApp.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
