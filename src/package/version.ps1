param([String] $commonAssemblyInfo, [String]$build)

"Updating Version Build Number To: " + $build

$assemblyInfo = Get-Content $commonAssemblyInfo
$version = '$1.' + $build
$replace = 'Version("' + $version + '")'
$assemblyInfo -Replace  'Version\(\"([0-9]+\.[0-9]+\.[0-9]+)(\.[0-9]+)?\"\)', $replace | Out-File $commonAssemblyInfo
