using System;
using System.Collections.Generic;
using System.Text;

namespace GitAssistant.Git;

public class GitRepoResponseDTO
{
    public string Message { get; set; } = string.Empty;
    public bool Success { get; set; }
}
