$dirs = Get-ChildItem -Recurse -Directory
foreach ($dir in $dirs) {
    $acl = Get-Acl $dir.FullName
    foreach ($ace in $acl.Access) {
        if ($ace.FileSystemRights -eq "FullControl" -and $ace.IdentityReference -eq "BUILTIN\Users") {
            Write-Host "$($dir.FullName) - $($ace.IdentityReference): $($ace.FileSystemRights)"
        }
    }
}
